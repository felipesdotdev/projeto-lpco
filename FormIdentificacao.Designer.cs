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
            pnlContainer.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.White;
            pnlContainer.Controls.Add(lblRodape);
            pnlContainer.Controls.Add(btnAnonimo);
            pnlContainer.Controls.Add(btnEntrarCpf);
            pnlContainer.Controls.Add(mskCPF);
            pnlContainer.Controls.Add(lblInstrucao);
            pnlContainer.Controls.Add(lblSubtitulo);
            pnlContainer.Controls.Add(lblTitulo);
            pnlContainer.Location = new Point(88, 54);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(624, 342);
            pnlContainer.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.FromArgb(24, 24, 27);
            lblTitulo.Location = new Point(42, 34);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(245, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Totem Express";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblSubtitulo.ForeColor = Color.FromArgb(100, 100, 110);
            lblSubtitulo.Location = new Point(47, 86);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(396, 19);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Comece seu pedido se identificando ou continue sem CPF.";
            // 
            // lblInstrucao
            // 
            lblInstrucao.AutoSize = true;
            lblInstrucao.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblInstrucao.ForeColor = Color.FromArgb(39, 39, 42);
            lblInstrucao.Location = new Point(48, 138);
            lblInstrucao.Name = "lblInstrucao";
            lblInstrucao.Size = new Size(95, 19);
            lblInstrucao.TabIndex = 2;
            lblInstrucao.Text = "CPF opcional";
            // 
            // mskCPF
            // 
            mskCPF.BackColor = Color.FromArgb(250, 250, 250);
            mskCPF.BorderStyle = BorderStyle.FixedSingle;
            mskCPF.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            mskCPF.Location = new Point(48, 166);
            mskCPF.Mask = "000.000.000-00";
            mskCPF.Name = "mskCPF";
            mskCPF.Size = new Size(252, 32);
            mskCPF.TabIndex = 0;
            // 
            // btnEntrarCpf
            // 
            btnEntrarCpf.BackColor = Color.FromArgb(24, 24, 27);
            btnEntrarCpf.Cursor = Cursors.Hand;
            btnEntrarCpf.FlatAppearance.BorderSize = 0;
            btnEntrarCpf.FlatStyle = FlatStyle.Flat;
            btnEntrarCpf.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnEntrarCpf.ForeColor = Color.White;
            btnEntrarCpf.Location = new Point(318, 164);
            btnEntrarCpf.Name = "btnEntrarCpf";
            btnEntrarCpf.Size = new Size(242, 38);
            btnEntrarCpf.TabIndex = 1;
            btnEntrarCpf.Text = "Entrar com CPF";
            btnEntrarCpf.UseVisualStyleBackColor = false;
            btnEntrarCpf.Click += btnEntrarCpf_Click;
            // 
            // btnAnonimo
            // 
            btnAnonimo.BackColor = Color.FromArgb(244, 244, 245);
            btnAnonimo.Cursor = Cursors.Hand;
            btnAnonimo.FlatAppearance.BorderColor = Color.FromArgb(220, 220, 225);
            btnAnonimo.FlatStyle = FlatStyle.Flat;
            btnAnonimo.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAnonimo.ForeColor = Color.FromArgb(39, 39, 42);
            btnAnonimo.Location = new Point(48, 220);
            btnAnonimo.Name = "btnAnonimo";
            btnAnonimo.Size = new Size(512, 42);
            btnAnonimo.TabIndex = 2;
            btnAnonimo.Text = "Continuar como anônimo";
            btnAnonimo.UseVisualStyleBackColor = false;
            btnAnonimo.Click += btnAnonimo_Click;
            // 
            // lblRodape
            // 
            lblRodape.AutoSize = true;
            lblRodape.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblRodape.ForeColor = Color.FromArgb(120, 120, 130);
            lblRodape.Location = new Point(48, 291);
            lblRodape.Name = "lblRodape";
            lblRodape.Size = new Size(343, 15);
            lblRodape.TabIndex = 6;
            lblRodape.Text = "Seu CPF será usado apenas para vincular este pedido no sistema.";
            // 
            // FormIdentificacao
            // 
            AcceptButton = btnEntrarCpf;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 244, 245);
            CancelButton = btnAnonimo;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlContainer);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormIdentificacao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Identificação do Cliente";
            pnlContainer.ResumeLayout(false);
            pnlContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblInstrucao;
        private MaskedTextBox mskCPF;
        private Button btnEntrarCpf;
        private Button btnAnonimo;
        private Label lblRodape;
    }
}
