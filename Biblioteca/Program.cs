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
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Contexto.Form = new Form1();

            // Ler arquivo de estoque
            Util.LerArquivoEstoque("estoque.xml");

            // Ler arquivo de clientes
            Util.LerArquivoClientes("clientes.xml");

            // Ler arquivo de tarefas
            Util.LerArquivoTarefas("tarefas.xml");

            // Criar e iniciar threads
            Tempo tempo = new Tempo();
            Task.Run(tempo.Run);

            int atendentes = 1;

            if (args.Length > 0)
                atendentes = Convert.ToInt32(args[1]);

            for (int i = 0; i < atendentes; i++) {
                Atendente atendente = new Atendente();
                atendente.Nome = (i+1).ToString();
                Task.Run(atendente.Run);
            }

            Application.Run(Contexto.Form);
        }
    }
}
