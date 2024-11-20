namespace EmployeeManagementSystem
{
    partial class QuemSomos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuemSomos));
            this.lblCorpo = new System.Windows.Forms.Label();
            this.picBanner = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVoltar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCorpo
            // 
            this.lblCorpo.AutoSize = true;
            this.lblCorpo.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblCorpo.Location = new System.Drawing.Point(12, 55);
            this.lblCorpo.Name = "lblCorpo";
            this.lblCorpo.Size = new System.Drawing.Size(420, 299);
            this.lblCorpo.TabIndex = 0;
            this.lblCorpo.Text = resources.GetString("lblCorpo.Text");
            // 
            // picBanner
            // 
            this.picBanner.Image = global::CultivaTechDesktop.Properties.Resources.IMG_20240525_WA00201;
            this.picBanner.Location = new System.Drawing.Point(439, -2);
            this.picBanner.Margin = new System.Windows.Forms.Padding(4);
            this.picBanner.Name = "picBanner";
            this.picBanner.Size = new System.Drawing.Size(375, 391);
            this.picBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBanner.TabIndex = 4;
            this.picBanner.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(47, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(152, 24);
            this.lblTitulo.TabIndex = 9;
            this.lblTitulo.Text = "Quem Somos?";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Image = global::CultivaTechDesktop.Properties.Resources.voltar;
            this.btnVoltar.Location = new System.Drawing.Point(12, 12);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(29, 31);
            this.btnVoltar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnVoltar.TabIndex = 10;
            this.btnVoltar.TabStop = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // QuemSomos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 386);
            this.ControlBox = false;
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.picBanner);
            this.Controls.Add(this.lblCorpo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuemSomos";
            this.Text = "QuemSomos";
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVoltar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCorpo;
        private System.Windows.Forms.PictureBox picBanner;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox btnVoltar;
    }
}