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
            this.btn_wr_ram = new System.Windows.Forms.Button();
            this.btn_erase = new System.Windows.Forms.Button();
            this.btn_check = new System.Windows.Forms.Button();
            this.btn_wr_rom = new System.Windows.Forms.Button();
            this.btn_rd_ram = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.consoleBox = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
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
            this.btn_wr_rom28cc = new System.Windows.Forms.Button();
            this.btn_rd_rom28cc = new System.Windows.Forms.Button();
            this.btn_erase28cc = new System.Windows.Forms.Button();
            this.btn_sw_rom28cc = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_rd_rom
            // 
            this.btn_rd_rom.Location = new System.Drawing.Point(8, 23);
            this.btn_rd_rom.Margin = new System.Windows.Forms.Padding(4);
            this.btn_rd_rom.Name = "btn_rd_rom";
            this.btn_rd_rom.Size = new System.Drawing.Size(85, 62);
            this.btn_rd_rom.TabIndex = 0;
            this.btn_rd_rom.Text = "Read ROM";
            this.btn_rd_rom.UseVisualStyleBackColor = true;
            this.btn_rd_rom.Click += new System.EventHandler(this.btn_rd_rom_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_wr_ram);
            this.groupBox1.Controls.Add(this.btn_erase);
            this.groupBox1.Controls.Add(this.btn_check);
            this.groupBox1.Controls.Add(this.btn_wr_rom);
            this.groupBox1.Controls.Add(this.btn_rd_ram);
            this.groupBox1.Controls.Add(this.btn_rd_rom);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(289, 163);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flash-Cart DIY (29W-series) 2 or 4 MB";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btn_wr_ram
            // 
            this.btn_wr_ram.Location = new System.Drawing.Point(102, 92);
            this.btn_wr_ram.Margin = new System.Windows.Forms.Padding(4);
            this.btn_wr_ram.Name = "btn_wr_ram";
            this.btn_wr_ram.Size = new System.Drawing.Size(85, 62);
            this.btn_wr_ram.TabIndex = 3;
            this.btn_wr_ram.Text = "Write SRAM";
            this.btn_wr_ram.UseVisualStyleBackColor = true;
            this.btn_wr_ram.Click += new System.EventHandler(this.btn_wr_ram_Click);
            // 
            // btn_erase
            // 
            this.btn_erase.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_erase.Location = new System.Drawing.Point(195, 23);
            this.btn_erase.Margin = new System.Windows.Forms.Padding(4);
            this.btn_erase.Name = "btn_erase";
            this.btn_erase.Size = new System.Drawing.Size(85, 62);
            this.btn_erase.TabIndex = 5;
            this.btn_erase.Text = "Erase only Flash ROM";
            this.btn_erase.UseVisualStyleBackColor = false;
            this.btn_erase.Click += new System.EventHandler(this.btn_erase_Click);
            // 
            // btn_check
            // 
            this.btn_check.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_check.Location = new System.Drawing.Point(195, 93);
            this.btn_check.Margin = new System.Windows.Forms.Padding(4);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(85, 62);
            this.btn_check.TabIndex = 4;
            this.btn_check.Text = "Cart info";
            this.btn_check.UseVisualStyleBackColor = false;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // btn_wr_rom
            // 
            this.btn_wr_rom.Location = new System.Drawing.Point(102, 23);
            this.btn_wr_rom.Margin = new System.Windows.Forms.Padding(4);
            this.btn_wr_rom.Name = "btn_wr_rom";
            this.btn_wr_rom.Size = new System.Drawing.Size(85, 62);
            this.btn_wr_rom.TabIndex = 1;
            this.btn_wr_rom.Text = "Write Flash ROM";
            this.btn_wr_rom.UseVisualStyleBackColor = true;
            this.btn_wr_rom.Click += new System.EventHandler(this.btn_wr_rom_Click);
            // 
            // btn_rd_ram
            // 
            this.btn_rd_ram.Location = new System.Drawing.Point(8, 92);
            this.btn_rd_ram.Margin = new System.Windows.Forms.Padding(4);
            this.btn_rd_ram.Name = "btn_rd_ram";
            this.btn_rd_ram.Size = new System.Drawing.Size(85, 62);
            this.btn_rd_ram.TabIndex = 2;
            this.btn_rd_ram.Text = "Read SRAM";
            this.btn_rd_ram.UseVisualStyleBackColor = true;
            this.btn_rd_ram.Click += new System.EventHandler(this.btn_rd_ram_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 603);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(935, 69);
            this.progressBar1.TabIndex = 3;
            // 
            // consoleBox
            // 
            this.consoleBox.BackColor = System.Drawing.SystemColors.Control;
            this.consoleBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.consoleBox.Location = new System.Drawing.Point(319, 15);
            this.consoleBox.Margin = new System.Windows.Forms.Padding(4);
            this.consoleBox.Multiline = true;
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ReadOnly = true;
            this.consoleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleBox.Size = new System.Drawing.Size(631, 580);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_erase28);
            this.groupBox2.Controls.Add(this.btn_wr_rom28);
            this.groupBox2.Controls.Add(this.btn_rd_rom28);
            this.groupBox2.Location = new System.Drawing.Point(16, 390);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(289, 94);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OTP-Cart Mod (PA28F400) ½ MB";
            // 
            // btn_erase28
            // 
            this.btn_erase28.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_erase28.Location = new System.Drawing.Point(195, 23);
            this.btn_erase28.Margin = new System.Windows.Forms.Padding(4);
            this.btn_erase28.Name = "btn_erase28";
            this.btn_erase28.Size = new System.Drawing.Size(85, 62);
            this.btn_erase28.TabIndex = 5;
            this.btn_erase28.Text = "Erase only Flash ROM";
            this.btn_erase28.UseVisualStyleBackColor = false;
            this.btn_erase28.Click += new System.EventHandler(this.btn_erase28_Click);
            // 
            // btn_wr_rom28
            // 
            this.btn_wr_rom28.Location = new System.Drawing.Point(102, 23);
            this.btn_wr_rom28.Margin = new System.Windows.Forms.Padding(4);
            this.btn_wr_rom28.Name = "btn_wr_rom28";
            this.btn_wr_rom28.Size = new System.Drawing.Size(85, 62);
            this.btn_wr_rom28.TabIndex = 2;
            this.btn_wr_rom28.Text = "Write Flash ROM";
            this.btn_wr_rom28.UseVisualStyleBackColor = true;
            this.btn_wr_rom28.Click += new System.EventHandler(this.btn_wr_rom28_Click);
            // 
            // btn_rd_rom28
            // 
            this.btn_rd_rom28.Location = new System.Drawing.Point(8, 23);
            this.btn_rd_rom28.Margin = new System.Windows.Forms.Padding(4);
            this.btn_rd_rom28.Name = "btn_rd_rom28";
            this.btn_rd_rom28.Size = new System.Drawing.Size(85, 62);
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
            this.groupBox3.Location = new System.Drawing.Point(16, 186);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(289, 94);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Flash-Cart DIY (MX29L3211) 4 MB";
            // 
            // btn_erase29l
            // 
            this.btn_erase29l.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_erase29l.Location = new System.Drawing.Point(195, 23);
            this.btn_erase29l.Margin = new System.Windows.Forms.Padding(4);
            this.btn_erase29l.Name = "btn_erase29l";
            this.btn_erase29l.Size = new System.Drawing.Size(85, 62);
            this.btn_erase29l.TabIndex = 5;
            this.btn_erase29l.Text = "Erase only Flash ROM";
            this.btn_erase29l.UseVisualStyleBackColor = false;
            this.btn_erase29l.Click += new System.EventHandler(this.btn_erase29l_Click);
            // 
            // btn_wr_rom29l
            // 
            this.btn_wr_rom29l.Location = new System.Drawing.Point(102, 23);
            this.btn_wr_rom29l.Margin = new System.Windows.Forms.Padding(4);
            this.btn_wr_rom29l.Name = "btn_wr_rom29l";
            this.btn_wr_rom29l.Size = new System.Drawing.Size(85, 62);
            this.btn_wr_rom29l.TabIndex = 2;
            this.btn_wr_rom29l.Text = "Write Flash ROM";
            this.btn_wr_rom29l.UseVisualStyleBackColor = true;
            this.btn_wr_rom29l.Click += new System.EventHandler(this.btn_wr_rom29l_Click);
            // 
            // btn_rd_rom29l
            // 
            this.btn_rd_rom29l.Location = new System.Drawing.Point(8, 23);
            this.btn_rd_rom29l.Margin = new System.Windows.Forms.Padding(4);
            this.btn_rd_rom29l.Name = "btn_rd_rom29l";
            this.btn_rd_rom29l.Size = new System.Drawing.Size(85, 62);
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
            this.groupBox4.Location = new System.Drawing.Point(16, 288);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(289, 94);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Flash-Cart DIY (MX29LV320) 4 MB";
            // 
            // btn_erase29lv
            // 
            this.btn_erase29lv.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_erase29lv.Location = new System.Drawing.Point(195, 23);
            this.btn_erase29lv.Margin = new System.Windows.Forms.Padding(4);
            this.btn_erase29lv.Name = "btn_erase29lv";
            this.btn_erase29lv.Size = new System.Drawing.Size(85, 62);
            this.btn_erase29lv.TabIndex = 5;
            this.btn_erase29lv.Text = "Erase only Flash ROM";
            this.btn_erase29lv.UseVisualStyleBackColor = false;
            this.btn_erase29lv.Click += new System.EventHandler(this.btn_erase29lv_Click);
            // 
            // btn_wr_rom29lv
            // 
            this.btn_wr_rom29lv.Location = new System.Drawing.Point(102, 23);
            this.btn_wr_rom29lv.Margin = new System.Windows.Forms.Padding(4);
            this.btn_wr_rom29lv.Name = "btn_wr_rom29lv";
            this.btn_wr_rom29lv.Size = new System.Drawing.Size(85, 62);
            this.btn_wr_rom29lv.TabIndex = 2;
            this.btn_wr_rom29lv.Text = "Write Flash ROM";
            this.btn_wr_rom29lv.UseVisualStyleBackColor = true;
            this.btn_wr_rom29lv.Click += new System.EventHandler(this.btn_wr_rom29lv_Click);
            // 
            // btn_rd_rom29lv
            // 
            this.btn_rd_rom29lv.Location = new System.Drawing.Point(8, 23);
            this.btn_rd_rom29lv.Margin = new System.Windows.Forms.Padding(4);
            this.btn_rd_rom29lv.Name = "btn_rd_rom29lv";
            this.btn_rd_rom29lv.Size = new System.Drawing.Size(85, 62);
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
            this.groupBox5.Location = new System.Drawing.Point(16, 492);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(289, 94);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Mega-CC (PA28F400 last half only) ¼ MB";
            // 
            // btn_wr_rom28cc
            // 
            this.btn_wr_rom28cc.Location = new System.Drawing.Point(102, 23);
            this.btn_wr_rom28cc.Margin = new System.Windows.Forms.Padding(4);
            this.btn_wr_rom28cc.Name = "btn_wr_rom28cc";
            this.btn_wr_rom28cc.Size = new System.Drawing.Size(85, 62);
            this.btn_wr_rom28cc.TabIndex = 2;
            this.btn_wr_rom28cc.Text = "Write Flash ROM";
            this.btn_wr_rom28cc.UseVisualStyleBackColor = true;
            this.btn_wr_rom28cc.Click += new System.EventHandler(this.btn_wr_rom28cc_Click);
            // 
            // btn_rd_rom28cc
            // 
            this.btn_rd_rom28cc.Location = new System.Drawing.Point(8, 23);
            this.btn_rd_rom28cc.Margin = new System.Windows.Forms.Padding(4);
            this.btn_rd_rom28cc.Name = "btn_rd_rom28cc";
            this.btn_rd_rom28cc.Size = new System.Drawing.Size(85, 62);
            this.btn_rd_rom28cc.TabIndex = 1;
            this.btn_rd_rom28cc.Text = "Read ROM";
            this.btn_rd_rom28cc.UseVisualStyleBackColor = true;
            this.btn_rd_rom28cc.Click += new System.EventHandler(this.btn_rd_rom28cc_Click);
            // 
            // btn_erase28cc
            // 
            this.btn_erase28cc.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_erase28cc.Location = new System.Drawing.Point(195, 23);
            this.btn_erase28cc.Margin = new System.Windows.Forms.Padding(4);
            this.btn_erase28cc.Name = "btn_erase28cc";
            this.btn_erase28cc.Size = new System.Drawing.Size(85, 62);
            this.btn_erase28cc.TabIndex = 5;
            this.btn_erase28cc.Text = "Erase only Flash ROM";
            this.btn_erase28cc.UseVisualStyleBackColor = false;
            this.btn_erase28cc.Visible = false;
            this.btn_erase28cc.Click += new System.EventHandler(this.btn_erase28cc_Click);
            // 
            // btn_sw_rom28cc
            // 
            this.btn_sw_rom28cc.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_sw_rom28cc.Location = new System.Drawing.Point(195, 23);
            this.btn_sw_rom28cc.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sw_rom28cc.Name = "btn_sw_rom28cc";
            this.btn_sw_rom28cc.Size = new System.Drawing.Size(85, 62);
            this.btn_sw_rom28cc.TabIndex = 6;
            this.btn_sw_rom28cc.Text = "Switch to Cart in slot";
            this.btn_sw_rom28cc.UseVisualStyleBackColor = false;
            this.btn_sw_rom28cc.Click += new System.EventHandler(this.btn_sw_rom28cc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 683);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Flashkit-md-plus";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
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
    }
}

