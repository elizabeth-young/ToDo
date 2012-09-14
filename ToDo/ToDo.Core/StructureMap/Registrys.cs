using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using ToDo.Data.Context;

namespace ToDo.Core.StructureMap
{
    public class RepositoryRegistory : Registry
    {
        public RepositoryRegistory()
        {
            Scan(x =>
            {
                x.Assembly("ToDo.Data");
                x.TheCallingAssembly();
                x.WithDefaultConventions();
            });
            //Tell structuremap what to send to the constructor
            For<IToDoContextProvider>().Use<ToDoContextProvider>().Ctor<string>("dbName").Is(String.Empty);
        }
    }

    public class ServiceRegistory : Registry
    {
        public ServiceRegistory()
        {
            Scan(x =>
            {
                x.Assembly("ToDo.Services");
                x.TheCallingAssembly();
                x.WithDefaultConventions();
            });
        }
    }
}
