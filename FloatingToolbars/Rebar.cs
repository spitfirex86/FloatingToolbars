using FloatingToolbars.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FloatingToolbars
{
    public partial class Rebar : Form
    {
        public Rebar()
        {
            InitializeComponent();

            Toolbar.Grip.GripDrag += (clickLocation, e) =>
            {
                Location = new Point((Location.X - clickLocation.X) + e.X, (Location.Y - clickLocation.Y) + e.Y);
                Update();
            };
            Toolbar.Grip.GripDragEnd += e =>
            {
                Screen scn = Screen.FromPoint(Location);
                //if (DoSnap(Left, scn.WorkingArea.Left)) Left = scn.WorkingArea.Left;
                if (DoSnap(Top, scn.WorkingArea.Top)) Top = scn.WorkingArea.Top;
                //if (DoSnap(scn.WorkingArea.Right, Right)) Left = scn.WorkingArea.Right - Width;
                if (DoSnap(scn.WorkingArea.Bottom, Bottom)) Top = scn.WorkingArea.Bottom - Height;
            };

            ToolbarButton tb1 = new ToolbarButton(Resources.file);
            ToolbarButton tb2 = new ToolbarButton(Resources.dir);

            ContextMenuStrip = contextMenu;
            toolTip.SetToolTip(tb1, "Example Text");

            Toolbar.AddButton(tb1);
            Toolbar.AddButton(tb2);
        }

        private void toolbarPanel1_Load(object sender, EventArgs e)
        {
            Size = new Size(160, 28);
        }

        private void Rebar_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenu.Show();
            }
        }

        private const int SnapDist = 20;
        private bool DoSnap(int pos, int edge)
        {
            int delta = pos - edge;
            return delta > 0 && delta <= SnapDist;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
