namespace FickleStripper
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sequenceToolstripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSequenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topologyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sequenceToolstripMenuItem,
            this.topologyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(821, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sequenceToolstripMenuItem
            // 
            this.sequenceToolstripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSequenceToolStripMenuItem});
            this.sequenceToolstripMenuItem.Name = "sequenceToolstripMenuItem";
            this.sequenceToolstripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.sequenceToolstripMenuItem.Text = "&Sequence";
            // 
            // addSequenceToolStripMenuItem
            // 
            this.addSequenceToolStripMenuItem.Name = "addSequenceToolStripMenuItem";
            this.addSequenceToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.addSequenceToolStripMenuItem.Text = "Add &Sequence";
            // 
            // topologyToolStripMenuItem
            // 
            this.topologyToolStripMenuItem.Name = "topologyToolStripMenuItem";
            this.topologyToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.topologyToolStripMenuItem.Text = "&Topology";
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Location = new System.Drawing.Point(12, 27);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(667, 523);
            this.tcMain.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 562);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Fickle Stripper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sequenceToolstripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSequenceToolStripMenuItem;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.ToolStripMenuItem topologyToolStripMenuItem;
    }
}

