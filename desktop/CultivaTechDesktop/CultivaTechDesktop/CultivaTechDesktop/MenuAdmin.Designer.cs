
using CultivaTechNovo;
using System;

namespace CultivaTechNovo
{
    partial class MenuAdmin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.sair = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGerenciarAdmins = new System.Windows.Forms.Button();
            this.btnGerenciarUsuario = new System.Windows.Forms.Button();
            this.btnGerFornecedores = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnGerEstoque = new System.Windows.Forms.Button();
            this.dashboard_btn = new System.Windows.Forms.Button();
            this.greet_user = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lime;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCadastrar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.sair);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1467, 43);
            this.panel1.TabIndex = 0;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.BackColor = System.Drawing.Color.Lime;
            this.btnCadastrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastrar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnCadastrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnCadastrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.ForeColor = System.Drawing.Color.White;
            this.btnCadastrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCadastrar.Location = new System.Drawing.Point(1182, 4);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(173, 34);
            this.btnCadastrar.TabIndex = 8;
            this.btnCadastrar.Text = "Cadastrar Admin";
            this.btnCadastrar.UseVisualStyleBackColor = false;
            this.btnCadastrar.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "CultivaTech";
            // 
            // sair
            // 
            this.sair.AutoSize = true;
            this.sair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sair.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sair.ForeColor = System.Drawing.Color.White;
            this.sair.Location = new System.Drawing.Point(1439, 10);
            this.sair.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sair.Name = "sair";
            this.sair.Size = new System.Drawing.Size(20, 21);
            this.sair.TabIndex = 0;
            this.sair.Text = "X";
            this.sair.Click += new System.EventHandler(this.exit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lime;
            this.panel2.Controls.Add(this.btnGerenciarAdmins);
            this.panel2.Controls.Add(this.btnGerenciarUsuario);
            this.panel2.Controls.Add(this.btnGerFornecedores);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnSair);
            this.panel2.Controls.Add(this.btnGerEstoque);
            this.panel2.Controls.Add(this.dashboard_btn);
            this.panel2.Controls.Add(this.greet_user);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 695);
            this.panel2.TabIndex = 1;
            // 
            // btnGerenciarAdmins
            // 
            this.btnGerenciarAdmins.BackColor = System.Drawing.Color.Lime;
            this.btnGerenciarAdmins.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerenciarAdmins.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnGerenciarAdmins.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnGerenciarAdmins.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnGerenciarAdmins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerenciarAdmins.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerenciarAdmins.ForeColor = System.Drawing.Color.White;
            this.btnGerenciarAdmins.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerenciarAdmins.Location = new System.Drawing.Point(19, 456);
            this.btnGerenciarAdmins.Margin = new System.Windows.Forms.Padding(4);
            this.btnGerenciarAdmins.Name = "btnGerenciarAdmins";
            this.btnGerenciarAdmins.Size = new System.Drawing.Size(267, 49);
            this.btnGerenciarAdmins.TabIndex = 9;
            this.btnGerenciarAdmins.Text = "Gerenciar Admins";
            this.btnGerenciarAdmins.UseVisualStyleBackColor = false;
            this.btnGerenciarAdmins.Click += new System.EventHandler(this.btnGerenciarAdmins_Click);
            // 
            // btnGerenciarUsuario
            // 
            this.btnGerenciarUsuario.BackColor = System.Drawing.Color.Lime;
            this.btnGerenciarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerenciarUsuario.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnGerenciarUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnGerenciarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnGerenciarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerenciarUsuario.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerenciarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnGerenciarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerenciarUsuario.Location = new System.Drawing.Point(19, 399);
            this.btnGerenciarUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.btnGerenciarUsuario.Name = "btnGerenciarUsuario";
            this.btnGerenciarUsuario.Size = new System.Drawing.Size(267, 49);
            this.btnGerenciarUsuario.TabIndex = 8;
            this.btnGerenciarUsuario.Text = "Gerenciar Usuários";
            this.btnGerenciarUsuario.UseVisualStyleBackColor = false;
            this.btnGerenciarUsuario.Click += new System.EventHandler(this.btnGerenciarUsuario_Click_2);
            // 
            // btnGerFornecedores
            // 
            this.btnGerFornecedores.BackColor = System.Drawing.Color.Lime;
            this.btnGerFornecedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerFornecedores.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnGerFornecedores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnGerFornecedores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnGerFornecedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerFornecedores.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerFornecedores.ForeColor = System.Drawing.Color.White;
            this.btnGerFornecedores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerFornecedores.Location = new System.Drawing.Point(19, 342);
            this.btnGerFornecedores.Margin = new System.Windows.Forms.Padding(4);
            this.btnGerFornecedores.Name = "btnGerFornecedores";
            this.btnGerFornecedores.Size = new System.Drawing.Size(267, 49);
            this.btnGerFornecedores.TabIndex = 7;
            this.btnGerFornecedores.Text = "Gerenciar Fornecedores";
            this.btnGerFornecedores.UseVisualStyleBackColor = false;
            this.btnGerFornecedores.Click += new System.EventHandler(this.btnGerFornecedores_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(71, 649);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sair";
            // 
            // btnSair
            // 
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnSair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Image = global::CultivaTechDesktop.Properties.Resources.icons8_logout_rounded_up_filled_25px;
            this.btnSair.Location = new System.Drawing.Point(15, 636);
            this.btnSair.Margin = new System.Windows.Forms.Padding(4);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(47, 43);
            this.btnSair.TabIndex = 5;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // btnGerEstoque
            // 
            this.btnGerEstoque.BackColor = System.Drawing.Color.Lime;
            this.btnGerEstoque.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerEstoque.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnGerEstoque.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnGerEstoque.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btnGerEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerEstoque.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerEstoque.ForeColor = System.Drawing.Color.White;
            this.btnGerEstoque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerEstoque.Location = new System.Drawing.Point(19, 285);
            this.btnGerEstoque.Margin = new System.Windows.Forms.Padding(4);
            this.btnGerEstoque.Name = "btnGerEstoque";
            this.btnGerEstoque.Size = new System.Drawing.Size(267, 49);
            this.btnGerEstoque.TabIndex = 3;
            this.btnGerEstoque.Text = "Gerenciar Estoque";
            this.btnGerEstoque.UseVisualStyleBackColor = false;
            this.btnGerEstoque.Click += new System.EventHandler(this.btnGerEstoque_Click);
            // 
            // dashboard_btn
            // 
            this.dashboard_btn.BackColor = System.Drawing.Color.Lime;
            this.dashboard_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dashboard_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.dashboard_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.dashboard_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.dashboard_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboard_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard_btn.ForeColor = System.Drawing.Color.White;
            this.dashboard_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboard_btn.Location = new System.Drawing.Point(19, 228);
            this.dashboard_btn.Margin = new System.Windows.Forms.Padding(4);
            this.dashboard_btn.Name = "dashboard_btn";
            this.dashboard_btn.Size = new System.Drawing.Size(267, 49);
            this.dashboard_btn.TabIndex = 2;
            this.dashboard_btn.Text = "Menu";
            this.dashboard_btn.UseVisualStyleBackColor = false;
            this.dashboard_btn.Click += new System.EventHandler(this.dashboard_btn_Click);
            // 
            // greet_user
            // 
            this.greet_user.AutoSize = true;
            this.greet_user.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greet_user.ForeColor = System.Drawing.Color.White;
            this.greet_user.Location = new System.Drawing.Point(54, 182);
            this.greet_user.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.greet_user.Name = "greet_user";
            this.greet_user.Size = new System.Drawing.Size(171, 24);
            this.greet_user.TabIndex = 1;
            this.greet_user.Text = "Bem vindo, admin";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CultivaTechDesktop.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(83, 55);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(300, 43);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1167, 695);
            this.panel3.TabIndex = 2;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // MenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 738);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label sair;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label greet_user;
        private System.Windows.Forms.Button dashboard_btn;
        private System.Windows.Forms.Button btnGerEstoque;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private Dashboard dashboard1;
        private GerenciarEstoque gerenciarEstoque1;
        private GerenciarAdmin gerenciarAdmin1;
        private GerenciarUsuario gerenciarUsuario1;
        private GerenciarFornecedor gerenciarFornecedor1;
        private System.Windows.Forms.Button btnGerFornecedores;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnGerenciarUsuario;
        private System.Windows.Forms.Button btnGerenciarAdmins;
    }
}