using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using DataAccess.UnitOfWork;
using DataAccess.UnitOfWork.Interfaces;
using System.Web.Http;
using System.Web.Mvc;

namespace Presentation.App_Start
{
    public class AutofacConfig
    {
    public static void Configure()
        {

            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerRequest();
            containerBuilder.RegisterApiControllers(typeof(MvcApplication).Assembly).InstancePerRequest();


            containerBuilder.RegisterType<PiazzaDbContext>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<AccountService>().As<IAccountService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<OfferService>().As<IOfferService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<AccountRepository>().As<IAccountRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<OfferImageRepository>().As<IOfferImageRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<OfferRepository>().As<IOfferRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            IContainer autofacContainer = containerBuilder.Build();
            AutofacDependencyResolver mvcDependencyResolver = new AutofacDependencyResolver(autofacContainer);
            AutofacWebApiDependencyResolver webapiDependencyResolver = new AutofacWebApiDependencyResolver(autofacContainer);
            DependencyResolver.SetResolver(mvcDependencyResolver);
            GlobalConfiguration.Configuration.DependencyResolver = webapiDependencyResolver;
        }
    }
}