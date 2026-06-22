namespace ProjetoLPCO
{
    partial class FormIdentificacao
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlContainer = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            lblInstrucao = new Label();
            mskCPF = new MaskedTextBox();
            btnEntrarCpf = new Button();
            btnAnonimo = new Button();
            lblRodape = new Label();
            pnlConteudo = new Panel();
            pnlContainer.SuspendLayout();
            pnlConteudo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.White;
            pnlContainer.Controls.Add(pnlConteudo);
            pnlContainer.Location = new Point(58, 42);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(684, 366);
            pnlContainer.TabIndex = 0;
            // 
            // pnlConteudo
            // 
            pnlConteudo.BackColor = Color.FromArgb(248, 250, 252);
            pnlConteudo.BorderStyle = BorderStyle.FixedSingle;
            pnlConteudo.Controls.Add(lblRodape);
            pnlConteudo.Controls.Add(btnAnonimo);
            pnlConteudo.Controls.Add(btnEntrarCpf);
            pnlConteudo.Controls.Add(mskCPF);
            pnlConteudo.Controls.Add(lblInstrucao);
            pnlConteudo.Controls.Add(lblSubtitulo);
            pnlConteudo.Controls.Add(lblTitulo);
            pnlConteudo.Location = new Point(0, 0);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(684, 366);
            pnlConteudo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitulo.Location = new Point(32, 28);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(246, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Alabama Comidaria";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblSubtitulo.ForeColor = Color.FromArgb(71, 85, 105);
            lblSubtitulo.Location = new Point(34, 78);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(337, 19);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Informe seu CPF ou continue sem identificação.";
            // 
            // lblInstrucao
            // 
            lblInstrucao.AutoSize = true;
            lblInstrucao.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblInstrucao.ForeColor = Color.FromArgb(15, 23, 42);
            lblInstrucao.Location = new Point(34, 136);
            lblInstrucao.Name = "lblInstrucao";
            lblInstrucao.Size = new Size(89, 19);
            lblInstrucao.TabIndex = 2;
            lblInstrucao.Text = "CPF opcional";
            // 
            // mskCPF
            // 
            mskCPF.BackColor = Color.White;
            mskCPF.BorderStyle = BorderStyle.FixedSingle;
            mskCPF.ForeColor = Color.FromArgb(15, 23, 42);
            mskCPF.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            mskCPF.Location = new Point(34, 164);
            mskCPF.Mask = "000.000.000-00";
            mskCPF.Name = "mskCPF";
            mskCPF.Size = new Size(256, 32);
            mskCPF.TabIndex = 0;
            // 
            // btnEntrarCpf
            // 
            btnEntrarCpf.BackColor = Color.FromArgb(37, 99, 235);
            btnEntrarCpf.Cursor = Cursors.Hand;
            btnEntrarCpf.FlatAppearance.BorderSize = 0;
            btnEntrarCpf.FlatStyle = FlatStyle.Flat;
            btnEntrarCpf.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnEntrarCpf.ForeColor = Color.White;
            btnEntrarCpf.Location = new Point(308, 160);
            btnEntrarCpf.Name = "btnEntrarCpf";
            btnEntrarCpf.Size = new Size(330, 40);
            btnEntrarCpf.TabIndex = 1;
            btnEntrarCpf.Text = "Continuar com CPF";
            btnEntrarCpf.UseVisualStyleBackColor = false;
            btnEntrarCpf.Click += btnEntrarCpf_Click;
            // 
            // btnAnonimo
            // 
            btnAnonimo.BackColor = Color.White;
            btnAnonimo.Cursor = Cursors.Hand;
            btnAnonimo.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnAnonimo.FlatStyle = FlatStyle.Flat;
            btnAnonimo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAnonimo.ForeColor = Color.FromArgb(15, 23, 42);
            btnAnonimo.Location = new Point(34, 220);
            btnAnonimo.Name = "btnAnonimo";
            btnAnonimo.Size = new Size(604, 40);
            btnAnonimo.TabIndex = 2;
            btnAnonimo.Text = "Continuar sem CPF";
            btnAnonimo.UseVisualStyleBackColor = false;
            btnAnonimo.Click += btnAnonimo_Click;
            // 
            // lblRodape
            // 
            lblRodape.AutoSize = true;
            lblRodape.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblRodape.ForeColor = Color.FromArgb(100, 116, 139);
            lblRodape.Location = new Point(34, 286);
            lblRodape.Name = "lblRodape";
            lblRodape.Size = new Size(350, 15);
            lblRodape.TabIndex = 6;
            lblRodape.Text = "O CPF será usado somente para vincular o pedido ao cliente.";
            // 
            // FormIdentificacao
            // 
            AcceptButton = btnEntrarCpf;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            CancelButton = btnAnonimo;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlContainer);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormIdentificacao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alabama Comidaria - Identificação";
            pnlContainer.ResumeLayout(false);
            pnlConteudo.ResumeLayout(false);
            pnlConteudo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlConteudo;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblInstrucao;
        private MaskedTextBox mskCPF;
        private Button btnEntrarCpf;
        private Button btnAnonimo;
        private Label lblRodape;
    }
}
