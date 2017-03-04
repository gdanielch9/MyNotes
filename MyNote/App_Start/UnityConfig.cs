using System;
using MyNote.Services;
using MyNote.Models;
using System.Data.Entity;
using MyNote.Repositories;
using AutoMapper;
using MyNote.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyNote.Controllers;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace MyNote.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType<UserManager<ApplicationUser>>();
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<IMapper>( new InjectionFactory(c => AutoMapperConfiguration.ConfigureMapper()));
            container.RegisterType<IMappingInfrastructure, MappingInfrastructure>();
            container.RegisterType<IAuthInfrastructure, AuthInfrastructure>();
            container.RegisterType<IEventService, EventService>();
            container.RegisterType<IEventsRepository, EventsRepository>();
            container.RegisterType<IPhotosService, PhotosService>();

        }
    }
}
