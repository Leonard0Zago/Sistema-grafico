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

                Figura figuraSelecionada = (Figura)listBox.SelectedItem;

                if (figuraSelecionada is Ponto ponto)
                {
                    ponto.CoordenadaX += transX;
                    ponto.CoordenadaY += transY;
                }
                else if (figuraSelecionada is Linha linha)
                {
                    linha.CoordenadaX1 += transX;
                    linha.CoordenadaY1 += transY;
                    linha.CoordenadaX2 += transX;
                    linha.CoordenadaY2 += transY;
                }
                else if (figuraSelecionada is Polilinha polilinha)
                {
                    foreach (Ponto p in polilinha.Pontos)
                    {
                        p.CoordenadaX += transX;
                        p.CoordenadaY += transY;
                    }
                }
                else if (figuraSelecionada is Poligono poligono)
                {
                    foreach (Ponto p in poligono.Pontos)
                    {
                        p.CoordenadaX += transX;
                        p.CoordenadaY += transY;
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

            if (figura is Ponto ponto)
            {
                float xNovo = (float)(ponto.CoordenadaX * Math.Cos(radianos) - ponto.CoordenadaY * Math.Sin(radianos));
                float yNovo = (float)(ponto.CoordenadaX * Math.Sin(radianos) + ponto.CoordenadaY * Math.Cos(radianos));

                ponto.CoordenadaX = xNovo;
                ponto.CoordenadaY = yNovo;
            }
            else if (figura is Linha linha)
            {
                float x1Novo = (float)(linha.CoordenadaX1 * Math.Cos(radianos) - linha.CoordenadaY1 * Math.Sin(radianos));
                float y1Novo = (float)(linha.CoordenadaX1 * Math.Sin(radianos) + linha.CoordenadaY1 * Math.Cos(radianos));

                float x2Novo = (float)(linha.CoordenadaX2 * Math.Cos(radianos) - linha.CoordenadaY2 * Math.Sin(radianos));
                float y2Novo = (float)(linha.CoordenadaX2 * Math.Sin(radianos) + linha.CoordenadaY2 * Math.Cos(radianos));

                linha.CoordenadaX1 = x1Novo;
                linha.CoordenadaY1 = y1Novo;
                linha.CoordenadaX2 = x2Novo;
                linha.CoordenadaY2 = y2Novo;
            }
            else if (figura is Polilinha polilinha)
            {
                foreach (var pontoPolilinha in polilinha.Pontos)
                {
                    float xNovo = (float)(pontoPolilinha.CoordenadaX * Math.Cos(radianos) - pontoPolilinha.CoordenadaY * Math.Sin(radianos));
                    float yNovo = (float)(pontoPolilinha.CoordenadaX * Math.Sin(radianos) + pontoPolilinha.CoordenadaY * Math.Cos(radianos));

                    pontoPolilinha.CoordenadaX = xNovo;
                    pontoPolilinha.CoordenadaY = yNovo;
                }
            }
            else if (figura is Poligono poligono)
            {
                foreach (var pontoPoligono in poligono.Pontos)
                {
                    float xNovo = (float)(pontoPoligono.CoordenadaX * Math.Cos(radianos) - pontoPoligono.CoordenadaY * Math.Sin(radianos));
                    float yNovo = (float)(pontoPoligono.CoordenadaX * Math.Sin(radianos) + pontoPoligono.CoordenadaY * Math.Cos(radianos));

                    pontoPoligono.CoordenadaX = xNovo;
                    pontoPoligono.CoordenadaY = yNovo;
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
            if (figura is Ponto pontoUnico)
            {
                pontoUnico.CoordenadaX *= escalaX;
                pontoUnico.CoordenadaY *= escalaY;
            }
            else if (figura is Linha linha)
            {
                linha.CoordenadaX1 *= escalaX;
                linha.CoordenadaY1 *= escalaY;

                linha.CoordenadaX2 *= escalaX;
                linha.CoordenadaY2 *= escalaY;
            }
            else if (figura is Polilinha polilinha)
            {
                foreach (var pontoPolilinha in polilinha.Pontos)
                {
                    pontoPolilinha.CoordenadaX *= escalaX;
                    pontoPolilinha.CoordenadaY *= escalaY;
                }
            }
            else if (figura is Poligono poligono)
            {
                foreach (var pontoPoligono in poligono.Pontos)
                {
                    pontoPoligono.CoordenadaX *= escalaX;
                    pontoPoligono.CoordenadaY *= escalaY;
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
