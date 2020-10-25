namespace GenerareDateAntrenament_Laborator_1
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
            this.SuspendLayout();
            // 
            // Spatiu_de_reprezentare_date
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 663);
            this.Name = "Spatiu_de_reprezentare_date";
            this.Text = "Generare date de antrenament";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

