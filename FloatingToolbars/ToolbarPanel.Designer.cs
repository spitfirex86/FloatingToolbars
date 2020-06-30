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
            this.Grip = new FloatingToolbars.ToolbarGrip();
            this.SuspendLayout();
            // 
            // Grip
            // 
            this.Grip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Grip.Location = new System.Drawing.Point(3, 3);
            this.Grip.Name = "Grip";
            this.Grip.Size = new System.Drawing.Size(7, 22);
            this.Grip.TabIndex = 0;
            // 
            // ToolbarPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Grip);
            this.Name = "ToolbarPanel";
            this.Size = new System.Drawing.Size(100, 28);
            this.ResumeLayout(false);

        }

        #endregion

        public ToolbarGrip Grip;
    }
}
