namespace FloatingToolbars
{
    partial class ToolbarPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.overflowMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.overflowButton = new FloatingToolbars.ToolbarButton();
            this.Grip = new FloatingToolbars.ToolbarGrip();
            this.SuspendLayout();
            // 
            // overflowMenu
            // 
            this.overflowMenu.Name = "overflowMenu";
            this.overflowMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.overflowMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // overflowButton
            // 
            this.overflowButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.overflowButton.Icon = null;
            this.overflowButton.IconOffset = new System.Drawing.Point(1, 2);
            this.overflowButton.Location = new System.Drawing.Point(84, 0);
            this.overflowButton.MoveIconWhenPressed = true;
            this.overflowButton.Name = "overflowButton";
            this.overflowButton.Path = null;
            this.overflowButton.Size = new System.Drawing.Size(16, 22);
            this.overflowButton.TabIndex = 1;
            this.overflowButton.Visible = false;
            this.overflowButton.Click += new System.EventHandler(this.overflowButton_Click);
            // 
            // Grip
            // 
            this.Grip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Grip.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.Grip.Invisible = false;
            this.Grip.Location = new System.Drawing.Point(0, 0);
            this.Grip.Margin = new System.Windows.Forms.Padding(0);
            this.Grip.Name = "Grip";
            this.Grip.Size = new System.Drawing.Size(7, 22);
            this.Grip.TabIndex = 0;
            // 
            // ToolbarPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.overflowButton);
            this.Controls.Add(this.Grip);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ToolbarPanel";
            this.Size = new System.Drawing.Size(100, 22);
            this.ResumeLayout(false);

        }

        #endregion

        public ToolbarGrip Grip;
        private System.Windows.Forms.ToolTip toolTip;
        private ToolbarButton overflowButton;
        private System.Windows.Forms.ContextMenuStrip overflowMenu;
    }
}
