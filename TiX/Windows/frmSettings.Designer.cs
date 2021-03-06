﻿namespace TiX.Windows
{
    partial class frmSettings
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
            this.chkTopMost = new System.Windows.Forms.CheckBox();
            this.chkReversedCtrl = new System.Windows.Forms.CheckBox();
            this.ctlUniformity = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblCopyRight = new System.Windows.Forms.Label();
            this.chkEnableShell = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkTopMost
            // 
            this.chkTopMost.AutoSize = true;
            this.chkTopMost.Location = new System.Drawing.Point(12, 32);
            this.chkTopMost.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.Size = new System.Drawing.Size(114, 19);
            this.chkTopMost.TabIndex = 0;
            this.chkTopMost.Text = "TiX 를 항상 위로";
            this.chkTopMost.UseVisualStyleBackColor = true;
            // 
            // chkReversedCtrl
            // 
            this.chkReversedCtrl.AutoSize = true;
            this.chkReversedCtrl.Location = new System.Drawing.Point(12, 59);
            this.chkReversedCtrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkReversedCtrl.Name = "chkReversedCtrl";
            this.chkReversedCtrl.Size = new System.Drawing.Size(233, 19);
            this.chkReversedCtrl.TabIndex = 1;
            this.chkReversedCtrl.Text = "Ctrl키를 누른 채 드래그해야 본문 입력";
            this.chkReversedCtrl.UseVisualStyleBackColor = true;
            // 
            // ctlUniformity
            // 
            this.ctlUniformity.AutoSize = true;
            this.ctlUniformity.Location = new System.Drawing.Point(12, 86);
            this.ctlUniformity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctlUniformity.Name = "ctlUniformity";
            this.ctlUniformity.Size = new System.Drawing.Size(254, 19);
            this.ctlUniformity.TabIndex = 2;
            this.ctlUniformity.Text = "한번에 여러 사진을 올리는 경우 내용 통일";
            this.ctlUniformity.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(221, 140);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(114, 140);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 28);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "확인";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblCopyRight
            // 
            this.lblCopyRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCopyRight.Location = new System.Drawing.Point(12, 9);
            this.lblCopyRight.Name = "lblCopyRight";
            this.lblCopyRight.Size = new System.Drawing.Size(265, 19);
            this.lblCopyRight.TabIndex = 3;
            this.lblCopyRight.Text = "By RyuaNerin && Sasarino MARi";
            this.lblCopyRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCopyRight.Click += new System.EventHandler(this.lblCopyRight_Click);
            // 
            // chkEnableShell
            // 
            this.chkEnableShell.AutoSize = true;
            this.chkEnableShell.Location = new System.Drawing.Point(12, 113);
            this.chkEnableShell.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEnableShell.Name = "chkEnableShell";
            this.chkEnableShell.Size = new System.Drawing.Size(106, 19);
            this.chkEnableShell.TabIndex = 3;
            this.chkEnableShell.Text = "윈도우 셸 확장";
            this.chkEnableShell.UseVisualStyleBackColor = true;
            this.chkEnableShell.CheckedChanged += new System.EventHandler(this.chkEnableShell_CheckedChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 181);
            this.Controls.Add(this.lblCopyRight);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkEnableShell);
            this.Controls.Add(this.ctlUniformity);
            this.Controls.Add(this.chkReversedCtrl);
            this.Controls.Add(this.chkTopMost);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "설정";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkTopMost;
        private System.Windows.Forms.CheckBox chkReversedCtrl;
        private System.Windows.Forms.CheckBox ctlUniformity;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblCopyRight;
        private System.Windows.Forms.CheckBox chkEnableShell;
    }
}
