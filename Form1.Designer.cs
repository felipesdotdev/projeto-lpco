namespace ProjetoLPCO
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            menuPrincipal = new MenuStrip();
            arquivoToolStripMenuItem = new ToolStripMenuItem();
            novoPedidoToolStripMenuItem = new ToolStripMenuItem();
            finalizarPedidoToolStripMenuItem = new ToolStripMenuItem();
            sairToolStripMenuItem = new ToolStripMenuItem();
            ajudaToolStripMenuItem = new ToolStripMenuItem();
            sobreToolStripMenuItem = new ToolStripMenuItem();
            pnlHeader = new Panel();
            lblCliente = new Label();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            pnlCardapio = new Panel();
            btnAlterarItem = new Button();
            btnAdicionar = new Button();
            chkSemCebola = new CheckBox();
            chkMolhoEspecial = new CheckBox();
            chkBaconExtra = new CheckBox();
            chkQueijoExtra = new CheckBox();
            chkHamburguerExtra = new CheckBox();
            lblPersonalizar = new Label();
            nudQuantidade = new NumericUpDown();
            lblQuantidade = new Label();
            lblProdutoSelecionado = new Label();
            dgvProdutos = new DataGridView();
            btnPesquisar = new Button();
            cmbCategoria = new ComboBox();
            lblCategoria = new Label();
            txtPesquisa = new TextBox();
            lblPesquisa = new Label();
            lblCardapio = new Label();
            pnlSacola = new Panel();
            lblPagamento = new Label();
            cmbPagamento = new ComboBox();
            btnFinalizar = new Button();
            btnLimpar = new Button();
            btnRemoverItem = new Button();
            lblTotal = new Label();
            lblItens = new Label();
            dgvCarrinho = new DataGridView();
            lblSacolaSubtitulo = new Label();
            lblSacola = new Label();
            menuPrincipal.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlCardapio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantidade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            pnlSacola.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrinho).BeginInit();
            SuspendLayout();
            // 
            // menuPrincipal
            // 
            menuPrincipal.BackColor = Color.White;
            menuPrincipal.Items.AddRange(new ToolStripItem[] { arquivoToolStripMenuItem, ajudaToolStripMenuItem });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(1184, 24);
            menuPrincipal.TabIndex = 0;
            menuPrincipal.Text = "menuPrincipal";
            // 
            // arquivoToolStripMenuItem
            // 
            arquivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novoPedidoToolStripMenuItem, finalizarPedidoToolStripMenuItem, sairToolStripMenuItem });
            arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            arquivoToolStripMenuItem.Size = new Size(61, 20);
            arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // novoPedidoToolStripMenuItem
            // 
            novoPedidoToolStripMenuItem.Name = "novoPedidoToolStripMenuItem";
            novoPedidoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            novoPedidoToolStripMenuItem.Size = new Size(208, 22);
            novoPedidoToolStripMenuItem.Text = "Novo pedido";
            novoPedidoToolStripMenuItem.Click += novoPedidoToolStripMenuItem_Click;
            // 
            // finalizarPedidoToolStripMenuItem
            // 
            finalizarPedidoToolStripMenuItem.Name = "finalizarPedidoToolStripMenuItem";
            finalizarPedidoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Enter;
            finalizarPedidoToolStripMenuItem.Size = new Size(208, 22);
            finalizarPedidoToolStripMenuItem.Text = "Finalizar pedido";
            finalizarPedidoToolStripMenuItem.Click += finalizarPedidoToolStripMenuItem_Click;
            // 
            // sairToolStripMenuItem
            // 
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            sairToolStripMenuItem.Size = new Size(208, 22);
            sairToolStripMenuItem.Text = "Sair";
            sairToolStripMenuItem.Click += sairToolStripMenuItem_Click;
            // 
            // ajudaToolStripMenuItem
            // 
            ajudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sobreToolStripMenuItem });
            ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            ajudaToolStripMenuItem.Size = new Size(50, 20);
            ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // sobreToolStripMenuItem
            // 
            sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            sobreToolStripMenuItem.ShortcutKeys = Keys.F1;
            sobreToolStripMenuItem.Size = new Size(126, 22);
            sobreToolStripMenuItem.Text = "Sobre";
            sobreToolStripMenuItem.Click += sobreToolStripMenuItem_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(24, 24, 27);
            pnlHeader.Controls.Add(lblCliente);
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Location = new Point(0, 24);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1184, 90);
            pnlHeader.TabIndex = 1;
            // 
            // lblCliente
            // 
            lblCliente.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblCliente.ForeColor = Color.White;
            lblCliente.Location = new Point(742, 28);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(400, 28);
            lblCliente.TabIndex = 2;
            lblCliente.Text = "Cliente:";
            lblCliente.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblSubtitulo.ForeColor = Color.FromArgb(210, 210, 215);
            lblSubtitulo.Location = new Point(28, 55);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(395, 19);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Monte sua sacola, personalize os itens e finalize o pedido.";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(24, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(245, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Totem Express";
            // 
            // pnlCardapio
            // 
            pnlCardapio.BackColor = Color.White;
            pnlCardapio.Controls.Add(btnAlterarItem);
            pnlCardapio.Controls.Add(btnAdicionar);
            pnlCardapio.Controls.Add(chkSemCebola);
            pnlCardapio.Controls.Add(chkMolhoEspecial);
            pnlCardapio.Controls.Add(chkBaconExtra);
            pnlCardapio.Controls.Add(chkQueijoExtra);
            pnlCardapio.Controls.Add(chkHamburguerExtra);
            pnlCardapio.Controls.Add(lblPersonalizar);
            pnlCardapio.Controls.Add(nudQuantidade);
            pnlCardapio.Controls.Add(lblQuantidade);
            pnlCardapio.Controls.Add(lblProdutoSelecionado);
            pnlCardapio.Controls.Add(dgvProdutos);
            pnlCardapio.Controls.Add(btnPesquisar);
            pnlCardapio.Controls.Add(cmbCategoria);
            pnlCardapio.Controls.Add(lblCategoria);
            pnlCardapio.Controls.Add(txtPesquisa);
            pnlCardapio.Controls.Add(lblPesquisa);
            pnlCardapio.Controls.Add(lblCardapio);
            pnlCardapio.Location = new Point(20, 132);
            pnlCardapio.Name = "pnlCardapio";
            pnlCardapio.Size = new Size(700, 548);
            pnlCardapio.TabIndex = 2;
            // 
            // btnAlterarItem
            // 
            btnAlterarItem.BackColor = Color.FromArgb(244, 244, 245);
            btnAlterarItem.Cursor = Cursors.Hand;
            btnAlterarItem.FlatAppearance.BorderColor = Color.FromArgb(210, 210, 215);
            btnAlterarItem.FlatStyle = FlatStyle.Flat;
            btnAlterarItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAlterarItem.ForeColor = Color.FromArgb(39, 39, 42);
            btnAlterarItem.Location = new Point(469, 486);
            btnAlterarItem.Name = "btnAlterarItem";
            btnAlterarItem.Size = new Size(203, 38);
            btnAlterarItem.TabIndex = 9;
            btnAlterarItem.Text = "Alterar item selecionado";
            btnAlterarItem.UseVisualStyleBackColor = false;
            btnAlterarItem.Click += btnAlterarItem_Click;
            // 
            // btnAdicionar
            // 
            btnAdicionar.BackColor = Color.FromArgb(24, 24, 27);
            btnAdicionar.Cursor = Cursors.Hand;
            btnAdicionar.FlatAppearance.BorderSize = 0;
            btnAdicionar.FlatStyle = FlatStyle.Flat;
            btnAdicionar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdicionar.ForeColor = Color.White;
            btnAdicionar.Location = new Point(248, 486);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(203, 38);
            btnAdicionar.TabIndex = 8;
            btnAdicionar.Text = "Adicionar à sacola";
            btnAdicionar.UseVisualStyleBackColor = false;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // chkSemCebola
            // 
            chkSemCebola.AutoSize = true;
            chkSemCebola.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chkSemCebola.ForeColor = Color.FromArgb(63, 63, 70);
            chkSemCebola.Location = new Point(524, 439);
            chkSemCebola.Name = "chkSemCebola";
            chkSemCebola.Size = new Size(85, 19);
            chkSemCebola.TabIndex = 7;
            chkSemCebola.Text = "Sem cebola";
            chkSemCebola.UseVisualStyleBackColor = true;
            // 
            // chkMolhoEspecial
            // 
            chkMolhoEspecial.AutoSize = true;
            chkMolhoEspecial.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chkMolhoEspecial.ForeColor = Color.FromArgb(63, 63, 70);
            chkMolhoEspecial.Location = new Point(395, 439);
            chkMolhoEspecial.Name = "chkMolhoEspecial";
            chkMolhoEspecial.Size = new Size(127, 19);
            chkMolhoEspecial.TabIndex = 6;
            chkMolhoEspecial.Text = "Molho especial +2";
            chkMolhoEspecial.UseVisualStyleBackColor = true;
            // 
            // chkBaconExtra
            // 
            chkBaconExtra.AutoSize = true;
            chkBaconExtra.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chkBaconExtra.ForeColor = Color.FromArgb(63, 63, 70);
            chkBaconExtra.Location = new Point(284, 439);
            chkBaconExtra.Name = "chkBaconExtra";
            chkBaconExtra.Size = new Size(107, 19);
            chkBaconExtra.TabIndex = 5;
            chkBaconExtra.Text = "Bacon extra +5";
            chkBaconExtra.UseVisualStyleBackColor = true;
            // 
            // chkQueijoExtra
            // 
            chkQueijoExtra.AutoSize = true;
            chkQueijoExtra.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chkQueijoExtra.ForeColor = Color.FromArgb(63, 63, 70);
            chkQueijoExtra.Location = new Point(161, 439);
            chkQueijoExtra.Name = "chkQueijoExtra";
            chkQueijoExtra.Size = new Size(112, 19);
            chkQueijoExtra.TabIndex = 4;
            chkQueijoExtra.Text = "Queijo extra +3";
            chkQueijoExtra.UseVisualStyleBackColor = true;
            // 
            // chkHamburguerExtra
            // 
            chkHamburguerExtra.AutoSize = true;
            chkHamburguerExtra.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chkHamburguerExtra.ForeColor = Color.FromArgb(63, 63, 70);
            chkHamburguerExtra.Location = new Point(22, 439);
            chkHamburguerExtra.Name = "chkHamburguerExtra";
            chkHamburguerExtra.Size = new Size(135, 19);
            chkHamburguerExtra.TabIndex = 3;
            chkHamburguerExtra.Text = "Hambúrguer extra +6";
            chkHamburguerExtra.UseVisualStyleBackColor = true;
            // 
            // lblPersonalizar
            // 
            lblPersonalizar.AutoSize = true;
            lblPersonalizar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblPersonalizar.ForeColor = Color.FromArgb(39, 39, 42);
            lblPersonalizar.Location = new Point(22, 412);
            lblPersonalizar.Name = "lblPersonalizar";
            lblPersonalizar.Size = new Size(149, 19);
            lblPersonalizar.TabIndex = 17;
            lblPersonalizar.Text = "Personalizar pedido";
            // 
            // nudQuantidade
            // 
            nudQuantidade.BackColor = Color.FromArgb(250, 250, 250);
            nudQuantidade.BorderStyle = BorderStyle.FixedSingle;
            nudQuantidade.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            nudQuantidade.Location = new Point(22, 491);
            nudQuantidade.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            nudQuantidade.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantidade.Name = "nudQuantidade";
            nudQuantidade.Size = new Size(196, 27);
            nudQuantidade.TabIndex = 2;
            nudQuantidade.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQuantidade
            // 
            lblQuantidade.AutoSize = true;
            lblQuantidade.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblQuantidade.ForeColor = Color.FromArgb(82, 82, 91);
            lblQuantidade.Location = new Point(22, 470);
            lblQuantidade.Name = "lblQuantidade";
            lblQuantidade.Size = new Size(72, 15);
            lblQuantidade.TabIndex = 15;
            lblQuantidade.Text = "Quantidade";
            // 
            // lblProdutoSelecionado
            // 
            lblProdutoSelecionado.AutoSize = true;
            lblProdutoSelecionado.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblProdutoSelecionado.ForeColor = Color.FromArgb(24, 24, 27);
            lblProdutoSelecionado.Location = new Point(22, 383);
            lblProdutoSelecionado.Name = "lblProdutoSelecionado";
            lblProdutoSelecionado.Size = new Size(249, 19);
            lblProdutoSelecionado.TabIndex = 14;
            lblProdutoSelecionado.Text = "Selecione um produto do cardápio";
            // 
            // dgvProdutos
            // 
            dgvProdutos.AllowUserToAddRows = false;
            dgvProdutos.AllowUserToDeleteRows = false;
            dgvProdutos.BackgroundColor = Color.White;
            dgvProdutos.BorderStyle = BorderStyle.None;
            dgvProdutos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProdutos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvProdutos.ColumnHeadersHeight = 32;
            dgvProdutos.EnableHeadersVisualStyles = false;
            dgvProdutos.GridColor = Color.FromArgb(235, 235, 240);
            dgvProdutos.Location = new Point(22, 126);
            dgvProdutos.MultiSelect = false;
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.ReadOnly = true;
            dgvProdutos.RowHeadersVisible = false;
            dgvProdutos.RowTemplate.Height = 34;
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.Size = new Size(650, 238);
            dgvProdutos.TabIndex = 10;
            dgvProdutos.CellClick += dgvProdutos_CellClick;
            // 
            // btnPesquisar
            // 
            btnPesquisar.BackColor = Color.FromArgb(244, 244, 245);
            btnPesquisar.Cursor = Cursors.Hand;
            btnPesquisar.FlatAppearance.BorderColor = Color.FromArgb(210, 210, 215);
            btnPesquisar.FlatStyle = FlatStyle.Flat;
            btnPesquisar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnPesquisar.ForeColor = Color.FromArgb(39, 39, 42);
            btnPesquisar.Location = new Point(577, 76);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(95, 31);
            btnPesquisar.TabIndex = 2;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = false;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // cmbCategoria
            // 
            cmbCategoria.BackColor = Color.FromArgb(250, 250, 250);
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FlatStyle = FlatStyle.Flat;
            cmbCategoria.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(411, 79);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(150, 25);
            cmbCategoria.TabIndex = 1;
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCategoria.ForeColor = Color.FromArgb(82, 82, 91);
            lblCategoria.Location = new Point(411, 57);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(61, 15);
            lblCategoria.TabIndex = 5;
            lblCategoria.Text = "Categoria";
            // 
            // txtPesquisa
            // 
            txtPesquisa.BackColor = Color.FromArgb(250, 250, 250);
            txtPesquisa.BorderStyle = BorderStyle.FixedSingle;
            txtPesquisa.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtPesquisa.Location = new Point(22, 78);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.PlaceholderText = "Ex: X-Tudo, batata ou código 101";
            txtPesquisa.Size = new Size(371, 27);
            txtPesquisa.TabIndex = 0;
            txtPesquisa.TextChanged += txtPesquisa_TextChanged;
            // 
            // lblPesquisa
            // 
            lblPesquisa.AutoSize = true;
            lblPesquisa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPesquisa.ForeColor = Color.FromArgb(82, 82, 91);
            lblPesquisa.Location = new Point(22, 57);
            lblPesquisa.Name = "lblPesquisa";
            lblPesquisa.Size = new Size(112, 15);
            lblPesquisa.TabIndex = 3;
            lblPesquisa.Text = "Pesquisar produto";
            // 
            // lblCardapio
            // 
            lblCardapio.AutoSize = true;
            lblCardapio.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblCardapio.ForeColor = Color.FromArgb(24, 24, 27);
            lblCardapio.Location = new Point(20, 18);
            lblCardapio.Name = "lblCardapio";
            lblCardapio.Size = new Size(108, 30);
            lblCardapio.TabIndex = 0;
            lblCardapio.Text = "Cardápio";
            // 
            // pnlSacola
            // 
            pnlSacola.BackColor = Color.White;
            pnlSacola.Controls.Add(lblPagamento);
            pnlSacola.Controls.Add(cmbPagamento);
            pnlSacola.Controls.Add(btnFinalizar);
            pnlSacola.Controls.Add(btnLimpar);
            pnlSacola.Controls.Add(btnRemoverItem);
            pnlSacola.Controls.Add(lblTotal);
            pnlSacola.Controls.Add(lblItens);
            pnlSacola.Controls.Add(dgvCarrinho);
            pnlSacola.Controls.Add(lblSacolaSubtitulo);
            pnlSacola.Controls.Add(lblSacola);
            pnlSacola.Location = new Point(740, 132);
            pnlSacola.Name = "pnlSacola";
            pnlSacola.Size = new Size(424, 548);
            pnlSacola.TabIndex = 3;
            // 
            // lblPagamento
            // 
            lblPagamento.AutoSize = true;
            lblPagamento.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPagamento.ForeColor = Color.FromArgb(82, 82, 91);
            lblPagamento.Location = new Point(22, 389);
            lblPagamento.Name = "lblPagamento";
            lblPagamento.Size = new Size(130, 15);
            lblPagamento.TabIndex = 9;
            lblPagamento.Text = "Forma de pagamento";
            // 
            // cmbPagamento
            // 
            cmbPagamento.BackColor = Color.FromArgb(250, 250, 250);
            cmbPagamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPagamento.FlatStyle = FlatStyle.Flat;
            cmbPagamento.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbPagamento.FormattingEnabled = true;
            cmbPagamento.Items.AddRange(new object[] { "Pix", "Cartão de crédito", "Cartão de débito", "Dinheiro" });
            cmbPagamento.Location = new Point(22, 411);
            cmbPagamento.Name = "cmbPagamento";
            cmbPagamento.Size = new Size(378, 25);
            cmbPagamento.TabIndex = 10;
            // 
            // btnFinalizar
            // 
            btnFinalizar.BackColor = Color.FromArgb(24, 24, 27);
            btnFinalizar.Cursor = Cursors.Hand;
            btnFinalizar.FlatAppearance.BorderSize = 0;
            btnFinalizar.FlatStyle = FlatStyle.Flat;
            btnFinalizar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnFinalizar.ForeColor = Color.White;
            btnFinalizar.Location = new Point(22, 480);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(378, 44);
            btnFinalizar.TabIndex = 13;
            btnFinalizar.Text = "Finalizar pedido";
            btnFinalizar.UseVisualStyleBackColor = false;
            btnFinalizar.Click += btnFinalizar_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.BackColor = Color.FromArgb(244, 244, 245);
            btnLimpar.Cursor = Cursors.Hand;
            btnLimpar.FlatAppearance.BorderColor = Color.FromArgb(210, 210, 215);
            btnLimpar.FlatStyle = FlatStyle.Flat;
            btnLimpar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnLimpar.ForeColor = Color.FromArgb(39, 39, 42);
            btnLimpar.Location = new Point(218, 333);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(182, 34);
            btnLimpar.TabIndex = 12;
            btnLimpar.Text = "Novo / limpar";
            btnLimpar.UseVisualStyleBackColor = false;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnRemoverItem
            // 
            btnRemoverItem.BackColor = Color.FromArgb(244, 244, 245);
            btnRemoverItem.Cursor = Cursors.Hand;
            btnRemoverItem.FlatAppearance.BorderColor = Color.FromArgb(210, 210, 215);
            btnRemoverItem.FlatStyle = FlatStyle.Flat;
            btnRemoverItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRemoverItem.ForeColor = Color.FromArgb(39, 39, 42);
            btnRemoverItem.Location = new Point(22, 333);
            btnRemoverItem.Name = "btnRemoverItem";
            btnRemoverItem.Size = new Size(182, 34);
            btnRemoverItem.TabIndex = 11;
            btnRemoverItem.Text = "Remover item";
            btnRemoverItem.UseVisualStyleBackColor = false;
            btnRemoverItem.Click += btnRemoverItem_Click;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotal.ForeColor = Color.FromArgb(24, 24, 27);
            lblTotal.Location = new Point(22, 439);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(378, 36);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "Total: R$ 0,00";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblItens
            // 
            lblItens.AutoSize = true;
            lblItens.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblItens.ForeColor = Color.FromArgb(100, 100, 110);
            lblItens.Location = new Point(22, 310);
            lblItens.Name = "lblItens";
            lblItens.Size = new Size(105, 15);
            lblItens.TabIndex = 4;
            lblItens.Text = "0 item(ns) na sacola";
            // 
            // dgvCarrinho
            // 
            dgvCarrinho.AllowUserToAddRows = false;
            dgvCarrinho.AllowUserToDeleteRows = false;
            dgvCarrinho.BackgroundColor = Color.White;
            dgvCarrinho.BorderStyle = BorderStyle.None;
            dgvCarrinho.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCarrinho.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCarrinho.ColumnHeadersHeight = 32;
            dgvCarrinho.EnableHeadersVisualStyles = false;
            dgvCarrinho.GridColor = Color.FromArgb(235, 235, 240);
            dgvCarrinho.Location = new Point(22, 88);
            dgvCarrinho.MultiSelect = false;
            dgvCarrinho.Name = "dgvCarrinho";
            dgvCarrinho.ReadOnly = true;
            dgvCarrinho.RowHeadersVisible = false;
            dgvCarrinho.RowTemplate.Height = 34;
            dgvCarrinho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrinho.Size = new Size(378, 212);
            dgvCarrinho.TabIndex = 3;
            dgvCarrinho.CellClick += dgvCarrinho_CellClick;
            // 
            // lblSacolaSubtitulo
            // 
            lblSacolaSubtitulo.AutoSize = true;
            lblSacolaSubtitulo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblSacolaSubtitulo.ForeColor = Color.FromArgb(100, 100, 110);
            lblSacolaSubtitulo.Location = new Point(24, 52);
            lblSacolaSubtitulo.Name = "lblSacolaSubtitulo";
            lblSacolaSubtitulo.Size = new Size(309, 15);
            lblSacolaSubtitulo.TabIndex = 2;
            lblSacolaSubtitulo.Text = "Clique em um item para alterar quantidade ou adicionais.";
            // 
            // lblSacola
            // 
            lblSacola.AutoSize = true;
            lblSacola.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblSacola.ForeColor = Color.FromArgb(24, 24, 27);
            lblSacola.Location = new Point(20, 18);
            lblSacola.Name = "lblSacola";
            lblSacola.Size = new Size(79, 30);
            lblSacola.TabIndex = 1;
            lblSacola.Text = "Sacola";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 244, 245);
            ClientSize = new Size(1184, 701);
            Controls.Add(pnlSacola);
            Controls.Add(pnlCardapio);
            Controls.Add(pnlHeader);
            Controls.Add(menuPrincipal);
            MainMenuStrip = menuPrincipal;
            MinimumSize = new Size(1200, 740);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Totem Express - Autoatendimento";
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlCardapio.ResumeLayout(false);
            pnlCardapio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantidade).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            pnlSacola.ResumeLayout(false);
            pnlSacola.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrinho).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuPrincipal;
        private ToolStripMenuItem arquivoToolStripMenuItem;
        private ToolStripMenuItem novoPedidoToolStripMenuItem;
        private ToolStripMenuItem finalizarPedidoToolStripMenuItem;
        private ToolStripMenuItem sairToolStripMenuItem;
        private ToolStripMenuItem ajudaToolStripMenuItem;
        private ToolStripMenuItem sobreToolStripMenuItem;
        private Panel pnlHeader;
        private Label lblCliente;
        private Label lblSubtitulo;
        private Label lblTitulo;
        private Panel pnlCardapio;
        private Label lblCardapio;
        private TextBox txtPesquisa;
        private Label lblPesquisa;
        private ComboBox cmbCategoria;
        private Label lblCategoria;
        private Button btnPesquisar;
        private DataGridView dgvProdutos;
        private Label lblProdutoSelecionado;
        private NumericUpDown nudQuantidade;
        private Label lblQuantidade;
        private Label lblPersonalizar;
        private CheckBox chkSemCebola;
        private CheckBox chkMolhoEspecial;
        private CheckBox chkBaconExtra;
        private CheckBox chkQueijoExtra;
        private CheckBox chkHamburguerExtra;
        private Button btnAdicionar;
        private Button btnAlterarItem;
        private Panel pnlSacola;
        private Label lblSacola;
        private Label lblSacolaSubtitulo;
        private DataGridView dgvCarrinho;
        private Label lblItens;
        private Label lblTotal;
        private Button btnLimpar;
        private Button btnRemoverItem;
        private Button btnFinalizar;
        private Label lblPagamento;
        private ComboBox cmbPagamento;
    }
}
