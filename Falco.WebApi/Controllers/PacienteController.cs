﻿using Falco.WebApi.DAL;
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
        IGenericRepository<Paciente> _PacienteRepository;

        //use DI by unity
        public PacienteController(IGenericRepository<Paciente> PacienteRepository)
        {
            this._PacienteRepository = PacienteRepository;
        }

        [HttpGet]
        public IEnumerable GetAll()
        {
            var temp = _PacienteRepository.GetAll();
            return temp;
        }
    }
}
