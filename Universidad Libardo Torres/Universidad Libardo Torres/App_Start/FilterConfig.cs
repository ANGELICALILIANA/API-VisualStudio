using System.Web;
using System.Web.Mvc;

namespace Universidad_Libardo_Torres
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
