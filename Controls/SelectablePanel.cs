namespace GolfClashHelper
{
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;
    using System.Collections.Generic;

    class SelectablePanel : Panel
    {
        const int ScrollSmallChange = 10;
        public SelectablePanel()
        {
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.UserMouse, true);
            TabStop = true;
        }

        public bool ProcessCmdKeyPublic(ref Message msg, Keys keyData)
        {
            return ProcessCmdKey(ref msg, keyData);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            /*
            if (!Focused)
                return base.ProcessCmdKey(ref msg, keyData);
            */

            this.Parent.SuspendLayout();

            PictureBox picBox;
            int picScroll;
            try
            {
                picBox = (this.Controls.Cast<Control>().Where(x => x.GetType() == typeof(PictureBox)).FirstOrDefault() as PictureBox); //this.Controls.OfType<PictureBox>();
                picScroll = picBox.Height + 50;
            }
            catch
            {
                this.Parent.ResumeLayout(false);
                return base.ProcessCmdKey(ref msg, keyData);
            }

            var p = AutoScrollPosition;
            switch (keyData)
            {
                case Keys.Left:
                    AutoScrollPosition = new Point(-ScrollSmallChange - p.X, -p.Y);
                    this.Parent.ResumeLayout(false);
                    return true;
                case Keys.Right:
                    AutoScrollPosition = new Point(ScrollSmallChange - p.X, -p.Y);
                    this.Parent.ResumeLayout(false);
                    return true;
                case Keys.Up:
                    AutoScrollPosition = new Point(-p.X, -ScrollSmallChange - p.Y);
                    this.Parent.ResumeLayout(false);
                    return true;
                case Keys.Down:
                    AutoScrollPosition = new Point(-p.X, ScrollSmallChange - p.Y);
                    this.Parent.ResumeLayout(false);
                    return true;
                case Keys.PageDown:
                    //AutoScrollPosition = new Point(-p.X, this.Height - p.Y);
                    AutoScrollPosition = new Point(-p.X, picScroll - p.Y);
                    this.Parent.ResumeLayout(false);
                    return true;
                case Keys.PageUp:
                    //AutoScrollPosition = new Point(-p.X, -this.Height - p.Y);
                    AutoScrollPosition = new Point(-p.X, -picScroll - p.Y);
                    this.Parent.ResumeLayout(false);
                    return true;
                case Keys.Home:
                    AutoScrollPosition = new Point(0, 0);
                    this.Parent.ResumeLayout(false);
                    return true;
                case Keys.End:
                    AutoScrollPosition = new Point(0, this.VerticalScroll.Maximum);
                    this.Parent.ResumeLayout(false);
                    return true;
                default:
                    this.Parent.ResumeLayout(false);
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
    }
}
