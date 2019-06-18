using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Biblioteca.Modelo;
using Biblioteca.Negocio;

namespace Biblioteca.Negocio
{
    public class Util
    {
        public static void WriteLine(String mensagem)
        {
            Contexto.SemaforoLog.WaitOne();

            Console.WriteLine(mensagem);

            using (StreamWriter w = File.AppendText("log.txt"))
            {
                w.WriteLine(mensagem);
            }

            Contexto.Form.WriteLineLog(mensagem);

            Contexto.SemaforoLog.Release();
        }

        public static void LerArquivoEstoque(String arquivo)
        {
            Util.WriteLine("Lendo arquivo " + arquivo);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Obra>));
            TextReader reader = new StreamReader(arquivo);
            Contexto.Estoque = (List<Obra>) serializer.Deserialize(reader);
            Util.WriteLine("Arquivo lido com sucesso");
        }

        public static void LerArquivoClientes(String arquivo)
        {
            Util.WriteLine("Lendo arquivo " + arquivo);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Cliente>));
            TextReader reader = new StreamReader(arquivo);
            Contexto.Clientes = (List<Cliente>)serializer.Deserialize(reader);
            Util.WriteLine("Arquivo lido com sucesso");
        }

        public static void LerArquivoTarefas(String arquivo)
        {
            Util.WriteLine("Lendo arquivo " + arquivo);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Tarefa>));
            TextReader reader = new StreamReader(arquivo);
            Contexto.Tarefas = (List<Tarefa>)serializer.Deserialize(reader);
            Util.WriteLine("Arquivo lido com sucesso");
        }
    }
}
