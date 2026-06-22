namespace ProjetoLPCO
{
    public sealed class FormCpfNota : Form
    {
        private readonly MaskedTextBox mskCPF;
        private readonly Button btnOk;
        private readonly Button btnCancelar;

        public string CpfInformado { get; private set; } = string.Empty;

        public FormCpfNota()
        {
            Text = "CPF na nota";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(420, 200);
            BackColor = Color.FromArgb(241, 245, 249);

            Label titulo = new Label
            {
                Text = "CPF na nota",
                Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(22, 18),
                Size = new Size(180, 32)
            };

            Label subtitulo = new Label
            {
                Text = "Digite o CPF para vincular este pedido.",
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(71, 85, 105),
                Location = new Point(24, 56),
                Size = new Size(250, 20)
            };

            mskCPF = new MaskedTextBox
            {
                Location = new Point(24, 88),
                Size = new Size(180, 28),
                Mask = "000.000.000-00",
                Font = new Font("Segoe UI", 12F),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(15, 23, 42)
            };

            btnOk = new Button
            {
                Text = "Confirmar",
                Location = new Point(24, 132),
                Size = new Size(180, 38),
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.Click += (_, _) => Confirmar();

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(220, 132),
                Size = new Size(176, 38),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(15, 23, 42),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnCancelar.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };

            Controls.Add(titulo);
            Controls.Add(subtitulo);
            Controls.Add(mskCPF);
            Controls.Add(btnOk);
            Controls.Add(btnCancelar);

            AcceptButton = btnOk;
            CancelButton = btnCancelar;
        }

        private void Confirmar()
        {
            if (!mskCPF.MaskCompleted)
            {
                MessageBox.Show(
                    "Digite um CPF completo.",
                    "CPF inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                mskCPF.Focus();
                return;
            }

            CpfInformado = mskCPF.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
