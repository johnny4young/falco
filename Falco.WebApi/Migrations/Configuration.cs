namespace Falco.WebApi.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Falco.WebApi.DAL.ContextModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Falco.WebApi.DAL.ContextModel context)
        {
            //create the "tipos de citas"
            var tiposCita = new List<TipoCita>
            {
                new TipoCita { Descripcion = "Medicina General" },
                new TipoCita { Descripcion = "Odontología" },
                new TipoCita { Descripcion = "Pediatría" },
                new TipoCita { Descripcion = "Neurología" }
            };

            tiposCita.ForEach(tipoCita => context.TipoCita.AddOrUpdate(p => p.Descripcion , tipoCita));
            context.SaveChanges();

            //create two "paciente" for testing
            var pacientes = new List<Paciente>
            {
                new Paciente { Nombre ="johnny",   Edad=34, Sexo=Sexo.Hombre },
                new Paciente { Nombre ="carolina", Edad=27, Sexo=Sexo.Mujer },
            };
            pacientes.ForEach(paciente => context.Paciente.AddOrUpdate( p => p.Nombre, paciente));
            context.SaveChanges();
        }
    }
}
