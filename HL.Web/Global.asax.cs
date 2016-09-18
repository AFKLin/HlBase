using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HL.Core.Infrastructure;
using HL.Ioc.Autofac;
using HL.Core.Ioc;
using HL.Data;
using HL.Core;
using HL.Core.Cache;

namespace HL.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Bootstrapper.Create()
                .UseAutoFac()
                .RegestCustomCommponet(c =>
                {
                    c.RegisterType<IDbContext>(() => new EfDbContext("Data Source=.;Initial Catalog=HlBase;User ID=sa;Password=a456852"),null,LifeStyle.PreRequest);
                    c.RegisterType<IUnitOfWork, UnitOfWork>(LifeStyle.PreRequest);
                    c.RegisterType<ICacheManager, MemoryCacheManager>(LifeStyle.Singleton);
                    c.RegisterType<ICacheManager, MemoryCacheManager>(LifeStyle.Singleton);
                });

        }
    }
}
