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
                "101;Alabama Apimentado;Promoções;20.90;20",
                "102;Alabama Bacon Duplo;Promoções;26.90;20",
                "103;Alabama Clássico;Burger Tradicional;15.90;30",
                "104;Alabama Filé;Burger Especial;22.90;18",
                "105;Alabama Kids;Burger Tradicional;14.90;25",
                "106;Alabama Supremo;Burger Especial;22.90;16",
                "107;Alabama Tudo;Burger Especial;25.90;18",
                "108;Alabama Vegano;Burger Especial;27.90;12",
                "109;Suco Laranja 1L;Sucos e Refri;9.90;30",
                "110;Suco Uva 1L;Sucos e Refri;9.90;30",
                "111;Suco Morango 1L;Sucos e Refri;9.90;30"
            };

            File.WriteAllLines(arquivoProdutos, produtosPadrao, Encoding.UTF8);
        }
    }
}


