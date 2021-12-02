using System.Web;
using System.Web.Mvc;

namespace SLIT_Mvc_2017_WithImage
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
