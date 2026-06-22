namespace ProjetoLPCO.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public bool Anonimo { get; set; }
        public bool TemCpf => !string.IsNullOrWhiteSpace(CPF);

        public Cliente(string nome, string cpf, bool anonimo)
        {
            Nome = nome;
            CPF = cpf;
            Anonimo = anonimo;
        }

        public static Cliente CriarAnonimo()
        {
            return new Cliente("Cliente Anônimo", "", true);
        }

        public static Cliente CriarComCpf(string cpf)
        {
            return new Cliente("Cliente Identificado", cpf, false);
        }

        public string ObterIdentificacao()
        {
            if (Anonimo)
            {
                return "Cliente: Anônimo";
            }

            return "Cliente identificado - CPF: " + CPF;
        }
    }
}

