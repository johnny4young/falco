using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Falco.WebApi.Models
{
    public class CitaDto 
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Paciente")]
        public int PacientId { get; set; }
        public DateTime Fecha { get; set; }        
        public int TipoCitaId { get; set; }

        public  Paciente paciente { get; set; }
        public TipoCita tipoCita { get; set; }
        public string NombrePaciente { get; set; }
    }
}