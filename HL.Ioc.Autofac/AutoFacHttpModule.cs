using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Autofac;

namespace HL.Ioc.Autofac
{
    public class AutoFacHttpModule : IHttpModule
    {
        public static readonly string HttpTag = "AutoFacTag";
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.EndRequest += Context_EndRequest;
        }

        public static ILifetimeScope GetLifeScope(ILifetimeScope container)
        {
            if (HttpContext.Current != null)
            {
                if (LifeScope==null)
                {
                    LifeScope = InitLifeScope(container);
                    return LifeScope;
                }
                else
                {
                    return LifeScope;
                }
                
            }
            else
            {
                throw new Exception("无法获取HttpCurrent");
            }
        }

        private static ILifetimeScope LifeScope
        {
            get
            {
                return (ILifetimeScope)HttpContext.Current.Items[typeof(ILifetimeScope)];
            }
            set
            {
                HttpContext.Current.Items[typeof(ILifetimeScope)] = value;
            }
        }
        private void Context_EndRequest(object sender, EventArgs e)
        {
            var life = LifeScope;
            if (life != null)
                LifeScope.Dispose();
        }

        private static ILifetimeScope InitLifeScope(ILifetimeScope container)
        {
            return container.BeginLifetimeScope(HttpTag);
        }
    }
}
