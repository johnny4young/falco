﻿using Falco.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Falco.WebApi.DAL.Repository
{
    public class PacienteRepository : GenericRepository<Paciente>
    {
        public PacienteRepository()
           : base()
       {

        }
    }
}