namespace ProjetoLPCO
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (FormIdentificacao formIdentificacao = new FormIdentificacao())
            {
                if (formIdentificacao.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Form1(formIdentificacao.ClienteAtual));
                }
            }
        }
    }
}
