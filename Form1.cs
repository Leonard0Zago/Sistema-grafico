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
        }
        public class Ponto : Figura
        {
            public float CoordenadaX { get; set; }
            public float CoordenadaY { get; set; }

            public Ponto() { }

            public Ponto(float coordenadaX, float coordenadaY)
            {
                CoordenadaX = coordenadaX;
                CoordenadaY = coordenadaY;
            }

            public override string ToString()
            {
                return $"Ponto {Nome}";
            }
        }
        public class Linha : Figura
        {
            public float CoordenadaX1 { get; set; }
            public float CoordenadaY1 { get; set; }
            public float CoordenadaX2 { get; set; }
            public float CoordenadaY2 { get; set; }

            public override string ToString()
            {
                return $"Linha {Nome}";
            }
        }
        public class Polilinha : Figura
        {
            public List<Ponto> Pontos { get; set; } = new List<Ponto>();
            public override string ToString()
            {
                return $"Polilinha {Nome}";
            }
        }
        public class Poligono : Figura
        {
            public List<Ponto> Pontos { get; set; } = new List<Ponto>();
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
                CoordenadaY = int.Parse(cordYPonto.Text)
            };

            figuras.Add(novoPonto);

            DesenharPonto(novoPonto, picBox.CreateGraphics());

            nomePonto.Clear();
            cordXPonto.Clear();
            cordYPonto.Clear();

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
                CoordenadaX2 = int.Parse(cordX2Linha.Text),
                CoordenadaY2 = int.Parse(cordY2Linha.Text)
            };

            figuras.Add(novaLinha);

            DesenharLinha(novaLinha, picBox.CreateGraphics());

            nomeLinha.Clear();
            cordX1Linha.Clear();
            cordY1Linha.Clear();
            cordX2Linha.Clear();
            cordY2Linha.Clear();

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
                novaPolilinha.Pontos.Add(new Ponto { CoordenadaX = x, CoordenadaY = y });
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
                novoPoligono.Pontos.Add(new Ponto { CoordenadaX = x, CoordenadaY = y });
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
        private void btnTConfirma_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                float transX = float.Parse(txtTransX.Text);
                float transY = float.Parse(txtTransY.Text);

                Matriz matrizTranslacao = new Matriz(3, 3);
                matrizTranslacao.DefinirValor(0, 0, 1);
                matrizTranslacao.DefinirValor(0, 2, transX);
                matrizTranslacao.DefinirValor(1, 1, 1);
                matrizTranslacao.DefinirValor(1, 2, transY);
                matrizTranslacao.DefinirValor(2, 2, 1);

                Figura figuraSelecionada = (Figura)listBox.SelectedItem;

                Func<Ponto, Ponto> aplicarTranslacao = p =>
                {
                    Matriz pontoMatriz = new Matriz(3, 1);
                    pontoMatriz.DefinirValor(0, 0, p.CoordenadaX);
                    pontoMatriz.DefinirValor(1, 0, p.CoordenadaY);
                    pontoMatriz.DefinirValor(2, 0, 1);

                    Matriz resultado = Matriz.Multiplicar(matrizTranslacao, pontoMatriz);

                    return new Ponto((float)resultado.ObterValor(0, 0), (float)resultado.ObterValor(1, 0));
                };

                if (figuraSelecionada is Ponto ponto)
                {
                    Ponto novoPonto = aplicarTranslacao(ponto);
                    ponto.CoordenadaX = novoPonto.CoordenadaX;
                    ponto.CoordenadaY = novoPonto.CoordenadaY;
                }
                else if (figuraSelecionada is Linha linha)
                {
                    var pontoInicialTransladado = aplicarTranslacao(new Ponto(linha.CoordenadaX1, linha.CoordenadaY1));
                    linha.CoordenadaX1 = pontoInicialTransladado.CoordenadaX;
                    linha.CoordenadaY1 = pontoInicialTransladado.CoordenadaY;

                    var pontoFinalTransladado = aplicarTranslacao(new Ponto(linha.CoordenadaX2, linha.CoordenadaY2));
                    linha.CoordenadaX2 = pontoFinalTransladado.CoordenadaX;
                    linha.CoordenadaY2 = pontoFinalTransladado.CoordenadaY;
                }
                else if (figuraSelecionada is Polilinha polilinha)
                {
                    for (int i = 0; i < polilinha.Pontos.Count; i++)
                    {
                        polilinha.Pontos[i] = aplicarTranslacao(polilinha.Pontos[i]);
                    }
                }
                else if (figuraSelecionada is Poligono poligono)
                {
                    for (int i = 0; i < poligono.Pontos.Count; i++)
                    {
                        poligono.Pontos[i] = aplicarTranslacao(poligono.Pontos[i]);
                    }
                }

                picBox.Invalidate();
            }
            else
            {
                MessageBox.Show("Nenhuma figura selecionada para translação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            txtTransX.Clear();
            txtTransY.Clear();
        }
        private void btnTCancela_Click(object sender, EventArgs e)
        {
            txtTransX.Clear();
            txtTransY.Clear();
        }
        private void RotacionarFigura(Figura figura, float angulo)
        {
            double radianos = angulo * (Math.PI / 180.0);

            Matriz rotacao = new Matriz(2, 2);
            rotacao.DefinirValor(0, 0, Math.Cos(radianos));
            rotacao.DefinirValor(0, 1, -Math.Sin(radianos));
            rotacao.DefinirValor(1, 0, Math.Sin(radianos));
            rotacao.DefinirValor(1, 1, Math.Cos(radianos));

            void aplicarRotacao(Ponto pontoAtual)
            {
                Matriz pontoMatriz = new Matriz(2, 1);
                pontoMatriz.DefinirValor(0, 0, pontoAtual.CoordenadaX);
                pontoMatriz.DefinirValor(1, 0, pontoAtual.CoordenadaY);

                Matriz resultado = Matriz.Multiplicar(rotacao, pontoMatriz);

                pontoAtual.CoordenadaX = (float)resultado.ObterValor(0, 0);
                pontoAtual.CoordenadaY = (float)resultado.ObterValor(1, 0);
            }

            if (figura is Ponto ponto)
            {
                aplicarRotacao(ponto);
            }
            else if (figura is Linha linha)
            {
                Ponto pontoInicial = new Ponto(linha.CoordenadaX1, linha.CoordenadaY1);
                Ponto pontoFinal = new Ponto(linha.CoordenadaX2, linha.CoordenadaY2);

                aplicarRotacao(pontoInicial);
                aplicarRotacao(pontoFinal);

                linha.CoordenadaX1 = pontoInicial.CoordenadaX;
                linha.CoordenadaY1 = pontoInicial.CoordenadaY;
                linha.CoordenadaX2 = pontoFinal.CoordenadaX;
                linha.CoordenadaY2 = pontoFinal.CoordenadaY;
            }
            else if (figura is Polilinha polilinha)
            {
                foreach (var pontoPolilinha in polilinha.Pontos)
                {
                    aplicarRotacao(pontoPolilinha);
                }
            }
            else if (figura is Poligono poligono)
            {
                foreach (var pontoPoligono in poligono.Pontos)
                {
                    aplicarRotacao(pontoPoligono);
                }
            }
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
        private void EscalonarFigura(Figura figura, float escalaX, float escalaY)
        {
            Matriz escalonamento = new Matriz(2, 2);
            escalonamento.DefinirValor(0, 0, escalaX);
            escalonamento.DefinirValor(0, 1, 0);
            escalonamento.DefinirValor(1, 0, 0);
            escalonamento.DefinirValor(1, 1, escalaY);

            void aplicarEscalonamento(Ponto ponto)
            {
                Matriz pontoMatriz = new Matriz(2, 1);
                pontoMatriz.DefinirValor(0, 0, ponto.CoordenadaX);
                pontoMatriz.DefinirValor(1, 0, ponto.CoordenadaY);

                Matriz resultado = Matriz.Multiplicar(escalonamento, pontoMatriz);

                ponto.CoordenadaX = (float)resultado.ObterValor(0, 0);
                ponto.CoordenadaY = (float)resultado.ObterValor(1, 0);
            }

            if (figura is Ponto pontoUnico)
            {
                aplicarEscalonamento(pontoUnico);
            }
            else if (figura is Linha linha)
            {
                Ponto pontoInicial = new Ponto(linha.CoordenadaX1, linha.CoordenadaY1);
                Ponto pontoFinal = new Ponto(linha.CoordenadaX2, linha.CoordenadaY2);

                aplicarEscalonamento(pontoInicial);
                aplicarEscalonamento(pontoFinal);

                linha.CoordenadaX1 = pontoInicial.CoordenadaX;
                linha.CoordenadaY1 = pontoInicial.CoordenadaY;
                linha.CoordenadaX2 = pontoFinal.CoordenadaX;
                linha.CoordenadaY2 = pontoFinal.CoordenadaY;
            }
            else if (figura is Polilinha polilinha)
            {
                foreach (var pontoPolilinha in polilinha.Pontos)
                {
                    aplicarEscalonamento(pontoPolilinha);
                }
            }
            else if (figura is Poligono poligono)
            {
                foreach (var pontoPoligono in poligono.Pontos)
                {
                    aplicarEscalonamento(pontoPoligono);
                }
            }
        }
        private void btnEConfirma_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txtEscalaX.Text, out float escalaX) && float.TryParse(txtEscalaY.Text, out float escalaY))
            {
                if (listBox.SelectedItem is Figura figuraSelecionada)
                {
                    EscalonarFigura(figuraSelecionada, escalaX, escalaY);
                    picBox.Invalidate();
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira valores válidos para a escala.");
            }
            txtEscalaX.Clear();
            txtEscalaY.Clear();
        }
        private void btnECancela_Click(object sender, EventArgs e)
        {
            txtEscalaX.Clear();
            txtEscalaY.Clear();
        }

    }
}
