using Falco.WebApi.DAL.Repository;
using Falco.WebApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Falco.WebApi.Controllers
{
    public class CitaController : ApiController
    {
        
        IGenericRepository<Cita> _CitaRepository;

        //use DI by unity
        public CitaController(IGenericRepository<Cita> CitaRepository)
        {
            this._CitaRepository = CitaRepository;
        }

        [HttpGet]
        public IEnumerable GetAll()
        {
            var temp = _CitaRepository.GetAll();
            return temp;
        }

        [HttpPost]
        [Route("api/cita/crear")]
        public HttpResponseMessage Crear(Cita cita)
        {
            //we need validate the business constraint
            if ( cita.PacientId == 0)
            {
                // send error                                
                return  Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Seleccione un paciente");
            }

            if ( cita.TipoCitaId == 0)
            {
                // send error
                return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Seleccione un tipo de cita");
            }

            //1. minimun 24 hour
            TimeSpan diff = cita.Fecha - DateTime.Now;
            double hoursDiff = diff.TotalHours;

            if(hoursDiff < 24)
            {
                //send error
                return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Fecha ingresada inválida");
            }

            //2. check if appointment was created previouly in the same day
            var citasFounded = _CitaRepository.GetAll().Where(x => x.Fecha.Year == cita.Fecha.Year && x.Fecha.Month == cita.Fecha.Month && x.Fecha.Day == cita.Fecha.Day).Count();
            if ( citasFounded > 0)
            {
                // send error
                return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Ya se encuentra una cita asignada para el día de la fecha seleccionada");
            }

            //create cita
            _CitaRepository.Add(cita);
            _CitaRepository.Save();

            return Request.CreateResponse<Cita>(HttpStatusCode.OK, cita); ;
        }
    }
}
