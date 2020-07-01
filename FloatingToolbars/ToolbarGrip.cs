using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FloatingToolbars
{
    public partial class ToolbarGrip : UserControl
    {
        [Category("Appearance")]
        public bool Invisible { get; set; }

        public ToolbarGrip()
        {
            InitializeComponent();
        }

        public event Action<Point, MouseEventArgs> GripDrag;
        public event Action<MouseEventArgs> GripDragBegin;
        public event Action<MouseEventArgs> GripDragEnd;

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Invisible) return;
            base.OnPaint(e);

            Graphics g = e.Graphics;
            ControlPaint.DrawBorder3D(g, new Rectangle(2, 2, ClientSize.Width - 4, ClientSize.Height - 4), Border3DStyle.RaisedInner);
        }

        private Point lastLocation;
        private bool mouseDown;

        protected virtual void OnGripDrag(Point clickLocation, MouseEventArgs e) => GripDrag?.Invoke(clickLocation, e);
        protected virtual void OnGripDragBegin(MouseEventArgs obj) => GripDragBegin?.Invoke(obj);
        protected virtual void OnGripDragEnd(MouseEventArgs obj) => GripDragEnd?.Invoke(obj);

        private void ToolbarGrip_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
            OnGripDragBegin(e);
        }

        private void ToolbarGrip_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                OnGripDrag(lastLocation, e);
            }
        }

        private void ToolbarGrip_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            OnGripDragEnd(e);
        }

        
    }
}
