using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace flashkit_md
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = this.Text + " " + this.ProductVersion;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            consWriteLine("-----------------------------------------------------");
            int ram_size;

            try
            {

                Device.connect();
                Device.setDelay(1);
                consWriteLine("Connected to: " + Device.getPortName());
                consWriteLine("ROM name : " + Cart.getRomName());
                consWriteLine("ROM size : " + Cart.getRomSize() / 1024 + "K");
                ram_size = Cart.getRamSize();
                if (ram_size < 1024)
                {
                    consWriteLine("RAM size : " + ram_size + "B");
                }
                else
                {
                    consWriteLine("RAM size : " + ram_size / 1024 + "K");
                }

                //consWrite("CART type: ");


            }
            catch (Exception x)
            {

                consWriteLine(x.Message);
            }
            Device.disconnect();

        }

        void consWrite(string str)
        {
            consoleBox.AppendText(str);
        }


        void consWriteLine(string str)
        {
            consoleBox.AppendText(str + "\r\n");
        }



        private void btn_rd_ram_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] ram;
                int ram_size;
                Device.connect();
                Device.setDelay(1);
                string rom_name = Cart.getRomName();
                rom_name += ".srm";
                saveFileDialog1.FileName = rom_name;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    consWriteLine("-----------------------------------------------------");
                    ram_size = Cart.getRamSize();
                    if (ram_size == 0) throw new Exception("RAM is not detected");
                    consWriteLine("Read RAM to " + saveFileDialog1.FileName);
                    if (ram_size < 1024)
                    {
                        consWriteLine("RAM size : " + ram_size + "B");
                    }
                    else
                    {
                        consWriteLine("RAM size : " + ram_size / 1024 + "K");
                    }
                    Device.writeWord(0xA13000, 0xffff);
                    Device.setAddr(0x200000);
                    ram = new byte[ram_size * 2];
                    Device.read(ram, 0, ram.Length);

                    FileStream f = File.OpenWrite(saveFileDialog1.FileName);
                    f.Write(ram, 0, ram.Length);
                    f.Close();
                    printMD5(ram);
                    consWriteLine("OK");
                }

            }
            catch (Exception x)
            {
                consWriteLine(x.Message);
            }
            Device.disconnect();

        }



        private void btn_rd_rom_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] rom;
                int rom_size;
                int block_size = 32768;
                Device.connect();
                Device.setDelay(1);
                string rom_name = Cart.getRomName();
                rom_name += ".bin";
                saveFileDialog1.FileName = rom_name;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    consWriteLine("-----------------------------------------------------");
                    rom_size = Cart.getRomSize();
                    progressBar1.Value = 0;
                    progressBar1.Maximum = rom_size;
                    rom = new byte[rom_size];

                    consWriteLine("Read ROM to " + saveFileDialog1.FileName);
                    consWriteLine("ROM size : " + rom_size / 1024 + "K");

                    Device.writeWord(0xA13000, 0x0000);
                    Device.setAddr(0);
                    DateTime t = DateTime.Now;
                    for (int i = 0; i < rom_size; i += block_size)
                    {
                        //Device.read(rom, i, block_size);
                        Device.read(rom, i, i + block_size <= rom_size ? block_size : rom_size - (rom_size / block_size) * block_size);
                        progressBar1.Value = i;
                        this.Update();
                    }
                    progressBar1.Value = rom_size;
                    //int time = (int)(DateTime.Now.Ticks - t.Ticks);
                    //consWriteLine("Time: " + time / 10000);
                    double time = (double)(DateTime.Now.Ticks - t.Ticks);
                    consWriteLine("Time: " + ((time / 10000) / 1000).ToString("F") + "sec");

                    FileStream f = File.OpenWrite(saveFileDialog1.FileName);
                    f.Write(rom, 0, rom.Length);
                    f.Close();

                    printMD5(rom);

                    consWriteLine("OK");
                }

            }
            catch (Exception x)
            {
                consWriteLine(x.Message);
            }
            Device.disconnect();

        }

        private void printMD5(byte[] buff)
        {
            MD5 hash = MD5.Create();
            byte[] hash_data = hash.ComputeHash(buff);
            consWriteLine("MD5: " + BitConverter.ToString(hash_data));
        }


        private void btn_wr_ram_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] ram;
                int ram_size;
                int copy_len;
                Device.connect();
                Device.setDelay(1);

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    consWriteLine("-----------------------------------------------------");
                    consWriteLine("Write RAM...");
                    this.Update();
                    FileStream f = File.OpenRead(openFileDialog1.FileName);
                    ram = new byte[f.Length];
                    f.Read(ram, 0, ram.Length);
                    f.Close();

                    ram_size = Cart.getRamSize();
                    if (ram_size == 0) throw new Exception("RAM is not detected");
                    this.Update();

                    ram_size *= 2;
                    copy_len = ram.Length;
                    if (ram_size < copy_len) copy_len = ram_size;
                    if (copy_len % 2 != 0) copy_len--;
                    Device.writeWord(0xA13000, 0xffff);
                    Device.setAddr(0x200000);
                    Device.write(ram, 0, copy_len);
                    consWriteLine("Verify...");
                    this.Update();
                    byte[] ram2 = new byte[copy_len];
                    Device.setAddr(0x200000);
                    Device.read(ram2, 0, copy_len);
                    for (int i = 0; i < copy_len; i++)
                    {
                        if (i % 2 == 0) continue;
                        if (ram[i] != ram2[i]) throw new Exception("Verify error at " + i);
                    }

                    copy_len /= 2;
                    consWriteLine("" + copy_len + " words sent");

                    printMD5(ram);
                    consWriteLine("OK");
                }

            }
            catch (Exception x)
            {
                consWriteLine(x.Message);
            }
            Device.disconnect();

        }


        private void btn_wr_rom_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] rom;
                int rom_size;
                int block_len = 4096;
                Device.connect();
                Device.setDelay(0);

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    consWriteLine("-----------------------------------------------------");
                    FileStream f = File.OpenRead(openFileDialog1.FileName);
                    rom_size = (int)f.Length;
                    if (rom_size % 65536 != 0) rom_size = rom_size / 65536 * 65536 + 65536;
                    if (rom_size > 0x400000) rom_size = 0x400000;
                    rom = new byte[rom_size];
                    f.Read(rom, 0, rom_size);
                    f.Close();

                    progressBar1.Value = 0;
                    progressBar1.Maximum = rom_size;
                    consWriteLine("Flash erase...");
                    Device.flashResetByPass();
                    DateTime t = DateTime.Now;

                    for (int i = 0; i < rom_size; i += 65536)
                    {
                        Device.flashErase(i);
                        progressBar1.Value = i;
                        this.Update();
                    }
                    double time = (double)(DateTime.Now.Ticks - t.Ticks);
                    consWriteLine("Time: " + ((time / 10000) / 1000).ToString("F") + "sec");

                    progressBar1.Value = 0;
                    consWriteLine("Flash write...");
                    Device.flashUnlockBypass();
                    Device.setAddr(0);
                    t = DateTime.Now;

                    for (int i = 0; i < rom_size; i += block_len)
                    {
                        Device.flashWrite(rom, i, block_len);
                        progressBar1.Value = i;
                        this.Update();
                    }
                    time = (double)(DateTime.Now.Ticks - t.Ticks);
                    consWriteLine("Time: " + ((time / 10000) / 1000).ToString("F") + "sec");
                    progressBar1.Value = 0;
                    Device.flashResetByPass();

                    consWriteLine("Flash verify...");
                    byte[] rom2 = new byte[rom.Length];

                    Device.setAddr(0);
                    for (int i = 0; i < rom_size; i += block_len)
                    {
                        Device.read(rom2, i, block_len);
                        progressBar1.Value = i;
                        this.Update();
                    }
                    progressBar1.Value = rom_size;
                    for (int i = 0; i < rom_size; i++)
                    {
                        if (rom[i] != rom2[i]) throw new Exception("Verify error at " + i);
                    }

                    consWriteLine("OK");

                }

            }
            catch (Exception x)
            {
                try
                {
                    Device.flashResetByPass();
                }
                catch (Exception) { }
                consWriteLine(x.Message);
            }
            Device.disconnect();

        }

        private void btn_erase_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] rom;
                int rom_size = 4194304; // max volume
                int block_len = 32768;
                Device.connect();
                Device.setDelay(0);

                consWriteLine("-----------------------------------------------------");
                progressBar1.Value = 0;
                progressBar1.Maximum = rom_size;
                consWriteLine("Flash erase...");
                consWriteLine("Wait ... (~20-40sec average)");
                Device.flashResetByPass();
                DateTime t = DateTime.Now;

                Device.flashEraseAll();

                /*
                for (int i = 0; i < rom_size; i += 65536)
                {
                    Device.flashErase(i);
                    progressBar1.Value = i;
                    this.Update();
                }
                progressBar1.Value = rom_size;
                */

                double time = (double)(DateTime.Now.Ticks - t.Ticks);
                consWriteLine("Time: " + ((time / 10000) / 1000).ToString("F") + "sec");

                consWriteLine("OK");

                Device.flashResetByPass();
                consWriteLine("Blank verify...");
                rom = new byte[rom_size];
                Device.setAddr(0);

                for (int i = 0; i < rom_size; i += block_len)
                {
                    Device.read(rom, i, block_len);
                    progressBar1.Value = i;
                    this.Update();
                }
                progressBar1.Value = rom_size;
                for (int i = 0; i < rom_size; i++)
                {
                    if (rom[i] != 0xff) throw new Exception("Verify error at " + i);
                }

                consWriteLine("OK");

            }
            catch (Exception x)
            {
                try
                {
                    Device.flashResetByPass();
                }
                catch (Exception) { }
                consWriteLine(x.Message);
            }
            Device.disconnect();

        }

        private void btn_rd_rom28_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] rom;
                int rom_size;
                int block_size = 32768;
                Device.connect();
                Device.setDelay(1);
                string rom_name = Cart.getRomName();
                rom_name += ".bin";
                saveFileDialog1.FileName = rom_name;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    consWriteLine("-----------------------------------------------------");
                    rom_size = Cart.getRomSize();
                    //rom_size = 524288; //*
                    progressBar1.Value = 0;
                    progressBar1.Maximum = rom_size;
                    rom = new byte[rom_size];

                    consWriteLine("Read ROM to " + saveFileDialog1.FileName);
                    consWriteLine("ROM size : " + rom_size / 1024 + "K");

                    Device.flash28Reset();
                    Device.setAddr(0);
                    DateTime t = DateTime.Now;
                    for (int i = 0; i < rom_size; i += block_size)
                    {
                        //Device.read(rom, i, block_size);
                        Device.read(rom, i, i + block_size <= rom_size ? block_size : rom_size - (rom_size / block_size) * block_size);
                        progressBar1.Value = i;
                        this.Update();
                    }
                    progressBar1.Value = rom_size;
                    double time = (double)(DateTime.Now.Ticks - t.Ticks);
                    consWriteLine("Time: " + ((time / 10000) / 1000).ToString("F") + "sec");

                    FileStream f = File.OpenWrite(saveFileDialog1.FileName);
                    f.Write(rom, 0, rom.Length);
                    f.Close();

                    printMD5(rom);

                    consWriteLine("OK");
                }

            }
            catch (Exception x)
            {
                consWriteLine(x.Message);
            }
            Device.disconnect();

        }

        private void btn_wr_rom28_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] rom;
                int rom_size;
                int block_len = 1024;
                Device.connect();
                Device.setDelay(0);

                if (Device.flash28IdentMfr() != 137) throw new Exception("Device 28F400 not found ..."); // 0x0089

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    consWriteLine("-----------------------------------------------------");
                    FileStream f = File.OpenRead(openFileDialog1.FileName);
                    rom_size = (int)f.Length;
                    if (rom_size % 65536 != 0) rom_size = rom_size / 65536 * 65536 + 65536;
                    if (rom_size > 0x400000) rom_size = 0x400000;
                    rom = new byte[rom_size];
                    f.Read(rom, 0, rom_size);
                    f.Close();

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = rom_size;
                    progressBar1.Value = 0;
                    progressBar1.Step = rom_size / 5;
                    consWriteLine("Flash erase...");

                    for (int i = 0; i < rom_size; i += 131072)
                    {
                        consWriteLine("Erase sector from: 0x" + i.ToString("X6"));
                        //progressBar1.Value = i;
                        progressBar1.PerformStep();
                        Device.flash28Erase(i);
                        this.Update();
                    }

                    progressBar1.PerformStep();
                    if ((rom_size > 0x78000) && (Device.flash28IdentDev() == 17520)) // 0x4470
                    {
                        consWriteLine("Detected -T device, erase boot block sectors ...");
                        Device.flash28Erase(0x78000);
                        Device.flash28Erase(0x7A000);
                        Device.flash28Erase(0x7C000);
                    }
                    else if (Device.flash28IdentDev() == 17520) // 0x4470
                    {
                        consWriteLine("Detected -T device, not need erase boot block sectors ...");
                    }
                    else if (Device.flash28IdentDev() == 17521) // 0x4471
                    {
                        consWriteLine("Detected -B device, erase boot block sectors ...");
                        Device.flash28Erase(0x04000);
                        Device.flash28Erase(0x06000);
                        Device.flash28Erase(0x08000);
                    }
                    else throw new Exception("Unknown variant of 28F400 - boot block not erased ...");

                    progressBar1.Value = 0;
                    consWriteLine("Flash write...");
                    consWriteLine("Size: " + (rom_size / 1024).ToString("G") + "KB");
                    consWriteLine("Wait... (~10sec max)");
                    Device.setAddr(0);
                    DateTime t = DateTime.Now;

                    for (int i = 0; i < rom_size; i += block_len)
                    {
                        Device.flash28ProgBlock(rom, i, block_len);
                        progressBar1.Value = i;
                        this.Update();
                    }

                    /*
                    // alt write - Ok, but too slow ...
                    for (int i = 0; i < rom_size; i += 2)
                    {
                        Device.flash28Prog(i / 2 , (UInt16)((rom[i] << 8) + rom[i+1]));
                        progressBar1.Value = i;
                        this.Update();
                    }
                    */

                    double time = (double)(DateTime.Now.Ticks - t.Ticks);
                    consWriteLine("Time: " + ((time / 10000) / 1000).ToString("F") + "sec");
                    //printMD5(rom); // Send data checksumm

                    progressBar1.Value = 0;
                    consWriteLine("Flash verify...");
                    byte[] rom2 = new byte[rom.Length];
                    Device.flash28Reset();
                    Device.setAddr(0);
                    t = DateTime.Now;

                    for (int i = 0; i < rom_size; i += block_len)
                    {
                        Device.read(rom2, i, block_len);
                        progressBar1.Value = i;
                        this.Update();
                    }
                    progressBar1.Value = rom_size;
                    for (int i = 0; i < rom_size; i++)
                    {
                        if (rom[i] != rom2[i]) throw new Exception("Verify error at " + i);
                    }

                    time = (double)(DateTime.Now.Ticks - t.Ticks);
                    consWriteLine("Time: " + ((time / 10000) / 1000).ToString("F") + "sec");
                    //printMD5(rom); // Read data checksumm

                    consWriteLine("OK");

                }

            }
            catch (Exception x)
            {
                try
                {
                    Device.flash28Reset();
                }
                catch (Exception) { }
                consWriteLine(x.Message);
            }
            Device.disconnect();

        }

        private void btn_erase28_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] rom;
                int rom_size = 524288; // 512k - all volume
                int block_len = 1024;
                Device.connect();
                Device.setDelay(0);

                if (Device.flash28IdentMfr() != 137) throw new Exception("Device 28F400 not found ..."); // 0x0089

                consWriteLine("-----------------------------------------------------");
                progressBar1.Minimum = 0;
                progressBar1.Maximum = rom_size;
                progressBar1.Value = 0;
                progressBar1.Step = rom_size / 5;
                consWriteLine("Flash erase...");

                for (int i = 0; i < rom_size; i += 131072)
                {
                    consWriteLine("Erase sector from: 0x" + i.ToString("X6"));
                    //progressBar1.Value = i;
                    progressBar1.PerformStep();
                    Device.flash28Erase(i);
                    this.Update();
                }

                progressBar1.PerformStep();
                if (Device.flash28IdentDev() == 17520) // 0x4470
                {
                    consWriteLine("Detected -T device, erase boot block sectors ...");
                    Device.flash28Erase(0x78000);
                    Device.flash28Erase(0x7A000);
                    Device.flash28Erase(0x7C000);
                }
                else if (Device.flash28IdentDev() == 17521) // 0x4471
                {
                    consWriteLine("Detected -B device, erase boot block sectors ...");
                    Device.flash28Erase(0x04000);
                    Device.flash28Erase(0x06000);
                    Device.flash28Erase(0x08000);
                }
                else throw new Exception("Unknown variant of 28F400 - boot block not erased ...");
                progressBar1.Value = rom_size;

                Device.flash28Reset();
                consWriteLine("Blank verify...");
                rom = new byte[rom_size];
                Device.setAddr(0);

                for (int i = 0; i < rom_size; i += block_len)
                {
                    Device.read(rom, i, block_len);
                    progressBar1.Value = i;
                    this.Update();
                }
                progressBar1.Value = rom_size;
                for (int i = 0; i < rom_size; i++)
                {
                    if (rom[i] != 0xff) throw new Exception("Verify error at " + i);
                }

                consWriteLine("OK");

            }
            catch (Exception x)
            {
                try
                {
                    Device.flash28Reset();
                }
                catch (Exception) { }
                consWriteLine(x.Message);
            }
            Device.disconnect();

        }

        private void btn_rd_rom29l_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] rom;
                int rom_size;
                int block_size = 4096; // portion size
                Device.connect();
                Device.setDelay(1);
                string rom_name = Cart.getRomName();
                rom_name += ".bin";
                saveFileDialog1.FileName = rom_name;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    consWriteLine("-----------------------------------------------------");
                    Device.flash29lReset();
                    rom_size = Cart.getRomSize();
                    consWriteLine("ROM size : " + rom_size);
                    //rom_size = 4194304; //*
                    progressBar1.Value = 0;
                    progressBar1.Maximum = rom_size;
                    rom = new byte[rom_size];

                    consWriteLine("Read ROM to " + saveFileDialog1.FileName);
                    consWriteLine("ROM size : " + rom_size / 1024 + "K");

                    Device.flash29lReset();
                    Device.setAddr(0);
                    DateTime t = DateTime.Now;
                    for (int i = 0; i < rom_size; i += block_size)
                    {
                        Device.read(rom, i, i + block_size <= rom_size ? block_size : rom_size - (rom_size / block_size) * block_size);
                        /*
                        if (i + block_size <= rom_size)
                        {
                            Device.read(rom, i, block_size);
                        }
                        else
                        {
                            Device.read(rom, i, (rom_size - (rom_size / block_size) * block_size));
                        }
                        */
                        progressBar1.Value = i;
                        this.Update();
                        /*
                        double ctime = (double)(DateTime.Now.Ticks - t.Ticks);
                        progressBar1.CreateGraphics().DrawString((Math.Floor(ctime / 10000 / 1000)).ToString("G") + "sec",
                            new Font("Tahoma", (float)10.25, FontStyle.Regular),
                            Brushes.Blue, new PointF(progressBar1.Width / 2 - 10,
                            progressBar1.Height / 2 - 7));
                        */ 
                    }
                    progressBar1.Value = rom_size;
                    double time = (double)(DateTime.Now.Ticks - t.Ticks);
                    consWriteLine("Time: " + ((time / 10000) / 1000).ToString("F") + "sec");

                    FileStream f = File.OpenWrite(saveFileDialog1.FileName);
                    f.Write(rom, 0, rom.Length);
                    f.Close();

                    printMD5(rom);

                    consWriteLine("OK");
                }

            }
            catch (Exception x)
            {
                consWriteLine(x.Message);
            }
            Device.disconnect();

        }

        private void btn_wr_rom29l_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] rom;
                byte[] err_rate = new byte[32];
                int rom_size;
                int block_len = 256; // portion size by page program of Flash
                Device.connect();
                Device.setDelay(1);

                if (Device.flash29lIdentMfr() != 0xC2)
                    if (Device.flash29lIdentDev() != 0xF9) throw new Exception("Device 29l3211 not found ...");

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    consWriteLine("-----------------------------------------------------");
                    FileStream f = File.OpenRead(openFileDialog1.FileName);
                    rom_size = (int)f.Length;
                    //if (rom_size % 65536 != 0) rom_size = rom_size / 65536 * 65536 + 65536;
                    if (rom_size % block_len != 0) rom_size = rom_size / block_len * block_len + block_len;
                    if (rom_size > 0x400000) rom_size = 0x400000;
                    rom = new byte[rom_size];
                    byte[] rom2 = new byte[rom.Length];
                    f.Read(rom, 0, rom_size);
                    f.Close();

                    progressBar1.Value = 0;
                    progressBar1.Maximum = rom_size;
                    consWriteLine("Flash erase...");
                    consWriteLine("Wait ... (~0.2-2sec average)");
                    Device.flash29lReset();
                    DateTime t = DateTime.Now;

                    Device.flash29lEraseAll();

                    double time = (double)(DateTime.Now.Ticks - t.Ticks);
                    consWriteLine("Time: " + ((time / 10000) / 1000).ToString("F") + "sec");

                    progressBar1.Value = 0;
                    consWriteLine("Flash write...");
                    consWriteLine("Size: " + (rom_size / 1024).ToString("G") + "KB or " + (rom_size < 131072 ? 1 : (rom_size - (rom_size / 131072) * 131072) == 0 ? rom_size / 131072 : (rom_size / 131072) + 1).ToString("G") + " Sectors");
                    consWriteLine("Wait ... (~1min/MB average)");
                    Device.flash29lReset();
                    Device.setAddr(0);
                    t = DateTime.Now;

                    for (int i = 0; i < rom_size; i += block_len)
                    {
                        Device.flash29lWrite(rom, i, block_len);
                        progressBar1.Value = i;
                        this.Update();
                        /*
                        double ctime = (double)(DateTime.Now.Ticks - t.Ticks);
                        progressBar1.CreateGraphics().DrawString((Math.Floor(ctime / 10000 / 1000)).ToString("G") + "sec",
                            new Font("Tahoma", (float)10.25, FontStyle.Regular),
                            Brushes.Blue, new PointF(progressBar1.Width / 2 - 10,
                            progressBar1.Height / 2 - 7));
                        */
                    }
                    time = (double)(DateTime.Now.Ticks - t.Ticks);
                    consWriteLine("Time: " + ((time / 10000) / 1000).ToString("F") + "sec");
                    //printMD5(rom); // Send data checksumm

                    progressBar1.Value = 0;
                    consWriteLine("Flash verify (and fix)...");
                    Device.flash29lReset();
                    Device.setAddr(0);
                    t = DateTime.Now;

                    for (int i = 0; i < rom_size; i += block_len)
                    {
                        Device.read(rom2, i, block_len);
                        progressBar1.Value = i;
                        this.Update();
                    }
                    progressBar1.Value = rom_size;
                    for (int i = 0; i < rom_size; i++)
                    {
                        while (rom[i] != rom2[i])
                        {
                            int j = 256 - (i - (i / 256) * 256);
                            consWriteLine("... afterburn at " + (i % 2 != 0 ? i-- : i).ToString("X6") + " to " + (i + j).ToString("X6"));
                            Device.setAddr(i);
                            Device.flash29lWrite(rom, i % 2 != 0 ? i-- : i, j);
                            Device.setDelay(5);
                            Device.flash29lReset();
                            Device.setAddr(i % 2 != 0 ? i-- : i);
                            Device.read(rom2, i % 2 != 0 ? i-- : i, j);
                            Device.setDelay(5);
                        }

                    }
                    time = (double)(DateTime.Now.Ticks - t.Ticks);
                    consWriteLine("Time: " + ((time / 10000) / 1000).ToString("F") + "sec");
                    //printMD5(rom2); // Read data checksumm

                    consWriteLine("OK");

                }

            }
            catch (Exception x)
            {
                try
                {
                    Device.flash29lReset();
                }
                catch (Exception) { }
                consWriteLine(x.Message);
            }
            Device.disconnect();

        }

        private void btn_erase29l_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] rom;
                int rom_size = 4194304; // max volume
                //int sec_size = 131072; // portion size (by erase-block)
                int block_len = 4096;
                Device.connect();
                Device.setDelay(1);

                if (Device.flash29lIdentMfr() != 0xC2)
                    if (Device.flash29lIdentDev() != 0xF9) throw new Exception("Device 29l3211 not found ...");

                consWriteLine("-----------------------------------------------------");
                progressBar1.Value = 0;
                progressBar1.Maximum = rom_size;

                consWriteLine("Flash erase...");
                consWriteLine("Wait ... (~0.2-2sec average)");
                Device.flash29lReset();
                DateTime t = DateTime.Now; // start time

                Device.flash29lEraseAll();
                //for (int i = 0; i < 32; i++) Device.flash29lErase(i * sec_size);

                double time = (double)(DateTime.Now.Ticks - t.Ticks); // finish time
                consWriteLine("Time: " + ((time / 10000) / 1000).ToString("F") + "sec");

                consWriteLine("OK");

                consWriteLine("Blank verify...");
                rom = new byte[rom_size];
                Device.flash29lReset();
                Device.setAddr(0);
                t = DateTime.Now;

                for (int i = 0; i < rom_size; i += block_len)
                {
                    Device.read(rom, i, block_len);
                    progressBar1.Value = i;
                    this.Update();
                    /*
                    double ctime = (double)(DateTime.Now.Ticks - t.Ticks);
                    progressBar1.CreateGraphics().DrawString((Math.Floor(ctime / 10000 / 1000)).ToString("G") + "sec",
                        new Font("Tahoma", (float)10.25, FontStyle.Regular),
                        Brushes.Blue, new PointF(progressBar1.Width / 2 - 10,
                        progressBar1.Height / 2 - 7));
                    */
                }
                progressBar1.Value = rom_size;
                for (int i = 0; i < rom_size; i++)
                {
                    if (rom[i] != 0xff) throw new Exception("Verify error at " + i.ToString("X6"));
                }
                time = (double)(DateTime.Now.Ticks - t.Ticks);
                consWriteLine("Time: " + ((time / 10000) / 1000).ToString("F") + "sec");

                consWriteLine("OK");

            }
            catch (Exception x)
            {
                try
                {
                    Device.flash29lReset();
                }
                catch (Exception) { }
                consWriteLine(x.Message);
            }
            Device.disconnect();

        }

    }
}
