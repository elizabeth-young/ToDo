using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using StructureMap;

namespace ToDo.Core.StructureMap
{
    public class DependencyResolver : IDependencyResolver
    {
        private readonly IContainer container;

        public DependencyResolver(IContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.GetInstance(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.GetAllInstances<object>().Where(s => s.GetType() == serviceType);
        }
    }
}
