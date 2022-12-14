using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Locadora.Models;

namespace Locadora.Data
{
    public class LocadoraContext : DbContext
    {
        public LocadoraContext (DbContextOptions<LocadoraContext> options)
            : base(options)
        {
        }

        public DbSet<Locadora.Models.Cliente> Cliente { get; set; }


        public DbSet<Locadora.Models.Filme> Filme { get; set; }


        public DbSet<Locadora.Models.Aluguel> Aluguel { get; set; }
        public object Filmes { get; internal set; }
        public object Clientes { get; internal set; }
    }
}

