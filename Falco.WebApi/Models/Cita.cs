using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Falco.WebApi.Models
{
    public class Cita
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Paciente")]
        public int PacientId { get; set; }
        public DateTime Fecha { get; set; }

        [Display(Name = "Tipo de cita")]
        public int TipoCitaId { get; set; }

        public virtual Paciente paciente { get; set; }
        public virtual TipoCita tipoCita { get; set; }
    }
}