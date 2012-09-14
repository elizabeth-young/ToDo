using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace ToDo.Core.StructureMap
{
    public class ControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                if (controllerType != null)
                {
                    return ObjectFactory.GetInstance(controllerType) as Controller;
                }
                return base.GetControllerInstance(requestContext, controllerType);
            }
            catch (HttpException)
            {
                return null;
            }
        }
    }
}
