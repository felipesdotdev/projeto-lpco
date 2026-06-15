using ProjetoLPCO.Models;

namespace ProjetoLPCO
{
    public partial class FormIdentificacao : Form
    {
        public Cliente ClienteAtual { get; private set; }

        public FormIdentificacao()
        {
            InitializeComponent();
            ClienteAtual = Cliente.CriarAnonimo();
        }

        private void btnAnonimo_Click(object sender, EventArgs e)
        {
            ClienteAtual = Cliente.CriarAnonimo();

            MessageBox.Show(
                "Você entrou como cliente anônimo.",
                "Identificação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnEntrarCpf_Click(object sender, EventArgs e)
        {
            if (!mskCPF.MaskCompleted)
            {
                MessageBox.Show(
                    "Digite um CPF completo ou continue como anônimo.",
                    "CPF inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                mskCPF.Focus();
                return;
            }

            ClienteAtual = Cliente.CriarComCpf(mskCPF.Text);

            MessageBox.Show(
                "Cliente identificado com sucesso.",
                "Identificação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
