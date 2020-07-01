using FloatingToolbars.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FloatingToolbars
{
    public partial class Rebar : Form
    {
        public Rebar()
        {
            InitializeComponent();
            Icon = Resources.FT;

            Toolbar.Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"Microsoft\Internet Explorer\Quick Launch");
            Toolbar.LoadFiles();

            // TODO: move grip to rebar
            // TODO: use toolbar grip to move toolbars on rebar
            // TODO: multiple toolbars
            // TODO: grip z-order?
            Toolbar.Grip.GripDrag += (clickLocation, e) =>
            {
                int px = Location.X + e.X - clickLocation.X;
                int py = Location.Y + e.Y - clickLocation.Y;
                Location = new Point(px, py);
                Update();
            };
            Toolbar.Grip.GripDragEnd += e =>
            {
                Screen scn = Screen.FromPoint(Location);
                if (DoSnap(Left, scn.WorkingArea.Left)) Left = scn.WorkingArea.Left;
                if (DoSnap(Top, scn.WorkingArea.Top)) Top = scn.WorkingArea.Top;
                if (DoSnap(Right, scn.WorkingArea.Right)) Left = scn.WorkingArea.Right - Width;
                if (DoSnap(Bottom, scn.WorkingArea.Bottom)) Top = scn.WorkingArea.Bottom - Height;
            };

            sizeGrip.GripDrag += (clickLocation, e) =>
            {
                int width = Width + e.X - clickLocation.X;
                Width = width;
                Invalidate();
                Toolbar.RecalculateButtonPositions();
            };

            ContextMenuStrip = contextMenu;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            ControlPaint.DrawBorder3D(g, ClientRectangle, Border3DStyle.Raised);
        }

        private void toolbarPanel1_Load(object sender, EventArgs e)
        {
            Size = new Size(160, 28);
            Toolbar.RecalculateButtonPositions();
        }

        private void Rebar_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenu.Show();
            }
        }

        private const int SnapDist = 12;
        private bool DoSnap(int pos, int edge)
        {
            int delta = pos - edge;
            if (edge > 0) delta = -delta;
            return delta < 0 || delta <= SnapDist;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void alwaysOntopToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = alwaysOntopToolStripMenuItem.Checked;
        }
    }
}
