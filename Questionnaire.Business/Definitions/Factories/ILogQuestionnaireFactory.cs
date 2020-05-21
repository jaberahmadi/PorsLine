using Questionnaire.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Business.Dtos.LogQuestionnaireDto;

namespace Questionnaire.Business.Definitions.Factories
{
    public interface ILogQuestionnaireFactory
    {
        LogQuestionnaireDto CreateLogQuestionnaireDto( FormSetting formSetting,string operations);
        LogQuestionnaire CreateLogQuestionnaire(LogQuestionnaireDto logQuestionnaireDto);
    }
}
