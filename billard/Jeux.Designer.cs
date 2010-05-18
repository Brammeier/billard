namespace billard
{
    partial class Jeux
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
            this.SuspendLayout();
            // 
            // Jeux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Name = "Jeux";
            this.Size = new System.Drawing.Size(368, 191);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Jeux_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Jeux_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Jeux_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
