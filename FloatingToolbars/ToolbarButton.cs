using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloatingToolbars
{
    public partial class ToolbarButton : UserControl
    {
        private static Bitmap PressedBg;

        static ToolbarButton()
        {
            PressedBg = new Bitmap(2, 2);
            PressedBg.SetPixel(0,0,SystemColors.Control);
            PressedBg.SetPixel(0,1,SystemColors.ControlLightLight);
            PressedBg.SetPixel(1,0,SystemColors.ControlLightLight);
            PressedBg.SetPixel(1,1,SystemColors.Control);
        }

        [Category("Appearance"), Description("The position of the icon.")]  
        public Point IconOffset { get; set; } = new Point(3, 3);

        [Category("Appearance"), Description("Specifies if the icon should move down and to the right when the button is pressed.")]
        public bool MoveIconWhenPressed { get; set; } = true;

        public Icon Icon { get; set; }
        public string Path { get; set; }

        public ToolbarButton(string name, string path, Icon icon) : this()
        {
            Text = name;
            Path = path;
            Icon = new Icon(icon, SystemInformation.SmallIconSize);
        }

        public ToolbarButton(string name, string path) : this()
        {
            Text = name;
            Path = path;
            Icon = NativeIcon.GetSmallIcon(path);
        }

        public ToolbarButton()
        {
            InitializeComponent();
        }

        private bool isPressed;
        private bool isMouseOver;

        public void OpenTarget()
        {
            if (!string.IsNullOrEmpty(Path))
            {
                Task.Run(() => Process.Start(Path));
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            OpenTarget();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                isPressed = true;
                BackgroundImage = PressedBg;
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isPressed = false;
            BackgroundImage = null;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isMouseOver = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isMouseOver = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            if (isMouseOver)
            {
                Border3DStyle borderStyle = isPressed ? Border3DStyle.SunkenInner : Border3DStyle.RaisedInner;
                ControlPaint.DrawBorder3D(g, ClientRectangle, borderStyle);
            }

            if (Icon != null)
            {
                // g.DrawIcon(Icon, new Rectangle(3, 3, 16, 16));
                Point iconOffset = (MoveIconWhenPressed && isPressed) ? new Point(IconOffset.X+1, IconOffset.Y+1) : IconOffset;
                g.DrawIcon(Icon, new Rectangle(iconOffset, SystemInformation.SmallIconSize));
            }
        }
    }
}
