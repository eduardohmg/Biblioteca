﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Negocio
{
    public class Tempo
    {
        public async Task Run()
        {
            while (true)
            {
                await Task.Delay(Contexto.TempoEspera);

                Contexto.Data = Contexto.Data.AddDays(1);
                Util.WriteLine("Data atual alterada para " + Contexto.Data);
            }
        }
    }
}