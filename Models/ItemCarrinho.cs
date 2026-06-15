namespace ProjetoLPCO.Models
{
    public class ItemCarrinho
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public List<Adicional> Adicionais { get; set; }

        public ItemCarrinho(Produto produto, int quantidade, List<Adicional>? adicionais = null)
        {
            Produto = produto;
            Quantidade = quantidade;
            Adicionais = adicionais ?? new List<Adicional>();
        }

        public decimal ValorAdicionais
        {
            get { return Adicionais.Sum(a => a.Valor); }
        }

        public decimal PrecoUnitarioFinal
        {
            get { return Produto.Preco + ValorAdicionais; }
        }

        public decimal Subtotal
        {
            get { return PrecoUnitarioFinal * Quantidade; }
        }

        public string DescricaoAdicionais()
        {
            if (Adicionais.Count == 0)
            {
                return "Sem alterações";
            }

            return string.Join(", ", Adicionais.Select(a => a.Nome));
        }
    }
}
