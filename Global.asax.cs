﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcContrib.ControllerFactories;
using MvcContrib.Services;
using MvcContrib.StructureMap;
using MVCSample.Controllers;
using MVCSample.Models;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace MVCSample
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);

            
            DependencyResolver.InitializeWith(new StructureMapDependencyResolver());
            ObjectFactory.Initialize(init => init.AddRegistry(new MVCSampleRegistry()));
            ControllerBuilder.Current.SetControllerFactory(new IoCControllerFactory());
        }
    }

    public class MVCSampleRegistry : Registry
    {
        public MVCSampleRegistry()
        {
            ForRequestedType<HomeController>()
                .TheDefaultIsConcreteType<HomeController>();

            ForRequestedType<ILinkRepository>()
                .TheDefaultIsConcreteType<InMemoryLinks>();
        }
    }
}