using Earth_In_Beats.WebService.Business.Contracts.Services;
using Earth_In_Beats.WebService.Business.Fake.Services;
using Microsoft.Practices.Unity;
using System;

namespace Earth_In_Beats.WebService.IoC
{
    public class Resolver : IResolver
    {
        protected IUnityContainer container;
        protected static IResolver instance;

        public static IResolver Instance
        {
            get
            {
                return instance ?? (instance = new Resolver(new UnityContainer()));

            }
        }

        static Resolver()
        {
            instance = new Resolver(new UnityContainer());
        }

        Resolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
            this.Bind();
        }

        private void Bind()
        {
            container.RegisterType<IDeviceService, DeviceService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITrackService, TrackService>(new HierarchicalLifetimeManager());
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
