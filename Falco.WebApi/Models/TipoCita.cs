using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Falco.WebApi.Models
{
    public class TipoCita
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cita> Citas { get; set; }
    }
}