namespace ProjetoLPCO.Models
{
    public class Adicional
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public Adicional(string nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;
        }
    }
}
