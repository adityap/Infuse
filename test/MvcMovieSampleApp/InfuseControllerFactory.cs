using Infuse;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcMovieSampleApp
{
    public class InfuseControllerFactory : DefaultControllerFactory
    {
        private readonly IContainer _container;

        public InfuseControllerFactory(IContainer container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return _container.Resolve(controllerType) as IController;

        }
    }
}
