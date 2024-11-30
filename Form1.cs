using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProjetoJanela.CompGrafica;

namespace ProjetoJanela
{
    public partial class CompGrafica : Form
    {
        // Classes das figuras/vertices
        public abstract class Figura
        {
            public string Nome { get; set; }

            public abstract float CalcularCentroX();
            public abstract float CalcularCentroY();
            public abstract float CalcularCentroZ();
        }
        public class Ponto : Figura
        {
            public float CoordenadaX { get; set; }
            public float CoordenadaY { get; set; }
            public float CoordenadaZ { get; set; }

            public Ponto() { }

            public Ponto(float coordenadaX, float coordenadaY, float coordenadaZ)
            {
                CoordenadaX = coordenadaX;
                CoordenadaY = coordenadaY;
                CoordenadaZ = coordenadaZ;
            }

            public override float CalcularCentroX() => CoordenadaX;
            public override float CalcularCentroY() => CoordenadaY;
            public override float CalcularCentroZ() => CoordenadaZ;

            public override string ToString()
            {
                return $"Ponto {Nome}";
            }
        }
        public class Linha : Figura
        {
            public float CoordenadaX1 { get; set; }
            public float CoordenadaY1 { get; set; }
            public float CoordenadaZ1 { get; set; }
            public float CoordenadaX2 { get; set; }
            public float CoordenadaY2 { get; set; }
            public float CoordenadaZ2 { get; set; }

            public override float CalcularCentroX()
            {
                return (CoordenadaX1 + CoordenadaX2) / 2;
            }
            public override float CalcularCentroY()
            {
                return (CoordenadaY1 + CoordenadaY2) / 2;
            }
            public override float CalcularCentroZ()
            {
                return (CoordenadaZ1 + CoordenadaZ2) / 2;
            }

            public override string ToString()
            {
                return $"Linha {Nome}";
            }
        }
        public class Polilinha : Figura
        {
            public List<Ponto> Pontos { get; set; } = new List<Ponto>();

            public override float CalcularCentroX()
            {
                float xMin = Pontos.Min(p => p.CoordenadaX);
                float xMax = Pontos.Max(p => p.CoordenadaX);
                return (xMin + xMax) / 2;
            }

            public override float CalcularCentroY()
            {
                float yMin = Pontos.Min(p => p.CoordenadaY);
                float yMax = Pontos.Max(p => p.CoordenadaY);
                return (yMin + yMax) / 2;
            }
            public override float CalcularCentroZ()
            {
                float zMin = Pontos.Min(p => p.CoordenadaZ);
                float zMax = Pontos.Max(p => p.CoordenadaZ);
                return (zMin + zMax) / 2;
            }

            public override string ToString()
            {
                return $"Polilinha {Nome}";
            }
        }
        public class Poligono : Figura
        {
            public List<Ponto> Pontos { get; set; } = new List<Ponto>();

            public override float CalcularCentroX()
            {
                float xMin = Pontos.Min(p => p.CoordenadaX);
                float xMax = Pontos.Max(p => p.CoordenadaX);
                return (xMin + xMax) / 2;
            }

            public override float CalcularCentroY()
            {
                float yMin = Pontos.Min(p => p.CoordenadaY);
                float yMax = Pontos.Max(p => p.CoordenadaY);
                return (yMin + yMax) / 2;
            }
            public override float CalcularCentroZ()
            {
                float zMin = Pontos.Min(p => p.CoordenadaZ);
                float zMax = Pontos.Max(p => p.CoordenadaZ);
                return (zMin + zMax) / 2;
            }

            public override string ToString()
            {
                return $"Poligono {Nome}";
            }
        }
        List<Figura> figuras = new List<Figura>();
        // Classe da matriz
        public class Matriz
        {
            private double[,] valores;
            public int Linhas { get; private set; }
            public int Colunas { get; private set; }

            public Matriz(int linhas, int colunas)
            {
                Linhas = linhas;
                Colunas = colunas;
                valores = new double[linhas, colunas];
            }

            public void DefinirValor(int linha, int coluna, double valor)
            {
                if (linha >= Linhas || coluna >= Colunas || linha < 0 || coluna < 0)
                {
                    throw new ArgumentOutOfRangeException("Índice fora dos limites da matriz.");
                }
                valores[linha, coluna] = valor;
            }

            public double ObterValor(int linha, int coluna)
            {
                if (linha >= Linhas || coluna >= Colunas || linha < 0 || coluna < 0)
                {
                    throw new ArgumentOutOfRangeException("Índice fora dos limites da matriz.");
                }
                return valores[linha, coluna];
            }

            public Ponto MultiplicarComVetor(Ponto ponto)
            {
                if (Linhas != 4 || Colunas != 4)
                {
                    throw new InvalidOperationException("A matriz precisa ser 4x4 para multiplicar com um vetor 3D.");
                }

                double x = ponto.CoordenadaX * ObterValor(0, 0) + ponto.CoordenadaY * ObterValor(0, 1) + ponto.CoordenadaZ * ObterValor(0, 2) + ObterValor(0, 3);
                double y = ponto.CoordenadaX * ObterValor(1, 0) + ponto.CoordenadaY * ObterValor(1, 1) + ponto.CoordenadaZ * ObterValor(1, 2) + ObterValor(1, 3);
                double z = ponto.CoordenadaX * ObterValor(2, 0) + ponto.CoordenadaY * ObterValor(2, 1) + ponto.CoordenadaZ * ObterValor(2, 2) + ObterValor(2, 3);

                return new Ponto((float)x, (float)y, (float)z);
            }

            public static Matriz Multiplicar(Matriz m1, Matriz m2)
            {
                if (m1.Colunas != m2.Linhas)
                {
                    throw new InvalidOperationException("Multiplicação não permitida. O número de colunas da primeira matriz deve ser igual ao número de linhas da segunda matriz.");
                }

                Matriz resultado = new Matriz(m1.Linhas, m2.Colunas);

                for (int i = 0; i < m1.Linhas; i++)
                {
                    for (int j = 0; j < m2.Colunas; j++)
                    {
                        double soma = 0;
                        for (int k = 0; k < m1.Colunas; k++)
                        {
                            soma += m1.ObterValor(i, k) * m2.ObterValor(k, j);
                        }
                        resultado.DefinirValor(i, j, soma);
                    }
                }

                return resultado;
            }
            public void Imprimir()
            {
                for (int i = 0; i < Linhas; i++)
                {
                    for (int j = 0; j < Colunas; j++)
                    {
                        Console.Write(valores[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
        // Classes window e viewport
        public class Window
        {
            public double XMin { get; set; }
            public double YMin { get; set; }
            public double XMax { get; set; }
            public double YMax { get; set; }

            public Window(double xmin, double ymin, double xmax, double ymax)
            {
                XMin = xmin;
                YMin = ymin;
                XMax = xmax;
                YMax = ymax;
            }
        }
        public class Viewport
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public Viewport(int x, int y, int width, int height)
            {
                X = x;
                Y = y;
                Width = width;
                Height = height;
            }

            public Point WorldToViewport(Window window, double x, double y)
            {
                double viewportX = ((x - window.XMin) / (window.XMax - window.XMin)) * Width;
                double viewportY = ((window.YMax - y) / (window.YMax - window.YMin)) * Height;

                return new Point((int)viewportX, (int)viewportY);
            }
        }
        Viewport viewport = new Viewport(0, 0, 600, 600);
        Window window = new Window(-300, -300, 300, 300);

        public CompGrafica()
        {
            InitializeComponent();
        }
        // Tela de desenho
        private void picBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DesenharEixos(g);

            foreach (Figura figura in figuras)
            {
                if (figura is Ponto ponto)
                {
                    DesenharPonto(ponto, g);
                }
                else if (figura is Linha linha)
                {
                    DesenharLinha(linha, g);
                }
                else if (figura is Polilinha polilinha)
                {
                    DesenharPolilinha(polilinha, g);
                }
                else if (figura is Poligono poligono)
                {
                    DesenharPoligono(poligono, g);
                }
            }
        }
        // Funções para desenhar cada vertice
        private void DesenharPonto(Ponto ponto, Graphics g)
        {
            Point pontoConvertido = viewport.WorldToViewport(window, ponto.CoordenadaX, ponto.CoordenadaY);

            Pen pen = new Pen(Color.Blue, 2);
            g.DrawEllipse(pen, pontoConvertido.X - 2, pontoConvertido.Y - 2, 5, 5);
            pen.Dispose();
        }
        private void DesenharLinha(Linha linha, Graphics g)
        {
            Point ponto1Convertido = viewport.WorldToViewport(window, linha.CoordenadaX1, linha.CoordenadaY1);
            Point ponto2Convertido = viewport.WorldToViewport(window, linha.CoordenadaX2, linha.CoordenadaY2);

            Pen pen = new Pen(Color.Green, 2);
            g.DrawLine(pen, ponto1Convertido.X, ponto1Convertido.Y, ponto2Convertido.X, ponto2Convertido.Y);
            pen.Dispose();
        }
        private void DesenharPolilinha(Polilinha polilinha, Graphics g)
        {
            if (polilinha.Pontos.Count >= 2)
            {
                Pen pen = new Pen(Color.Yellow, 2);
                Point[] pontosConvertidos = polilinha.Pontos
                    .Select(p => viewport.WorldToViewport(window, p.CoordenadaX, p.CoordenadaY))
                    .ToArray();

                g.DrawLines(pen, pontosConvertidos);
                pen.Dispose();
            }
            else
            {
                MessageBox.Show("É necessário inserir pelo menos três pontos para desenhar uma polilinha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DesenharPoligono(Poligono poligono, Graphics g)
        {
            if (poligono.Pontos.Count >= 3)
            {
                Pen pen = new Pen(Color.Red, 2);
                Point[] pontosConvertidos = poligono.Pontos
                    .Select(p => viewport.WorldToViewport(window, p.CoordenadaX, p.CoordenadaY))
                    .ToArray();

                g.DrawPolygon(pen, pontosConvertidos);
                pen.Dispose();
            }
            else
            {
                MessageBox.Show("É necessário inserir pelo menos três pontos para desenhar um poligono.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DesenharEixos(Graphics g)
        {
            Pen pen = new Pen(Color.LightPink, 2);

            g.DrawLine(pen, viewport.WorldToViewport(window, window.XMin, 0).X,
                              viewport.WorldToViewport(window, window.XMin, 0).Y,
                              viewport.WorldToViewport(window, window.XMax, 0).X,
                              viewport.WorldToViewport(window, window.XMax, 0).Y);

            g.DrawLine(pen, viewport.WorldToViewport(window, 0, window.YMin).X,
                              viewport.WorldToViewport(window, 0, window.YMin).Y,
                              viewport.WorldToViewport(window, 0, window.YMax).X,
                              viewport.WorldToViewport(window, 0, window.YMax).Y);

            pen.Dispose();
        }
        // Deletar
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                Figura figuraSelecionada = (Figura)listBox.SelectedItem;

                figuras.Remove(figuraSelecionada);

                listBox.DataSource = null;
                listBox.DataSource = figuras;

                picBox.Invalidate();

                picBox.Refresh();
            }
            else
            {
                MessageBox.Show("Nenhuma figura selecionada para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Botões para salvar
        private void btnSalvPonto_Click(object sender, EventArgs e)
        {
            Ponto novoPonto = new Ponto
            {
                Nome = nomePonto.Text,
                CoordenadaX = int.Parse(cordXPonto.Text),
                CoordenadaY = int.Parse(cordYPonto.Text),
                CoordenadaZ = string.IsNullOrEmpty(cordZPonto.Text) ? 0 : int.Parse(cordZPonto.Text)
            };

            figuras.Add(novoPonto);

            DesenharPonto(novoPonto, picBox.CreateGraphics());

            nomePonto.Clear();
            cordXPonto.Clear();
            cordYPonto.Clear();
            cordZPonto.Clear();

            listBox.DataSource = null;
            listBox.DataSource = figuras;
        }
        private void btnSalvLinha_Click(object sender, EventArgs e)
        {
            Linha novaLinha = new Linha
            {
                Nome = nomeLinha.Text,
                CoordenadaX1 = int.Parse(cordX1Linha.Text),
                CoordenadaY1 = int.Parse(cordY1Linha.Text),
                CoordenadaZ1 = string.IsNullOrEmpty(cordZ1Linha.Text) ? 0 : int.Parse(cordZ1Linha.Text),
                CoordenadaX2 = int.Parse(cordX2Linha.Text),
                CoordenadaY2 = int.Parse(cordY2Linha.Text),
                CoordenadaZ2 = string.IsNullOrEmpty(cordZ2Linha.Text) ? 0 : int.Parse(cordZ2Linha.Text)
            };

            figuras.Add(novaLinha);

            DesenharLinha(novaLinha, picBox.CreateGraphics());

            nomeLinha.Clear();
            cordX1Linha.Clear();
            cordY1Linha.Clear();
            cordZ1Linha.Clear();
            cordX2Linha.Clear();
            cordY2Linha.Clear();
            cordZ2Linha.Clear();

            listBox.DataSource = null;
            listBox.DataSource = figuras;
        }
        private void btnSalvPolilinha_Click(object sender, EventArgs e)
        {
            Polilinha novaPolilinha = new Polilinha { Nome = nomePolilinha.Text };

            foreach (DataGridViewRow row in gridPolilinha.Rows)
            {
                if (row.IsNewRow) continue;

                int x = int.Parse(row.Cells[0].Value.ToString());
                int y = int.Parse(row.Cells[1].Value.ToString());
                int z = string.IsNullOrEmpty(row.Cells[2].Value.ToString()) ? 0 : int.Parse(row.Cells[2].Value.ToString());

                novaPolilinha.Pontos.Add(new Ponto { CoordenadaX = x, CoordenadaY = y, CoordenadaZ = z });
            }

            figuras.Add(novaPolilinha);

            DesenharPolilinha(novaPolilinha, picBox.CreateGraphics());

            nomePolilinha.Clear();
            gridPolilinha.Rows.Clear();

            listBox.DataSource = null;
            listBox.DataSource = figuras;
        }
        private void btnSalvPoligono_Click(object sender, EventArgs e)
        {
            Poligono novoPoligono = new Poligono { Nome = nomePoligono.Text };

            foreach (DataGridViewRow row in gridPoligono.Rows)
            {
                if (row.IsNewRow) continue;

                int x = int.Parse(row.Cells[0].Value.ToString());
                int y = int.Parse(row.Cells[1].Value.ToString());
                int z = string.IsNullOrEmpty(row.Cells[2].Value.ToString()) ? 0 : int.Parse(row.Cells[2].Value.ToString());

                novoPoligono.Pontos.Add(new Ponto { CoordenadaX = x, CoordenadaY = y, CoordenadaZ = z });
            }

            figuras.Add(novoPoligono);

            DesenharPoligono(novoPoligono, picBox.CreateGraphics());

            nomePoligono.Clear();
            gridPoligono.Rows.Clear();

            listBox.DataSource = null;
            listBox.DataSource = figuras;
        }
        // Botões de movimento e zoom
        private void btnMais_Click(object sender, EventArgs e)
        {
            double fatorZoom = 0.9;
            window.XMin *= fatorZoom;
            window.YMin *= fatorZoom;
            window.XMax *= fatorZoom;
            window.YMax *= fatorZoom;

            picBox.Invalidate();
        }
        private void btnMenos_Click(object sender, EventArgs e)
        {
            double fatorZoom = 1.1;
            window.XMin *= fatorZoom;
            window.YMin *= fatorZoom;
            window.XMax *= fatorZoom;
            window.YMax *= fatorZoom;

            picBox.Invalidate();
        }
        private void btnCima_Click(object sender, EventArgs e)
        {
            double movimento = 10;
            window.YMin += movimento;
            window.YMax += movimento;

            picBox.Invalidate();
        }
        private void btnBaixo_Click(object sender, EventArgs e)
        {
            double movimento = 10;
            window.YMin -= movimento;
            window.YMax -= movimento;

            picBox.Invalidate();
        }
        private void btnEsq_Click(object sender, EventArgs e)
        {
            double movimento = 10;
            window.XMin -= movimento;
            window.XMax -= movimento;

            picBox.Invalidate();
        }
        private void btnDir_Click(object sender, EventArgs e)
        {
            double movimento = 10;
            window.XMin += movimento;
            window.XMax += movimento;

            picBox.Invalidate();
        }
        // Botões de transformação dos objetos
        private void AplicarTransformacao(Figura figura, Matriz transformacao)
        {
            void aplicarTransformacao(Ponto ponto)
            {
                Matriz pontoMatriz = new Matriz(4, 1);
                pontoMatriz.DefinirValor(0, 0, ponto.CoordenadaX);
                pontoMatriz.DefinirValor(1, 0, ponto.CoordenadaY);
                pontoMatriz.DefinirValor(2, 0, ponto.CoordenadaZ);
                pontoMatriz.DefinirValor(3, 0, 1);

                Matriz resultado = Matriz.Multiplicar(transformacao, pontoMatriz);

                ponto.CoordenadaX = (float)resultado.ObterValor(0, 0);
                ponto.CoordenadaY = (float)resultado.ObterValor(1, 0);
                ponto.CoordenadaZ = (float)resultado.ObterValor(2, 0);
            }

            if (figura is Ponto pontoUnico)
            {
                aplicarTransformacao(pontoUnico);
            }
            else if (figura is Linha linha)
            {
                Ponto pontoInicial = new Ponto(linha.CoordenadaX1, linha.CoordenadaY1, linha.CoordenadaZ1);
                Ponto pontoFinal = new Ponto(linha.CoordenadaX2, linha.CoordenadaY2, linha.CoordenadaZ2);

                aplicarTransformacao(pontoInicial);
                aplicarTransformacao(pontoFinal);

                linha.CoordenadaX1 = pontoInicial.CoordenadaX;
                linha.CoordenadaY1 = pontoInicial.CoordenadaY;
                linha.CoordenadaZ1 = pontoInicial.CoordenadaZ;
                linha.CoordenadaX2 = pontoFinal.CoordenadaX;
                linha.CoordenadaY2 = pontoFinal.CoordenadaY;
                linha.CoordenadaZ2 = pontoFinal.CoordenadaZ;
            }
            else if (figura is Polilinha polilinha)
            {
                foreach (var pontoPolilinha in polilinha.Pontos)
                {
                    aplicarTransformacao(pontoPolilinha);
                }
            }
            else if (figura is Poligono poligono)
            {
                foreach (var pontoPoligono in poligono.Pontos)
                {
                    aplicarTransformacao(pontoPoligono);
                }
            }
        }
        private void btnTConfirma_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                float transX = float.Parse(txtTransX.Text);
                float transY = float.Parse(txtTransY.Text);
                float transZ = float.Parse(txtTransZ.Text);

                Matriz matrizTranslacao = new Matriz(4, 4);
                matrizTranslacao.DefinirValor(0, 0, 1);
                matrizTranslacao.DefinirValor(0, 3, transX);
                matrizTranslacao.DefinirValor(1, 1, 1);
                matrizTranslacao.DefinirValor(1, 3, transY);
                matrizTranslacao.DefinirValor(2, 2, 1);
                matrizTranslacao.DefinirValor(2, 3, transZ);
                matrizTranslacao.DefinirValor(3, 3, 1);

                Figura figuraSelecionada = (Figura)listBox.SelectedItem;
                AplicarTransformacao(figuraSelecionada, matrizTranslacao);

                picBox.Invalidate();
            }
            else
            {
                MessageBox.Show("Nenhuma figura selecionada para translação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            txtTransX.Clear();
            txtTransY.Clear();
            txtTransZ.Clear();
        }
        private void btnTCancela_Click(object sender, EventArgs e)
        {
            txtTransX.Clear();
            txtTransY.Clear();
            txtTransZ.Clear();
        }
        private void RotacionarFigura(Figura figura, float angulo)
        {
            double radianos = angulo * (Math.PI / 180.0);
            float pontoX = 0, pontoY = 0, pontoZ = 0;

            if (rdOrigem.Checked)
            {
                pontoX = 0;
                pontoY = 0;
                pontoZ = 0;
            }
            else if (rdPonto.Checked)
            {
                pontoX = float.Parse(txtX.Text);
                pontoY = float.Parse(txtY.Text);
                pontoZ = float.Parse(txtZ.Text);
            }
            else if (rdCentro.Checked)
            {
                pontoX = figura.CalcularCentroX();
                pontoY = figura.CalcularCentroY();
                pontoZ = figura.CalcularCentroZ();
            }

            Matriz matrizTranslacaoOrigem = new Matriz(4, 4);
            matrizTranslacaoOrigem.DefinirValor(0, 0, 1);
            matrizTranslacaoOrigem.DefinirValor(0, 3, -pontoX);
            matrizTranslacaoOrigem.DefinirValor(1, 1, 1);
            matrizTranslacaoOrigem.DefinirValor(1, 3, -pontoY);
            matrizTranslacaoOrigem.DefinirValor(2, 2, 1);
            matrizTranslacaoOrigem.DefinirValor(2, 3, -pontoZ);
            matrizTranslacaoOrigem.DefinirValor(3, 3, 1);

            Matriz matrizRotacao = new Matriz(4, 4);
            if (rdX.Checked)
            {
                matrizRotacao.DefinirValor(0, 0, 1);
                matrizRotacao.DefinirValor(1, 1, (float)Math.Cos(radianos));
                matrizRotacao.DefinirValor(1, 2, -(float)Math.Sin(radianos));
                matrizRotacao.DefinirValor(2, 1, (float)Math.Sin(radianos));
                matrizRotacao.DefinirValor(2, 2, (float)Math.Cos(radianos));
                matrizRotacao.DefinirValor(3, 3, 1);
            }
            else if (rdY.Checked)
            {
                matrizRotacao.DefinirValor(0, 0, (float)Math.Cos(radianos));
                matrizRotacao.DefinirValor(0, 2, (float)Math.Sin(radianos));
                matrizRotacao.DefinirValor(1, 1, 1);
                matrizRotacao.DefinirValor(2, 0, -(float)Math.Sin(radianos));
                matrizRotacao.DefinirValor(2, 2, (float)Math.Cos(radianos));
                matrizRotacao.DefinirValor(3, 3, 1);
            }
            else if (rdZ.Checked)
            {
                matrizRotacao.DefinirValor(0, 0, (float)Math.Cos(radianos));
                matrizRotacao.DefinirValor(0, 1, -(float)Math.Sin(radianos));
                matrizRotacao.DefinirValor(1, 0, (float)Math.Sin(radianos));
                matrizRotacao.DefinirValor(1, 1, (float)Math.Cos(radianos));
                matrizRotacao.DefinirValor(2, 2, 1);
                matrizRotacao.DefinirValor(3, 3, 1);
            }

            Matriz matrizTranslacaoDeVolta = new Matriz(4, 4);
            matrizTranslacaoDeVolta.DefinirValor(0, 0, 1);
            matrizTranslacaoDeVolta.DefinirValor(0, 3, pontoX);
            matrizTranslacaoDeVolta.DefinirValor(1, 1, 1);
            matrizTranslacaoDeVolta.DefinirValor(1, 3, pontoY);
            matrizTranslacaoDeVolta.DefinirValor(2, 2, 1);
            matrizTranslacaoDeVolta.DefinirValor(2, 3, pontoZ);
            matrizTranslacaoDeVolta.DefinirValor(3, 3, 1);

            Matriz transformacaoCompleta = Matriz.Multiplicar(matrizTranslacaoDeVolta,
                Matriz.Multiplicar(matrizRotacao, matrizTranslacaoOrigem));

            AplicarTransformacao(figura, transformacaoCompleta);
        }
        private void btnRConfirma_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null && float.TryParse(txtRota.Text, out float angulo))
            {
                Figura figuraSelecionada = (Figura)listBox.SelectedItem;
                RotacionarFigura(figuraSelecionada, angulo);

                picBox.Invalidate();
            }
            else
            {
                MessageBox.Show("Selecione uma figura e insira um valor válido para a rotação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtRota.Clear();
        }
        private void btnRCancela_Click(object sender, EventArgs e)
        {
            txtRota.Clear();
        }
        private void EscalonarFigura(Figura figura, float escalaX, float escalaY, float escalaZ)
        {
            float refX = 0, refY = 0, refZ = 0;

            if (rdESimples.Checked)
            {
                refX = 0;
                refY = 0;
                refZ = 0;
            }
            else if (rdEOrigem.Checked)
            {
                if (figura is Linha linha)
                {
                    refX = linha.CoordenadaX1;
                    refY = linha.CoordenadaY1;
                    refZ = 0;
                }
                else if (figura is Polilinha polilinha && polilinha.Pontos.Count > 0)
                {
                    refX = polilinha.Pontos[0].CoordenadaX;
                    refY = polilinha.Pontos[0].CoordenadaY;
                    refZ = 0;
                }
                else if (figura is Poligono poligono && poligono.Pontos.Count > 0)
                {
                    refX = poligono.Pontos[0].CoordenadaX;
                    refY = poligono.Pontos[0].CoordenadaY;
                    refZ = 0;
                }
            }
            else if (rdECentro.Checked)
            {
                refX = figura.CalcularCentroX();
                refY = figura.CalcularCentroY();
                refZ = 0;
            }

            Matriz matrizTranslacaoOrigem = new Matriz(4, 4);
            matrizTranslacaoOrigem.DefinirValor(0, 0, 1);
            matrizTranslacaoOrigem.DefinirValor(0, 3, -refX);
            matrizTranslacaoOrigem.DefinirValor(1, 1, 1);
            matrizTranslacaoOrigem.DefinirValor(1, 3, -refY);
            matrizTranslacaoOrigem.DefinirValor(2, 2, 1);
            matrizTranslacaoOrigem.DefinirValor(2, 3, -refZ);
            matrizTranslacaoOrigem.DefinirValor(3, 3, 1);

            Matriz matrizEscalonamento = new Matriz(4, 4);
            matrizEscalonamento.DefinirValor(0, 0, escalaX);
            matrizEscalonamento.DefinirValor(1, 1, escalaY);
            matrizEscalonamento.DefinirValor(2, 2, escalaZ);
            matrizEscalonamento.DefinirValor(3, 3, 1);

            Matriz matrizTranslacaoDeVolta = new Matriz(4, 4);
            matrizTranslacaoDeVolta.DefinirValor(0, 0, 1);
            matrizTranslacaoDeVolta.DefinirValor(0, 3, refX);
            matrizTranslacaoDeVolta.DefinirValor(1, 1, 1);
            matrizTranslacaoDeVolta.DefinirValor(1, 3, refY);
            matrizTranslacaoDeVolta.DefinirValor(2, 2, 1);
            matrizTranslacaoDeVolta.DefinirValor(2, 3, refZ);
            matrizTranslacaoDeVolta.DefinirValor(3, 3, 1);

            Matriz transformacaoCompleta = Matriz.Multiplicar(matrizTranslacaoDeVolta,
                Matriz.Multiplicar(matrizEscalonamento, matrizTranslacaoOrigem));

            AplicarTransformacao(figura, transformacaoCompleta);
        }
        private void btnEConfirma_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txtEscalaX.Text, out float escalaX) &&
                float.TryParse(txtEscalaY.Text, out float escalaY) &&
                float.TryParse(txtEscalaZ.Text, out float escalaZ))
            {
                if (listBox.SelectedItem is Figura figuraSelecionada)
                {
                    EscalonarFigura(figuraSelecionada, escalaX, escalaY, escalaZ);
                    picBox.Invalidate();
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira valores válidos para a escala.");
            }
            txtEscalaX.Clear();
            txtEscalaY.Clear();
            txtEscalaZ.Clear();
        }
        private void btnECancela_Click(object sender, EventArgs e)
        {
            txtEscalaX.Clear();
            txtEscalaY.Clear();
            txtEscalaZ.Clear();
        }
        private void EspelharFigura(Figura figura, bool espelharX, bool espelharY, bool espelharZ)
        {
            float refX = 0, refY = 0, refZ = 0;

            if (rdESimples.Checked)
            {
                refX = 0;
                refY = 0;
                refZ = 0;
            }
            else if (rdEOrigem.Checked)
            {
                if (figura is Linha linha)
                {
                    refX = linha.CoordenadaX1;
                    refY = linha.CoordenadaY1;
                    refZ = linha.CoordenadaZ1;
                }
                else if (figura is Polilinha polilinha && polilinha.Pontos.Count > 0)
                {
                    refX = polilinha.Pontos[0].CoordenadaX;
                    refY = polilinha.Pontos[0].CoordenadaY;
                    refZ = polilinha.Pontos[0].CoordenadaZ;
                }
                else if (figura is Poligono poligono && poligono.Pontos.Count > 0)
                {
                    refX = poligono.Pontos[0].CoordenadaX;
                    refY = poligono.Pontos[0].CoordenadaY;
                    refZ = poligono.Pontos[0].CoordenadaZ;
                }
            }
            else if (rdECentro.Checked)
            {
                refX = figura.CalcularCentroX();
                refY = figura.CalcularCentroY();
                refZ = figura.CalcularCentroZ();
            }

            Matriz matrizTranslacaoOrigem = new Matriz(4, 4);
            matrizTranslacaoOrigem.DefinirValor(0, 0, 1);
            matrizTranslacaoOrigem.DefinirValor(0, 3, -refX);
            matrizTranslacaoOrigem.DefinirValor(1, 1, 1);
            matrizTranslacaoOrigem.DefinirValor(1, 3, -refY);
            matrizTranslacaoOrigem.DefinirValor(2, 2, 1);
            matrizTranslacaoOrigem.DefinirValor(2, 3, -refZ);
            matrizTranslacaoOrigem.DefinirValor(3, 3, 1);

            Matriz matrizEspelhamento = new Matriz(4, 4);
            matrizEspelhamento.DefinirValor(0, 0, espelharX ? -1 : 1);
            matrizEspelhamento.DefinirValor(1, 1, espelharY ? -1 : 1);
            matrizEspelhamento.DefinirValor(2, 2, espelharZ ? -1 : 1);
            matrizEspelhamento.DefinirValor(3, 3, 1);

            Matriz matrizTranslacaoDeVolta = new Matriz(4, 4);
            matrizTranslacaoDeVolta.DefinirValor(0, 0, 1);
            matrizTranslacaoDeVolta.DefinirValor(0, 3, refX);
            matrizTranslacaoDeVolta.DefinirValor(1, 1, 1);
            matrizTranslacaoDeVolta.DefinirValor(1, 3, refY);
            matrizTranslacaoDeVolta.DefinirValor(2, 2, 1);
            matrizTranslacaoDeVolta.DefinirValor(2, 3, refZ);
            matrizTranslacaoDeVolta.DefinirValor(3, 3, 1);

            Matriz transformacaoCompleta = Matriz.Multiplicar(matrizTranslacaoDeVolta,
                Matriz.Multiplicar(matrizEspelhamento, matrizTranslacaoOrigem));

            AplicarTransformacao(figura, transformacaoCompleta);
        }
        private void btnRefConfirma_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem is Figura figuraSelecionada)
            {
                bool espelharX = ckX.Checked;
                bool espelharY = ckY.Checked;
                bool espelharZ = ckZ.Checked;

                EspelharFigura(figuraSelecionada, espelharX, espelharY, espelharZ);
                picBox.Invalidate();
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma figura para aplicar o espelhamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnRefCancela_Click(object sender, EventArgs e)
        {
            ckX.Checked = false;
            ckY.Checked = false;
            ckZ.Checked = false;
        }
        private void CisalharFigura(Figura figura, float cisX, float cisY, float cisZ)
        {
            Matriz matrizTranslacaoOrigem = new Matriz(4, 4);
            matrizTranslacaoOrigem.DefinirValor(0, 0, 1);
            matrizTranslacaoOrigem.DefinirValor(1, 1, 1);
            matrizTranslacaoOrigem.DefinirValor(2, 2, 1);
            matrizTranslacaoOrigem.DefinirValor(3, 3, 1);

            Matriz matrizCisalhamento = new Matriz(4, 4);
            matrizCisalhamento.DefinirValor(0, 0, 1);
            matrizCisalhamento.DefinirValor(0, 1, cisX);
            matrizCisalhamento.DefinirValor(1, 0, cisY);
            matrizCisalhamento.DefinirValor(2, 0, cisZ);
            matrizCisalhamento.DefinirValor(3, 3, 1);

            Matriz matrizTranslacaoDeVolta = new Matriz(4, 4);
            matrizTranslacaoDeVolta.DefinirValor(0, 0, 1);
            matrizTranslacaoDeVolta.DefinirValor(1, 1, 1);
            matrizTranslacaoDeVolta.DefinirValor(2, 2, 1);
            matrizTranslacaoDeVolta.DefinirValor(3, 3, 1);

            Matriz transformacaoCompleta = Matriz.Multiplicar(matrizTranslacaoDeVolta,
                Matriz.Multiplicar(matrizCisalhamento, matrizTranslacaoOrigem));

            AplicarTransformacao(figura, transformacaoCompleta);
        }
        private void btnCisConfirma_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txtCisX.Text, out float cisX) && float.TryParse(txtCisY.Text, out float cisY) && float.TryParse(txtCisZ.Text, out float cisZ))
            {
                if (listBox.SelectedItem is Figura figuraSelecionada)
                {
                    CisalharFigura(figuraSelecionada, cisX, cisY, cisZ);
                    picBox.Invalidate();
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira valores válidos para o cisalhamento.");
            }
            txtCisX.Clear();
            txtCisY.Clear();
            txtCisZ.Clear();
        }
        private void btnCisCancela_Click(object sender, EventArgs e)
        {
            txtCisX.Clear();
            txtCisY.Clear();
            txtCisZ.Clear();
        }

    }
}
