using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeusClientes.EF
{
    public class DadoEndereco
    {
        public int Id { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
    }
}
