using Biblioteca.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Negocio
{
    public class Atendente
    {
        public String Nome = "";
        private long QtdeAtendimentos = 0;
        private DateTime UltimaData = DateTime.Now;

        public async Task Run()
        {
            Util.WriteLine("Atendente " + this.Nome + ": " + " Inicializado");
            
            while (true)
            {
                if (!this.UltimaData.Equals(Contexto.DataAtual))
                {
                    //Util.WriteLine("Atendente " + this.Nome + ": " + " Novo dia. Resetando contador de atendimentos");
                    this.QtdeAtendimentos = 0;
                    this.UltimaData = Contexto.DataAtual;
                }

                // Verificar se pode atender
                if(this.QtdeAtendimentos < Contexto.QtdeAtendimento)
                {
                    Contexto.SemaforoAtendente.WaitOne(); // Para que duas threads não acessem ao mesmo tempo a lista
                    //Util.WriteLine("Atendente " + this.Nome + ": " + " Obteve o semáforo");
                    // Buscar próxima tarefa com data até hoje
                    Tarefa tarefa = Contexto.Tarefas.FirstOrDefault(tar => !tar.Executada);

                    if (tarefa != null && tarefa.Data <= Contexto.DataAtual)
                    {
                        // Executa
                        Obra obra = Contexto.Estoque.Find(obj => obj.Id == tarefa.Obra.Id);
                        Cliente cliente = Contexto.Clientes.Find(cli => cli.Id == tarefa.Cliente.Id);

                        if (Acao.Aluguel.Equals(tarefa.Acao))
                        {
                            Util.WriteLine("Atendente " + this.Nome + ": " + "Cliente " + cliente.Nome + " quer alugar a obra " + obra.Nome);

                            if (!cliente.Obras.Exists(obraCliente => obraCliente.Id == obra.Id))
                            {
                                if (obra.Disponivel > 1)
                                {
                                    obra.Disponivel--;
                                    cliente.Obras.Add(obra);
                                    cliente.Obras.Last().DataAluguel = Contexto.DataAtual;
                                    Util.WriteLine("Atendente " + this.Nome + ": " + "Cliente " + cliente.Nome + " alugou a obra " + obra.Nome);
                                } else
                                {
                                    Util.WriteLine("Atendente " + this.Nome + ": " + "A obra " + obra.Nome + " só possui um único exemplar");
                                }
                            } else
                            {
                                Util.WriteLine("Atendente " + this.Nome + ": " + "Cliente " + cliente.Nome + " já possui a obra " + obra.Nome);
                            }
                        } else
                        {
                            Util.WriteLine("Atendente " + this.Nome + ": " + "Cliente " + cliente.Nome + " quer devolver a obra " + obra.Nome);

                            if (cliente.Obras.Exists(obraCliente => obraCliente.Id == obra.Id))
                            {
                                obra.Disponivel++;
                                long diasAlugados = Convert.ToInt64(Contexto.DataAtual.Subtract(cliente.Obras.Find(oo => oo.Id == obra.Id).DataAluguel).TotalDays);
                                cliente.Obras.Remove(obra);
                                if (diasAlugados > 7)
                                {
                                    long multa = diasAlugados - 7;
                                    Util.WriteLine("Atendente " + this.Nome + ": " + "Cliente " + cliente.Nome + " devolveu a obra " + obra.Nome + " com multa de " + multa + " reais");
                                }
                                else
                                {
                                    Util.WriteLine("Atendente " + this.Nome + ": " + "Cliente " + cliente.Nome + " devolveu a obra " + obra.Nome);
                                }
                            } else
                            {
                                Util.WriteLine("Atendente " + this.Nome + ": " + "Cliente " + cliente.Nome + " não possui a obra " + obra.Nome);
                            }
                        }

                        tarefa.Executada = true;
                        this.QtdeAtendimentos++;
                    }

                    Contexto.SemaforoAtendente.Release();
                    //Util.WriteLine("Atendente " + this.Nome + ": " + " Largou o semáforo");
                }

                await Task.Delay(Contexto.TempoAntendente);
            }
        }
    }
}
