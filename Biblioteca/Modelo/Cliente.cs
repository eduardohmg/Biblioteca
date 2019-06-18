using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelo
{
    public class Cliente
    {
        public Int32 Id { get; set; }
        public String Nome { get; set; }
        public List<Obra> Obras { get; set; }
    }
}
