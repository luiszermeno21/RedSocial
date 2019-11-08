namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.iniciodeSesion1 = new WindowsFormsApp1.UserControls.IniciodeSesion();
            this.paginaInicio1 = new WindowsFormsApp1.UserControls.PaginaInicio();
            this.menuRegistrar1 = new WindowsFormsApp1.UserControls.MenuRegistrar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ImageLocation = "C:\\Users\\Luis Zermeño\\source\\repos\\RedSocial\\WindowsFormsApp1\\iphones.png";
            this.pictureBox1.Location = new System.Drawing.Point(358, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 470);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.ImageLocation = "C:\\Users\\Luis Zermeño\\source\\repos\\RedSocial\\WindowsFormsApp1\\tiendasapp.png";
            this.pictureBox2.Location = new System.Drawing.Point(725, 576);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(223, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.ImageLocation = "C:\\Users\\Luis Zermeño\\source\\repos\\RedSocial\\WindowsFormsApp1\\letras.png";
            this.pictureBox3.Location = new System.Drawing.Point(240, 681);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(814, 13);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // iniciodeSesion1
            // 
            this.iniciodeSesion1.Location = new System.Drawing.Point(34, 156);
            this.iniciodeSesion1.Name = "iniciodeSesion1";
            this.iniciodeSesion1.Size = new System.Drawing.Size(280, 304);
            this.iniciodeSesion1.TabIndex = 5;
            // 
            // paginaInicio1
            // 
            this.paginaInicio1.BackColor = System.Drawing.Color.White;
            this.paginaInicio1.Location = new System.Drawing.Point(691, 487);
            this.paginaInicio1.Name = "paginaInicio1";
            this.paginaInicio1.Size = new System.Drawing.Size(293, 51);
            this.paginaInicio1.TabIndex = 4;
            // 
            // menuRegistrar1
            // 
            this.menuRegistrar1.BackColor = System.Drawing.Color.White;
            this.menuRegistrar1.Location = new System.Drawing.Point(691, 11);
            this.menuRegistrar1.Name = "menuRegistrar1";
            this.menuRegistrar1.Size = new System.Drawing.Size(293, 470);
            this.menuRegistrar1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1350, 749);
            this.Controls.Add(this.menuRegistrar1);
            this.Controls.Add(this.iniciodeSesion1);
            this.Controls.Add(this.paginaInicio1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(1366, 788);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private UserControls.PaginaInicio paginaInicio1;
        private UserControls.IniciodeSesion iniciodeSesion1;
        private UserControls.MenuRegistrar menuRegistrar1;
    }
}

