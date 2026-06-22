namespace ProjetoLPCO.Models
{
    public class Pedido
    {
        public int Numero { get; set; }
        public Cliente Cliente { get; set; }
        public List<ItemCarrinho> Itens { get; set; }
        public string FormaPagamento { get; set; }
        public DateTime DataHora { get; set; }

        public Pedido(int numero, Cliente cliente)
        {
            Numero = numero;
            Cliente = cliente;
            Itens = new List<ItemCarrinho>();
            FormaPagamento = "Não informado";
            DataHora = DateTime.Now;
        }

        public decimal Total
        {
            get { return Itens.Sum(item => item.Subtotal); }
        }
    }
}


