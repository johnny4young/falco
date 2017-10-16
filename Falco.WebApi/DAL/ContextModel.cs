using Falco.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Falco.WebApi.DAL
{
    public class ContextModel : DbContext
    {
        public ContextModel(): base("DefaultConnection") { }

        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<TipoCita> TipoCita { get; set; }
        public DbSet<Cita> Cita { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}