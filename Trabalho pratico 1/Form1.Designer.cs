namespace Trabalho_pratico_1
{
    partial class Form1
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
            this.btnGerar = new System.Windows.Forms.Button();
            this.txtTamanho = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnResetar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.checkOrdenado = new System.Windows.Forms.CheckBox();
            this.lblresult = new System.Windows.Forms.Label();
            this.clbOrdenacoes = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtgResultados = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.lblQuantidadeVertores = new System.Windows.Forms.Label();
            this.lblInfoSistema = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.dtgMedias = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMedias)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(26, 169);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(193, 23);
            this.btnGerar.TabIndex = 0;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // txtTamanho
            // 
            this.txtTamanho.Location = new System.Drawing.Point(26, 59);
            this.txtTamanho.Name = "txtTamanho";
            this.txtTamanho.Size = new System.Drawing.Size(193, 20);
            this.txtTamanho.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tamanho";
            // 
            // btnResetar
            // 
            this.btnResetar.Location = new System.Drawing.Point(401, 487);
            this.btnResetar.Name = "btnResetar";
            this.btnResetar.Size = new System.Drawing.Size(350, 23);
            this.btnResetar.TabIndex = 3;
            this.btnResetar.Text = "Resetar";
            this.btnResetar.UseVisualStyleBackColor = true;
            this.btnResetar.Click += new System.EventHandler(this.btnResetar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Quantidade";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(26, 112);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(193, 20);
            this.txtQuantidade.TabIndex = 5;
            // 
            // checkOrdenado
            // 
            this.checkOrdenado.AutoSize = true;
            this.checkOrdenado.Location = new System.Drawing.Point(29, 142);
            this.checkOrdenado.Name = "checkOrdenado";
            this.checkOrdenado.Size = new System.Drawing.Size(107, 17);
            this.checkOrdenado.TabIndex = 7;
            this.checkOrdenado.Text = "Vetor Ordenado?";
            this.checkOrdenado.UseVisualStyleBackColor = true;
            // 
            // lblresult
            // 
            this.lblresult.AutoSize = true;
            this.lblresult.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblresult.Location = new System.Drawing.Point(410, 15);
            this.lblresult.Name = "lblresult";
            this.lblresult.Size = new System.Drawing.Size(287, 39);
            this.lblresult.TabIndex = 9;
            this.lblresult.Text = "Resultados Teste";
            // 
            // clbOrdenacoes
            // 
            this.clbOrdenacoes.FormattingEnabled = true;
            this.clbOrdenacoes.Items.AddRange(new object[] {
            "Bolha",
            "Selecao",
            "Insercao",
            "ShellSort",
            "QuickSort",
            "HeapSort",
            "MergeSort"});
            this.clbOrdenacoes.Location = new System.Drawing.Point(29, 225);
            this.clbOrdenacoes.Name = "clbOrdenacoes";
            this.clbOrdenacoes.Size = new System.Drawing.Size(208, 214);
            this.clbOrdenacoes.TabIndex = 10;
            this.clbOrdenacoes.ThreeDCheckBoxes = true;
            this.clbOrdenacoes.UseTabStops = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ordenação";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(12, 487);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(350, 23);
            this.btnIniciar.TabIndex = 12;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(364, 551);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(387, 39);
            this.label4.TabIndex = 13;
            this.label4.Text = "Informações do sistema";
            // 
            // dtgResultados
            // 
            this.dtgResultados.AllowUserToAddRows = false;
            this.dtgResultados.AllowUserToDeleteRows = false;
            this.dtgResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgResultados.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dtgResultados.Location = new System.Drawing.Point(268, 57);
            this.dtgResultados.Name = "dtgResultados";
            this.dtgResultados.ReadOnly = true;
            this.dtgResultados.Size = new System.Drawing.Size(570, 406);
            this.dtgResultados.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 447);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Quantidade de vetores: ";
            // 
            // lblQuantidadeVertores
            // 
            this.lblQuantidadeVertores.AutoSize = true;
            this.lblQuantidadeVertores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidadeVertores.Location = new System.Drawing.Point(172, 447);
            this.lblQuantidadeVertores.Name = "lblQuantidadeVertores";
            this.lblQuantidadeVertores.Size = new System.Drawing.Size(14, 16);
            this.lblQuantidadeVertores.TabIndex = 17;
            this.lblQuantidadeVertores.Text = "0";
            // 
            // lblInfoSistema
            // 
            this.lblInfoSistema.AutoSize = true;
            this.lblInfoSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoSistema.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblInfoSistema.Location = new System.Drawing.Point(32, 601);
            this.lblInfoSistema.Name = "lblInfoSistema";
            this.lblInfoSistema.Size = new System.Drawing.Size(86, 18);
            this.lblInfoSistema.TabIndex = 20;
            this.lblInfoSistema.Text = "Carregando";
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(790, 487);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(350, 23);
            this.btnExportar.TabIndex = 21;
            this.btnExportar.Text = "Exportar Excel";
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // dtgMedias
            // 
            this.dtgMedias.AllowUserToAddRows = false;
            this.dtgMedias.AllowUserToDeleteRows = false;
            this.dtgMedias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgMedias.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dtgMedias.Location = new System.Drawing.Point(856, 57);
            this.dtgMedias.Name = "dtgMedias";
            this.dtgMedias.ReadOnly = true;
            this.dtgMedias.Size = new System.Drawing.Size(284, 406);
            this.dtgMedias.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(886, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(225, 39);
            this.label6.TabIndex = 23;
            this.label6.Text = "Media Testes";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 709);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtgMedias);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.lblInfoSistema);
            this.Controls.Add(this.lblQuantidadeVertores);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtgResultados);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.clbOrdenacoes);
            this.Controls.Add(this.lblresult);
            this.Controls.Add(this.checkOrdenado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.btnResetar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTamanho);
            this.Controls.Add(this.btnGerar);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMedias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.TextBox txtTamanho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnResetar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.CheckBox checkOrdenado;
        private System.Windows.Forms.Label lblresult;
        private System.Windows.Forms.CheckedListBox clbOrdenacoes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dtgResultados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblQuantidadeVertores;
        private System.Windows.Forms.Label lblInfoSistema;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridView dtgMedias;
        private System.Windows.Forms.Label label6;
    }
}

