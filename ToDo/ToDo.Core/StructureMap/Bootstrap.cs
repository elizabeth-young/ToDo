using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using StructureMap;

namespace ToDo.Core.StructureMap
{
    public static class Bootstrap
    {
        public static void Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<RepositoryRegistory>();
                x.AddRegistry<ServiceRegistory>();
                x.For<IPrincipal>().Use(c => HttpContext.Current.User);
            });
            Debug.WriteLine(ObjectFactory.WhatDoIHave());
        }
    }
}
