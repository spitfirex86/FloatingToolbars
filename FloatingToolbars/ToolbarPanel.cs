using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace FloatingToolbars
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class ToolbarPanel : UserControl
    {
        public ToolbarPanel()
        {
            InitializeComponent();
            Buttons = new List<ToolbarButton>();
        }

        public List<ToolbarButton> Buttons { get; private set; }

        public void AddButton(ToolbarButton button)
        {
            int count = Buttons.Count;
            button.Location = new Point(12 + 22 * count, 3);
            button.Size = new Size(22, 22);
            Buttons.Add(button);
            Controls.Add(button);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            ControlPaint.DrawBorder3D(g, ClientRectangle, Border3DStyle.Raised);
            ControlPaint.DrawBorder3D(g, new Rectangle(5, 5, 3, ClientSize.Height - 10), Border3DStyle.RaisedInner);
        }
    }
}
