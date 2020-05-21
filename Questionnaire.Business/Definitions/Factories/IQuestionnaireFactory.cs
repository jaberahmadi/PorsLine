using System.Collections.Generic;
using Questionnaire.Business.Dtos;
using Questionnaire.Common.Entities;

namespace Questionnaire.Business.Definitions.Factories
{
    public interface IQuestionnaireFactory
    {
        List<Questionnaires> CreateQuestionnaire(QuestionnaireDto questionnaireDto, int formId);
    }
}
