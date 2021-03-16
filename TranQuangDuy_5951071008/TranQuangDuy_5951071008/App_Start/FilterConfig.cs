using System.Web;
using System.Web.Mvc;

namespace TranQuangDuy_5951071008
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
