using Falco.WebApi.DAL.Repository;
using Falco.WebApi.Models;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace Falco.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers     
            container.RegisterType<IGenericRepository<Paciente>, PacienteRepository>();
            container.RegisterType<IGenericRepository<Cita>, CitaRepository>();
            // e.g. container.RegisterType<ITestService, TestService>();
            //Register the Repository in the Unity Container            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}