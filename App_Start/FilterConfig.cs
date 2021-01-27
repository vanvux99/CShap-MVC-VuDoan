using System.Web;
using System.Web.Mvc;

namespace CShap_MVC_VuDoan
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
