using System.Web;
using System.Web.Mvc;

namespace Earth_In_Beats.WebService.OData
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
