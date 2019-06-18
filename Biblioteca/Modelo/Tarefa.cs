using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelo
{
    public class Tarefa
    {
        public DateTime Data { get; set; }
        public Cliente Cliente { get; set; }
        public Obra Obra { get; set; }
        public Acao Acao { get; set; }
        public Boolean Executada { get; set; }

        public Tarefa()
        {
            this.Executada = false;
        }
    }
}
