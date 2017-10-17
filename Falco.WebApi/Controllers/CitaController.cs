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
    }
}
