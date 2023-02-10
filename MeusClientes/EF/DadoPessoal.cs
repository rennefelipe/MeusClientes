using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeusClientes.EF
{
    public class DadoPessoal
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNasc { get; set; }
    }
}
