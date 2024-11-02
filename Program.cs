<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProjetoJanela.CompGrafica;

namespace ProjetoJanela
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CompGrafica());
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProjetoJanela.CompGrafica;

namespace ProjetoJanela
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CompGrafica());

            // Criar matrizes e chamar a multiplicação
            Matriz matriz1 = new Matriz(2, 3);
            matriz1.DefinirValor(0, 0, 1);
            matriz1.DefinirValor(0, 1, 2);
            matriz1.DefinirValor(0, 2, 3);
            matriz1.DefinirValor(1, 0, 4);
            matriz1.DefinirValor(1, 1, 5);
            matriz1.DefinirValor(1, 2, 6);
            // [1, 2, 3]
            // [4, 5, 6]

            Matriz matriz2 = new Matriz(3, 2);
            matriz2.DefinirValor(0, 0, 6);
            matriz2.DefinirValor(0, 1, 5);
            matriz2.DefinirValor(1, 0, 4);
            matriz2.DefinirValor(1, 1, 3);
            matriz2.DefinirValor(2, 0, 2);
            matriz2.DefinirValor(2, 1, 1);
            // [6, 5]
            // [4, 3]
            // [2, 1]

            try
            {
                Matriz resultado = Matriz.Multiplicar(matriz1, matriz2);
                Console.WriteLine("Resultado da multiplicação:");
                resultado.Imprimir();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}
>>>>>>> fc64f2d7e1cf1446ca006ae8d37152a3df4b6098
