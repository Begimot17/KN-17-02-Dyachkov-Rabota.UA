using System.Web;
using System.Web.Mvc;

namespace Kursach_Web_Dyachkov
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
