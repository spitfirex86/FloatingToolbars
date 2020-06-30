using System;
using System.Drawing;
using System.Windows.Forms;

namespace FloatingToolbars
{
    public partial class ToolbarButton : UserControl
    {
        public Icon Icon { get; set; }

        public ToolbarButton(Icon icon) : this()
        {
            Icon = new Icon(icon, SystemInformation.SmallIconSize);
        }

        public ToolbarButton()
        {
            InitializeComponent();

            bg = new Bitmap(2, 2);
            bg.SetPixel(0,0,SystemColors.Control);
            bg.SetPixel(0,1,SystemColors.ControlLightLight);
            bg.SetPixel(1,0,SystemColors.ControlLightLight);
            bg.SetPixel(1,1,SystemColors.Control);
        }

        private bool isPressed;
        private bool isMouseOver;

        private Bitmap bg;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                isPressed = true;
                BackgroundImage = bg;
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
                ControlPaint.DrawBorder3D(g, ClientRectangle, isPressed ? Border3DStyle.SunkenInner : Border3DStyle.RaisedInner);
            }

            if (Icon != null)
            {
                g.DrawIcon(Icon, new Rectangle(3, 3, 16, 16));
            }
        }
    }
}
