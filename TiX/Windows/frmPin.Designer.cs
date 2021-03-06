﻿namespace TiX.Windows
{
	partial class frmPin
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
            this.bgwBefore = new System.ComponentModel.BackgroundWorker();
            this.bgwAfter = new System.ComponentModel.BackgroundWorker();
            this.pnl = new System.Windows.Forms.Panel();
            this.ajax = new TiX.Windows.AjaxControl();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgwBefore
            // 
            this.bgwBefore.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwBefore_DoWork);
            this.bgwBefore.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwBefore_RunWorkerCompleted);
            // 
            // bgwAfter
            // 
            this.bgwAfter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwAfter_DoWork);
            this.bgwAfter.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwAfter_RunWorkerCompleted);
            // 
            // pnl
            // 
            this.pnl.Controls.Add(this.ajax);
            this.pnl.Controls.Add(this.txtPin);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl.Location = new System.Drawing.Point(0, 0);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(148, 47);
            this.pnl.TabIndex = 3;
            // 
            // ajax
            // 
            this.ajax.Is16 = true;
            this.ajax.Location = new System.Drawing.Point(68, 19);
            this.ajax.Name = "ajax";
            this.ajax.Size = new System.Drawing.Size(16, 16);
            this.ajax.TabIndex = 2;
            this.ajax.Visible = false;
            // 
            // txtPin
            // 
            this.txtPin.Enabled = false;
            this.txtPin.Location = new System.Drawing.Point(12, 12);
            this.txtPin.MaxLength = 8;
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(124, 23);
            this.txtPin.TabIndex = 1;
            this.txtPin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPin_KeyDown);
            // 
            // frmPin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(148, 47);
            this.Controls.Add(this.pnl);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "핀번호 입력";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPin_FormClosing);
            this.Load += new System.EventHandler(this.frmPin_Load);
            this.pnl.ResumeLayout(false);
            this.pnl.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.ComponentModel.BackgroundWorker bgwBefore;
		private System.ComponentModel.BackgroundWorker bgwAfter;
		private System.Windows.Forms.Panel pnl;
        private AjaxControl ajax;
        private System.Windows.Forms.TextBox txtPin;
	}
}
