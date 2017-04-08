using System.Web;
using System.Web.Mvc;

namespace Patacchiola.Patrik._5h.XMLWebAddRecord
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
