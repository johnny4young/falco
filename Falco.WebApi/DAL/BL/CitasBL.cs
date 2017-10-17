using Falco.WebApi.DAL.Repository;
using Falco.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Falco.WebApi.DAL.BL
{
    public class CitasBL
    {
        Cita citaCreated;
        public static string Crear(Cita cita)
        {
            IGenericRepository<Cita> _CitaRepository = new GenericRepository<Cita>();
            //we need validate the business constraint
            if (cita.PacientId == 0)
            {
                // send error                                
                return "Seleccione un paciente";
            }

            if (cita.TipoCitaId == 0)
            {
                // send error
                return "Seleccione un tipo de cita";
            }

            //1. minimun 24 hour
            TimeSpan diff = cita.Fecha - DateTime.Now;
            double hoursDiff = diff.TotalHours;

            if (hoursDiff < 24)
            {
                //send error
                return "Fecha ingresada inválida";
            }

            //2. check if appointment was created previouly in the same day
            var citasFounded = _CitaRepository.GetAll().Where(x => x.Fecha.Year == cita.Fecha.Year && x.Fecha.Month == cita.Fecha.Month && x.Fecha.Day == cita.Fecha.Day).Count();
            if (citasFounded > 0)
            {
                // send error
                return  "Ya se encuentra una cita asignada para el día de la fecha seleccionada";
            }

            //create cita
            _CitaRepository.Add(cita);
            _CitaRepository.Save();

            return string.Empty;
        }
    }
}