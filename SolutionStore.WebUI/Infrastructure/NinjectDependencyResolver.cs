using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using SolutionStore.Domain.Abstract;
using SolutionStore.Domain.Entities;
using SolutionStore.Domain.Concrete;

namespace SolutionStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel mykernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            mykernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type myserviceType)
        {
            return mykernel.TryGet(myserviceType);
        }

        public IEnumerable<object> GetServices(Type myserviceType)
        {
            return mykernel.GetAll(myserviceType);
        }

        private void AddBindings()
        {
            mykernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}