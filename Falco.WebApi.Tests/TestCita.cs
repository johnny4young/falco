using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Falco.WebApi.Controllers;
using Falco.WebApi.DAL.Repository;
using Falco.WebApi.Models;
using Falco.WebApi.DAL.BL;

namespace Falco.WebApi.Tests
{
    [TestClass]
    public class TestCita
    {
        [TestMethod]
        public void CrearCita_ShouldValidPaciente()
        {
                        

            //create cita sin paciente
            Cita cita = new Cita()
            {
                PacientId = 0,
                TipoCitaId = 1,
                Fecha = DateTime.Now
            };
            var resp =  CitasBL.Crear(cita);

            Assert.AreEqual(resp, "Seleccione un paciente");

        }

        [TestMethod]
        public void CrearCita_ShouldValidTipoCita()
        {


            //create cita sin paciente
            Cita cita = new Cita()
            {
                PacientId = 1,
                TipoCitaId = 0,
                Fecha = DateTime.Now
            };
            var resp = CitasBL.Crear(cita);

            Assert.AreEqual(resp, "Seleccione un tipo de cita");

        }

        [TestMethod]
        public void CrearCita_ShouldValidFechaCorta()
        {


            //create cita sin paciente
            Cita cita = new Cita()
            {
                PacientId = 1,
                TipoCitaId = 1,
                Fecha = DateTime.Now.AddHours(5)
            };
            var resp = CitasBL.Crear(cita);

            Assert.AreEqual(resp, "Fecha ingresada inválida");

        }

        [TestMethod]
        public void CrearCita_ShouldValidFechaPermitida()
        {


            //create cita sin paciente
            Cita cita = new Cita()
            {
                PacientId = 1,
                TipoCitaId = 1,
                Fecha = DateTime.Now.AddHours(-100)
            };
            var resp = CitasBL.Crear(cita);

            Assert.AreEqual(resp, "Fecha ingresada inválida");

        }
    }
}
