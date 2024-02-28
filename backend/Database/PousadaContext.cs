using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using backend.Entidades.Cliente.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Database
{
    public class PousadaContext : IdentityDbContext
    {
        public PousadaContext(DbContextOptions<PousadaContext> options) : base(options) { }
        public DbSet<ClienteModel> Clientes { get; set; }
    }
}