using Falco.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Falco.WebApi.DAL
{
    public class ClinicaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ContextModel>
    {
        protected override void Seed(ContextModel context)
        {
            //create the "tipos de citas"
            var tiposCita = new List<TipoCita>
            {
                new TipoCita { Descripcion = "Medicina General" },
                new TipoCita { Descripcion = "Odontología" },
                new TipoCita { Descripcion = "Pediatría" },
                new TipoCita { Descripcion = "Neurología" }
            };

            tiposCita.ForEach(tipoCita => context.TipoCita.Add(tipoCita));
            context.SaveChanges();

            //create two "paciente" for testing
            var pacientes = new List<Paciente>
            {
                new Paciente { Nombre ="johnny",   Edad=34, Sexo=Sexo.Hombre },
                new Paciente { Nombre ="carolina", Edad=27, Sexo=Sexo.Mujer },
            };
            pacientes.ForEach(paciente => context.Paciente.Add(paciente));
            context.SaveChanges();
            
        }
    }
}