using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using Ninject;
using Preparation.Domain.Abstract;
using Preparation.Domain.Concrete;
using Preparation.Domain.Entities;

namespace Preparation.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _ninjectKernel;
        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext,
        Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)_ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            _ninjectKernel.Bind<IPreparationRepository>().To<EFPrepartionRepository>();
            _ninjectKernel.Bind<IPreparationStore>().To<PreparationStore>();
        } 
    }
}