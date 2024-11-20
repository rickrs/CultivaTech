namespace CultivaTechNovo
{
    partial class TelaPagamento
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
            this.labelProduto = new System.Windows.Forms.Label();
            this.labelPreco = new System.Windows.Forms.Label();
            this.labelQuantidade = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.btnPix = new System.Windows.Forms.Button();
            this.btnCartao = new System.Windows.Forms.Button();
            this.panelPix = new System.Windows.Forms.Panel();
            this.labelPixInfo = new System.Windows.Forms.Label();
            this.panelCard = new System.Windows.Forms.Panel();
            this.labelCardNumber = new System.Windows.Forms.Label();
            this.labelCardHolder = new System.Windows.Forms.Label();
            this.labelExpiryDate = new System.Windows.Forms.Label();
            this.labelCvv = new System.Windows.Forms.Label();
            this.textBoxCardNumber = new System.Windows.Forms.TextBox();
            this.textBoxCardHolder = new System.Windows.Forms.TextBox();
            this.textBoxExpiryDate = new System.Windows.Forms.TextBox();
            this.textBoxCvv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnConfirmarCard = new System.Windows.Forms.Button();
            this.btnConfirmarPix = new System.Windows.Forms.Button();
            this.panelPix.SuspendLayout();
            this.panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVoltar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelProduto
            // 
            this.labelProduto.AutoSize = true;
            this.labelProduto.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProduto.Location = new System.Drawing.Point(42, 96);
            this.labelProduto.Name = "labelProduto";
            this.labelProduto.Size = new System.Drawing.Size(89, 22);
            this.labelProduto.TabIndex = 0;
            this.labelProduto.Text = "Produto:";
            this.labelProduto.Click += new System.EventHandler(this.labelProduto_Click);
            // 
            // labelPreco
            // 
            this.labelPreco.AutoSize = true;
            this.labelPreco.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreco.Location = new System.Drawing.Point(42, 139);
            this.labelPreco.Name = "labelPreco";
            this.labelPreco.Size = new System.Drawing.Size(146, 22);
            this.labelPreco.TabIndex = 1;
            this.labelPreco.Text = "Preço Unitário:";
            // 
            // labelQuantidade
            // 
            this.labelQuantidade.AutoSize = true;
            this.labelQuantidade.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuantidade.Location = new System.Drawing.Point(42, 183);
            this.labelQuantidade.Name = "labelQuantidade";
            this.labelQuantidade.Size = new System.Drawing.Size(122, 22);
            this.labelQuantidade.TabIndex = 2;
            this.labelQuantidade.Text = "Quantidade:";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(42, 228);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(62, 22);
            this.labelTotal.TabIndex = 3;
            this.labelTotal.Text = "Total:";
            // 
            // btnPix
            // 
            this.btnPix.BackColor = System.Drawing.Color.Lime;
            this.btnPix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPix.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPix.ForeColor = System.Drawing.Color.White;
            this.btnPix.Location = new System.Drawing.Point(42, 322);
            this.btnPix.Name = "btnPix";
            this.btnPix.Size = new System.Drawing.Size(178, 41);
            this.btnPix.TabIndex = 4;
            this.btnPix.Text = "Pagar com PIX";
            this.btnPix.UseVisualStyleBackColor = false;
            this.btnPix.Click += new System.EventHandler(this.btnPix_Click_1);
            // 
            // btnCartao
            // 
            this.btnCartao.BackColor = System.Drawing.Color.Lime;
            this.btnCartao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCartao.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCartao.ForeColor = System.Drawing.Color.White;
            this.btnCartao.Location = new System.Drawing.Point(42, 271);
            this.btnCartao.Name = "btnCartao";
            this.btnCartao.Size = new System.Drawing.Size(178, 41);
            this.btnCartao.TabIndex = 5;
            this.btnCartao.Text = "Pagar com Cartão";
            this.btnCartao.UseVisualStyleBackColor = false;
            this.btnCartao.Click += new System.EventHandler(this.btnCartao_Click_1);
            // 
            // panelPix
            // 
            this.panelPix.BackColor = System.Drawing.Color.Lime;
            this.panelPix.Controls.Add(this.btnConfirmarPix);
            this.panelPix.Controls.Add(this.pictureBox1);
            this.panelPix.Controls.Add(this.labelPixInfo);
            this.panelPix.Location = new System.Drawing.Point(309, 96);
            this.panelPix.Name = "panelPix";
            this.panelPix.Size = new System.Drawing.Size(417, 338);
            this.panelPix.TabIndex = 6;
            // 
            // labelPixInfo
            // 
            this.labelPixInfo.AutoSize = true;
            this.labelPixInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPixInfo.Location = new System.Drawing.Point(14, 18);
            this.labelPixInfo.Name = "labelPixInfo";
            this.labelPixInfo.Size = new System.Drawing.Size(44, 18);
            this.labelPixInfo.TabIndex = 0;
            this.labelPixInfo.Text = "label1";
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.Lime;
            this.panelCard.Controls.Add(this.btnConfirmarCard);
            this.panelCard.Controls.Add(this.textBoxCvv);
            this.panelCard.Controls.Add(this.textBoxExpiryDate);
            this.panelCard.Controls.Add(this.textBoxCardHolder);
            this.panelCard.Controls.Add(this.textBoxCardNumber);
            this.panelCard.Controls.Add(this.labelCvv);
            this.panelCard.Controls.Add(this.labelExpiryDate);
            this.panelCard.Controls.Add(this.labelCardHolder);
            this.panelCard.Controls.Add(this.labelCardNumber);
            this.panelCard.Location = new System.Drawing.Point(322, 96);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(333, 225);
            this.panelCard.TabIndex = 7;
            // 
            // labelCardNumber
            // 
            this.labelCardNumber.AutoSize = true;
            this.labelCardNumber.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCardNumber.Location = new System.Drawing.Point(12, 18);
            this.labelCardNumber.Name = "labelCardNumber";
            this.labelCardNumber.Size = new System.Drawing.Size(145, 21);
            this.labelCardNumber.TabIndex = 0;
            this.labelCardNumber.Text = "Número do Cartão";
            // 
            // labelCardHolder
            // 
            this.labelCardHolder.AutoSize = true;
            this.labelCardHolder.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCardHolder.Location = new System.Drawing.Point(12, 66);
            this.labelCardHolder.Name = "labelCardHolder";
            this.labelCardHolder.Size = new System.Drawing.Size(129, 21);
            this.labelCardHolder.TabIndex = 1;
            this.labelCardHolder.Text = "Nome do Titular";
            // 
            // labelExpiryDate
            // 
            this.labelExpiryDate.AutoSize = true;
            this.labelExpiryDate.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExpiryDate.Location = new System.Drawing.Point(11, 115);
            this.labelExpiryDate.Name = "labelExpiryDate";
            this.labelExpiryDate.Size = new System.Drawing.Size(137, 21);
            this.labelExpiryDate.TabIndex = 2;
            this.labelExpiryDate.Text = "Data de Validade";
            // 
            // labelCvv
            // 
            this.labelCvv.AutoSize = true;
            this.labelCvv.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCvv.Location = new System.Drawing.Point(176, 115);
            this.labelCvv.Name = "labelCvv";
            this.labelCvv.Size = new System.Drawing.Size(40, 21);
            this.labelCvv.TabIndex = 3;
            this.labelCvv.Text = "CVV";
            // 
            // textBoxCardNumber
            // 
            this.textBoxCardNumber.Location = new System.Drawing.Point(15, 42);
            this.textBoxCardNumber.Name = "textBoxCardNumber";
            this.textBoxCardNumber.Size = new System.Drawing.Size(267, 22);
            this.textBoxCardNumber.TabIndex = 4;
            // 
            // textBoxCardHolder
            // 
            this.textBoxCardHolder.Location = new System.Drawing.Point(15, 90);
            this.textBoxCardHolder.Name = "textBoxCardHolder";
            this.textBoxCardHolder.Size = new System.Drawing.Size(267, 22);
            this.textBoxCardHolder.TabIndex = 5;
            // 
            // textBoxExpiryDate
            // 
            this.textBoxExpiryDate.Location = new System.Drawing.Point(15, 138);
            this.textBoxExpiryDate.Name = "textBoxExpiryDate";
            this.textBoxExpiryDate.Size = new System.Drawing.Size(142, 22);
            this.textBoxExpiryDate.TabIndex = 6;
            // 
            // textBoxCvv
            // 
            this.textBoxCvv.Location = new System.Drawing.Point(180, 138);
            this.textBoxCvv.Name = "textBoxCvv";
            this.textBoxCvv.Size = new System.Drawing.Size(42, 22);
            this.textBoxCvv.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(211, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Selecione a forma de pagamento:";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Image = global::CultivaTechDesktop.Properties.Resources.voltar;
            this.btnVoltar.Location = new System.Drawing.Point(12, 12);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(29, 31);
            this.btnVoltar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnVoltar.TabIndex = 9;
            this.btnVoltar.TabStop = false;
            this.btnVoltar.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CultivaTechDesktop.Properties.Resources._1731289656191;
            this.pictureBox1.Location = new System.Drawing.Point(83, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 218);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnConfirmarCard
            // 
            this.btnConfirmarCard.BackColor = System.Drawing.Color.White;
            this.btnConfirmarCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarCard.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarCard.ForeColor = System.Drawing.Color.Black;
            this.btnConfirmarCard.Location = new System.Drawing.Point(70, 175);
            this.btnConfirmarCard.Name = "btnConfirmarCard";
            this.btnConfirmarCard.Size = new System.Drawing.Size(178, 41);
            this.btnConfirmarCard.TabIndex = 10;
            this.btnConfirmarCard.Text = "Confirmar";
            this.btnConfirmarCard.UseVisualStyleBackColor = false;
            this.btnConfirmarCard.Click += new System.EventHandler(this.btnConfirmarCard_Click);
            // 
            // btnConfirmarPix
            // 
            this.btnConfirmarPix.BackColor = System.Drawing.Color.White;
            this.btnConfirmarPix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarPix.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarPix.ForeColor = System.Drawing.Color.Black;
            this.btnConfirmarPix.Location = new System.Drawing.Point(117, 290);
            this.btnConfirmarPix.Name = "btnConfirmarPix";
            this.btnConfirmarPix.Size = new System.Drawing.Size(178, 41);
            this.btnConfirmarPix.TabIndex = 11;
            this.btnConfirmarPix.Text = "Confirmar";
            this.btnConfirmarPix.UseVisualStyleBackColor = false;
            this.btnConfirmarPix.Click += new System.EventHandler(this.btnConfirmarPix_Click);
            // 
            // TelaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(753, 446);
            this.ControlBox = false;
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelCard);
            this.Controls.Add(this.panelPix);
            this.Controls.Add(this.btnCartao);
            this.Controls.Add(this.btnPix);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelQuantidade);
            this.Controls.Add(this.labelPreco);
            this.Controls.Add(this.labelProduto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaPagamento";
            this.Text = "TelaPagamento";
            this.panelPix.ResumeLayout(false);
            this.panelPix.PerformLayout();
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVoltar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProduto;
        private System.Windows.Forms.Label labelPreco;
        private System.Windows.Forms.Label labelQuantidade;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button btnPix;
        private System.Windows.Forms.Button btnCartao;
        private System.Windows.Forms.Panel panelPix;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelPixInfo;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.TextBox textBoxCvv;
        private System.Windows.Forms.TextBox textBoxExpiryDate;
        private System.Windows.Forms.TextBox textBoxCardHolder;
        private System.Windows.Forms.TextBox textBoxCardNumber;
        private System.Windows.Forms.Label labelCvv;
        private System.Windows.Forms.Label labelExpiryDate;
        private System.Windows.Forms.Label labelCardHolder;
        private System.Windows.Forms.Label labelCardNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnVoltar;
        private System.Windows.Forms.Button btnConfirmarPix;
        private System.Windows.Forms.Button btnConfirmarCard;
    }
}