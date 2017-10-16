using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Falco.WebApi.Models
{
    public enum Sexo
    {
        Hombre, Mujer
    }
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public Sexo? Sexo { get; set; }

        public virtual ICollection<Cita> Citas { get; set; }
    }
}