namespace CoffeeOtomasyonForm
{
    partial class UcMasalar
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
            this.flowLayoutPanelMasalar = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMasalar
            // 
            this.flowLayoutPanelMasalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMasalar.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMasalar.Name = "flowLayoutPanelMasalar";
            this.flowLayoutPanelMasalar.Size = new System.Drawing.Size(1280, 688);
            this.flowLayoutPanelMasalar.TabIndex = 3;
          
            // 
            // UcMasalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanelMasalar);
            this.Name = "UcMasalar";
            this.Size = new System.Drawing.Size(1280, 688);
            this.Load += new System.EventHandler(this.UcMasalar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMasalar;
    }
}
