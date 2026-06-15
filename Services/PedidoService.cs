using ProjetoLPCO.Models;
using System.Globalization;
using System.Text;

namespace ProjetoLPCO.Services
{
    public class PedidoService
    {
        private readonly string pastaDados;
        private readonly string arquivoPedidos;
        private readonly string arquivoContador;
        private readonly CultureInfo cultura = new CultureInfo("pt-BR");

        public PedidoService()
        {
            pastaDados = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dados");
            arquivoPedidos = Path.Combine(pastaDados, "pedidos.txt");
            arquivoContador = Path.Combine(pastaDados, "contador_pedidos.txt");
        }

        public int GerarNumeroPedido()
        {
            Directory.CreateDirectory(pastaDados);

            int numeroAtual = 1000;

            if (File.Exists(arquivoContador))
            {
                int.TryParse(File.ReadAllText(arquivoContador), out numeroAtual);
            }

            if (numeroAtual < 1000)
            {
                numeroAtual = 1000;
            }

            int novoNumero = numeroAtual + 1;
            File.WriteAllText(arquivoContador, novoNumero.ToString(), Encoding.UTF8);

            return novoNumero;
        }

        public void SalvarPedido(Pedido pedido)
        {
            Directory.CreateDirectory(pastaDados);

            List<string> linhas = new List<string>();

            linhas.Add("========================================");
            linhas.Add($"PEDIDO Nº {pedido.Numero}");
            linhas.Add($"Data/Hora: {pedido.DataHora:dd/MM/yyyy HH:mm:ss}");
            linhas.Add($"Cliente: {pedido.Cliente.ObterIdentificacao()}");
            linhas.Add($"Pagamento: {pedido.FormaPagamento}");
            linhas.Add("Itens:");

            foreach (ItemCarrinho item in pedido.Itens)
            {
                linhas.Add($"- {item.Produto.Nome} | Qtd: {item.Quantidade} | Unitário: {item.PrecoUnitarioFinal.ToString("C2", cultura)} | Subtotal: {item.Subtotal.ToString("C2", cultura)}");
                linhas.Add($"  Alterações: {item.DescricaoAdicionais()}");
            }

            linhas.Add($"TOTAL: {pedido.Total.ToString("C2", cultura)}");
            linhas.Add("========================================");
            linhas.Add("");

            File.AppendAllLines(arquivoPedidos, linhas, Encoding.UTF8);
        }
    }
}
