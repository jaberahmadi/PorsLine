using System.Web;
using System.Web.Mvc;

namespace Questionnaire.HttpEndpoint
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
