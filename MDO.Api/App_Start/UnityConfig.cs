
using MDO.Core.Interfaces;
using MDO.Core.Services;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.WebApi;


namespace MDO
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers


            // register DatabaseService with IDatabaseService
            container.RegisterType<IDatabaseService, DatabaseService>(
                new ContainerControlledLifetimeManager()
            );

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}