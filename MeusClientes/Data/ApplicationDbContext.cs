using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MeusClientes.EF;

namespace MeusClientes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MeusClientes.EF.DadoContato> DadoContato { get; set; }
        public DbSet<MeusClientes.EF.DadoEndereco> DadoEndereco { get; set; }
        public DbSet<MeusClientes.EF.DadoPessoal> DadoPessoal { get; set; }
        public DbSet<MeusClientes.EF.HistoricoSuporte> HistoricoSuporte { get; set; }
    }
}
