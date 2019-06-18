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
            Util.LerArquivoEstoque("estoque.xml");


            /*List<Cliente> clientes = new List<Cliente>();
            Cliente cliente = new Cliente();
            cliente.Id = 1;
            cliente.Nome = "Teste";
            cliente.Obras = Contexto.Estoque;
            clientes.Add(cliente);*/
            /*
            List<Tarefa> tarefas = new List<Tarefa>();
            Tarefa tarefa = new Tarefa();
            tarefa.Data = DateTime.Parse("01/06/2019");
            tarefa.Obra = Contexto.Estoque.ElementAt(0);
            tarefa.Cliente = cliente;

            tarefas.Add(tarefa);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Tarefa>));
            TextWriter reader = new StreamWriter("tarefas.xml");
            serializer.Serialize(reader, tarefas);
            */

            /*XmlSerializer serializer = new XmlSerializer(typeof(List<Cliente>));
            TextWriter reader = new StreamWriter("clientes.xml");
            serializer.Serialize(reader, clientes);*/

            // Ler arquivo de clientes
            Util.LerArquivoClientes("clientes.xml");

            // Ler arquivo de tarefas
            Util.LerArquivoTarefas("tarefas.xml");

            // Criar e iniciar threads
            Tempo tempo = new Tempo();
            Task.Run(tempo.Run);

            for (int i = 0; i < 1; i++) {
                Atendente atendente = new Atendente();
                atendente.Nome = (i+1).ToString();
                Task.Run(atendente.Run);
            }

            Form form = new Form1();
            
            Application.Run(new Form1());

            form.Hide();
        }
    }
}
