namespace ProjetoJanela
{
    partial class CompGrafica
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBox = new System.Windows.Forms.PictureBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.btnRemover = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPonto = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.cordYPonto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalvPonto = new System.Windows.Forms.Button();
            this.cordXPonto = new System.Windows.Forms.TextBox();
            this.nomePonto = new System.Windows.Forms.TextBox();
            this.tabLinha = new System.Windows.Forms.TabPage();
            this.btnSalvLinha = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cordY1Linha = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cordY2Linha = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cordX2Linha = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cordX1Linha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nomeLinha = new System.Windows.Forms.TextBox();
            this.tabPolilinha = new System.Windows.Forms.TabPage();
            this.btnSalvPolilinha = new System.Windows.Forms.Button();
            this.gridPolilinha = new System.Windows.Forms.DataGridView();
            this.colunaX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.nomePolilinha = new System.Windows.Forms.TextBox();
            this.tabPoligono = new System.Windows.Forms.TabPage();
            this.btnSalvPoligono = new System.Windows.Forms.Button();
            this.gridPoligono = new System.Windows.Forms.DataGridView();
            this.coluX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.nomePoligono = new System.Windows.Forms.TextBox();
            this.btnMais = new System.Windows.Forms.Button();
            this.btnMenos = new System.Windows.Forms.Button();
            this.btnBaixo = new System.Windows.Forms.Button();
            this.brnEsq = new System.Windows.Forms.Button();
            this.btnDir = new System.Windows.Forms.Button();
            this.btnCima = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTranslacao = new System.Windows.Forms.TabPage();
            this.btnTCancela = new System.Windows.Forms.Button();
            this.btnTConfirma = new System.Windows.Forms.Button();
            this.txtTransY = new System.Windows.Forms.TextBox();
            this.txtTransX = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabRotacao = new System.Windows.Forms.TabPage();
            this.btnRCancela = new System.Windows.Forms.Button();
            this.btnRConfirma = new System.Windows.Forms.Button();
            this.txtRota = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabEscalonamento = new System.Windows.Forms.TabPage();
            this.txtEscalaY = new System.Windows.Forms.TextBox();
            this.txtEscalaX = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btnECancela = new System.Windows.Forms.Button();
            this.btnEConfirma = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPonto.SuspendLayout();
            this.tabLinha.SuspendLayout();
            this.tabPolilinha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPolilinha)).BeginInit();
            this.tabPoligono.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPoligono)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabTranslacao.SuspendLayout();
            this.tabRotacao.SuspendLayout();
            this.tabEscalonamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picBox.Location = new System.Drawing.Point(326, 12);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(600, 600);
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            this.picBox.Paint += new System.Windows.Forms.PaintEventHandler(this.picBox_Paint);
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.SystemColors.Menu;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 12);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(309, 173);
            this.listBox.TabIndex = 1;
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(12, 191);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(75, 23);
            this.btnRemover.TabIndex = 3;
            this.btnRemover.Text = "Apagar";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPonto);
            this.tabControl.Controls.Add(this.tabLinha);
            this.tabControl.Controls.Add(this.tabPolilinha);
            this.tabControl.Controls.Add(this.tabPoligono);
            this.tabControl.Location = new System.Drawing.Point(12, 235);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(308, 274);
            this.tabControl.TabIndex = 4;
            // 
            // tabPonto
            // 
            this.tabPonto.Controls.Add(this.label6);
            this.tabPonto.Controls.Add(this.cordYPonto);
            this.tabPonto.Controls.Add(this.label2);
            this.tabPonto.Controls.Add(this.label1);
            this.tabPonto.Controls.Add(this.btnSalvPonto);
            this.tabPonto.Controls.Add(this.cordXPonto);
            this.tabPonto.Controls.Add(this.nomePonto);
            this.tabPonto.Location = new System.Drawing.Point(4, 22);
            this.tabPonto.Name = "tabPonto";
            this.tabPonto.Padding = new System.Windows.Forms.Padding(3);
            this.tabPonto.Size = new System.Drawing.Size(300, 248);
            this.tabPonto.TabIndex = 0;
            this.tabPonto.Text = "Ponto";
            this.tabPonto.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Coordenada Y";
            // 
            // cordYPonto
            // 
            this.cordYPonto.Location = new System.Drawing.Point(7, 108);
            this.cordYPonto.Name = "cordYPonto";
            this.cordYPonto.Size = new System.Drawing.Size(100, 20);
            this.cordYPonto.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Coordenada X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome";
            // 
            // btnSalvPonto
            // 
            this.btnSalvPonto.Location = new System.Drawing.Point(7, 145);
            this.btnSalvPonto.Name = "btnSalvPonto";
            this.btnSalvPonto.Size = new System.Drawing.Size(100, 23);
            this.btnSalvPonto.TabIndex = 2;
            this.btnSalvPonto.Text = "Salvar";
            this.btnSalvPonto.UseVisualStyleBackColor = true;
            this.btnSalvPonto.Click += new System.EventHandler(this.btnSalvPonto_Click);
            // 
            // cordXPonto
            // 
            this.cordXPonto.Location = new System.Drawing.Point(7, 69);
            this.cordXPonto.Name = "cordXPonto";
            this.cordXPonto.Size = new System.Drawing.Size(100, 20);
            this.cordXPonto.TabIndex = 1;
            // 
            // nomePonto
            // 
            this.nomePonto.Location = new System.Drawing.Point(7, 30);
            this.nomePonto.Name = "nomePonto";
            this.nomePonto.Size = new System.Drawing.Size(100, 20);
            this.nomePonto.TabIndex = 0;
            // 
            // tabLinha
            // 
            this.tabLinha.Controls.Add(this.btnSalvLinha);
            this.tabLinha.Controls.Add(this.label10);
            this.tabLinha.Controls.Add(this.cordY1Linha);
            this.tabLinha.Controls.Add(this.label9);
            this.tabLinha.Controls.Add(this.cordY2Linha);
            this.tabLinha.Controls.Add(this.label8);
            this.tabLinha.Controls.Add(this.cordX2Linha);
            this.tabLinha.Controls.Add(this.label7);
            this.tabLinha.Controls.Add(this.cordX1Linha);
            this.tabLinha.Controls.Add(this.label3);
            this.tabLinha.Controls.Add(this.nomeLinha);
            this.tabLinha.Location = new System.Drawing.Point(4, 22);
            this.tabLinha.Name = "tabLinha";
            this.tabLinha.Padding = new System.Windows.Forms.Padding(3);
            this.tabLinha.Size = new System.Drawing.Size(300, 248);
            this.tabLinha.TabIndex = 1;
            this.tabLinha.Text = "Linha";
            // 
            // btnSalvLinha
            // 
            this.btnSalvLinha.Location = new System.Drawing.Point(6, 144);
            this.btnSalvLinha.Name = "btnSalvLinha";
            this.btnSalvLinha.Size = new System.Drawing.Size(100, 23);
            this.btnSalvLinha.TabIndex = 14;
            this.btnSalvLinha.Text = "Salvar";
            this.btnSalvLinha.UseVisualStyleBackColor = true;
            this.btnSalvLinha.Click += new System.EventHandler(this.btnSalvLinha_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(111, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Y1";
            // 
            // cordY1Linha
            // 
            this.cordY1Linha.Location = new System.Drawing.Point(111, 68);
            this.cordY1Linha.Name = "cordY1Linha";
            this.cordY1Linha.Size = new System.Drawing.Size(100, 20);
            this.cordY1Linha.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(112, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Y2";
            // 
            // cordY2Linha
            // 
            this.cordY2Linha.Location = new System.Drawing.Point(112, 107);
            this.cordY2Linha.Name = "cordY2Linha";
            this.cordY2Linha.Size = new System.Drawing.Size(100, 20);
            this.cordY2Linha.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "X2";
            // 
            // cordX2Linha
            // 
            this.cordX2Linha.Location = new System.Drawing.Point(6, 107);
            this.cordX2Linha.Name = "cordX2Linha";
            this.cordX2Linha.Size = new System.Drawing.Size(100, 20);
            this.cordX2Linha.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "X1";
            // 
            // cordX1Linha
            // 
            this.cordX1Linha.Location = new System.Drawing.Point(6, 68);
            this.cordX1Linha.Name = "cordX1Linha";
            this.cordX1Linha.Size = new System.Drawing.Size(100, 20);
            this.cordX1Linha.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nome";
            // 
            // nomeLinha
            // 
            this.nomeLinha.Location = new System.Drawing.Point(6, 29);
            this.nomeLinha.Name = "nomeLinha";
            this.nomeLinha.Size = new System.Drawing.Size(100, 20);
            this.nomeLinha.TabIndex = 4;
            // 
            // tabPolilinha
            // 
            this.tabPolilinha.Controls.Add(this.btnSalvPolilinha);
            this.tabPolilinha.Controls.Add(this.gridPolilinha);
            this.tabPolilinha.Controls.Add(this.label4);
            this.tabPolilinha.Controls.Add(this.nomePolilinha);
            this.tabPolilinha.Location = new System.Drawing.Point(4, 22);
            this.tabPolilinha.Name = "tabPolilinha";
            this.tabPolilinha.Size = new System.Drawing.Size(300, 248);
            this.tabPolilinha.TabIndex = 2;
            this.tabPolilinha.Text = "Polilinha";
            this.tabPolilinha.UseVisualStyleBackColor = true;
            // 
            // btnSalvPolilinha
            // 
            this.btnSalvPolilinha.Location = new System.Drawing.Point(6, 215);
            this.btnSalvPolilinha.Name = "btnSalvPolilinha";
            this.btnSalvPolilinha.Size = new System.Drawing.Size(100, 23);
            this.btnSalvPolilinha.TabIndex = 15;
            this.btnSalvPolilinha.Text = "Salvar";
            this.btnSalvPolilinha.UseVisualStyleBackColor = true;
            this.btnSalvPolilinha.Click += new System.EventHandler(this.btnSalvPolilinha_Click);
            // 
            // gridPolilinha
            // 
            this.gridPolilinha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPolilinha.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaX,
            this.colunaY});
            this.gridPolilinha.Location = new System.Drawing.Point(6, 59);
            this.gridPolilinha.Name = "gridPolilinha";
            this.gridPolilinha.Size = new System.Drawing.Size(283, 150);
            this.gridPolilinha.TabIndex = 8;
            // 
            // colunaX
            // 
            this.colunaX.HeaderText = "Cord. X";
            this.colunaX.Name = "colunaX";
            // 
            // colunaY
            // 
            this.colunaY.HeaderText = "Cord. Y";
            this.colunaY.Name = "colunaY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nome";
            // 
            // nomePolilinha
            // 
            this.nomePolilinha.Location = new System.Drawing.Point(3, 32);
            this.nomePolilinha.Name = "nomePolilinha";
            this.nomePolilinha.Size = new System.Drawing.Size(100, 20);
            this.nomePolilinha.TabIndex = 6;
            // 
            // tabPoligono
            // 
            this.tabPoligono.Controls.Add(this.btnSalvPoligono);
            this.tabPoligono.Controls.Add(this.gridPoligono);
            this.tabPoligono.Controls.Add(this.label5);
            this.tabPoligono.Controls.Add(this.nomePoligono);
            this.tabPoligono.Location = new System.Drawing.Point(4, 22);
            this.tabPoligono.Name = "tabPoligono";
            this.tabPoligono.Size = new System.Drawing.Size(300, 248);
            this.tabPoligono.TabIndex = 3;
            this.tabPoligono.Text = "Poligono";
            this.tabPoligono.UseVisualStyleBackColor = true;
            // 
            // btnSalvPoligono
            // 
            this.btnSalvPoligono.Location = new System.Drawing.Point(6, 213);
            this.btnSalvPoligono.Name = "btnSalvPoligono";
            this.btnSalvPoligono.Size = new System.Drawing.Size(100, 23);
            this.btnSalvPoligono.TabIndex = 17;
            this.btnSalvPoligono.Text = "Salvar";
            this.btnSalvPoligono.UseVisualStyleBackColor = true;
            this.btnSalvPoligono.Click += new System.EventHandler(this.btnSalvPoligono_Click);
            // 
            // gridPoligono
            // 
            this.gridPoligono.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPoligono.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coluX,
            this.coluY});
            this.gridPoligono.Location = new System.Drawing.Point(6, 57);
            this.gridPoligono.Name = "gridPoligono";
            this.gridPoligono.Size = new System.Drawing.Size(280, 150);
            this.gridPoligono.TabIndex = 16;
            // 
            // coluX
            // 
            this.coluX.HeaderText = "Cord. X";
            this.coluX.Name = "coluX";
            // 
            // coluY
            // 
            this.coluY.HeaderText = "Cord. Y";
            this.coluY.Name = "coluY";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nome";
            // 
            // nomePoligono
            // 
            this.nomePoligono.Location = new System.Drawing.Point(3, 31);
            this.nomePoligono.Name = "nomePoligono";
            this.nomePoligono.Size = new System.Drawing.Size(100, 20);
            this.nomePoligono.TabIndex = 6;
            // 
            // btnMais
            // 
            this.btnMais.Location = new System.Drawing.Point(36, 531);
            this.btnMais.Name = "btnMais";
            this.btnMais.Size = new System.Drawing.Size(75, 23);
            this.btnMais.TabIndex = 5;
            this.btnMais.Text = "Zoom In";
            this.btnMais.UseVisualStyleBackColor = true;
            this.btnMais.Click += new System.EventHandler(this.btnMais_Click);
            // 
            // btnMenos
            // 
            this.btnMenos.Location = new System.Drawing.Point(36, 574);
            this.btnMenos.Name = "btnMenos";
            this.btnMenos.Size = new System.Drawing.Size(75, 23);
            this.btnMenos.TabIndex = 6;
            this.btnMenos.Text = "Zoom Out";
            this.btnMenos.UseVisualStyleBackColor = true;
            this.btnMenos.Click += new System.EventHandler(this.btnMenos_Click);
            // 
            // btnBaixo
            // 
            this.btnBaixo.Location = new System.Drawing.Point(187, 589);
            this.btnBaixo.Name = "btnBaixo";
            this.btnBaixo.Size = new System.Drawing.Size(75, 23);
            this.btnBaixo.TabIndex = 7;
            this.btnBaixo.Text = "Baixo";
            this.btnBaixo.UseVisualStyleBackColor = true;
            this.btnBaixo.Click += new System.EventHandler(this.btnBaixo_Click);
            // 
            // brnEsq
            // 
            this.brnEsq.Location = new System.Drawing.Point(127, 560);
            this.brnEsq.Name = "brnEsq";
            this.brnEsq.Size = new System.Drawing.Size(75, 23);
            this.brnEsq.TabIndex = 8;
            this.brnEsq.Text = "Esquerda";
            this.brnEsq.UseVisualStyleBackColor = true;
            this.brnEsq.Click += new System.EventHandler(this.btnEsq_Click);
            // 
            // btnDir
            // 
            this.btnDir.Location = new System.Drawing.Point(242, 561);
            this.btnDir.Name = "btnDir";
            this.btnDir.Size = new System.Drawing.Size(75, 23);
            this.btnDir.TabIndex = 9;
            this.btnDir.Text = "Direita";
            this.btnDir.UseVisualStyleBackColor = true;
            this.btnDir.Click += new System.EventHandler(this.btnDir_Click);
            // 
            // btnCima
            // 
            this.btnCima.Location = new System.Drawing.Point(187, 531);
            this.btnCima.Name = "btnCima";
            this.btnCima.Size = new System.Drawing.Size(75, 23);
            this.btnCima.TabIndex = 10;
            this.btnCima.Text = "Cima";
            this.btnCima.UseVisualStyleBackColor = true;
            this.btnCima.Click += new System.EventHandler(this.btnCima_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTranslacao);
            this.tabControl1.Controls.Add(this.tabRotacao);
            this.tabControl1.Controls.Add(this.tabEscalonamento);
            this.tabControl1.Location = new System.Drawing.Point(932, 33);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(219, 180);
            this.tabControl1.TabIndex = 11;
            // 
            // tabTranslacao
            // 
            this.tabTranslacao.Controls.Add(this.btnTCancela);
            this.tabTranslacao.Controls.Add(this.btnTConfirma);
            this.tabTranslacao.Controls.Add(this.txtTransY);
            this.tabTranslacao.Controls.Add(this.txtTransX);
            this.tabTranslacao.Controls.Add(this.label14);
            this.tabTranslacao.Controls.Add(this.label13);
            this.tabTranslacao.Controls.Add(this.label12);
            this.tabTranslacao.Location = new System.Drawing.Point(4, 22);
            this.tabTranslacao.Margin = new System.Windows.Forms.Padding(2);
            this.tabTranslacao.Name = "tabTranslacao";
            this.tabTranslacao.Padding = new System.Windows.Forms.Padding(2);
            this.tabTranslacao.Size = new System.Drawing.Size(211, 154);
            this.tabTranslacao.TabIndex = 0;
            this.tabTranslacao.Text = "Translação";
            this.tabTranslacao.UseVisualStyleBackColor = true;
            // 
            // btnTCancela
            // 
            this.btnTCancela.Location = new System.Drawing.Point(66, 133);
            this.btnTCancela.Margin = new System.Windows.Forms.Padding(2);
            this.btnTCancela.Name = "btnTCancela";
            this.btnTCancela.Size = new System.Drawing.Size(56, 19);
            this.btnTCancela.TabIndex = 6;
            this.btnTCancela.Text = "Cancelar";
            this.btnTCancela.UseVisualStyleBackColor = true;
            this.btnTCancela.Click += new System.EventHandler(this.btnTCancela_Click);
            // 
            // btnTConfirma
            // 
            this.btnTConfirma.Location = new System.Drawing.Point(4, 133);
            this.btnTConfirma.Margin = new System.Windows.Forms.Padding(2);
            this.btnTConfirma.Name = "btnTConfirma";
            this.btnTConfirma.Size = new System.Drawing.Size(56, 19);
            this.btnTConfirma.TabIndex = 5;
            this.btnTConfirma.Text = "Confirmar";
            this.btnTConfirma.UseVisualStyleBackColor = true;
            this.btnTConfirma.Click += new System.EventHandler(this.btnTConfirma_Click);
            // 
            // txtTransY
            // 
            this.txtTransY.Location = new System.Drawing.Point(58, 56);
            this.txtTransY.Margin = new System.Windows.Forms.Padding(2);
            this.txtTransY.Name = "txtTransY";
            this.txtTransY.Size = new System.Drawing.Size(76, 20);
            this.txtTransY.TabIndex = 4;
            // 
            // txtTransX
            // 
            this.txtTransX.Location = new System.Drawing.Point(57, 33);
            this.txtTransX.Margin = new System.Windows.Forms.Padding(2);
            this.txtTransX.Name = "txtTransX";
            this.txtTransX.Size = new System.Drawing.Size(76, 20);
            this.txtTransX.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 33);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Vetor X:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 57);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Vetor Y:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 2);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Vetor de translação";
            // 
            // tabRotacao
            // 
            this.tabRotacao.Controls.Add(this.btnRCancela);
            this.tabRotacao.Controls.Add(this.btnRConfirma);
            this.tabRotacao.Controls.Add(this.txtRota);
            this.tabRotacao.Controls.Add(this.label17);
            this.tabRotacao.Controls.Add(this.label16);
            this.tabRotacao.Controls.Add(this.label15);
            this.tabRotacao.Location = new System.Drawing.Point(4, 22);
            this.tabRotacao.Margin = new System.Windows.Forms.Padding(2);
            this.tabRotacao.Name = "tabRotacao";
            this.tabRotacao.Padding = new System.Windows.Forms.Padding(2);
            this.tabRotacao.Size = new System.Drawing.Size(211, 154);
            this.tabRotacao.TabIndex = 1;
            this.tabRotacao.Text = "Rotação";
            this.tabRotacao.UseVisualStyleBackColor = true;
            // 
            // btnRCancela
            // 
            this.btnRCancela.Location = new System.Drawing.Point(66, 133);
            this.btnRCancela.Margin = new System.Windows.Forms.Padding(2);
            this.btnRCancela.Name = "btnRCancela";
            this.btnRCancela.Size = new System.Drawing.Size(56, 19);
            this.btnRCancela.TabIndex = 8;
            this.btnRCancela.Text = "Cancelar";
            this.btnRCancela.UseVisualStyleBackColor = true;
            this.btnRCancela.Click += new System.EventHandler(this.btnRCancela_Click);
            // 
            // btnRConfirma
            // 
            this.btnRConfirma.Location = new System.Drawing.Point(4, 133);
            this.btnRConfirma.Margin = new System.Windows.Forms.Padding(2);
            this.btnRConfirma.Name = "btnRConfirma";
            this.btnRConfirma.Size = new System.Drawing.Size(56, 19);
            this.btnRConfirma.TabIndex = 7;
            this.btnRConfirma.Text = "Confirmar";
            this.btnRConfirma.UseVisualStyleBackColor = true;
            this.btnRConfirma.Click += new System.EventHandler(this.btnRConfirma_Click);
            // 
            // txtRota
            // 
            this.txtRota.Location = new System.Drawing.Point(56, 34);
            this.txtRota.Margin = new System.Windows.Forms.Padding(2);
            this.txtRota.Name = "txtRota";
            this.txtRota.Size = new System.Drawing.Size(76, 20);
            this.txtRota.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 37);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "Ângulo:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(2, 101);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(207, 26);
            this.label16.TabIndex = 1;
            this.label16.Text = "Ângulos positivos rotacionam no sentido\r\nanti-horário e negativos no sentido horá" +
    "rio.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 2);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Ângulo de rotação";
            // 
            // tabEscalonamento
            // 
            this.tabEscalonamento.Controls.Add(this.txtEscalaY);
            this.tabEscalonamento.Controls.Add(this.txtEscalaX);
            this.tabEscalonamento.Controls.Add(this.label18);
            this.tabEscalonamento.Controls.Add(this.label19);
            this.tabEscalonamento.Controls.Add(this.label20);
            this.tabEscalonamento.Controls.Add(this.btnECancela);
            this.tabEscalonamento.Controls.Add(this.btnEConfirma);
            this.tabEscalonamento.Location = new System.Drawing.Point(4, 22);
            this.tabEscalonamento.Margin = new System.Windows.Forms.Padding(2);
            this.tabEscalonamento.Name = "tabEscalonamento";
            this.tabEscalonamento.Padding = new System.Windows.Forms.Padding(2);
            this.tabEscalonamento.Size = new System.Drawing.Size(211, 154);
            this.tabEscalonamento.TabIndex = 2;
            this.tabEscalonamento.Text = "Escalonamento";
            this.tabEscalonamento.UseVisualStyleBackColor = true;
            // 
            // txtEscalaY
            // 
            this.txtEscalaY.Location = new System.Drawing.Point(57, 56);
            this.txtEscalaY.Margin = new System.Windows.Forms.Padding(2);
            this.txtEscalaY.Name = "txtEscalaY";
            this.txtEscalaY.Size = new System.Drawing.Size(76, 20);
            this.txtEscalaY.TabIndex = 13;
            // 
            // txtEscalaX
            // 
            this.txtEscalaX.Location = new System.Drawing.Point(56, 33);
            this.txtEscalaX.Margin = new System.Windows.Forms.Padding(2);
            this.txtEscalaX.Name = "txtEscalaX";
            this.txtEscalaX.Size = new System.Drawing.Size(76, 20);
            this.txtEscalaX.TabIndex = 12;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 33);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "Escala X:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 57);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 13);
            this.label19.TabIndex = 10;
            this.label19.Text = "Escala Y:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(4, 2);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(122, 13);
            this.label20.TabIndex = 9;
            this.label20.Text = "Vetor de escalonamento";
            // 
            // btnECancela
            // 
            this.btnECancela.Location = new System.Drawing.Point(66, 133);
            this.btnECancela.Margin = new System.Windows.Forms.Padding(2);
            this.btnECancela.Name = "btnECancela";
            this.btnECancela.Size = new System.Drawing.Size(56, 19);
            this.btnECancela.TabIndex = 8;
            this.btnECancela.Text = "Cancelar";
            this.btnECancela.UseVisualStyleBackColor = true;
            this.btnECancela.Click += new System.EventHandler(this.btnECancela_Click);
            // 
            // btnEConfirma
            // 
            this.btnEConfirma.Location = new System.Drawing.Point(4, 133);
            this.btnEConfirma.Margin = new System.Windows.Forms.Padding(2);
            this.btnEConfirma.Name = "btnEConfirma";
            this.btnEConfirma.Size = new System.Drawing.Size(56, 19);
            this.btnEConfirma.TabIndex = 7;
            this.btnEConfirma.Text = "Confirmar";
            this.btnEConfirma.UseVisualStyleBackColor = true;
            this.btnEConfirma.Click += new System.EventHandler(this.btnEConfirma_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(932, 12);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Transformação de objetos";
            // 
            // CompGrafica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1155, 621);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCima);
            this.Controls.Add(this.btnDir);
            this.Controls.Add(this.brnEsq);
            this.Controls.Add(this.btnBaixo);
            this.Controls.Add(this.btnMenos);
            this.Controls.Add(this.btnMais);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.picBox);
            this.Name = "CompGrafica";
            this.Text = "Sistema gráfico 2D";
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPonto.ResumeLayout(false);
            this.tabPonto.PerformLayout();
            this.tabLinha.ResumeLayout(false);
            this.tabLinha.PerformLayout();
            this.tabPolilinha.ResumeLayout(false);
            this.tabPolilinha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPolilinha)).EndInit();
            this.tabPoligono.ResumeLayout(false);
            this.tabPoligono.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPoligono)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabTranslacao.ResumeLayout(false);
            this.tabTranslacao.PerformLayout();
            this.tabRotacao.ResumeLayout(false);
            this.tabRotacao.PerformLayout();
            this.tabEscalonamento.ResumeLayout(false);
            this.tabEscalonamento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPonto;
        private System.Windows.Forms.TabPage tabLinha;
        private System.Windows.Forms.TextBox nomePonto;
        private System.Windows.Forms.TabPage tabPolilinha;
        private System.Windows.Forms.TabPage tabPoligono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalvPonto;
        private System.Windows.Forms.TextBox cordXPonto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nomeLinha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nomePolilinha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nomePoligono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox cordYPonto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox cordY1Linha;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox cordY2Linha;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox cordX2Linha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cordX1Linha;
        private System.Windows.Forms.Button btnSalvLinha;
        private System.Windows.Forms.DataGridView gridPolilinha;
        private System.Windows.Forms.Button btnSalvPolilinha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaY;
        private System.Windows.Forms.Button btnSalvPoligono;
        private System.Windows.Forms.DataGridView gridPoligono;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluX;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluY;
        private System.Windows.Forms.Button btnMais;
        private System.Windows.Forms.Button btnMenos;
        private System.Windows.Forms.Button btnBaixo;
        private System.Windows.Forms.Button brnEsq;
        private System.Windows.Forms.Button btnDir;
        private System.Windows.Forms.Button btnCima;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTranslacao;
        private System.Windows.Forms.TabPage tabRotacao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabEscalonamento;
        private System.Windows.Forms.TextBox txtTransY;
        private System.Windows.Forms.TextBox txtTransX;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnTCancela;
        private System.Windows.Forms.Button btnTConfirma;
        private System.Windows.Forms.Button btnRCancela;
        private System.Windows.Forms.Button btnRConfirma;
        private System.Windows.Forms.TextBox txtRota;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnECancela;
        private System.Windows.Forms.Button btnEConfirma;
        private System.Windows.Forms.TextBox txtEscalaY;
        private System.Windows.Forms.TextBox txtEscalaX;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
    }
}

