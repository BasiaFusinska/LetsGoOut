using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using LetsGoOut.Domain;
using LetsGoOut.Domain.DTOs;
using LetsGoOut.Domain.Handlers;
using LetsGoOut.Domain.Requests;
using LetsGoOut.Domain.Services;
using LetsGoOut.Persistence;

namespace LetsGoOut
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private IContainer _container;

        protected void Application_Start()
        {
     
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SetUpContainer();
        }

        private void SetUpContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new AutofacWebTypesModule());
            RegisterCustomServices(builder);

            _container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
        }

        private void RegisterCustomServices(ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseContext>()
                .As<DbContext>()
                .InstancePerRequest()
                .OnRelease(context => context.SaveChanges());

            builder.RegisterType<ActivityService>()
                .As<IActivityService>();
            builder.RegisterType<LinkService>()
                .As<ILinkService>();

            builder.RegisterType<CreateActivityHandler>()
                .As<IRequestHandler<CreateActivityRequest, CreateActivityModel>>()
                .As<IHandler<CreateActivityModel>>();

            builder.RegisterType<EditActivityHandler>()
                .As<IRequestHandler<EditActivityRequest, EditActivityModel>>()
                .As<IHandler<EditActivityModel>>();

            builder.RegisterType<MoveActivityHandler>()
                .As<IRequestHandler<MoveActivityRequest, MoveActivityModel>>()
                .As<IHandler<MoveActivityModel>>();
            
            builder.RegisterType<CreateLinkHandler>()
                .As<IRequestHandler<CreateLinkRequest, CreateLinkModel>>()
                .As<IHandler<CreateLinkModel>>();

            builder.RegisterType<CommandsBus>()
                .As<ICommandBus>();
        }
    }
}
