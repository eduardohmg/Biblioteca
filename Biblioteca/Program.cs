using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Biblioteca.Modelo;
using Biblioteca.Negocio;

namespace Biblioteca
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Ler arquivo de estoque
            Util.LerArquivo("testoo.xml");

            // Criar e iniciar threads
            Tempo tempo = new Tempo();
            Task.Run(tempo.Run);

            Application.Run(new Form1());
        }
    }
}
