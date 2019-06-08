using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Modelo;

namespace Biblioteca.Negocio
{
    public class Contexto
    {
        public static Int32 TempoEspera = 5000; // Milisegundos
        public static DateTime Data = DateTime.Parse("01/06/2019");
        public static List<Obra> Estoque = new List<Obra>();
    }
}
