using System.Web;
using System.Web.Mvc;

namespace Restaurant
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //HandleErrorAttribute shows a friendly error page if error occurs

            filters.Add(new HandleErrorAttribute());
        }
    }
}
