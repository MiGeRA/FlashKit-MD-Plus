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
                    port.ReadTimeout = 500;
                    port.WriteTimeout = 500;
                    id = getID();
                    if ((id & 0xff) == (id >> 8) && id != 0)
                    {
                        setDelay(0);
                        port.WriteTimeout = 2000;
                        port.ReadTimeout = 2000;
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
            throw new Exception("Device is not detected");

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

                for (int i = 0; i < rd_len; )
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
            int SR;
            byte[] cmd = new byte[1];
            cmd[0] = CMD_RD | PAR_SINGLE | PAR_MODE8;
            port.Write(cmd, 0, cmd.Length);
            SR = port.ReadByte();
            return SR;

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

        public static void flash29lReset() // Reset and set Read-mode
        {
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(0x5555 * 2, 0xf0);

        }

        public static UInt16 flash29lIdentMfr() // return Manufacturer ID: 29L3211 -> 0x00C2
        {
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(0x5555 * 2, 0x90);
            return (Device.readWord(0));

        }

        public static UInt16 flash29lIdentDev() // return Device ID: 29L3211 -> 0x00F9
        {
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(0x5555 * 2, 0x90);
            return (Device.readWord(2));

        }

        static Byte flash29lSRD() // Return Status Register value data (inside use): bit7=1 is ready stat
        {
            byte stat;
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(0x5555 * 2, 0x70);
            stat = (byte)(readWord(0));
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(0x5555 * 2, 0x50);
            return (stat);

        }

        public static void flash29lErase(int addr)
        {
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(0x5555 * 2, 0x80);
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(addr, 0x30); // addr to word, as if already *2

            while ((Device.getSR() & 0x80) == 0) { Device.setDelay(1); } // Fastest than Device.flash29lSRD()
            if ((Device.getSR() & 0x10) != 0) throw new Exception("Erase error ...");
            //while ((Device.flash29lSRD() & 0x80) == 0) { }

        }

        public static void flash29lEraseAll()
        {
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(0x5555 * 2, 0x80);
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(0x5555 * 2, 0x10);

            while ((Device.getSR() & 0x80) == 0) { Device.setDelay(1); } // Fastest than Device.flash29lSRD()
            if ((Device.getSR() & 0x10) != 0) throw new Exception("Erase error ...");
            //while ((Device.flash29lSRD() & 0x80) == 0) { }

        }

        public static void flash29lProg(int addr, UInt16 data) // Write single 16-bit word
        {
            Device.writeByte(0x5555 * 2, 0xaa);
            Device.writeByte(0x2aaa * 2, 0x55);
            Device.writeByte(0x5555 * 2, 0xa0);
            Device.writeWord(addr * 2, data);

            while ((Device.getSR() & 0x80) == 0) { } // Fastest than Device.flash29lSRD()
            if ((Device.getSR() & 0x10) != 0) throw new Exception("Program error ...");

        }

        static void flash29lWritePref(int addr)
        {
            byte[] cmd = new byte[33];
            addr /= 2;

            int addr_1st = 0x5555;
            int addr_2nd = 0x2aaa;
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

            port.Write(cmd, 0, cmd.Length);

        }

        public static void flash29lWrite(byte[] buff, int offset, int len) // Write page - many 16-bit word ;-)
        {
            int wr_len;

            while (len > 0)
            {
                wr_len = len > 256 ? 256 : len;

                Device.flash29lWritePref(offset); // Fastest than single next 4 usb-transaction
                /*
                Device.writeByte(0x5555 * 2, 0xaa);
                Device.writeByte(0x2aaa * 2, 0x55);
                Device.writeByte(0x5555 * 2, 0xa0);
                Device.setAddr(offset);
                */

                Device.write(buff, offset, wr_len);

                while ((Device.getSR() & 0x80) == 0) { } // Fastest than Device.flash29lSRD()
                //if ((Device.getSR() & 0x10) != 0) throw new Exception("Program error ...");

                len -= wr_len;
                offset += wr_len;
            }

        }

    }
}
