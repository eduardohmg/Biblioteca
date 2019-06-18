using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Biblioteca.Modelo;

namespace Biblioteca.Negocio
{
    public class Contexto
    {
        public static Int32 TempoDia = 500; // Milisegundos
        public static Int32 TempoAntendente = 50; // Milisegundos
        public static Int32 QtdeAtendimento = 1;
        public static DateTime DataAtual = DateTime.Parse("31/05/2019");
        public static List<Obra> Estoque = new List<Obra>();
        public static List<Cliente> Clientes = new List<Cliente>();
        public static List<Tarefa> Tarefas = new List<Tarefa>();
        public static Semaphore SemaforoAtendente = new Semaphore(1, 1, "Semáforo Atendente");
    }
}
