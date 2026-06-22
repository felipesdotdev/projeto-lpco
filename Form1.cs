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
        private FlowLayoutPanel? painelProdutosVisual;
        private FlowLayoutPanel? painelCategoriasVisual;
        private Panel? barraTotalVisual;
        private Label? lblTituloCategoriaVisual;
        private readonly Dictionary<string, Button> botoesCategorias = new Dictionary<string, Button>();
        private readonly Dictionary<int, Panel> cardsProdutos = new Dictionary<int, Panel>();
        private readonly Color corFundo = Color.FromArgb(245, 246, 248);
        private readonly Color corPainel = Color.White;
        private readonly Color corPainelClaro = Color.FromArgb(236, 239, 243);
        private readonly Color corVermelho = Color.FromArgb(32, 82, 149);
        private readonly Color corTexto = Color.FromArgb(26, 32, 44);
        private readonly Color corTextoSecundario = Color.FromArgb(100, 116, 139);

        public Form1(Cliente cliente)
        {
            InitializeComponent();

            clienteAtual = cliente;

            ConfigurarGrids();
            AplicarInterfaceTotem();
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

            if (painelCategoriasVisual != null)
            {
                painelCategoriasVisual.Controls.Clear();
                botoesCategorias.Clear();
                painelCategoriasVisual.Controls.Add(new Label
                {
                    Text = "MENU",
                    Size = new Size(150, 46),
                    ForeColor = corTexto,
                    Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter
                });

                foreach (object item in cmbCategoria.Items)
                {
                    string texto = item.ToString() == "Todas" ? "Todos" : item.ToString() ?? string.Empty;
                    Button botao = new Button
                    {
                        Text = texto,
                        Tag = item.ToString(),
                        Size = new Size(150, 42),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = corPainel,
                        ForeColor = corTexto,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Font = new Font("Segoe UI", 10F),
                        Cursor = Cursors.Hand
                    };
                    botao.FlatAppearance.BorderSize = 0;
                    botao.Click += (sender, args) =>
                    {
                        cmbCategoria.SelectedItem = ((Button)sender!).Tag?.ToString();
                        AtualizarCategoriaAtiva();
                    };
                    botoesCategorias[item.ToString() ?? string.Empty] = botao;
                    painelCategoriasVisual.Controls.Add(botao);
                }

                AtualizarCategoriaAtiva();
            }
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

            AtualizarCardsProdutos(lista);
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
            btnFinalizar.Text = "PAGAR " + total.ToString("C2", cultura).ToUpper();
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
            AtualizarProdutoSelecionadoVisual();
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


        private void AplicarInterfaceTotem()
        {
            BackColor = corFundo;
            ClientSize = new Size(1184, 760);
            MinimumSize = new Size(1000, 720);
            Text = "Alabama Comidaria - Autoatendimento";

            menuPrincipal.Visible = false;
            pnlHeader.Visible = false;

            pnlCardapio.BackColor = Color.White;
            pnlCardapio.Location = new Point(150, 24);
            pnlCardapio.Size = new Size(620, 670);
            pnlCardapio.BorderStyle = BorderStyle.FixedSingle;

            foreach (Control controle in pnlCardapio.Controls)
            {
                controle.Visible = false;
            }

            Label logo = CriarLogo();
            pnlCardapio.Controls.Add(logo);

            painelCategoriasVisual = new FlowLayoutPanel
            {
                Location = new Point(24, 132),
                Size = new Size(160, 360),
                BackColor = corPainel,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Visible = true
            };
            pnlCardapio.Controls.Add(painelCategoriasVisual);

            lblTituloCategoriaVisual = new Label
            {
                Text = "Todos",
                Location = new Point(210, 142),
                Size = new Size(240, 34),
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = corTexto,
                Visible = true
            };
            pnlCardapio.Controls.Add(lblTituloCategoriaVisual);

            PictureBox banner = new PictureBox
            {
                Location = new Point(210, 24),
                Size = new Size(380, 104),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.White,
                Image = ObterImagemProduto("Alabama Bacon Duplo"),
                Visible = true
            };
            pnlCardapio.Controls.Add(banner);

            painelProdutosVisual = new FlowLayoutPanel
            {
                Location = new Point(208, 184),
                Size = new Size(386, 396),
                AutoScroll = true,
                BackColor = corPainel,
                Visible = true
            };
            pnlCardapio.Controls.Add(painelProdutosVisual);

            lblProdutoSelecionado.AutoSize = false;
            lblProdutoSelecionado.Location = new Point(24, 502);
            lblProdutoSelecionado.Size = new Size(160, 44);
            lblProdutoSelecionado.ForeColor = corTexto;
            lblProdutoSelecionado.TextAlign = ContentAlignment.MiddleLeft;
            lblProdutoSelecionado.Visible = true;
            lblQuantidade.Location = new Point(24, 552);
            lblQuantidade.ForeColor = corTexto;
            lblQuantidade.Visible = true;
            nudQuantidade.Location = new Point(24, 574);
            nudQuantidade.Size = new Size(72, 30);
            nudQuantidade.Visible = true;
            btnAdicionar.Location = new Point(112, 568);
            btnAdicionar.Size = new Size(182, 42);
            btnAdicionar.BackColor = corVermelho;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.Visible = true;
            btnAlterarItem.Location = new Point(306, 568);
            btnAlterarItem.Size = new Size(120, 42);
            btnAlterarItem.BackColor = Color.FromArgb(236, 239, 243);
            btnAlterarItem.ForeColor = corTexto;
            btnAlterarItem.Text = "Alterar";
            btnAlterarItem.Visible = true;

            barraTotalVisual = new Panel { Location = new Point(0, 612), Size = new Size(620, 58), BackColor = corVermelho, Visible = true };
            pnlCardapio.Controls.Add(barraTotalVisual);
            lblTotal.Parent = barraTotalVisual;
            lblTotal.Location = new Point(110, 12);
            lblTotal.Size = new Size(260, 32);
            lblTotal.ForeColor = Color.White;
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            lblTotal.Visible = true;

            pnlSacola.BackColor = Color.White;
            pnlSacola.Location = new Point(790, 84);
            pnlSacola.Size = new Size(360, 570);
            lblSacola.Text = "Carrinho";
            lblSacola.ForeColor = corTexto;
            lblSacolaSubtitulo.ForeColor = corTextoSecundario;
            dgvCarrinho.Location = new Point(26, 112);
            dgvCarrinho.Size = new Size(308, 260);
            dgvCarrinho.BackgroundColor = corPainel;
            dgvCarrinho.DefaultCellStyle.BackColor = Color.White;
            dgvCarrinho.DefaultCellStyle.ForeColor = corTexto;
            dgvCarrinho.DefaultCellStyle.SelectionBackColor = corVermelho;
            dgvCarrinho.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvCarrinho.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(236, 239, 243);
            dgvCarrinho.ColumnHeadersDefaultCellStyle.ForeColor = corTexto;
            lblItens.Location = new Point(26, 386);
            lblItens.Size = new Size(220, 20);
            btnRemoverItem.Location = new Point(26, 416);
            btnRemoverItem.Size = new Size(145, 42);
            btnLimpar.Location = new Point(189, 416);
            btnLimpar.Size = new Size(145, 42);
            lblPagamento.Location = new Point(26, 474);
            lblPagamento.Size = new Size(180, 20);
            cmbPagamento.Location = new Point(26, 498);
            cmbPagamento.Size = new Size(308, 25);
            btnFinalizar.BackColor = corVermelho;
            btnFinalizar.ForeColor = Color.White;
            btnFinalizar.Location = new Point(26, 530);
            btnFinalizar.Size = new Size(308, 42);
            btnRemoverItem.BackColor = Color.FromArgb(236, 239, 243);
            btnRemoverItem.ForeColor = corTexto;
            btnLimpar.BackColor = corVermelho;
            btnLimpar.ForeColor = Color.White;
            lblItens.ForeColor = corTextoSecundario;
            lblPagamento.ForeColor = corTexto;
        }

        private Label CriarLogo()
        {
            return new Label
            {
                Text = "ALABAMA\nCOMIDARIA",
                Location = new Point(42, 28),
                Size = new Size(96, 80),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = corTexto,
                BackColor = Color.White,
                Visible = true
            };
        }

        private void AtualizarCardsProdutos(List<Produto> lista)
        {
            if (painelProdutosVisual == null) return;
            painelProdutosVisual.Controls.Clear();
            cardsProdutos.Clear();
            foreach (Produto produto in lista)
            {
                Panel card = new Panel { Size = new Size(112, 118), Margin = new Padding(6), BackColor = Color.White, Cursor = Cursors.Hand, Tag = produto.Codigo, BorderStyle = BorderStyle.FixedSingle };
                PictureBox foto = new PictureBox { Location = new Point(0, 0), Size = new Size(112, 70), SizeMode = PictureBoxSizeMode.Zoom, Image = ObterImagemProduto(produto.Nome), BackColor = Color.White };
                Label nome = new Label { Text = produto.Nome, Location = new Point(4, 73), Size = new Size(104, 18), TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 7F, FontStyle.Bold), ForeColor = corTexto };
                Label preco = new Label { Text = "A partir de " + produto.Preco.ToString("C2", cultura), Location = new Point(4, 94), Size = new Size(104, 18), TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 6.5F), ForeColor = corTexto };
                card.Paint += CardProduto_Paint;
                card.Controls.Add(foto); card.Controls.Add(nome); card.Controls.Add(preco);
                card.Click += CardProduto_Click; foto.Click += CardProduto_Click; nome.Click += CardProduto_Click; preco.Click += CardProduto_Click;
                cardsProdutos[produto.Codigo] = card;
                painelProdutosVisual.Controls.Add(card);
            }

            AtualizarProdutoSelecionadoVisual();
        }

        private void CardProduto_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel card || card.Tag is not int codigo)
            {
                return;
            }

            bool selecionado = produtoSelecionado?.Codigo == codigo;
            using Pen pen = new Pen(selecionado ? corVermelho : Color.FromArgb(203, 213, 225), selecionado ? 3 : 1);
            e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, card.Width - 1, card.Height - 1));
        }

        private void AtualizarProdutoSelecionadoVisual()
        {
            foreach (KeyValuePair<int, Panel> par in cardsProdutos)
            {
                bool selecionado = produtoSelecionado?.Codigo == par.Key;
                par.Value.BackColor = selecionado ? Color.FromArgb(231, 240, 253) : Color.White;

                foreach (Control controle in par.Value.Controls)
                {
                    if (controle is PictureBox)
                    {
                        controle.BackColor = selecionado ? Color.FromArgb(231, 240, 253) : Color.White;
                    }
                }

                par.Value.Invalidate();
            }
        }

        private void CardProduto_Click(object? sender, EventArgs e)
        {
            Control? c = sender as Control;
            while (c != null && c.Tag is not int) c = c.Parent;
            if (c?.Tag is int codigo) SelecionarProduto(codigo);
        }

        private Image? ObterImagemProduto(string nome)
        {
            string slug = nome.ToLowerInvariant().Replace(" ", "-");
            slug = slug.Replace("á", "a").Replace("â", "a").Replace("ã", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u");
            string[] caminhos =
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", slug + ".png"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "images", slug + ".png"),
                Path.Combine(Environment.CurrentDirectory, "images", slug + ".png")
            };
            string? caminho = caminhos.FirstOrDefault(File.Exists);
            if (caminho == null)
            {
                return null;
            }

            using Image imagemOriginal = Image.FromFile(caminho);
            return RemoverFundoVerde(imagemOriginal);
        }

        private static Image RemoverFundoVerde(Image imagemOriginal)
        {
            Bitmap bitmap = new Bitmap(imagemOriginal);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    bool fundoVerdeClaro =
                        pixel.R >= 180 &&
                        pixel.G >= 185 &&
                        pixel.B >= 135 &&
                        pixel.G >= pixel.R &&
                        pixel.G >= pixel.B &&
                        pixel.G - pixel.B <= 90;

                    if (fundoVerdeClaro)
                    {
                        bitmap.SetPixel(x, y, Color.White);
                    }
                }
            }

            return bitmap;
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

            Cliente clienteDoPedido = clienteAtual;
            DialogResult cpfNaNota = MessageBox.Show(
                "Deseja colocar CPF na nota?",
                "CPF na nota",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (cpfNaNota == DialogResult.Yes)
            {
                if (clienteAtual.TemCpf)
                {
                    clienteDoPedido = clienteAtual;
                }
                else
                {
                    using FormCpfNota formCpfNota = new FormCpfNota();
                    if (formCpfNota.ShowDialog(this) != DialogResult.OK)
                    {
                        return;
                    }

                    clienteDoPedido = Cliente.CriarComCpf(formCpfNota.CpfInformado);
                }
            }

            int numeroPedido = pedidoService.GerarNumeroPedido();
            Pedido pedido = new Pedido(numeroPedido, clienteDoPedido);
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
            AtualizarProdutoSelecionadoVisual();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            FiltrarProdutos();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarCategoriaAtiva();
            FiltrarProdutos();
        }

        private void AtualizarCategoriaAtiva()
        {
            string categoria = cmbCategoria.SelectedItem?.ToString() ?? "Todas";
            if (lblTituloCategoriaVisual != null)
            {
                lblTituloCategoriaVisual.Text = categoria == "Todas" ? "Todos" : categoria;
            }

            foreach (KeyValuePair<string, Button> par in botoesCategorias)
            {
                bool ativo = par.Key == categoria;
                par.Value.ForeColor = ativo ? corVermelho : corTexto;
                par.Value.Font = new Font("Segoe UI", 10F, ativo ? FontStyle.Bold : FontStyle.Regular);
                par.Value.BackColor = ativo ? Color.FromArgb(231, 240, 253) : Color.White;
            }
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






