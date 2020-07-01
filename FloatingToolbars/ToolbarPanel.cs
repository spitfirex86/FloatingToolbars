using FloatingToolbars.Properties;
using IWshRuntimeLibrary;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FloatingToolbars
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class ToolbarPanel : UserControl
    {
        private string _path;
        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                if (_path != null)
                {
                    directory = new DirectoryInfo(_path);
                }
            }
        }

        private List<ToolbarButton> Buttons { get; set; }
        private List<ToolbarButton> ButtonsInOverflow { get; set; }
        private DirectoryInfo directory;
        private Size buttonSize = new Size(22, 22);

        public ToolbarPanel()
        {
            InitializeComponent();

            DoubleBuffered = true;
            overflowButton.Icon = Resources.expand;
            Buttons = new List<ToolbarButton>();
            ButtonsInOverflow = new List<ToolbarButton>();
        }

        public void LoadFiles()
        {
            if (directory == null) return;

            foreach (FileInfo file in directory.EnumerateFiles())
            {
                if (file.Attributes.HasFlag(FileAttributes.Hidden)) continue;

                ToolbarButton button;
                if (file.Extension.ToLower() == ".lnk")
                {
                    WshShell shell = new WshShell();
                    IWshShortcut link = (IWshShortcut)shell.CreateShortcut(file.FullName);
                    string[] iconInfo = link.IconLocation.Split(new[] { ',' }, 2);

                    Icon targetIcon = NativeIcon.ExtractIcon(iconInfo[0], int.Parse(iconInfo[1]));
                    string name = file.Name.Substring(0, file.Name.Length - file.Extension.Length);

                    button = new ToolbarButton(name, file.FullName, targetIcon);
                }
                else
                {
                    button = new ToolbarButton(file.Name, file.FullName);
                }

                AddButton(button);
            }
        }

        public void AddButton(ToolbarButton button)
        {
            button.Size = buttonSize;
            toolTip.SetToolTip(button, button.Text);
            Controls.Add(button);

            if (CalculateAndSetPosition(button)) AddToButtons(button);
            else AddToOverflow(button);
        }

        public void SetSize(Size size)
        {
            Size = size;
            RecalculateButtonPositions();
        }

        // TODO: this is kinda slow, make it only move the icons that actually need to be moved
        public void RecalculateButtonPositions()
        {
            List<ToolbarButton> tempButtons = new List<ToolbarButton>(Buttons);
            tempButtons.AddRange(ButtonsInOverflow);

            Buttons = new List<ToolbarButton>();
            ButtonsInOverflow = new List<ToolbarButton>();
            overflowMenu.Items.Clear();

            foreach (ToolbarButton button in tempButtons)
            {
                if (CalculateAndSetPosition(button)) AddToButtons(button);
                else AddToOverflow(button);
            }

            overflowButton.Visible = ButtonsInOverflow.Count > 0;
        }

        private bool CalculateAndSetPosition(ToolbarButton button)
        {
            int count = Buttons.Count;
            Point potentialLocation = new Point(9 + 22 * count, 0);
            int maxX = overflowButton.Visible ? overflowButton.Left : ClientRectangle.Right - 1;

            if (potentialLocation.X + buttonSize.Width < maxX)
            {
                button.Visible = true;
                button.Location = potentialLocation;
                return true;
            }

            button.Visible = false;
            button.Location = Point.Empty;
            return false;
        }

        private void AddToButtons(ToolbarButton button)
        {
            Buttons.Add(button);
            //Controls.Add(button);
        }

        private void AddToOverflow(ToolbarButton button)
        {
            ButtonsInOverflow.Add(button);
            ToolStripItem item = new ToolStripMenuItem
            {
                Text = button.Text,
                Image = button.Icon.ToBitmap(),
                Tag = button,
            };
            item.Click += (sender, e) => button.OpenTarget();

            overflowMenu.Items.Add(item);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            //ControlPaint.DrawBorder3D(g, new Rectangle(5, 5, 3, ClientSize.Height - 10), Border3DStyle.RaisedInner);
        }

        private void overflowButton_Click(object sender, System.EventArgs e)
        {
            overflowMenu.Show(overflowButton, 0, overflowButton.Height);
        }
    }
}
