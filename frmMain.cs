// TODO Add Options page, such as Load Images at start or when needed, columns etc.

namespace GolfClashHelper
{
    using GolfClashHelper.Resources;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Resources;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using NLog;
    using System.Diagnostics;

    public partial class frmMain : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private List<PictureBox> formPictureBoxes = new List<PictureBox>();
        private List<Course> Courses = new List<Course>();
        private List<Tour> Tours = new List<Tour>();
        private int ImageWidth;
        private int ImageHeight;
        private readonly int ImageMargin = 50;
        private readonly int ImageColumns = 4;
        private frmSplash FormSplash;
        private int TotalHoles = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void SetImageDimensions()
        {
            ImageWidth = this.Width / ImageColumns - (ImageMargin * (ImageColumns - 2));
            ImageHeight = (int)(ImageWidth * 1.50);
        }

        private void LoadAllCourses()
        {
            Courses.Clear();
            Tours.Clear();
            cboTours.Items.Clear();

            // Load the main XML file with the tour information.
            string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string dataPath = Path.Combine(appPath, "res");
            string dataFile = dataPath + "\\content.xml";
            Contents contents = Contents.LoadXML(dataPath + "\\content.xml");
            Tours = contents.Tours.ToList();

            TotalHoles = Tours.Sum(t => t.CourseLinks.Length) * 9;

            foreach (Tour tour in Tours)
            {
                cboTours.Items.Add(tour.Name);

                foreach (Courselink course in tour.CourseLinks)
                {

                    string courseXML = Path.Combine(dataPath, course.Name) + "\\course.xml";

                    try
                    {
                        LoadCourse(courseXML);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex, Strings.COURSE_LOAD_ERROR);
                    }
                }
            }
        }

        private void UpdatePercentage(int total, int current)
        {
            if (FormSplash.progressBar1.Maximum != total)
            {
                FormSplash.progressBar1.Maximum = total;
            }

            Debug.WriteLine("Total {0} Current {1}", total, current);

            FormSplash.progressBar1.Value = current;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            FormSplash = new frmSplash();

            FormSplash.TopMost = true;
            FormSplash.Show();
            Application.DoEvents();

            try
            {
                Visible = false;

                WindowState = FormWindowState.Maximized;

                SetImageDimensions();

                LoadAllCourses();

                if (cboTours.Items.Count > 0)
                {
                    cboTours.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Strings.FORM_LOAD_ERROR);
                Logger.Error(ex, Strings.FORM_LOAD_ERROR);
            }
            finally
            {
                FormSplash?.Close();
                this.Visible = true;
                FormSplash = null;
            }
        }


        private void AddImages(bool onlyPar3s = false)
        {
            RemoveAllChildControls(this.panelCourses);
            formPictureBoxes.Clear();

            if (Tours.Count == 0)
            {
                return;
            }

            int index = 1;
            int x = 0;
            int y = 0;
            this.SuspendLayout();
            y = 0;
            x = ImageMargin;

            Tour selectedTour = Tours.Where(t => t.Name == cboTours.SelectedItem.ToString()).First();

            foreach (Course course in Courses.Where(c => selectedTour.CourseLinks.Any(l => l.Name == c.Name)))
            {
                var holes = course.Holes.Where(h => (onlyPar3s ? h.Par == 3 : h.Par > 0));
                Console.Out.WriteLine("Count: {0}", holes.Count());
                foreach (Hole hole in holes)
                {
                    PictureBox pic = AddHoleImage(course.Name, hole, x, y);
                    pic.Image = Image.FromFile(hole.HoleImage);

                    if (index == ImageColumns)
                    {
                        x = ImageMargin;
                        y += ImageMargin + ImageHeight;
                        index = 1;
                    }
                    else
                    {
                        x = ImageWidth * index + (ImageMargin * (index + 1));
                        index++;
                    }
                }
            }

            this.ResumeLayout(false);
        }

        void LoadCourse(string courseFile)
        {
            Course course = Course.LoadXML(courseFile);
            course.Folder = Path.GetDirectoryName(courseFile);

            int currentHole = 0;
            foreach (Hole hole in course.Holes)
            {
                currentHole++;

                UpdatePercentage(TotalHoles, (Courses.Count * 9) + currentHole);

                string imagePath = Path.Combine(course.Folder, hole.ID.ToString()) + ".png";

                if (File.Exists(imagePath))
                {
                    hole.HoleImage = imagePath; //Image.FromFile(imagePath);
                }
                else
                {
                    hole.HoleImage = "X"; //Images.no_image;
                }


                imagePath = Path.Combine(course.Folder, hole.ID.ToString()) + "_guide.png";
                if (File.Exists(imagePath))
                {
                    hole.GuideImage = imagePath; // Image.FromFile(imagePath);
                }
                else
                {
                    hole.GuideImage = "X"; // Images.no_image;
                }

                hole.CourseName = course.Name;
            }

            Courses.Add(course);
        }
        private static void RemoveAllChildControls(Control ctrl)
        {
            while (ctrl.Controls.Count > 0)
            {
                if (ctrl.Controls[0].Controls?.Count > 0)
                {
                    RemoveAllChildControls(ctrl.Controls[0]);
                }
                ctrl.Controls[0].Dispose();
            }
        }

        private void SaveCommentForHole(TextBox textBox)
        {
            Hole hole = (textBox.Tag as Hole);
            if (textBox.Text.Length > 0)
            {
                hole.Comment = textBox.Text;
                Course course = Courses.Find(t => t.Holes.Contains(hole));
                course.SaveXML(course.Folder + @"\course.xml");
            }
        }

        public void guideBox_Clicked(object sender, EventArgs e)
        {
            TextBox textBox = ((sender as PictureBox).Tag as TextBox);
            SaveCommentForHole(textBox);

            RemoveAllChildControls((sender as PictureBox));
            (sender as PictureBox).Dispose();
            panelCourses.Visible = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys[] acceptableKeys = { Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.PageDown, Keys.PageUp, Keys.Home, Keys.End };
            Control[] acceptableControls = { chkPar3s };

            if ((this.ActiveControl == null || acceptableControls.Contains(this.ActiveControl)) && (acceptableKeys.Contains(keyData)))
            {
                return panelCourses.ProcessCmdKeyPublic(ref msg, keyData);
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        public void pictureBox_Clicked(object sender, EventArgs e)
        {
            Hole hole = ((sender as PictureBox).Tag as Hole);

            PictureBox tmpPicture = new PictureBox();
            tmpPicture = new PictureBox();
            ((ISupportInitialize)(tmpPicture)).BeginInit();
            this.Controls.Add(tmpPicture);
            tmpPicture.Location = new System.Drawing.Point(ImageMargin, ImageMargin);
            tmpPicture.Name = string.Format("pictureBox_guide_{0}_{1}", hole.CourseName.Replace(" ", "_"), hole.ID);
            tmpPicture.Size = new System.Drawing.Size((this.Width - ImageMargin * 2), this.Height - (ImageMargin * 2));
            tmpPicture.TabIndex = 0;
            tmpPicture.BorderStyle = BorderStyle.FixedSingle;
            tmpPicture.SizeMode = PictureBoxSizeMode.Zoom;
            tmpPicture.TabStop = false;
            tmpPicture.Image = Image.FromFile(hole.GuideImage);
            tmpPicture.Click += new System.EventHandler(this.guideBox_Clicked);
            AddCommentButton(tmpPicture, hole);
            panelCourses.Visible = false;
            tmpPicture.BringToFront();
        }

        public void AddCommentButton(PictureBox picImage, Hole hole)
        {
            TextBox tmpTextBox = new TextBox();

            picImage.Controls.Add(tmpTextBox);
            tmpTextBox.Location = new System.Drawing.Point(50, picImage.Height / 2);
            tmpTextBox.Name = "txtBox_" + picImage.Name;
            tmpTextBox.Visible = false;
            tmpTextBox.Size = new System.Drawing.Size(picImage.Width - 100, picImage.Height / 2 - 100);
            tmpTextBox.TabIndex = 0;
            tmpTextBox.Font = new System.Drawing.Font("Calibri", 20, FontStyle.Bold, GraphicsUnit.Point);
            tmpTextBox.Multiline = true;
            tmpTextBox.ScrollBars = ScrollBars.Both;
            tmpTextBox.Tag = hole;
            tmpTextBox.Disposed += TmpTextBox_Disposed;
            if (hole.Comment != null && hole.Comment.ToString().Length > 0)
            {
                tmpTextBox.Text = hole.Comment;
            }

            picImage.Tag = tmpTextBox;

            Button tmpButton = new Button();
            picImage.Controls.Add(tmpButton);
            tmpButton.Size = new System.Drawing.Size(150, 30);
            tmpButton.Location = new System.Drawing.Point(picImage.Width - tmpButton.Width - 50, 50);
            tmpButton.Name = "cmd" + picImage.Name;
            tmpButton.TabIndex = 0;
            tmpButton.Tag = tmpTextBox;
            tmpButton.Text = "Comment";
            tmpButton.Visible = true;
            tmpButton.UseVisualStyleBackColor = true;
            tmpButton.Click += new System.EventHandler(this.CommentButtonClicked);
        }

        private void TmpTextBox_Disposed(object sender, EventArgs e)
        {
            SaveCommentForHole((sender as TextBox));
        }

        public void CommentButtonClicked(object sender, EventArgs e)
        {
            TextBox textBox = ((sender as Button).Tag as TextBox);
            textBox.Visible = !textBox.Visible;
        }

        PictureBox AddHoleImage(string course, Hole hole, int x, int y)
        {
            PictureBox tmpPicture = new PictureBox();


            tmpPicture = new PictureBox();
            ((ISupportInitialize)(tmpPicture)).BeginInit();
            tmpPicture.Location = new System.Drawing.Point(x, y);
            tmpPicture.Name = string.Format("pictureBox_{0}_{1}", course.Replace(" ", "_"), hole.ID);
            tmpPicture.Size = new System.Drawing.Size(ImageWidth, ImageHeight);
            tmpPicture.TabIndex = 0;
            tmpPicture.BorderStyle = BorderStyle.FixedSingle;
            tmpPicture.SizeMode = PictureBoxSizeMode.Zoom;
            tmpPicture.TabStop = false;
            tmpPicture.Tag = hole;
            tmpPicture.Click += new System.EventHandler(this.pictureBox_Clicked);

            this.panelCourses.Controls.Add(tmpPicture);
            formPictureBoxes.Add(tmpPicture);

            BorderLabel tmpName = new BorderLabel();

            tmpPicture.Controls.Add(tmpName);
            tmpName.AutoSize = false;
            tmpName.Location = new System.Drawing.Point(0, 0);
            tmpName.Name = string.Format("label_name_{0}_{1}", course, hole.ID);
            tmpName.Size = new System.Drawing.Size(tmpPicture.Width, (tmpPicture.Height / 15));
            tmpName.Font = new System.Drawing.Font("Segoe UI", (tmpPicture.Height / 10F) / 3F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tmpName.ForeColor = Color.Black;
            tmpName.BackColor = System.Drawing.Color.Transparent;
            tmpName.TabIndex = 0;
            tmpName.BorderColor = Color.White;
            tmpName.BorderSize = 1;
            tmpName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            tmpName.Text = string.Format("{0} {1}", course, hole.ID);

            BorderLabel tmpElevation = new BorderLabel();

            tmpPicture.Controls.Add(tmpElevation);
            tmpElevation.AutoSize = false;
            tmpElevation.Name = string.Format("label_name_{0}_{1}", course, hole.ID);

            tmpElevation.Size = new System.Drawing.Size(tmpPicture.Width, (tmpPicture.Height / 10));

            tmpElevation.Font = new System.Drawing.Font("Segoe UI", (tmpPicture.Height / 10F) / 2.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tmpElevation.ForeColor = Color.Black;
            tmpElevation.BackColor = System.Drawing.Color.Transparent;
            tmpElevation.TabIndex = 0;
            tmpElevation.BorderColor = Color.White;
            tmpElevation.BorderSize = 2;
            tmpElevation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            tmpElevation.Location = new System.Drawing.Point(0, (tmpPicture.Height - tmpElevation.Height) - 15);
            if (hole.Shot2 == -1)
            {
                tmpElevation.Text = string.Format("{0}%", hole.Shot1);
            }
            else if (hole.Shot3 == -1)
            {
                tmpElevation.Text = string.Format("{0}% - {1}%", hole.Shot1, hole.Shot2);
            }
            else
            {
                tmpElevation.Text = string.Format("{0}% - {1}% - {2}%", hole.Shot1, hole.Shot2, hole.Shot3);
            }

            return tmpPicture;
        }

        private void CheckPar3s_CheckedChanged(object sender, EventArgs e)
        {
            RemoveGuideImage();
            AddImages(chkPar3s.Checked);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                SetImageDimensions();
                AddImages(chkPar3s.Checked);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Course course in Courses)
            {
                course.SaveXML(course.Folder + @"\course.xml");
            }
        }

        private void ComboTours_SelectedValueChanged(object sender, EventArgs e)
        {
            RemoveGuideImage();
            AddImages(chkPar3s.Checked);
        }

        private void RemoveGuideImage()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Name.StartsWith("pictureBox_guide_"))
                {
                    this.guideBox_Clicked(ctrl, null);
                }
            }
        }
    }
}
