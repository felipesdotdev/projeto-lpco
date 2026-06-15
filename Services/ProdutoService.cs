using ProjetoLPCO.Models;
using System.Globalization;
using System.Text;

namespace ProjetoLPCO.Services
{
    public class ProdutoService
    {
        private readonly string pastaDados;
        private readonly string arquivoProdutos;
        private readonly CultureInfo culturaArquivo = CultureInfo.InvariantCulture;

        public ProdutoService()
        {
            pastaDados = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dados");
            arquivoProdutos = Path.Combine(pastaDados, "produtos.txt");
        }

        public List<Produto> CarregarProdutos()
        {
            GarantirArquivoProdutos();

            List<Produto> produtos = new List<Produto>();
            string[] linhas = File.ReadAllLines(arquivoProdutos, Encoding.UTF8);

            foreach (string linha in linhas)
            {
                if (string.IsNullOrWhiteSpace(linha))
                {
                    continue;
                }

                string[] partes = linha.Split(';');

                if (partes.Length != 5)
                {
                    continue;
                }

                bool codigoOk = int.TryParse(partes[0], out int codigo);
                string nome = partes[1];
                string categoria = partes[2];
                bool precoOk = decimal.TryParse(partes[3], NumberStyles.Number, culturaArquivo, out decimal preco);
                bool estoqueOk = int.TryParse(partes[4], out int estoque);

                if (codigoOk && precoOk && estoqueOk)
                {
                    produtos.Add(new Produto(codigo, nome, categoria, preco, estoque));
                }
            }

            return produtos;
        }

        public void SalvarProdutos(List<Produto> produtos)
        {
            Directory.CreateDirectory(pastaDados);

            List<string> linhas = produtos.Select(p =>
                $"{p.Codigo};{p.Nome};{p.Categoria};{p.Preco.ToString(culturaArquivo)};{p.Estoque}"
            ).ToList();

            File.WriteAllLines(arquivoProdutos, linhas, Encoding.UTF8);
        }

        public void BaixarEstoque(List<ItemCarrinho> itens, List<Produto> produtos)
        {
            foreach (ItemCarrinho item in itens)
            {
                Produto? produto = produtos.FirstOrDefault(p => p.Codigo == item.Produto.Codigo);

                if (produto != null)
                {
                    produto.Estoque -= item.Quantidade;

                    if (produto.Estoque < 0)
                    {
                        produto.Estoque = 0;
                    }
                }
            }

            SalvarProdutos(produtos);
        }

        private void GarantirArquivoProdutos()
        {
            Directory.CreateDirectory(pastaDados);

            if (File.Exists(arquivoProdutos))
            {
                return;
            }

            List<string> produtosPadrao = new List<string>
            {
                "101;X-Tudo;Lanches;28.90;20",
                "102;X-Burger;Lanches;19.90;30",
                "103;X-Salada;Lanches;22.50;25",
                "104;Batata Frita;Acompanhamentos;12.90;35",
                "105;Nuggets;Acompanhamentos;14.50;18",
                "106;Refrigerante Lata;Bebidas;7.00;50",
                "107;Suco Natural;Bebidas;9.90;22",
                "108;Milkshake;Sobremesas;15.90;12",
                "109;Brownie;Sobremesas;10.90;16"
            };

            File.WriteAllLines(arquivoProdutos, produtosPadrao, Encoding.UTF8);
        }
    }
}
