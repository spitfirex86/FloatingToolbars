namespace FloatingToolbars
{
    partial class Rebar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOntopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Toolbar = new FloatingToolbars.ToolbarPanel();
            this.sizeGrip = new FloatingToolbars.ToolbarGrip();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // alwaysOntopToolStripMenuItem
            // 
            this.alwaysOntopToolStripMenuItem.Checked = true;
            this.alwaysOntopToolStripMenuItem.CheckOnClick = true;
            this.alwaysOntopToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alwaysOntopToolStripMenuItem.Name = "alwaysOntopToolStripMenuItem";
            this.alwaysOntopToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.alwaysOntopToolStripMenuItem.Text = "Always on &top";
            this.alwaysOntopToolStripMenuItem.CheckedChanged += new System.EventHandler(this.alwaysOntopToolStripMenuItem_CheckedChanged);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alwaysOntopToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenu.Size = new System.Drawing.Size(150, 54);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // Toolbar
            // 
            this.Toolbar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Toolbar.BackColor = System.Drawing.Color.Transparent;
            this.Toolbar.Location = new System.Drawing.Point(3, 3);
            this.Toolbar.Margin = new System.Windows.Forms.Padding(0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Path = null;
            this.Toolbar.Size = new System.Drawing.Size(94, 22);
            this.Toolbar.TabIndex = 0;
            this.Toolbar.Load += new System.EventHandler(this.toolbarPanel1_Load);
            // 
            // sizeGrip
            // 
            this.sizeGrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeGrip.BackColor = System.Drawing.Color.Transparent;
            this.sizeGrip.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.sizeGrip.Invisible = true;
            this.sizeGrip.Location = new System.Drawing.Point(97, 3);
            this.sizeGrip.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.sizeGrip.Name = "sizeGrip";
            this.sizeGrip.Size = new System.Drawing.Size(3, 22);
            this.sizeGrip.TabIndex = 2;
            // 
            // Rebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(100, 28);
            this.ControlBox = false;
            this.Controls.Add(this.Toolbar);
            this.Controls.Add(this.sizeGrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(32, 28);
            this.Name = "Rebar";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rebar";
            this.TopMost = true;
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Rebar_MouseClick);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ToolbarPanel Toolbar;
        private ToolbarGrip sizeGrip;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOntopToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

