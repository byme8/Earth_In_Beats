using Earth_In_Beats.WebService.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Batch;
using System.Web.OData.Extensions;
using Microsoft.OData.Edm;
using System.Web.OData.Builder;
using Earth_In_Beats.WebService.Contracts.Models;

namespace Earth_In_Beats.WebService.OData
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute("odata", null, GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            config.EnsureInitialized();

            config.DependencyResolver = Resolver.Instance;
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "Earth_In_Beats.WebService";
            builder.ContainerName = "DefaultContainer";
            builder.EntitySet<Device>("Devices").EntityType.HasKey(o => o.PublicKey);
            var edmModel = builder.GetEdmModel();
            return edmModel;
        }
    }
}
