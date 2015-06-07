using PruebaVistasDinamicas.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PruebaVistasDinamicas
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new CustomRazorViewEngine());

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }

    public class CustomRazorViewEngine : RazorViewEngine
    {
        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            if (IsDynamicView(virtualPath))
            {
                CreateViewFiler(virtualPath);
            }
            return base.FileExists(controllerContext, virtualPath);
        }

        private static void CreateViewFiler(string virtualPath)
        {
            var viewName = virtualPath.Split('/')[1];


            string viewHtml = InMemoryStorage.templateCode.Code;
            var viewPath = HostingEnvironment.MapPath(virtualPath);

            //MemoryCache.Default.get
            // OJO: Asumimos que existe la carpeta /DynamicViews/

            File.Delete(viewPath);
            File.AppendAllText(path: viewPath,
                contents: viewHtml);
        }

        private static bool IsDynamicView(string virtualPath)
        {
            return virtualPath.ToLower().Contains("/dynamicviews/");
        }
    }
}