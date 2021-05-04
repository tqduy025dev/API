using System.Web;
using System.Web.Mvc;

namespace _5951071008_TranQuangDuy_Nhom3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
