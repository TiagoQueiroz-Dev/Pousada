using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entidades.Cliente.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Database
{
    public class PousadaContext : IdentityDbContext
    {
        public PousadaContext(DbContextOptions<PousadaContext> options) : base(options){}

        public DbSet<ClienteModel> clientes { get; set; }
    }
}