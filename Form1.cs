using ProjetoLPCO.Models;
using ProjetoLPCO.Services;
using System.Globalization;

namespace ProjetoLPCO
{
    public partial class Form1 : Form
    {
        private readonly Cliente clienteAtual;
        private readonly ProdutoService produtoService = new ProdutoService();
        private readonly PedidoService pedidoService = new PedidoService();
        private readonly CultureInfo cultura = new CultureInfo("pt-BR");

        private List<Produto> produtos = new List<Produto>();
        private List<ItemCarrinho> carrinho = new List<ItemCarrinho>();
        private Produto? produtoSelecionado;
        private int indiceItemSelecionado = -1;

        public Form1(Cliente cliente)
        {
            InitializeComponent();

            clienteAtual = cliente;

            ConfigurarGrids();
            CarregarSistema();
        }

        private void CarregarSistema()
        {
            produtos = produtoService.CarregarProdutos();
            ExibirCliente();
            CarregarCategorias();
            FiltrarProdutos();
            AtualizarCarrinho();
        }

        private void ConfigurarGrids()
        {
            dgvProdutos.Columns.Clear();
            dgvProdutos.AutoGenerateColumns = false;
            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCodigoProduto", HeaderText = "Cód.", Width = 60 });
            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNomeProduto", HeaderText = "Produto", Width = 220 });
            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCategoriaProduto", HeaderText = "Categoria", Width = 130 });
            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPrecoProduto", HeaderText = "Preço", Width = 90 });
            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEstoqueProduto", HeaderText = "Estoque", Width = 80 });

            dgvCarrinho.Columns.Clear();
            dgvCarrinho.AutoGenerateColumns = false;
            dgvCarrinho.Columns.Add(new DataGridViewTextBoxColumn { Name = "colProdutoCarrinho", HeaderText = "Item", Width = 145 });
            dgvCarrinho.Columns.Add(new DataGridViewTextBoxColumn { Name = "colQtdCarrinho", HeaderText = "Qtd.", Width = 48 });
            dgvCarrinho.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUnitarioCarrinho", HeaderText = "Unit.", Width = 75 });
            dgvCarrinho.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAdicionaisCarrinho", HeaderText = "Alterações", Width = 160 });
            dgvCarrinho.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSubtotalCarrinho", HeaderText = "Subtotal", Width = 82 });
        }

        private void ExibirCliente()
        {
            lblCliente.Text = clienteAtual.ObterIdentificacao();
        }

        private void CarregarCategorias()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Todas");

            foreach (string categoria in produtos.Select(p => p.Categoria).Distinct().OrderBy(c => c))
            {
                cmbCategoria.Items.Add(categoria);
            }

            cmbCategoria.SelectedIndex = 0;
        }

        private void FiltrarProdutos()
        {
            string termo = txtPesquisa.Text.Trim().ToLower();
            string categoria = cmbCategoria.SelectedItem?.ToString() ?? "Todas";

            List<Produto> filtrados = produtos
                .Where(p =>
                    (string.IsNullOrWhiteSpace(termo) ||
                     p.Nome.ToLower().Contains(termo) ||
                     p.Codigo.ToString().Contains(termo)) &&
                    (categoria == "Todas" || p.Categoria == categoria))
                .ToList();

            AtualizarProdutosNaTela(filtrados);
        }

        private void AtualizarProdutosNaTela(List<Produto> lista)
        {
            dgvProdutos.Rows.Clear();

            foreach (Produto produto in lista)
            {
                int linha = dgvProdutos.Rows.Add(
                    produto.Codigo,
                    produto.Nome,
                    produto.Categoria,
                    produto.Preco.ToString("C2", cultura),
                    produto.Estoque
                );

                if (produto.Estoque <= 0)
                {
                    dgvProdutos.Rows[linha].DefaultCellStyle.ForeColor = Color.Gray;
                }
            }
        }

        private void AtualizarCarrinho()
        {
            dgvCarrinho.Rows.Clear();

            foreach (ItemCarrinho item in carrinho)
            {
                dgvCarrinho.Rows.Add(
                    item.Produto.Nome,
                    item.Quantidade,
                    item.PrecoUnitarioFinal.ToString("C2", cultura),
                    item.DescricaoAdicionais(),
                    item.Subtotal.ToString("C2", cultura)
                );
            }

            decimal total = carrinho.Sum(item => item.Subtotal);
            int quantidadeItens = carrinho.Sum(item => item.Quantidade);

            lblTotal.Text = "Total: " + total.ToString("C2", cultura);
            lblItens.Text = quantidadeItens + " item(ns) na sacola";
        }

        private void SelecionarProduto(int codigo)
        {
            produtoSelecionado = produtos.FirstOrDefault(p => p.Codigo == codigo);
            indiceItemSelecionado = -1;

            if (produtoSelecionado == null)
            {
                return;
            }

            lblProdutoSelecionado.Text = "Selecionado: " + produtoSelecionado.Nome;
            nudQuantidade.Maximum = Math.Max(1, produtoSelecionado.Estoque);
            nudQuantidade.Value = 1;
            LimparAdicionais();
        }

        private List<Adicional> ObterAdicionaisSelecionados()
        {
            List<Adicional> adicionais = new List<Adicional>();

            if (chkHamburguerExtra.Checked)
            {
                adicionais.Add(new Adicional("Hambúrguer extra", 6.00m));
            }

            if (chkQueijoExtra.Checked)
            {
                adicionais.Add(new Adicional("Queijo extra", 3.00m));
            }

            if (chkBaconExtra.Checked)
            {
                adicionais.Add(new Adicional("Bacon extra", 5.00m));
            }

            if (chkMolhoEspecial.Checked)
            {
                adicionais.Add(new Adicional("Molho especial", 2.00m));
            }

            if (chkSemCebola.Checked)
            {
                adicionais.Add(new Adicional("Sem cebola", 0.00m));
            }

            return adicionais;
        }

        private void LimparAdicionais()
        {
            chkHamburguerExtra.Checked = false;
            chkQueijoExtra.Checked = false;
            chkBaconExtra.Checked = false;
            chkMolhoEspecial.Checked = false;
            chkSemCebola.Checked = false;
        }

        private void MarcarAdicionaisDoItem(ItemCarrinho item)
        {
            LimparAdicionais();

            chkHamburguerExtra.Checked = item.Adicionais.Any(a => a.Nome == "Hambúrguer extra");
            chkQueijoExtra.Checked = item.Adicionais.Any(a => a.Nome == "Queijo extra");
            chkBaconExtra.Checked = item.Adicionais.Any(a => a.Nome == "Bacon extra");
            chkMolhoEspecial.Checked = item.Adicionais.Any(a => a.Nome == "Molho especial");
            chkSemCebola.Checked = item.Adicionais.Any(a => a.Nome == "Sem cebola");
        }

        private int QuantidadeNoCarrinho(int codigoProduto, int? ignorarIndice = null)
        {
            int total = 0;

            for (int i = 0; i < carrinho.Count; i++)
            {
                if (ignorarIndice.HasValue && ignorarIndice.Value == i)
                {
                    continue;
                }

                if (carrinho[i].Produto.Codigo == codigoProduto)
                {
                    total += carrinho[i].Quantidade;
                }
            }

            return total;
        }

        private bool EstoqueDisponivel(Produto produto, int quantidadeDesejada, int? ignorarIndice = null)
        {
            int quantidadeJaNoCarrinho = QuantidadeNoCarrinho(produto.Codigo, ignorarIndice);
            return quantidadeJaNoCarrinho + quantidadeDesejada <= produto.Estoque;
        }

        private void AdicionarItemNaSacola()
        {
            if (produtoSelecionado == null)
            {
                MessageBox.Show("Selecione um produto do cardápio antes de adicionar.", "Produto não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (produtoSelecionado.Estoque <= 0)
            {
                MessageBox.Show("Este produto está sem estoque.", "Estoque indisponível", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantidade = (int)nudQuantidade.Value;

            if (!EstoqueDisponivel(produtoSelecionado, quantidade))
            {
                MessageBox.Show("A quantidade escolhida ultrapassa o estoque disponível.", "Estoque insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ItemCarrinho item = new ItemCarrinho(produtoSelecionado, quantidade, ObterAdicionaisSelecionados());
            carrinho.Add(item);

            AtualizarCarrinho();
            lblProdutoSelecionado.Text = "Adicionado: " + produtoSelecionado.Nome;
        }

        private void AlterarItemSelecionado()
        {
            if (indiceItemSelecionado < 0 || indiceItemSelecionado >= carrinho.Count)
            {
                MessageBox.Show("Selecione um item da sacola para alterar.", "Item não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ItemCarrinho item = carrinho[indiceItemSelecionado];
            int novaQuantidade = (int)nudQuantidade.Value;

            if (!EstoqueDisponivel(item.Produto, novaQuantidade, indiceItemSelecionado))
            {
                MessageBox.Show("A nova quantidade ultrapassa o estoque disponível.", "Estoque insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            item.Quantidade = novaQuantidade;
            item.Adicionais = ObterAdicionaisSelecionados();

            AtualizarCarrinho();
            lblProdutoSelecionado.Text = "Item alterado: " + item.Produto.Nome;
            indiceItemSelecionado = -1;
        }

        private void RemoverItemSelecionado()
        {
            if (indiceItemSelecionado < 0 || indiceItemSelecionado >= carrinho.Count)
            {
                MessageBox.Show("Selecione um item da sacola para remover.", "Item não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            carrinho.RemoveAt(indiceItemSelecionado);
            indiceItemSelecionado = -1;
            produtoSelecionado = null;
            lblProdutoSelecionado.Text = "Selecione um produto do cardápio";
            nudQuantidade.Value = 1;
            LimparAdicionais();
            AtualizarCarrinho();
        }

        private void NovoPedido()
        {
            if (carrinho.Count > 0)
            {
                DialogResult resposta = MessageBox.Show(
                    "Deseja limpar a sacola e iniciar um novo pedido?",
                    "Novo pedido",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resposta != DialogResult.Yes)
                {
                    return;
                }
            }

            carrinho.Clear();
            indiceItemSelecionado = -1;
            produtoSelecionado = null;
            txtPesquisa.Clear();
            cmbCategoria.SelectedIndex = 0;
            cmbPagamento.SelectedIndex = -1;
            lblProdutoSelecionado.Text = "Selecione um produto do cardápio";
            nudQuantidade.Value = 1;
            LimparAdicionais();
            AtualizarCarrinho();
            FiltrarProdutos();
        }

        private void FinalizarPedido()
        {
            if (carrinho.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um item à sacola antes de finalizar.", "Sacola vazia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPagamento.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma forma de pagamento.", "Pagamento obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPagamento.Focus();
                return;
            }

            int numeroPedido = pedidoService.GerarNumeroPedido();
            Pedido pedido = new Pedido(numeroPedido, clienteAtual);
            pedido.FormaPagamento = cmbPagamento.Text;

            foreach (ItemCarrinho item in carrinho)
            {
                List<Adicional> adicionaisCopiados = item.Adicionais
                    .Select(a => new Adicional(a.Nome, a.Valor))
                    .ToList();

                pedido.Itens.Add(new ItemCarrinho(item.Produto, item.Quantidade, adicionaisCopiados));
            }

            pedidoService.SalvarPedido(pedido);
            produtoService.BaixarEstoque(pedido.Itens, produtos);

            MessageBox.Show(
                "Pedido nº " + pedido.Numero + " finalizado com sucesso!\n\nTotal: " + pedido.Total.ToString("C2", cultura),
                "Pedido finalizado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            carrinho.Clear();
            indiceItemSelecionado = -1;
            produtoSelecionado = null;
            produtos = produtoService.CarregarProdutos();
            cmbPagamento.SelectedIndex = -1;
            lblProdutoSelecionado.Text = "Selecione um produto do cardápio";
            nudQuantidade.Value = 1;
            LimparAdicionais();
            AtualizarCarrinho();
            FiltrarProdutos();
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            object? valor = dgvProdutos.Rows[e.RowIndex].Cells["colCodigoProduto"].Value;

            if (valor == null)
            {
                return;
            }

            int codigo = Convert.ToInt32(valor);
            SelecionarProduto(codigo);
        }

        private void dgvCarrinho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= carrinho.Count)
            {
                return;
            }

            indiceItemSelecionado = e.RowIndex;
            ItemCarrinho item = carrinho[indiceItemSelecionado];
            produtoSelecionado = item.Produto;

            lblProdutoSelecionado.Text = "Editando item: " + item.Produto.Nome;
            nudQuantidade.Maximum = Math.Max(1, item.Produto.Estoque);
            nudQuantidade.Value = item.Quantidade;
            MarcarAdicionaisDoItem(item);
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            FiltrarProdutos();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarProdutos();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            FiltrarProdutos();
            txtPesquisa.Focus();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarItemNaSacola();
        }

        private void btnAlterarItem_Click(object sender, EventArgs e)
        {
            AlterarItemSelecionado();
        }

        private void btnRemoverItem_Click(object sender, EventArgs e)
        {
            RemoverItemSelecionado();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            NovoPedido();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            FinalizarPedido();
        }

        private void novoPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NovoPedido();
        }

        private void finalizarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinalizarPedido();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormSobre formSobre = new FormSobre())
            {
                formSobre.ShowDialog();
            }
        }
    }
}
