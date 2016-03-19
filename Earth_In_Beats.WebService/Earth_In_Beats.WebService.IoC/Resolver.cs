using System;
using Earth_In_Beats.WebService.Business.Contracts.Services;
using Earth_In_Beats.WebService.Business.Implementation.Services;
using Earth_In_Beats.WebService.DAL.Contracts.Repository;
using Earth_In_Beats.WebService.DAL.Fake.Implementation.Repositories;
using Microsoft.Practices.Unity;

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
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>), new HierarchicalLifetimeManager());
            container.RegisterType<IDeviceRepository, DeviceRepository>(new HierarchicalLifetimeManager());

	        container.RegisterType<IDeviceService, DeviceService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITrackService, TrackService>(new HierarchicalLifetimeManager());
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
