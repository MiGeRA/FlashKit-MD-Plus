using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace flashkit_md
{
    class Device
    {

        const byte CMD_ADDR = 0;
        const byte CMD_LEN = 1;
        const byte CMD_RD = 2;
        const byte CMD_WR = 3;
        const byte CMD_RY = 4;
        const byte CMD_DELAY = 5;
        const byte PAR_INC = 128;
        const byte PAR_SINGLE = 64;
        const byte PAR_DEV_ID = 32;
        const byte PAR_MODE8 = 16;

        static SerialPort port;

        public static int connect()
        {
            string[] ports = SerialPort.GetPortNames();
            int id;

            for (int i = 0; i < ports.Length; i++)
            {
                try
                {
                    port = new SerialPort(ports[i]);
                    //port.BaudRate = 115200;
                    //port.BaudRate = 230400;
                    //port.BaudRate = 460800;
                    //port.BaudRate = 921600;
                    port.Open();
                    port.ReadTimeout = 500; // 500ms
                    port.WriteTimeout = 500; // 500ms
                    id = getID();
                    if ((id & 0xff) == (id >> 8) && id != 0)
                    {
                        setDelay(0);
                        port.WriteTimeout = 1000;
                        port.ReadTimeout = 1000;
                        return (port.BaudRate);
                    }
                }
                catch (Exception)
                {
                    try { port.Close(); }
                    catch (Exception) { }
                }

            }

            port = null;
            throw new Exception("FlashKit-MD is not detected");

        }

        public static void disconnect()
        {
            if (port == null) return;
            try
            {
                port.Close();
                port = null;
            }
            catch (Exception) { }

        }

        public static string getPortName()
        {
            return port.PortName;

        }

        public static bool isConnected()
        {
            if (port == null) return false;
            return true;

        }

        static int getID()
        {
            int id;
            byte[] cmd = new byte[1];
            cmd[0] = CMD_RD | PAR_SINGLE | PAR_DEV_ID;
            port.Write(cmd, 0, 1);
            id = port.ReadByte() << 8;
            id |= port.ReadByte();
            return id;

        }

        public static void setDelay(int val)
        {
            byte[] cmd = new byte[2];
            cmd[0] = CMD_DELAY;
            cmd[1] = (byte)val;
            port.Write(cmd, 0, cmd.Length);

        }

        public static UInt16 readWord(int addr)
        {
            UInt16 val = 0;
            addr /= 2;

            byte[] cmd = new byte[7];

            cmd[0] = CMD_ADDR;
            cmd[1] = (byte)(addr >> 16);
            cmd[2] = CMD_ADDR;
            cmd[3] = (byte)(addr >> 8);
            cmd[4] = CMD_ADDR;
            cmd[5] = (byte)(addr);

            cmd[6] = CMD_RD | PAR_SINGLE;

            port.Write(cmd, 0, cmd.Length);

            val = (UInt16)(port.ReadByte() << 8);
            val |= (UInt16)port.ReadByte();

            return val;

        }

        public static void writeWord(int addr, UInt16 data)
        {
            byte[] cmd = new byte[9];
            addr /= 2;

            cmd[0] = CMD_ADDR;
            cmd[1] = (byte)(addr >> 16);
            cmd[2] = CMD_ADDR;
            cmd[3] = (byte)(addr >> 8);
            cmd[4] = CMD_ADDR;
            cmd[5] = (byte)(addr);
            cmd[6] = CMD_WR | PAR_SINGLE;
            cmd[7] = (byte)(data >> 8);
            cmd[8] = (byte)(data);

            port.Write(cmd, 0, cmd.Length);

        }

        public static void writeByte(int addr, byte data)
        {
            byte[] cmd = new byte[8];
            addr /= 2;

            cmd[0] = CMD_ADDR;
            cmd[1] = (byte)(addr >> 16);
            cmd[2] = CMD_ADDR;
            cmd[3] = (byte)(addr >> 8);
            cmd[4] = CMD_ADDR;
            cmd[5] = (byte)(addr);
            cmd[6] = CMD_WR | PAR_SINGLE | PAR_MODE8;
            cmd[7] = data;

            port.Write(cmd, 0, cmd.Length);

        }

        public static void read(byte[] buff, int offset, int len)
        {
            int rd_len;

            while (len > 0)
            {
                rd_len = len > 65536 ? 65536 : len;
                byte[] cmd = new byte[5];
                cmd[0] = CMD_LEN;
                cmd[1] = (byte)(rd_len / 2 >> 8);
                cmd[2] = CMD_LEN;
                cmd[3] = (byte)(rd_len / 2);
                cmd[4] = CMD_RD | PAR_INC;

                port.Write(cmd, 0, 5);

                for (int i = 0; i < rd_len;)
                {
                    i += port.Read(buff, offset + i, rd_len - i);
                }
                len -= rd_len;
                offset += rd_len;
            }

        }

        public static void write(byte[] buff, int offset, int len)
        {
            int wr_len;

            while (len > 0)
            {
                wr_len = len > 65536 ? 65536 : len;
                byte[] cmd = new byte[5];
                cmd[0] = CMD_LEN;
                cmd[1] = (byte)(wr_len / 2 >> 8);
                cmd[2] = CMD_LEN;
                cmd[3] = (byte)(wr_len / 2);
                cmd[4] = CMD_WR | PAR_INC;

                port.Write(cmd, 0, 5);

                port.Write(buff, offset, wr_len);

                len -= wr_len;
                offset += wr_len;
            }

        }

        public static void setAddr(int addr)
        {
            byte[] buff = new byte[6];
            addr /= 2;

            buff[0] = CMD_ADDR;
            buff[1] = (byte)(addr >> 16);
            buff[2] = CMD_ADDR;
            buff[3] = (byte)(addr >> 8);
            buff[4] = CMD_ADDR;
            buff[5] = (byte)(addr);

            port.Write(buff, 0, 6);

        }

        static int getSR() // Reading the status automatically set after operation
        {
            //int SR;
            byte[] cmd = new byte[1];
            cmd[0] = CMD_RD | PAR_SINGLE | PAR_MODE8;
            port.Write(cmd, 0, cmd.Length);
            //SR = port.ReadByte();
            //return SR;
            return port.ReadByte();

        }

        public static void flashErase(int addr)
        {
            byte[] cmd;
            addr /= 2;

            cmd = new byte[8 * 8];

            for (int i = 0; i < cmd.Length; i += 8)
            {
                cmd[0 + i] = CMD_ADDR;
                cmd[1 + i] = (byte)(addr >> 16);
                cmd[2 + i] = CMD_ADDR;
                cmd[3 + i] = (byte)(addr >> 8);
                cmd[4 + i] = CMD_ADDR;
                cmd[5 + i] = (byte)(addr);

                cmd[6 + i] = CMD_WR | PAR_SINGLE | PAR_MODE8;
                cmd[7 + i] = 0x30;
                addr += 4096;
            }

            Device.writeWord(0x555 * 2, 0xaa);
            Device.writeWord(0x2aa * 2, 0x55);
            Device.writeWord(0x555 * 2, 0x80);
            Device.writeWord(0x555 * 2, 0xaa);
            Device.writeWord(0x2aa * 2, 0x55);

            port.Write(cmd, 0, cmd.Length);
            flashRY();

        }

        public static void flashEraseAll()
        {
            Device.writeWord(0x555 * 2, 0xaa);
            Device.writeWord(0x2aa * 2, 0x55);
            Device.writeWord(0x555 * 2, 0x80);
            Device.writeWord(0x555 * 2, 0xaa);
            Device.writeWord(0x2aa * 2, 0x55);
            Device.writeWord(0x555 * 2, 0x10);

            while ((Device.getSR() & 0x80) == 0)
            {
                if (((Device.getSR() & 0x20) != 0) && ((Device.getSR() & 0x80) == 0)) throw new Exception("Erase error ...");
            }

        }

        static void flashRY()
        {
            byte[] cmd = new byte[2];
            cmd[0] = CMD_RY;
            cmd[1] = CMD_RD | PAR_SINGLE;

            port.Write(cmd, 0, 2);
            port.ReadByte();
            port.ReadByte();

        }

        public static void flashUnlockBypass()
        {
            Device.writeByte(0x555 * 2, 0xaa);
            Device.writeByte(0x2aa * 2, 0x55);
            Device.writeByte(0x555 * 2, 0x20);

        }

        public static void flashResetByPass()
        {
            Device.writeWord(0, 0xf0);
            Device.writeByte(0, 0x90);
            Device.writeByte(0, 0x00);

        }

        public static void flashWrite(byte[] buff, int offset, int len)
        {
            len /= 2;
            byte[] cmd = new byte[6 * len];

            for (int i = 0; i < cmd.Length; i += 6)
            {
                cmd[0 + i] = CMD_WR | PAR_SINGLE | PAR_MODE8;
                cmd[1 + i] = 0xA0;
                cmd[2 + i] = CMD_WR | PAR_SINGLE | PAR_INC;
                cmd[3 + i] = buff[offset++];
                cmd[4 + i] = buff[offset++];
                cmd[5 + i] = CMD_RY;
            }

            port.Write(cmd, 0, cmd.Length);

        }

        public static void flash28Reset()
        {
            Device.writeByte(0, 0xff);

        }

        public static UInt16 flash28IdentMfr() // return Manufacturer ID: 28F400 -> 0x0089
        {
            Device.writeByte(0, 0x90);
            return (Device.readWord(0));

        }

        public static UInt16 flash28IdentDev() // return Device ID: -T -> 0x4470; -B -> 0x4471
        {
            Device.writeByte(0, 0x90);
            return (Device.readWord(2));

        }

        static Byte flash28SRD() // Return Status Register value data (inside use): bit7=1 is ready stat
        {
            byte stat;
            Device.writeByte(0, 0x70);
            stat = (byte)(readWord(0));
            Device.writeByte(0, 0x50);
            return (stat);

        }

        public static void flash28Erase(int addr) // Erasing a sector containing an address
        {
            byte[] cmd;
            addr /= 2;
            cmd = new byte[8];

            cmd[0] = CMD_ADDR;
            cmd[1] = (byte)(addr >> 16);
            cmd[2] = CMD_ADDR;
            cmd[3] = (byte)(addr >> 8);
            cmd[4] = CMD_ADDR;
            cmd[5] = (byte)(addr);
            cmd[6] = CMD_WR | PAR_SINGLE | PAR_MODE8;
            cmd[7] = 0x20;
            port.Write(cmd, 0, cmd.Length);

            cmd[7] = 0xD0;
            port.Write(cmd, 0, cmd.Length);

            while ((Device.getSR() & 0x80) == 0) { Device.setDelay(1); } // Fastest than Device.flash28SRD()
            //while ((Device.flash28SRD() & 0x80) == 0) { }

        }

        public static void flash28Prog(int addr, UInt16 data)
        {
            Device.writeByte(addr * 2, 0x40);
            Device.writeWord(addr * 2, data);

            while ((Device.getSR() & 0x80) == 0) { Device.setDelay(1); } // Fastest than Device.flash28SRD()
            //while ((Device.flash28SRD() & 0x80) == 0) { }

        }

        public static void flash28ProgBlock(byte[] buff, int offset, int len)
        {
            // Native datasheet algorithm, but slow result ...
            /*
            byte[] word = new byte[5];
            word[0] = CMD_WR | PAR_SINGLE | PAR_MODE8;
            word[1] = 0x40;
            for (int i = 0; i < len; i += 2)
            {
                word[2] = CMD_WR | PAR_SINGLE | PAR_INC;
                word[3] = buff[offset++];
                word[4] = buff[offset++];
                port.Write(word, 0, word.Length);
                //while ((Device.getSR() & 0x80) == 0) { } // Fastest than Device.flash28SRD(), allows w/o this
            }
            */

            // Сan not check the status, but just wait a little
            len /= 2;
            byte[] cmd = new byte[13 * len];

            for (int i = 0; i < cmd.Length; i += 13)
            {
                cmd[0 + i] = CMD_WR | PAR_SINGLE | PAR_MODE8;
                cmd[1 + i] = 0x40;
                cmd[2 + i] = CMD_WR | PAR_SINGLE | PAR_INC;
                cmd[3 + i] = buff[offset++];
                cmd[4 + i] = buff[offset++];
                cmd[5 + i] = CMD_DELAY;
                cmd[6 + i] = 5; // 1pts ~0.5uS, summ ~10uS delay replace getting status 
                cmd[7 + i] = CMD_DELAY;
                cmd[8 + i] = 5;
                cmd[9 + i] = CMD_DELAY;
                cmd[10 + i] = 5;
                cmd[11 + i] = CMD_DELAY;
                cmd[12 + i] = 5;
            }

            port.Write(cmd, 0, cmd.Length);

        }

        public static void flash29lCmd(byte code) // Send command (for Flash-EEPROM) with "unlock" sequence
        {
            byte[] cmd = new byte[27];

            int addr_1st = 0x5555;
            int addr_2nd = 0x2aaa;
            byte dat_1st = 0xaa;
            byte dat_2nd = 0x55;
            byte dat_cmd = code;

            cmd[0] = CMD_ADDR;
            cmd[1] = (byte)(addr_1st >> 16);
            cmd[2] = CMD_ADDR;
            cmd[3] = (byte)(addr_1st >> 8);
            cmd[4] = CMD_ADDR;
            cmd[5] = (byte)(addr_1st);
            cmd[6] = CMD_WR | PAR_SINGLE | PAR_MODE8;
            cmd[7] = dat_1st;
            cmd[8] = CMD_RY;

            cmd[9] = CMD_ADDR;
            cmd[10] = (byte)(addr_2nd >> 16);
            cmd[11] = CMD_ADDR;
            cmd[12] = (byte)(addr_2nd >> 8);
            cmd[13] = CMD_ADDR;
            cmd[14] = (byte)(addr_2nd);
            cmd[15] = CMD_WR | PAR_SINGLE | PAR_MODE8;
            cmd[16] = dat_2nd;
            cmd[17] = CMD_RY;

            cmd[18] = CMD_ADDR;
            cmd[19] = (byte)(addr_1st >> 16);
            cmd[20] = CMD_ADDR;
            cmd[21] = (byte)(addr_1st >> 8);
            cmd[22] = CMD_ADDR;
            cmd[23] = (byte)(addr_1st);
            cmd[24] = CMD_WR | PAR_SINGLE | PAR_MODE8;
            cmd[25] = dat_cmd;
            cmd[26] = CMD_RY;

            port.Write(cmd, 0, cmd.Length);

        }

        public static void flash29lReset() // Reset and set Read-mode
        {
            // NOT optimal - very slow and ramdom time delay ...
            /*
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(0x5555 * 2, 0xf0);
            */

            // This is more optimal, albeit more cumbersome (do see inside to flash29lCmd)
            Device.flash29lCmd(0xf0);
        }

        public static UInt16 flash29lIdentMfr() // return Manufacturer ID: 29L3211 -> 0x00C2
        {
            UInt16 val = 0xFFFF;
            UInt16 buff_data;
            UInt16 buff_info;
            /*
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(0x5555 * 2, 0x90);
            */
            Device.flash29lCmd(0x90);
            buff_info = Device.readWord(0);
            Device.flash29lReset();
            buff_data = Device.readWord(0);
            if (buff_data != buff_info) val = buff_info;
            return val;

        }

        public static UInt16 flash29lIdentDev() // return Device ID: 29L3211 -> 0x00F9
        {
            UInt16 val = 0xFFFF;
            UInt16 buff_data;
            UInt16 buff_info;
            /*
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(0x5555 * 2, 0x90);
            */
            Device.flash29lCmd(0x90);
            buff_info = Device.readWord(2);
            Device.flash29lReset();
            buff_data = Device.readWord(2);
            if (buff_data != buff_info) val = buff_info;
            return val;

        }

        static Byte flash29lSRD() // Return Status Register value data (inside use): bit7=1 is ready stat
        {
            byte stat;

            /*
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(0x5555 * 2, 0x70);
            */
            Device.flash29lCmd(0x70);
            stat = (byte)(readWord(0));
            /*
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(0x5555 * 2, 0x50);
            */
            Device.flash29lCmd(0x50);
            return (stat);

        }

        public static void flash29lErase(int addr) // addr to word-mode !!! (linear / 2)
        {
            /*
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(0x5555 * 2, 0x80);
            */
            Device.flash29lCmd(0x80);

            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(addr * 2, 0x30);

            //while ((Device.flash29lSRD() & 0x80) == 0) { }
            while ((Device.getSR() & 0x80) == 0) { Device.setDelay(1); } // Fastest than Device.flash29lSRD()
            if ((Device.getSR() & 0x20) != 0) throw new Exception("Erase error ...");

        }

        public static void flash29lEraseAll()
        {
            /*
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(0x5555 * 2, 0x80);
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(0x5555 * 2, 0x10);
            */
            Device.flash29lCmd(0x80);
            Device.flash29lCmd(0x10);

            //while ((Device.flash29lSRD() & 0x80) == 0) { }
            while ((Device.getSR() & 0x80) == 0) { Device.setDelay(1); } // Fastest than Device.flash29lSRD()
            if ((Device.getSR() & 0x20) != 0) throw new Exception("Erase error ...");

        }

        public static void flash29lProg(int addr, UInt16 data) // Write single 16-bit word
        {
            /*
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(0x5555 * 2, 0xa0);
            */
            Device.flash29lCmd(0xa0);

            Device.writeWord(addr * 2, data);

            while ((Device.getSR() & 0x80) == 0) { } // Fastest than Device.flash29lSRD()
            if ((Device.getSR() & 0x10) != 0) throw new Exception("Program error ...");

        }

        public static void flash29lWritePage(byte[] buff, int offset, int len) // For write page - until 128 16-bit's words
        {
            int pref_len = 38; // "unlock" sequence (for Flash-EEPROM) + write command
            int suff_blk = 50; // control sequence (for FlashKit) do delay: 50 = ~100us (0.5*4*50)

            int page_len = 256; // page len - const for MX29L3211
            int wr_len;

            wr_len = len > page_len ? page_len : len;

            byte[] cmd = new byte[pref_len + page_len + suff_blk * 2];

            int addr_1st = 0x5555;
            int addr_2nd = 0x2aaa;
            byte dat_1st = 0xaa;
            byte dat_2nd = 0x55;
            byte dat_wrt = 0xa0;

            int addr;

            while (len > 0)
            {
                addr = offset / 2;

                cmd[0] = CMD_ADDR;
                cmd[1] = (byte)(addr_1st >> 16);
                cmd[2] = CMD_ADDR;
                cmd[3] = (byte)(addr_1st >> 8);
                cmd[4] = CMD_ADDR;
                cmd[5] = (byte)(addr_1st);
                cmd[6] = CMD_WR | PAR_SINGLE | PAR_MODE8;
                cmd[7] = dat_1st;
                cmd[8] = CMD_RY;

                cmd[9] = CMD_ADDR;
                cmd[10] = (byte)(addr_2nd >> 16);
                cmd[11] = CMD_ADDR;
                cmd[12] = (byte)(addr_2nd >> 8);
                cmd[13] = CMD_ADDR;
                cmd[14] = (byte)(addr_2nd);
                cmd[15] = CMD_WR | PAR_SINGLE | PAR_MODE8;
                cmd[16] = dat_2nd;
                cmd[17] = CMD_RY;

                cmd[18] = CMD_ADDR;
                cmd[19] = (byte)(addr_1st >> 16);
                cmd[20] = CMD_ADDR;
                cmd[21] = (byte)(addr_1st >> 8);
                cmd[22] = CMD_ADDR;
                cmd[23] = (byte)(addr_1st);
                cmd[24] = CMD_WR | PAR_SINGLE | PAR_MODE8;
                cmd[25] = dat_wrt;
                cmd[26] = CMD_RY;

                cmd[27] = CMD_ADDR;
                cmd[28] = (byte)(addr >> 16);
                cmd[29] = CMD_ADDR;
                cmd[30] = (byte)(addr >> 8);
                cmd[31] = CMD_ADDR;
                cmd[32] = (byte)(addr);

                cmd[33] = CMD_LEN;
                cmd[34] = (byte)(page_len / 2 >> 8);
                cmd[35] = CMD_LEN;
                cmd[36] = (byte)(page_len / 2);
                cmd[37] = CMD_WR | PAR_INC;

                for (int i = 0; i < page_len; i++)
                {
                    cmd[cmd.Length - page_len - suff_blk * 2 + i] = buff[offset + i];
                }

                for (int i = 0; i < suff_blk; i++)
                {
                    cmd[pref_len + page_len + i * 2] = CMD_DELAY;
                    cmd[pref_len + page_len + i * 2 + 1] = 4; // 1pts ~0.5uS, 4 = 2uS * suff_blk
                }

                port.Write(cmd, 0, cmd.Length);

                while ((Device.getSR() & 0x80) == 0) { } // Fastest than Device.flash29lSRD()
                //if ((Device.getSR() & 0x10) != 0) throw new Exception("Program error ...");

                len -= wr_len;
                offset += wr_len;
            }

        }

        public static void flash29lWrite(byte[] buff, int offset, int len) // Write many pages ;-)
        {
            int pref_len = 38; // "unlock" sequence (for Flash-EEPROM) + write command
            int suff_blk = 1333; // quantity control sequence (for FlashKit) do delay: typ. >= 5ms (0.5*6*1666)
            int pstf_len = 27; // postfix - reset (for Flash-EEPROM) command sequence

            int pg_len = 256; // page len - const for MX29L3211
            int pg_sum = len / pg_len; // quantity page (len must by multiple of 256)
            int pg_i = 0; // counter
            // 5555 2AAA 5555 addr+0 ... addr+128 [delay] 5555 2AAA 5555
            //  AA   55   A0  data16 ...  data16  [delay]  AA   55   F0 
            int pg_seq = pref_len + pg_len + suff_blk * 2 + pstf_len; // size of sequence to write page - array macro unit

            byte[] cmd = new byte[pg_seq * pg_sum];

            int addr_1st = 0x5555;
            int addr_2nd = 0x2aaa;
            byte dat_1st = 0xaa;
            byte dat_2nd = 0x55;
            byte dat_wrt = 0xa0;
            byte dat_rst = 0xf0;

            int addr;

            while (pg_i < pg_sum)
            {
                addr = offset / 2;

                cmd[pg_i * pg_seq + 0] = CMD_ADDR;
                cmd[pg_i * pg_seq + 1] = (byte)(addr_1st >> 16);
                cmd[pg_i * pg_seq + 2] = CMD_ADDR;
                cmd[pg_i * pg_seq + 3] = (byte)(addr_1st >> 8);
                cmd[pg_i * pg_seq + 4] = CMD_ADDR;
                cmd[pg_i * pg_seq + 5] = (byte)(addr_1st);
                cmd[pg_i * pg_seq + 6] = CMD_WR | PAR_SINGLE | PAR_MODE8;
                cmd[pg_i * pg_seq + 7] = dat_1st;
                cmd[pg_i * pg_seq + 8] = CMD_RY;

                cmd[pg_i * pg_seq + 9] = CMD_ADDR;
                cmd[pg_i * pg_seq + 10] = (byte)(addr_2nd >> 16);
                cmd[pg_i * pg_seq + 11] = CMD_ADDR;
                cmd[pg_i * pg_seq + 12] = (byte)(addr_2nd >> 8);
                cmd[pg_i * pg_seq + 13] = CMD_ADDR;
                cmd[pg_i * pg_seq + 14] = (byte)(addr_2nd);
                cmd[pg_i * pg_seq + 15] = CMD_WR | PAR_SINGLE | PAR_MODE8;
                cmd[pg_i * pg_seq + 16] = dat_2nd;
                cmd[pg_i * pg_seq + 17] = CMD_RY;

                cmd[pg_i * pg_seq + 18] = CMD_ADDR;
                cmd[pg_i * pg_seq + 19] = (byte)(addr_1st >> 16);
                cmd[pg_i * pg_seq + 20] = CMD_ADDR;
                cmd[pg_i * pg_seq + 21] = (byte)(addr_1st >> 8);
                cmd[pg_i * pg_seq + 22] = CMD_ADDR;
                cmd[pg_i * pg_seq + 23] = (byte)(addr_1st);
                cmd[pg_i * pg_seq + 24] = CMD_WR | PAR_SINGLE | PAR_MODE8;
                cmd[pg_i * pg_seq + 25] = dat_wrt;
                cmd[pg_i * pg_seq + 26] = CMD_RY;

                cmd[pg_i * pg_seq + 27] = CMD_ADDR;
                cmd[pg_i * pg_seq + 28] = (byte)(addr >> 16);
                cmd[pg_i * pg_seq + 29] = CMD_ADDR;
                cmd[pg_i * pg_seq + 30] = (byte)(addr >> 8);
                cmd[pg_i * pg_seq + 31] = CMD_ADDR;
                cmd[pg_i * pg_seq + 32] = (byte)(addr);

                cmd[pg_i * pg_seq + 33] = CMD_LEN;
                cmd[pg_i * pg_seq + 34] = (byte)(pg_len / 2 >> 8);
                cmd[pg_i * pg_seq + 35] = CMD_LEN;
                cmd[pg_i * pg_seq + 36] = (byte)(pg_len / 2);
                cmd[pg_i * pg_seq + 37] = CMD_WR | PAR_INC;

                for (int i = 0; i < pg_len; i++)
                {
                    cmd[pg_i * pg_seq + pref_len + i] = buff[offset++];
                }

                for (int i = 0; i < suff_blk; i++)
                {
                    cmd[pg_i * pg_seq + pref_len + pg_len + i * 2] = CMD_DELAY;
                    cmd[pg_i * pg_seq + pref_len + pg_len + i * 2 + 1] = 6; // 1pts ~0.5uS, 6 = 3uS * suff_blk
                }

                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 0] = CMD_ADDR;
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 1] = (byte)(addr_1st >> 16);
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 2] = CMD_ADDR;
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 3] = (byte)(addr_1st >> 8);
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 4] = CMD_ADDR;
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 5] = (byte)(addr_1st);
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 6] = CMD_WR | PAR_SINGLE | PAR_MODE8;
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 7] = dat_1st;
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 8] = CMD_RY;

                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 9] = CMD_ADDR;
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 10] = (byte)(addr_2nd >> 16);
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 11] = CMD_ADDR;
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 12] = (byte)(addr_2nd >> 8);
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 13] = CMD_ADDR;
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 14] = (byte)(addr_2nd);
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 15] = CMD_WR | PAR_SINGLE | PAR_MODE8;
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 16] = dat_2nd;
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 17] = CMD_RY;

                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 18] = CMD_ADDR;
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 19] = (byte)(addr_1st >> 16);
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 20] = CMD_ADDR;
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 21] = (byte)(addr_1st >> 8);
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 22] = CMD_ADDR;
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 23] = (byte)(addr_1st);
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 24] = CMD_WR | PAR_SINGLE | PAR_MODE8;
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 25] = dat_rst;
                cmd[pg_i * pg_seq + pref_len + pg_len + suff_blk * 2 + 26] = CMD_RY;

                pg_i++;
            }

            port.Write(cmd, 0, cmd.Length);

        }

        public static void flash29lvReset() // Reset and set Read-mode
        {
            Device.writeByte(0, 0xf0); // any address

        }

        static void flash29lvAS() // Automatic Select
        {
            byte[] cmd = new byte[27];

            int addr_1st = 0x555;
            int addr_2nd = 0x2aa;
            byte dat_1st = 0xaa;
            byte dat_2nd = 0x55;
            byte dat_wrt = 0x90;

            cmd[0] = CMD_ADDR;
            cmd[1] = (byte)(addr_1st >> 16);
            cmd[2] = CMD_ADDR;
            cmd[3] = (byte)(addr_1st >> 8);
            cmd[4] = CMD_ADDR;
            cmd[5] = (byte)(addr_1st);
            cmd[6] = CMD_WR | PAR_SINGLE | PAR_MODE8;
            cmd[7] = dat_1st;
            cmd[8] = CMD_RY;

            cmd[9] = CMD_ADDR;
            cmd[10] = (byte)(addr_2nd >> 16);
            cmd[11] = CMD_ADDR;
            cmd[12] = (byte)(addr_2nd >> 8);
            cmd[13] = CMD_ADDR;
            cmd[14] = (byte)(addr_2nd);
            cmd[15] = CMD_WR | PAR_SINGLE | PAR_MODE8;
            cmd[16] = dat_2nd;
            cmd[17] = CMD_RY;

            cmd[18] = CMD_ADDR;
            cmd[19] = (byte)(addr_1st >> 16);
            cmd[20] = CMD_ADDR;
            cmd[21] = (byte)(addr_1st >> 8);
            cmd[22] = CMD_ADDR;
            cmd[23] = (byte)(addr_1st);
            cmd[24] = CMD_WR | PAR_SINGLE | PAR_MODE8;
            cmd[25] = dat_wrt;
            cmd[26] = CMD_RY;

            port.Write(cmd, 0, cmd.Length);

        }

        public static UInt16 flash29lvIdentMfr() // return Manufacturer ID: 29LV320 -> 0x00C2
        {
            Device.writeByte(0, 0xf0);
            /*
            Device.writeByte(0x555 * 2, 0xaa);
            Device.writeByte(0x2aa * 2, 0x55);
            Device.writeByte(0x555 * 2, 0x90);
            */
            Device.flash29lvAS();
            return (Device.readWord(0));

        }

        public static UInt16 flash29lvIdentDev() // return Device ID: 29LV320 -> 0x22A7 | 0x22A8
        {
            Device.writeByte(0, 0xf0);
            /*
            Device.writeByte(0x555 * 2, 0xaa);
            Device.writeByte(0x2aa * 2, 0x55);
            Device.writeByte(0x555 * 2, 0x90);
            */
            Device.flash29lvAS();
            return (Device.readWord(2));

        }

        public static UInt16 flash29lvFactLock() // return Device ID: 29LV320 -> 0x22A7 | 0x22A8
        {
            Device.writeByte(0, 0xf0);
            /*
            Device.writeByte(0x555 * 2, 0xaa);
            Device.writeByte(0x2aa * 2, 0x55);
            Device.writeByte(0x555 * 2, 0x90);
            */
            Device.flash29lvAS();
            return (Device.readWord(6));

        }

        public static UInt16 flash29lvProtStat(int addr) // return Device ID: 29LV320 -> 0x22A7 | 0x22A8
        {
            Device.writeByte(0, 0xf0);
            /*
            Device.writeByte(0x555 * 2, 0xaa);
            Device.writeByte(0x2aa * 2, 0x55);
            Device.writeByte(0x555 * 2, 0x90);
            */
            Device.flash29lvAS();
            return (Device.readWord(addr + 4));

        }

        public static void flash29lvErase(int addr) // addr to word-mode !!! (linear / 2)
        {
            /*
            Device.writeByte(0x555 * 2, 0xaa);
            Device.writeByte(0x2aa * 2, 0x55);
            Device.writeByte(0x555 * 2, 0x80);
            Device.writeByte(0x555 * 2, 0xaa);
            Device.writeByte(0x2aa * 2, 0x55);
            Device.writeByte(addr * 2, 0x30);
            */

            byte[] cmd = new byte[53];

            int addr_1st = 0x555;
            int addr_2nd = 0x2aa;
            byte dat_1st = 0xaa;
            byte dat_2nd = 0x55;
            byte dat_es1 = 0x80;
            byte dat_es2 = 0x30;

            cmd[0] = CMD_ADDR;
            cmd[1] = (byte)(addr_1st >> 16);
            cmd[2] = CMD_ADDR;
            cmd[3] = (byte)(addr_1st >> 8);
            cmd[4] = CMD_ADDR;
            cmd[5] = (byte)(addr_1st);
            cmd[6] = CMD_WR | PAR_SINGLE | PAR_MODE8;
            cmd[7] = dat_1st;
            cmd[8] = CMD_RY;

            cmd[9] = CMD_ADDR;
            cmd[10] = (byte)(addr_2nd >> 16);
            cmd[11] = CMD_ADDR;
            cmd[12] = (byte)(addr_2nd >> 8);
            cmd[13] = CMD_ADDR;
            cmd[14] = (byte)(addr_2nd);
            cmd[15] = CMD_WR | PAR_SINGLE | PAR_MODE8;
            cmd[16] = dat_2nd;
            cmd[17] = CMD_RY;

            cmd[18] = CMD_ADDR;
            cmd[19] = (byte)(addr_1st >> 16);
            cmd[20] = CMD_ADDR;
            cmd[21] = (byte)(addr_1st >> 8);
            cmd[22] = CMD_ADDR;
            cmd[23] = (byte)(addr_1st);
            cmd[24] = CMD_WR | PAR_SINGLE | PAR_MODE8;
            cmd[25] = dat_es1;
            cmd[26] = CMD_RY;

            cmd[27] = CMD_ADDR;
            cmd[28] = (byte)(addr_1st >> 16);
            cmd[29] = CMD_ADDR;
            cmd[30] = (byte)(addr_1st >> 8);
            cmd[31] = CMD_ADDR;
            cmd[32] = (byte)(addr_1st);
            cmd[33] = CMD_WR | PAR_SINGLE | PAR_MODE8;
            cmd[34] = dat_1st;
            cmd[35] = CMD_RY;

            cmd[36] = CMD_ADDR;
            cmd[37] = (byte)(addr_2nd >> 16);
            cmd[38] = CMD_ADDR;
            cmd[39] = (byte)(addr_2nd >> 8);
            cmd[40] = CMD_ADDR;
            cmd[41] = (byte)(addr_2nd);
            cmd[42] = CMD_WR | PAR_SINGLE | PAR_MODE8;
            cmd[43] = dat_2nd;
            cmd[44] = CMD_RY;

            cmd[45] = CMD_ADDR;
            cmd[46] = (byte)(addr >> 16);
            cmd[47] = CMD_ADDR;
            cmd[48] = (byte)(addr >> 8);
            cmd[49] = CMD_ADDR;
            cmd[50] = (byte)(addr);
            cmd[51] = CMD_WR | PAR_SINGLE | PAR_MODE8;
            cmd[52] = dat_es2;

            port.Write(cmd, 0, cmd.Length);

            while ((Device.getSR() & 0x80) == 0)
                if (((Device.getSR() & 0x20) != 0) && ((Device.getSR() & 0x80) == 0)) throw new Exception("Erase error ...");

        }

        public static void flash29lvEraseAll()
        {
            Device.writeByte(0x555 * 2, 0xaa);
            Device.writeByte(0x2aa * 2, 0x55);
            Device.writeByte(0x555 * 2, 0x80);
            Device.writeByte(0x555 * 2, 0xaa);
            Device.writeByte(0x2aa * 2, 0x55);
            Device.writeByte(0x555 * 2, 0x10);

            while ((Device.getSR() & 0x80) == 0)
                if (((Device.getSR() & 0x20) != 0) && ((Device.getSR() & 0x80) == 0)) throw new Exception("Erase error ...");

        }

        public static void flash29lvProg(int addr, UInt16 data) // Write single 16-bit word
        {
            byte[] cmd = new byte[37];

            int addr_1st = 0x555;
            int addr_2nd = 0x2aa;
            byte dat_1st = 0xaa;
            byte dat_2nd = 0x55;
            byte dat_wrt = 0xa0;

            cmd[0] = CMD_ADDR;
            cmd[1] = (byte)(addr_1st >> 16);
            cmd[2] = CMD_ADDR;
            cmd[3] = (byte)(addr_1st >> 8);
            cmd[4] = CMD_ADDR;
            cmd[5] = (byte)(addr_1st);
            cmd[6] = CMD_WR | PAR_SINGLE | PAR_MODE8;
            cmd[7] = dat_1st;
            cmd[8] = CMD_RY;

            cmd[9] = CMD_ADDR;
            cmd[10] = (byte)(addr_2nd >> 16);
            cmd[11] = CMD_ADDR;
            cmd[12] = (byte)(addr_2nd >> 8);
            cmd[13] = CMD_ADDR;
            cmd[14] = (byte)(addr_2nd);
            cmd[15] = CMD_WR | PAR_SINGLE | PAR_MODE8;
            cmd[16] = dat_2nd;
            cmd[17] = CMD_RY;

            cmd[18] = CMD_ADDR;
            cmd[19] = (byte)(addr_1st >> 16);
            cmd[20] = CMD_ADDR;
            cmd[21] = (byte)(addr_1st >> 8);
            cmd[22] = CMD_ADDR;
            cmd[23] = (byte)(addr_1st);
            cmd[24] = CMD_WR | PAR_SINGLE | PAR_MODE8;
            cmd[25] = dat_wrt;
            cmd[26] = CMD_RY;

            cmd[27] = CMD_ADDR;
            cmd[28] = (byte)(addr >> 16);
            cmd[29] = CMD_ADDR;
            cmd[30] = (byte)(addr >> 8);
            cmd[31] = CMD_ADDR;
            cmd[32] = (byte)(addr);
            cmd[33] = CMD_WR | PAR_SINGLE;
            cmd[34] = (byte)(data >> 8);
            cmd[35] = (byte)(data);
            cmd[36] = CMD_RY;

            port.Write(cmd, 0, cmd.Length);

        }

        public static void flash29lvWrite(byte[] buff, int offset, int len)
        {
            len /= 2;
            byte[] cmd = new byte[37 * len];

            int addr_1st = 0x555;
            int addr_2nd = 0x2aa;
            int addr_dat = offset / 2;
            byte dat_1st = 0xaa;
            byte dat_2nd = 0x55;
            byte dat_wrt = 0xa0;

            for (int i = 0; i < cmd.Length; i += 37)
            {
                cmd[0 + i] = CMD_ADDR;
                cmd[1 + i] = (byte)(addr_1st >> 16);
                cmd[2 + i] = CMD_ADDR;
                cmd[3 + i] = (byte)(addr_1st >> 8);
                cmd[4 + i] = CMD_ADDR;
                cmd[5 + i] = (byte)(addr_1st);
                cmd[6 + i] = CMD_WR | PAR_SINGLE | PAR_MODE8;
                cmd[7 + i] = dat_1st;
                cmd[8 + i] = CMD_RY;

                cmd[9 + i] = CMD_ADDR;
                cmd[10 + i] = (byte)(addr_2nd >> 16);
                cmd[11 + i] = CMD_ADDR;
                cmd[12 + i] = (byte)(addr_2nd >> 8);
                cmd[13 + i] = CMD_ADDR;
                cmd[14 + i] = (byte)(addr_2nd);
                cmd[15 + i] = CMD_WR | PAR_SINGLE | PAR_MODE8;
                cmd[16 + i] = dat_2nd;
                cmd[17 + i] = CMD_RY;

                cmd[18 + i] = CMD_ADDR;
                cmd[19 + i] = (byte)(addr_1st >> 16);
                cmd[20 + i] = CMD_ADDR;
                cmd[21 + i] = (byte)(addr_1st >> 8);
                cmd[22 + i] = CMD_ADDR;
                cmd[23 + i] = (byte)(addr_1st);
                cmd[24 + i] = CMD_WR | PAR_SINGLE | PAR_MODE8;
                cmd[25 + i] = dat_wrt;
                cmd[26 + i] = CMD_RY;

                cmd[27 + i] = CMD_ADDR;
                cmd[28 + i] = (byte)(addr_dat >> 16);
                cmd[29 + i] = CMD_ADDR;
                cmd[30 + i] = (byte)(addr_dat >> 8);
                cmd[31 + i] = CMD_ADDR;
                cmd[32 + i] = (byte)(addr_dat);
                cmd[33 + i] = CMD_WR | PAR_SINGLE;
                cmd[34 + i] = buff[offset++];
                cmd[35 + i] = buff[offset++];
                cmd[36 + i] = CMD_RY;

                addr_dat++;
            }

            port.Write(cmd, 0, cmd.Length);

        }

        public static void ccSwitch()
        {
            Device.readWord(0x3f0000);

        }
    }
}
