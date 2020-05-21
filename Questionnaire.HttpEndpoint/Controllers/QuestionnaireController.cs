using System.Web.Http;
using Questionnaire.Business.Definitions.Services;
using Questionnaire.Common.Exceptions;

namespace Questionnaire.HttpEndpoint.Controllers
{
    [Route("api/Questionnaires")]
    public class QuestionnaireController : ApiController
    {
        private readonly IQuestionnaireService _questionnaireService;
        public QuestionnaireController(IQuestionnaireService questionnaireService)
        {
            _questionnaireService = questionnaireService;
        }
        [Route("Questionnaires")]
        public IHttpActionResult GetCurrentTest()
        {
            return Ok(_questionnaireService.GetQuestionnaire(null, 0));
        }
    }
}
