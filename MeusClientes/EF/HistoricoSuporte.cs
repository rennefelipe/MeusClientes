using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeusClientes.EF
{
    public class HistoricoSuporte
    {
        public int Id { get; set; }
        public string Equipamento { get; set; }
        public string Data { get; set; }
        public string Anotacao { get; set; }
    }
}
