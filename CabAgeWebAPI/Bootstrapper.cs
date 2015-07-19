using System.Web.Http;
using CabAgeBusinessServices.Interfaces;
using CabAgeBusinessServices.Services;
using Microsoft.Practices.Unity;
using Resolver;

namespace CabAgeWebAPI
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            //container.RegisterType<ICategoryMasterService,CategoryMasterService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());            
            RegisterTypes(container);
            return container;
        }


        public static void RegisterTypes(IUnityContainer container)
        {

            //Component initialization via MEF
            ComponentLoader.LoadContainer(container, ".\\bin", "CabAgeWebAPI.dll");
            ComponentLoader.LoadContainer(container, ".\\bin", "CabAgeBusinessServices.dll");

        }

    }
}