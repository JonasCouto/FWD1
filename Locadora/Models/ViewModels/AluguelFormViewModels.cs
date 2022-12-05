using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models.ViewModels
{
    public class AluguelFormViewModels
    {
        public Aluguel? Aluguel { get; set; }
        public ICollection<Filme> Filmes = new List<Filme>();
        public ICollection<Cliente> Clientes = new List<Cliente>();
    }
}
