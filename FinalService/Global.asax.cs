using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace FinalService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AppDomain.CurrentDomain.SetData("DataDirectory", @"C:\Users\Ian\Desktop\Final 2\CST356FinalProject\Lab_01_Ian_Gesner\App_Data\");
            //DependencyInjectionConfig.Register();

        }
    }
}
