namespace ProjetoLPCO
{
    partial class FormSobre
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
            btnFechar = new Button();
            lblTexto = new Label();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.White;
            pnlContainer.Controls.Add(btnFechar);
            pnlContainer.Controls.Add(lblTexto);
            pnlContainer.Controls.Add(lblTitulo);
            pnlContainer.Location = new Point(38, 32);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(484, 306);
            pnlContainer.TabIndex = 0;
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.FromArgb(24, 24, 27);
            btnFechar.Cursor = Cursors.Hand;
            btnFechar.FlatAppearance.BorderSize = 0;
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnFechar.ForeColor = Color.White;
            btnFechar.Location = new Point(302, 239);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(140, 38);
            btnFechar.TabIndex = 2;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;
            // 
            // lblTexto
            // 
            lblTexto.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblTexto.ForeColor = Color.FromArgb(63, 63, 70);
            lblTexto.Location = new Point(42, 90);
            lblTexto.Name = "lblTexto";
            lblTexto.Size = new Size(400, 132);
            lblTexto.TabIndex = 1;
            lblTexto.Text = "Sistema de Autoatendimento para Restaurante\r\n\r\nDesenvolvido em C# Windows Forms.\r\n\r\nGrupo: coloque aqui o nome dos integrantes\r\nDisciplina: Linguagem de Programação\r\nVersão: 1.0";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.FromArgb(24, 24, 27);
            lblTitulo.Location = new Point(38, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(245, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Totem Express";
            // 
            // FormSobre
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 244, 245);
            ClientSize = new Size(560, 370);
            Controls.Add(pnlContainer);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSobre";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sobre";
            pnlContainer.ResumeLayout(false);
            pnlContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Label lblTitulo;
        private Label lblTexto;
        private Button btnFechar;
    }
}
