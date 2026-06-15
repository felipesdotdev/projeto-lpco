namespace ProjetoLPCO.Models
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }

        public Produto(int codigo, string nome, string categoria, decimal preco, int estoque)
        {
            Codigo = codigo;
            Nome = nome;
            Categoria = categoria;
            Preco = preco;
            Estoque = estoque;
        }

        public override string ToString()
        {
            return $"{Codigo} - {Nome}";
        }
    }
}
