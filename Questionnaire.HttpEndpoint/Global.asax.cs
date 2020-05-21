using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json.Serialization;
using Questionnaire.Business.Definitions.Factories;
using Questionnaire.Business.Definitions.Services;
using Questionnaire.Business.Factories;
using Questionnaire.Business.Implementations.Factories;
using Questionnaire.Business.Implementations.Services;
using Questionnaire.DataAccess;
using Questionnaire.DataAccess.MSSQL;
using Unity;
using Unity.AspNet.Mvc;

namespace Questionnaire.HttpEndpoint
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new UnityContainer();
            container.RegisterType<IQuestionnaireService, QuestionnaireService>();
            container.RegisterType<IQuestionnaireFactory, QuestionnaireFactory>();
            container.RegisterType<ILogQuestionnaireService, LogQuestionnaireService>();
            container.RegisterType<ILogQuestionnaireFactory, LogQuestionnaireFactory>();
            container.RegisterType<IUnitOfWork, SqlUnitOfWork>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            var config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

        }
	}
}
