using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Falco.WebApi.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public int PacientId { get; set; }
        public DateTime Fecha { get; set; }
        public int TipoCitaId { get; set; }

        public virtual Paciente paciente { get; set; }
        public virtual TipoCita tipoCita { get; set; }
    }
}