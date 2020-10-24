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
            this.zeroy = new System.Windows.Forms.Label();
            this.zerox = new System.Windows.Forms.Label();
            this.treisutey = new System.Windows.Forms.Label();
            this.treisutex = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // zeroy
            // 
            this.zeroy.AutoSize = true;
            this.zeroy.BackColor = System.Drawing.SystemColors.WindowText;
            this.zeroy.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.zeroy.Location = new System.Drawing.Point(231, 427);
            this.zeroy.Name = "zeroy";
            this.zeroy.Size = new System.Drawing.Size(16, 17);
            this.zeroy.TabIndex = 0;
            this.zeroy.Text = "0";
            // 
            // zerox
            // 
            this.zerox.AutoSize = true;
            this.zerox.BackColor = System.Drawing.SystemColors.WindowText;
            this.zerox.ForeColor = System.Drawing.SystemColors.Window;
            this.zerox.Location = new System.Drawing.Point(12, 214);
            this.zerox.Name = "zerox";
            this.zerox.Size = new System.Drawing.Size(16, 17);
            this.zerox.TabIndex = 1;
            this.zerox.Text = "0";
            // 
            // treisutey
            // 
            this.treisutey.AutoSize = true;
            this.treisutey.BackColor = System.Drawing.SystemColors.WindowText;
            this.treisutey.ForeColor = System.Drawing.Color.White;
            this.treisutey.Location = new System.Drawing.Point(-4, 30);
            this.treisutey.Name = "treisutey";
            this.treisutey.Size = new System.Drawing.Size(32, 17);
            this.treisutey.TabIndex = 2;
            this.treisutey.Text = "300";
            // 
            // treisutex
            // 
            this.treisutex.AutoSize = true;
            this.treisutex.BackColor = System.Drawing.SystemColors.Desktop;
            this.treisutex.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.treisutex.Location = new System.Drawing.Point(411, 427);
            this.treisutex.Name = "treisutex";
            this.treisutex.Size = new System.Drawing.Size(32, 17);
            this.treisutex.TabIndex = 3;
            this.treisutex.Text = "300";
            // 
            // Spatiu_de_reprezentare_date
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.treisutex);
            this.Controls.Add(this.treisutey);
            this.Controls.Add(this.zerox);
            this.Controls.Add(this.zeroy);
            this.Name = "Spatiu_de_reprezentare_date";
            this.Text = "Generare date de antrenament";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label zeroy;
        private System.Windows.Forms.Label zerox;
        private System.Windows.Forms.Label treisutey;
        private System.Windows.Forms.Label treisutex;
    }
}

