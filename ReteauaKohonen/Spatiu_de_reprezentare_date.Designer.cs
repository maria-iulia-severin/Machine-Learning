namespace ReteauaKohonen
{
    partial class Spatiu_de_reprezentare_date
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
            this.labelEra = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labelEra
            // 
            this.labelEra.AutoSize = true;
            this.labelEra.Location = new System.Drawing.Point(781, 9);
            this.labelEra.Name = "labelEra";
            this.labelEra.Size = new System.Drawing.Size(0, 17);
            this.labelEra.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 664);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // Spatiu_de_reprezentare_date
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 663);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelEra);
            this.Name = "Spatiu_de_reprezentare_date";
            this.Text = "Harti Kohonen";
            this.Click += new System.EventHandler(this.Spatiu_de_reprezentare_date_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEra;
        private System.Windows.Forms.Panel panel1;
    }
}

