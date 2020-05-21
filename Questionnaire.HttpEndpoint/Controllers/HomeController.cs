using System.Timers;
using System.Web.Mvc;
using Questionnaire.Business.Definitions.Services;

namespace Questionnaire.HttpEndpoint.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuestionnaireService _questionnaireService;

        public HomeController(IQuestionnaireService questionnaireService)
        {
            _questionnaireService = questionnaireService;
        }
        public ActionResult Index()
        {
            //First call questionnaire
            _questionnaireService.CreateFormSettingForQuestionnaire();
            //Start period for questionnaire
            _questionnaireService.PeriodQuestionnaireTimer();

            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
