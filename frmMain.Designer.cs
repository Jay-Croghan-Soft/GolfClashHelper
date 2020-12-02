﻿
namespace GolfClashHelper
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelCourses = new GolfClashHelper.SelectablePanel();
            this.chkPar3s = new System.Windows.Forms.CheckBox();
            this.cboTours = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // panelCourses
            // 
            this.panelCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCourses.AutoScroll = true;
            this.panelCourses.Location = new System.Drawing.Point(10, 51);
            this.panelCourses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelCourses.Name = "panelCourses";
            this.panelCourses.Size = new System.Drawing.Size(679, 278);
            this.panelCourses.TabIndex = 1;
            this.panelCourses.TabStop = true;
            // 
            // chkPar3s
            // 
            this.chkPar3s.AutoSize = true;
            this.chkPar3s.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkPar3s.Location = new System.Drawing.Point(27, 9);
            this.chkPar3s.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkPar3s.Name = "chkPar3s";
            this.chkPar3s.Size = new System.Drawing.Size(152, 36);
            this.chkPar3s.TabIndex = 1;
            this.chkPar3s.Text = "Only Par 3s";
            this.chkPar3s.UseVisualStyleBackColor = true;
            this.chkPar3s.CheckedChanged += new System.EventHandler(this.CheckPar3s_CheckedChanged);
            // 
            // cboTours
            // 
            this.cboTours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTours.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboTours.FormattingEnabled = true;
            this.cboTours.Location = new System.Drawing.Point(386, 5);
            this.cboTours.Name = "cboTours";
            this.cboTours.Size = new System.Drawing.Size(302, 40);
            this.cboTours.TabIndex = 2;
            this.cboTours.SelectedValueChanged += new System.EventHandler(this.ComboTours_SelectedValueChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.cboTours);
            this.Controls.Add(this.chkPar3s);
            this.Controls.Add(this.panelCourses);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.Text = "Golf Clash Helper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SelectablePanel panelCourses;
        private System.Windows.Forms.CheckBox chkPar3s;
        private System.Windows.Forms.ComboBox cboTours;
    }
}

