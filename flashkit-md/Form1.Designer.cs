namespace flashkit_md
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_rd_rom = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_erase = new System.Windows.Forms.Button();
            this.btn_wr_rom = new System.Windows.Forms.Button();
            this.btn_wr_ram = new System.Windows.Forms.Button();
            this.btn_check = new System.Windows.Forms.Button();
            this.btn_rd_ram = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.consoleBox = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_erase28 = new System.Windows.Forms.Button();
            this.btn_wr_rom28 = new System.Windows.Forms.Button();
            this.btn_rd_rom28 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_erase29l = new System.Windows.Forms.Button();
            this.btn_wr_rom29l = new System.Windows.Forms.Button();
            this.btn_rd_rom29l = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_erase29lv = new System.Windows.Forms.Button();
            this.btn_wr_rom29lv = new System.Windows.Forms.Button();
            this.btn_rd_rom29lv = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_sw_rom28cc = new System.Windows.Forms.Button();
            this.btn_erase28cc = new System.Windows.Forms.Button();
            this.btn_wr_rom28cc = new System.Windows.Forms.Button();
            this.btn_rd_rom28cc = new System.Windows.Forms.Button();
            this.cb_ident_chk = new System.Windows.Forms.CheckBox();
            this.cb_force_erase = new System.Windows.Forms.CheckBox();
            this.cb_rd_max = new System.Windows.Forms.CheckBox();
            this.cb_erase_chk = new System.Windows.Forms.CheckBox();
            this.btn_cc_ram = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btn_rd_stream = new System.Windows.Forms.Button();
            this.p_mag16_flash = new System.Windows.Forms.Panel();
            this.rb_flash_full = new System.Windows.Forms.RadioButton();
            this.rb_flash_low = new System.Windows.Forms.RadioButton();
            this.rb_flash_high = new System.Windows.Forms.RadioButton();
            this.btn_wr_stream = new System.Windows.Forms.Button();
            this.btn_rd_page = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btn_sram_dis = new System.Windows.Forms.Button();
            this.btn_sram_en = new System.Windows.Forms.Button();
            this.btn_sel_2nd = new System.Windows.Forms.Button();
            this.btn_sel_1st = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btn_clr_sram = new System.Windows.Forms.Button();
            this.btn_wr_sram = new System.Windows.Forms.Button();
            this.btn_rd_sram = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.p_mag16_flash.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_rd_rom
            // 
            this.btn_rd_rom.Location = new System.Drawing.Point(4, 31);
            this.btn_rd_rom.Name = "btn_rd_rom";
            this.btn_rd_rom.Size = new System.Drawing.Size(64, 50);
            this.btn_rd_rom.TabIndex = 0;
            this.btn_rd_rom.Text = "Read ROM";
            this.btn_rd_rom.UseVisualStyleBackColor = true;
            this.btn_rd_rom.Click += new System.EventHandler(this.btn_rd_rom_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_erase);
            this.groupBox1.Controls.Add(this.btn_wr_rom);
            this.groupBox1.Controls.Add(this.btn_rd_rom);
            this.groupBox1.Location = new System.Drawing.Point(12, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 88);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Word-bypass alg. (etc. 29W-series) Flash-Cart 2 or 4 MB or EverDrive-MD v2";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btn_erase
            // 
            this.btn_erase.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_erase.Location = new System.Drawing.Point(143, 31);
            this.btn_erase.Name = "btn_erase";
            this.btn_erase.Size = new System.Drawing.Size(64, 50);
            this.btn_erase.TabIndex = 5;
            this.btn_erase.Text = "Erase only Flash ROM";
            this.btn_erase.UseVisualStyleBackColor = false;
            this.btn_erase.Click += new System.EventHandler(this.btn_erase_Click);
            // 
            // btn_wr_rom
            // 
            this.btn_wr_rom.Location = new System.Drawing.Point(74, 31);
            this.btn_wr_rom.Name = "btn_wr_rom";
            this.btn_wr_rom.Size = new System.Drawing.Size(64, 50);
            this.btn_wr_rom.TabIndex = 1;
            this.btn_wr_rom.Text = "Write Flash ROM";
            this.btn_wr_rom.UseVisualStyleBackColor = true;
            this.btn_wr_rom.Click += new System.EventHandler(this.btn_wr_rom_Click);
            // 
            // btn_wr_ram
            // 
            this.btn_wr_ram.Location = new System.Drawing.Point(74, 19);
            this.btn_wr_ram.Name = "btn_wr_ram";
            this.btn_wr_ram.Size = new System.Drawing.Size(64, 50);
            this.btn_wr_ram.TabIndex = 3;
            this.btn_wr_ram.Text = "Write SRAM";
            this.btn_wr_ram.UseVisualStyleBackColor = true;
            this.btn_wr_ram.Click += new System.EventHandler(this.btn_wr_ram_Click);
            // 
            // btn_check
            // 
            this.btn_check.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_check.Location = new System.Drawing.Point(143, 19);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(64, 50);
            this.btn_check.TabIndex = 4;
            this.btn_check.Text = "Cart info";
            this.btn_check.UseVisualStyleBackColor = false;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // btn_rd_ram
            // 
            this.btn_rd_ram.Location = new System.Drawing.Point(4, 19);
            this.btn_rd_ram.Name = "btn_rd_ram";
            this.btn_rd_ram.Size = new System.Drawing.Size(64, 50);
            this.btn_rd_ram.TabIndex = 2;
            this.btn_rd_ram.Text = "Read SRAM";
            this.btn_rd_ram.UseVisualStyleBackColor = true;
            this.btn_rd_ram.Click += new System.EventHandler(this.btn_rd_ram_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(238, 506);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(475, 41);
            this.progressBar1.TabIndex = 3;
            // 
            // consoleBox
            // 
            this.consoleBox.BackColor = System.Drawing.SystemColors.Control;
            this.consoleBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.consoleBox.Location = new System.Drawing.Point(238, 12);
            this.consoleBox.Multiline = true;
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ReadOnly = true;
            this.consoleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleBox.Size = new System.Drawing.Size(475, 264);
            this.consoleBox.TabIndex = 4;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "bin";
            this.saveFileDialog1.Filter = "ROM Images|*.gen;*.smd;*.bin;*.rom|All files|*.*";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "bin";
            this.openFileDialog1.Filter = "ROM Images|*.gen;*.smd;*.bin;*.rom|All files|*.*";
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.DefaultExt = "srm";
            this.saveFileDialog2.Filter = "SRAM Dump|*.srm|All files|*.*";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.DefaultExt = "srm";
            this.openFileDialog2.Filter = "SRAM Dump|*.srm|All files|*.*";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_erase28);
            this.groupBox2.Controls.Add(this.btn_wr_rom28);
            this.groupBox2.Controls.Add(this.btn_rd_rom28);
            this.groupBox2.Location = new System.Drawing.Point(12, 376);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 88);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Old-style single-word alg. (PA28F400) OTP-Cart Mod ½ MB";
            // 
            // btn_erase28
            // 
            this.btn_erase28.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_erase28.Location = new System.Drawing.Point(143, 31);
            this.btn_erase28.Name = "btn_erase28";
            this.btn_erase28.Size = new System.Drawing.Size(64, 50);
            this.btn_erase28.TabIndex = 5;
            this.btn_erase28.Text = "Erase only Flash ROM";
            this.btn_erase28.UseVisualStyleBackColor = false;
            this.btn_erase28.Click += new System.EventHandler(this.btn_erase28_Click);
            // 
            // btn_wr_rom28
            // 
            this.btn_wr_rom28.Location = new System.Drawing.Point(74, 31);
            this.btn_wr_rom28.Name = "btn_wr_rom28";
            this.btn_wr_rom28.Size = new System.Drawing.Size(64, 50);
            this.btn_wr_rom28.TabIndex = 2;
            this.btn_wr_rom28.Text = "Write Flash ROM";
            this.btn_wr_rom28.UseVisualStyleBackColor = true;
            this.btn_wr_rom28.Click += new System.EventHandler(this.btn_wr_rom28_Click);
            // 
            // btn_rd_rom28
            // 
            this.btn_rd_rom28.Location = new System.Drawing.Point(4, 31);
            this.btn_rd_rom28.Name = "btn_rd_rom28";
            this.btn_rd_rom28.Size = new System.Drawing.Size(64, 50);
            this.btn_rd_rom28.TabIndex = 1;
            this.btn_rd_rom28.Text = "Read ROM";
            this.btn_rd_rom28.UseVisualStyleBackColor = true;
            this.btn_rd_rom28.Click += new System.EventHandler(this.btn_rd_rom28_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_erase29l);
            this.groupBox3.Controls.Add(this.btn_wr_rom29l);
            this.groupBox3.Controls.Add(this.btn_rd_rom29l);
            this.groupBox3.Location = new System.Drawing.Point(10, 188);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(217, 88);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Page multi-word alg. (etc. MX29Lxx11) Flash-Cart DIY 2 or 4 MB";
            // 
            // btn_erase29l
            // 
            this.btn_erase29l.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_erase29l.Location = new System.Drawing.Point(146, 31);
            this.btn_erase29l.Name = "btn_erase29l";
            this.btn_erase29l.Size = new System.Drawing.Size(64, 50);
            this.btn_erase29l.TabIndex = 5;
            this.btn_erase29l.Text = "Erase only Flash ROM";
            this.btn_erase29l.UseVisualStyleBackColor = false;
            this.btn_erase29l.Click += new System.EventHandler(this.btn_erase29l_Click);
            // 
            // btn_wr_rom29l
            // 
            this.btn_wr_rom29l.Location = new System.Drawing.Point(76, 31);
            this.btn_wr_rom29l.Name = "btn_wr_rom29l";
            this.btn_wr_rom29l.Size = new System.Drawing.Size(64, 50);
            this.btn_wr_rom29l.TabIndex = 2;
            this.btn_wr_rom29l.Text = "Write Flash ROM";
            this.btn_wr_rom29l.UseVisualStyleBackColor = true;
            this.btn_wr_rom29l.Click += new System.EventHandler(this.btn_wr_rom29l_Click);
            // 
            // btn_rd_rom29l
            // 
            this.btn_rd_rom29l.Location = new System.Drawing.Point(6, 31);
            this.btn_rd_rom29l.Name = "btn_rd_rom29l";
            this.btn_rd_rom29l.Size = new System.Drawing.Size(64, 50);
            this.btn_rd_rom29l.TabIndex = 1;
            this.btn_rd_rom29l.Text = "Read ROM";
            this.btn_rd_rom29l.UseVisualStyleBackColor = true;
            this.btn_rd_rom29l.Click += new System.EventHandler(this.btn_rd_rom29l_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_erase29lv);
            this.groupBox4.Controls.Add(this.btn_wr_rom29lv);
            this.groupBox4.Controls.Add(this.btn_rd_rom29lv);
            this.groupBox4.Location = new System.Drawing.Point(10, 282);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(217, 88);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Classic single-word alg. (etc. MX29LV320 or MX26L6420) Flash-Cart DIY 4 or 8 MB";
            // 
            // btn_erase29lv
            // 
            this.btn_erase29lv.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_erase29lv.Location = new System.Drawing.Point(146, 31);
            this.btn_erase29lv.Name = "btn_erase29lv";
            this.btn_erase29lv.Size = new System.Drawing.Size(64, 50);
            this.btn_erase29lv.TabIndex = 5;
            this.btn_erase29lv.Text = "Erase only Flash ROM";
            this.btn_erase29lv.UseVisualStyleBackColor = false;
            this.btn_erase29lv.Click += new System.EventHandler(this.btn_erase29lv_Click);
            // 
            // btn_wr_rom29lv
            // 
            this.btn_wr_rom29lv.Location = new System.Drawing.Point(76, 31);
            this.btn_wr_rom29lv.Name = "btn_wr_rom29lv";
            this.btn_wr_rom29lv.Size = new System.Drawing.Size(64, 50);
            this.btn_wr_rom29lv.TabIndex = 2;
            this.btn_wr_rom29lv.Text = "Write Flash ROM";
            this.btn_wr_rom29lv.UseVisualStyleBackColor = true;
            this.btn_wr_rom29lv.Click += new System.EventHandler(this.btn_wr_rom29lv_Click);
            // 
            // btn_rd_rom29lv
            // 
            this.btn_rd_rom29lv.Location = new System.Drawing.Point(6, 31);
            this.btn_rd_rom29lv.Name = "btn_rd_rom29lv";
            this.btn_rd_rom29lv.Size = new System.Drawing.Size(64, 50);
            this.btn_rd_rom29lv.TabIndex = 1;
            this.btn_rd_rom29lv.Text = "Read ROM";
            this.btn_rd_rom29lv.UseVisualStyleBackColor = true;
            this.btn_rd_rom29lv.Click += new System.EventHandler(this.btn_rd_rom29lv_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_sw_rom28cc);
            this.groupBox5.Controls.Add(this.btn_erase28cc);
            this.groupBox5.Controls.Add(this.btn_wr_rom28cc);
            this.groupBox5.Controls.Add(this.btn_rd_rom28cc);
            this.groupBox5.Location = new System.Drawing.Point(10, 470);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(217, 76);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Mega-CC (PA28F400 last half only) ¼ MB";
            // 
            // btn_sw_rom28cc
            // 
            this.btn_sw_rom28cc.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_sw_rom28cc.Location = new System.Drawing.Point(146, 19);
            this.btn_sw_rom28cc.Name = "btn_sw_rom28cc";
            this.btn_sw_rom28cc.Size = new System.Drawing.Size(64, 50);
            this.btn_sw_rom28cc.TabIndex = 6;
            this.btn_sw_rom28cc.Text = "Switch to Cart in slot";
            this.btn_sw_rom28cc.UseVisualStyleBackColor = false;
            this.btn_sw_rom28cc.Click += new System.EventHandler(this.btn_sw_rom28cc_Click);
            // 
            // btn_erase28cc
            // 
            this.btn_erase28cc.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_erase28cc.Location = new System.Drawing.Point(146, 19);
            this.btn_erase28cc.Name = "btn_erase28cc";
            this.btn_erase28cc.Size = new System.Drawing.Size(64, 50);
            this.btn_erase28cc.TabIndex = 5;
            this.btn_erase28cc.Text = "Erase only Flash ROM";
            this.btn_erase28cc.UseVisualStyleBackColor = false;
            this.btn_erase28cc.Visible = false;
            this.btn_erase28cc.Click += new System.EventHandler(this.btn_erase28cc_Click);
            // 
            // btn_wr_rom28cc
            // 
            this.btn_wr_rom28cc.Location = new System.Drawing.Point(76, 19);
            this.btn_wr_rom28cc.Name = "btn_wr_rom28cc";
            this.btn_wr_rom28cc.Size = new System.Drawing.Size(64, 50);
            this.btn_wr_rom28cc.TabIndex = 2;
            this.btn_wr_rom28cc.Text = "Write Flash ROM";
            this.btn_wr_rom28cc.UseVisualStyleBackColor = true;
            this.btn_wr_rom28cc.Click += new System.EventHandler(this.btn_wr_rom28cc_Click);
            // 
            // btn_rd_rom28cc
            // 
            this.btn_rd_rom28cc.Location = new System.Drawing.Point(6, 19);
            this.btn_rd_rom28cc.Name = "btn_rd_rom28cc";
            this.btn_rd_rom28cc.Size = new System.Drawing.Size(64, 50);
            this.btn_rd_rom28cc.TabIndex = 1;
            this.btn_rd_rom28cc.Text = "Read ROM";
            this.btn_rd_rom28cc.UseVisualStyleBackColor = true;
            this.btn_rd_rom28cc.Click += new System.EventHandler(this.btn_rd_rom28cc_Click);
            // 
            // cb_ident_chk
            // 
            this.cb_ident_chk.AutoSize = true;
            this.cb_ident_chk.Location = new System.Drawing.Point(238, 379);
            this.cb_ident_chk.Margin = new System.Windows.Forms.Padding(2);
            this.cb_ident_chk.Name = "cb_ident_chk";
            this.cb_ident_chk.Size = new System.Drawing.Size(122, 17);
            this.cb_ident_chk.TabIndex = 8;
            this.cb_ident_chk.Text = "Checking Device ID";
            this.cb_ident_chk.UseVisualStyleBackColor = true;
            // 
            // cb_force_erase
            // 
            this.cb_force_erase.AutoSize = true;
            this.cb_force_erase.Checked = true;
            this.cb_force_erase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_force_erase.Location = new System.Drawing.Point(238, 423);
            this.cb_force_erase.Margin = new System.Windows.Forms.Padding(2);
            this.cb_force_erase.Name = "cb_force_erase";
            this.cb_force_erase.Size = new System.Drawing.Size(122, 17);
            this.cb_force_erase.TabIndex = 9;
            this.cb_force_erase.Text = "Erasing before Write";
            this.cb_force_erase.UseVisualStyleBackColor = true;
            // 
            // cb_rd_max
            // 
            this.cb_rd_max.AutoSize = true;
            this.cb_rd_max.Location = new System.Drawing.Point(238, 401);
            this.cb_rd_max.Margin = new System.Windows.Forms.Padding(2);
            this.cb_rd_max.Name = "cb_rd_max";
            this.cb_rd_max.Size = new System.Drawing.Size(111, 17);
            this.cb_rd_max.TabIndex = 10;
            this.cb_rd_max.Text = "Read max volume";
            this.cb_rd_max.UseVisualStyleBackColor = true;
            // 
            // cb_erase_chk
            // 
            this.cb_erase_chk.AutoSize = true;
            this.cb_erase_chk.Checked = true;
            this.cb_erase_chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_erase_chk.Location = new System.Drawing.Point(238, 445);
            this.cb_erase_chk.Margin = new System.Windows.Forms.Padding(2);
            this.cb_erase_chk.Name = "cb_erase_chk";
            this.cb_erase_chk.Size = new System.Drawing.Size(120, 17);
            this.cb_erase_chk.TabIndex = 11;
            this.cb_erase_chk.Text = "Verifying after Erase";
            this.cb_erase_chk.UseVisualStyleBackColor = true;
            // 
            // btn_cc_ram
            // 
            this.btn_cc_ram.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_cc_ram.Location = new System.Drawing.Point(20, 18);
            this.btn_cc_ram.Name = "btn_cc_ram";
            this.btn_cc_ram.Size = new System.Drawing.Size(95, 23);
            this.btn_cc_ram.TabIndex = 12;
            this.btn_cc_ram.Text = "RAM Test";
            this.btn_cc_ram.UseVisualStyleBackColor = false;
            this.btn_cc_ram.Click += new System.EventHandler(this.btn_cc_ram_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btn_wr_ram);
            this.groupBox6.Controls.Add(this.btn_check);
            this.groupBox6.Controls.Add(this.btn_rd_ram);
            this.groupBox6.Location = new System.Drawing.Point(12, 11);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(217, 76);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Generic function";
            // 
            // btn_rd_stream
            // 
            this.btn_rd_stream.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_rd_stream.Location = new System.Drawing.Point(20, 46);
            this.btn_rd_stream.Name = "btn_rd_stream";
            this.btn_rd_stream.Size = new System.Drawing.Size(95, 23);
            this.btn_rd_stream.TabIndex = 14;
            this.btn_rd_stream.Text = "Magistr16 Read";
            this.btn_rd_stream.UseVisualStyleBackColor = false;
            this.btn_rd_stream.Click += new System.EventHandler(this.btn_rd_stream_Click);
            // 
            // p_mag16_flash
            // 
            this.p_mag16_flash.Controls.Add(this.rb_flash_full);
            this.p_mag16_flash.Controls.Add(this.rb_flash_low);
            this.p_mag16_flash.Controls.Add(this.rb_flash_high);
            this.p_mag16_flash.Location = new System.Drawing.Point(5, 18);
            this.p_mag16_flash.Margin = new System.Windows.Forms.Padding(2);
            this.p_mag16_flash.Name = "p_mag16_flash";
            this.p_mag16_flash.Size = new System.Drawing.Size(234, 22);
            this.p_mag16_flash.TabIndex = 15;
            // 
            // rb_flash_full
            // 
            this.rb_flash_full.AutoSize = true;
            this.rb_flash_full.Checked = true;
            this.rb_flash_full.Location = new System.Drawing.Point(160, 2);
            this.rb_flash_full.Margin = new System.Windows.Forms.Padding(2);
            this.rb_flash_full.Name = "rb_flash_full";
            this.rb_flash_full.Size = new System.Drawing.Size(66, 17);
            this.rb_flash_full.TabIndex = 2;
            this.rb_flash_full.TabStop = true;
            this.rb_flash_full.Text = "Flash full";
            this.rb_flash_full.UseVisualStyleBackColor = true;
            // 
            // rb_flash_low
            // 
            this.rb_flash_low.AutoSize = true;
            this.rb_flash_low.Location = new System.Drawing.Point(83, 2);
            this.rb_flash_low.Margin = new System.Windows.Forms.Padding(2);
            this.rb_flash_low.Name = "rb_flash_low";
            this.rb_flash_low.Size = new System.Drawing.Size(71, 17);
            this.rb_flash_low.TabIndex = 1;
            this.rb_flash_low.Text = "Flash odd";
            this.rb_flash_low.UseVisualStyleBackColor = true;
            // 
            // rb_flash_high
            // 
            this.rb_flash_high.AutoSize = true;
            this.rb_flash_high.Location = new System.Drawing.Point(2, 2);
            this.rb_flash_high.Margin = new System.Windows.Forms.Padding(2);
            this.rb_flash_high.Name = "rb_flash_high";
            this.rb_flash_high.Size = new System.Drawing.Size(77, 17);
            this.rb_flash_high.TabIndex = 0;
            this.rb_flash_high.Text = "Flash even";
            this.rb_flash_high.UseVisualStyleBackColor = true;
            // 
            // btn_wr_stream
            // 
            this.btn_wr_stream.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_wr_stream.Location = new System.Drawing.Point(120, 46);
            this.btn_wr_stream.Name = "btn_wr_stream";
            this.btn_wr_stream.Size = new System.Drawing.Size(95, 23);
            this.btn_wr_stream.TabIndex = 16;
            this.btn_wr_stream.Text = "Magistr16 Write";
            this.btn_wr_stream.UseVisualStyleBackColor = false;
            this.btn_wr_stream.Click += new System.EventHandler(this.btn_wr_stream_Click);
            // 
            // btn_rd_page
            // 
            this.btn_rd_page.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_rd_page.Location = new System.Drawing.Point(284, 468);
            this.btn_rd_page.Name = "btn_rd_page";
            this.btn_rd_page.Size = new System.Drawing.Size(64, 23);
            this.btn_rd_page.TabIndex = 18;
            this.btn_rd_page.Text = "Test Func";
            this.btn_rd_page.UseVisualStyleBackColor = false;
            this.btn_rd_page.Visible = false;
            this.btn_rd_page.Click += new System.EventHandler(this.btn_rd_page_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btn_cc_ram);
            this.groupBox7.Location = new System.Drawing.Point(471, 451);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox7.Size = new System.Drawing.Size(242, 49);
            this.groupBox7.TabIndex = 20;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Mega-CC";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btn_wr_stream);
            this.groupBox8.Controls.Add(this.btn_rd_stream);
            this.groupBox8.Controls.Add(this.p_mag16_flash);
            this.groupBox8.Location = new System.Drawing.Point(471, 375);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox8.Size = new System.Drawing.Size(242, 75);
            this.groupBox8.TabIndex = 21;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Inside Magistr16 Flash over Mega EverDrive";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btn_sram_dis);
            this.groupBox9.Controls.Add(this.btn_sram_en);
            this.groupBox9.Controls.Add(this.btn_sel_2nd);
            this.groupBox9.Controls.Add(this.btn_sel_1st);
            this.groupBox9.Location = new System.Drawing.Point(362, 375);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox9.Size = new System.Drawing.Size(105, 125);
            this.groupBox9.TabIndex = 22;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "EverDrive-MD v2";
            // 
            // btn_sram_dis
            // 
            this.btn_sram_dis.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_sram_dis.Location = new System.Drawing.Point(5, 97);
            this.btn_sram_dis.Name = "btn_sram_dis";
            this.btn_sram_dis.Size = new System.Drawing.Size(95, 23);
            this.btn_sram_dis.TabIndex = 23;
            this.btn_sram_dis.Text = "SRAM Disable";
            this.btn_sram_dis.UseVisualStyleBackColor = false;
            this.btn_sram_dis.Click += new System.EventHandler(this.btn_sram_dis_Click);
            // 
            // btn_sram_en
            // 
            this.btn_sram_en.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_sram_en.Location = new System.Drawing.Point(5, 72);
            this.btn_sram_en.Name = "btn_sram_en";
            this.btn_sram_en.Size = new System.Drawing.Size(95, 23);
            this.btn_sram_en.TabIndex = 15;
            this.btn_sram_en.Text = "SRAM Enable";
            this.btn_sram_en.UseVisualStyleBackColor = false;
            this.btn_sram_en.Click += new System.EventHandler(this.btn_sram_en_Click);
            // 
            // btn_sel_2nd
            // 
            this.btn_sel_2nd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_sel_2nd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btn_sel_2nd.Location = new System.Drawing.Point(5, 42);
            this.btn_sel_2nd.Name = "btn_sel_2nd";
            this.btn_sel_2nd.Size = new System.Drawing.Size(95, 23);
            this.btn_sel_2nd.TabIndex = 14;
            this.btn_sel_2nd.Text = "Main area";
            this.btn_sel_2nd.UseVisualStyleBackColor = false;
            this.btn_sel_2nd.Click += new System.EventHandler(this.btn_sel_2nd_Click);
            // 
            // btn_sel_1st
            // 
            this.btn_sel_1st.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_sel_1st.Location = new System.Drawing.Point(5, 18);
            this.btn_sel_1st.Name = "btn_sel_1st";
            this.btn_sel_1st.Size = new System.Drawing.Size(95, 23);
            this.btn_sel_1st.TabIndex = 13;
            this.btn_sel_1st.Text = "Boot area";
            this.btn_sel_1st.UseVisualStyleBackColor = false;
            this.btn_sel_1st.Click += new System.EventHandler(this.btn_sel_1st_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.btn_clr_sram);
            this.groupBox10.Controls.Add(this.btn_wr_sram);
            this.groupBox10.Controls.Add(this.btn_rd_sram);
            this.groupBox10.Location = new System.Drawing.Point(238, 282);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(217, 88);
            this.groupBox10.TabIndex = 23;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Direct r/w access to Static RAM array (etc. Mega RAM-Cart) Custom DIY 4 MB";
            // 
            // btn_clr_sram
            // 
            this.btn_clr_sram.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_clr_sram.Enabled = false;
            this.btn_clr_sram.Location = new System.Drawing.Point(146, 31);
            this.btn_clr_sram.Name = "btn_clr_sram";
            this.btn_clr_sram.Size = new System.Drawing.Size(64, 50);
            this.btn_clr_sram.TabIndex = 5;
            this.btn_clr_sram.Text = "Test && Clear SRAM";
            this.btn_clr_sram.UseVisualStyleBackColor = false;
            this.btn_clr_sram.Visible = false;
            // 
            // btn_wr_sram
            // 
            this.btn_wr_sram.Location = new System.Drawing.Point(76, 31);
            this.btn_wr_sram.Name = "btn_wr_sram";
            this.btn_wr_sram.Size = new System.Drawing.Size(64, 50);
            this.btn_wr_sram.TabIndex = 2;
            this.btn_wr_sram.Text = "Write SRAM";
            this.btn_wr_sram.UseVisualStyleBackColor = true;
            this.btn_wr_sram.Click += new System.EventHandler(this.btn_wr_sram_Click);
            // 
            // btn_rd_sram
            // 
            this.btn_rd_sram.Location = new System.Drawing.Point(6, 31);
            this.btn_rd_sram.Name = "btn_rd_sram";
            this.btn_rd_sram.Size = new System.Drawing.Size(64, 50);
            this.btn_rd_sram.TabIndex = 1;
            this.btn_rd_sram.Text = "Read SRAM";
            this.btn_rd_sram.UseVisualStyleBackColor = true;
            this.btn_rd_sram.Click += new System.EventHandler(this.btn_rd_sram_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 555);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btn_rd_page);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.cb_erase_chk);
            this.Controls.Add(this.cb_rd_max);
            this.Controls.Add(this.cb_force_erase);
            this.Controls.Add(this.cb_ident_chk);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Flashkit-md-plus";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_rd_rom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_wr_rom;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.Button btn_wr_ram;
        private System.Windows.Forms.Button btn_rd_ram;
        private System.Windows.Forms.TextBox consoleBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_erase;
        private System.Windows.Forms.Button btn_erase28;
        private System.Windows.Forms.Button btn_wr_rom28;
        private System.Windows.Forms.Button btn_rd_rom28;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_erase29l;
        private System.Windows.Forms.Button btn_wr_rom29l;
        private System.Windows.Forms.Button btn_rd_rom29l;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_erase29lv;
        private System.Windows.Forms.Button btn_wr_rom29lv;
        private System.Windows.Forms.Button btn_rd_rom29lv;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_wr_rom28cc;
        private System.Windows.Forms.Button btn_rd_rom28cc;
        private System.Windows.Forms.Button btn_sw_rom28cc;
        private System.Windows.Forms.Button btn_erase28cc;
        private System.Windows.Forms.CheckBox cb_ident_chk;
        private System.Windows.Forms.CheckBox cb_force_erase;
        private System.Windows.Forms.CheckBox cb_rd_max;
        private System.Windows.Forms.CheckBox cb_erase_chk;
        private System.Windows.Forms.Button btn_cc_ram;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btn_rd_stream;
        private System.Windows.Forms.Panel p_mag16_flash;
        private System.Windows.Forms.RadioButton rb_flash_full;
        private System.Windows.Forms.RadioButton rb_flash_low;
        private System.Windows.Forms.RadioButton rb_flash_high;
        private System.Windows.Forms.Button btn_wr_stream;
        private System.Windows.Forms.Button btn_rd_page;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btn_sel_2nd;
        private System.Windows.Forms.Button btn_sel_1st;
        private System.Windows.Forms.Button btn_sram_dis;
        private System.Windows.Forms.Button btn_sram_en;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button btn_clr_sram;
        private System.Windows.Forms.Button btn_wr_sram;
        private System.Windows.Forms.Button btn_rd_sram;
    }
}

