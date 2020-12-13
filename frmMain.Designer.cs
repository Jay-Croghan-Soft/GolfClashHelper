
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
            this.panelSettings = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.chkEarlyLoadImages = new System.Windows.Forms.CheckBox();
            this.lblSettingsTitle = new System.Windows.Forms.Label();
            this.cmdSettings = new System.Windows.Forms.Button();
            this.panelSettings.SuspendLayout();
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
            // panelSettings
            // 
            this.panelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSettings.Controls.Add(this.cmdCancel);
            this.panelSettings.Controls.Add(this.cmdSave);
            this.panelSettings.Controls.Add(this.chkEarlyLoadImages);
            this.panelSettings.Controls.Add(this.lblSettingsTitle);
            this.panelSettings.Location = new System.Drawing.Point(1, 1);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(703, 342);
            this.panelSettings.TabIndex = 3;
            this.panelSettings.Visible = false;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmdCancel.Location = new System.Drawing.Point(562, 279);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(125, 46);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmdSave.Location = new System.Drawing.Point(431, 279);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(125, 46);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "&Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // chkEarlyLoadImages
            // 
            this.chkEarlyLoadImages.AutoSize = true;
            this.chkEarlyLoadImages.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkEarlyLoadImages.Location = new System.Drawing.Point(11, 50);
            this.chkEarlyLoadImages.Name = "chkEarlyLoadImages";
            this.chkEarlyLoadImages.Size = new System.Drawing.Size(224, 36);
            this.chkEarlyLoadImages.TabIndex = 1;
            this.chkEarlyLoadImages.Tag = "EARLY_LOAD_IMAGES";
            this.chkEarlyLoadImages.Text = "Early Load Images";
            this.chkEarlyLoadImages.UseVisualStyleBackColor = true;
            // 
            // lblSettingsTitle
            // 
            this.lblSettingsTitle.AutoSize = true;
            this.lblSettingsTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSettingsTitle.Location = new System.Drawing.Point(11, 8);
            this.lblSettingsTitle.Name = "lblSettingsTitle";
            this.lblSettingsTitle.Size = new System.Drawing.Size(106, 32);
            this.lblSettingsTitle.TabIndex = 0;
            this.lblSettingsTitle.Text = "Settings";
            // 
            // cmdSettings
            // 
            this.cmdSettings.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmdSettings.Location = new System.Drawing.Point(200, 7);
            this.cmdSettings.Name = "cmdSettings";
            this.cmdSettings.Size = new System.Drawing.Size(137, 36);
            this.cmdSettings.TabIndex = 4;
            this.cmdSettings.Text = "Settings";
            this.cmdSettings.UseVisualStyleBackColor = true;
            this.cmdSettings.Click += new System.EventHandler(this.cmdSettings_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.cboTours);
            this.Controls.Add(this.chkPar3s);
            this.Controls.Add(this.panelCourses);
            this.Controls.Add(this.cmdSettings);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.Text = "Golf Clash Helper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SelectablePanel panelCourses;
        private System.Windows.Forms.CheckBox chkPar3s;
        private System.Windows.Forms.ComboBox cboTours;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label lblSettingsTitle;
        private System.Windows.Forms.CheckBox chkEarlyLoadImages;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdSettings;
    }
}

