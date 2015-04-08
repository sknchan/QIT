﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QIT
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }
        private void frmSettings_Load(object sender, EventArgs e)
        {
            this.TopMost = Settings.isTopmost;
            this.checkBox1.Checked = Settings.isTopmost;
            this.checkBox2.Checked = Settings.isReversedCtrl;
            this.checkBox3.Checked = Settings.isUniformityText;
            this.checkBox4.Checked = Settings.PNGTrans;
            if (Settings.ImageExt == 0)
                this.radioButton1.Checked = true;
            else if (Settings.ImageExt == 1)
                this.radioButton2.Checked = true;
            else if (Settings.ImageExt == 2)
                this.radioButton3.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings.isTopmost = this.checkBox1.Checked;
            Settings.isReversedCtrl = this.checkBox2.Checked;
            Settings.isUniformityText = this.checkBox3.Checked;
            Settings.PNGTrans = this.checkBox4.Checked;
            if (this.radioButton1.Checked) Settings.ImageExt = 0;
            else if (this.radioButton2.Checked) Settings.ImageExt = 1;
            else if (this.radioButton3.Checked) Settings.ImageExt = 2;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", "\"http://blog.ryuanerin.kr/\"");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", "\"http://shinku.panty.moe/\"");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings.UToken = Settings.USecret= string.Empty;
            Application.Exit();
        }

    }
}