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
        public static void WriteLine(String message)
        {
            Console.WriteLine(message);
        }

        public static void LerArquivo(String arquivo)
        {
            Util.WriteLine("Lendo arquivo " + arquivo);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Obra>));
            TextReader reader = new StreamReader(arquivo);
            Contexto.Estoque = (List<Obra>) serializer.Deserialize(reader);
            Util.WriteLine("Arquivo lido com sucesso");
        }
    }
}
