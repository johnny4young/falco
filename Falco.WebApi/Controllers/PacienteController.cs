using Falco.WebApi.DAL;
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
    public class PacienteController : ApiController
    {
        ContextModel _context = null;
        IGenericRepository<Paciente> _PersonaRepository;

        public PacienteController()
        {
            this._context = new ContextModel();
            this._PersonaRepository = new GenericRepository<Paciente>(this._context);
        }

        [HttpGet]
        public IEnumerable GetAll()
        {
            var temp = _PersonaRepository.GetAll();
            return temp;
        }
    }
}
