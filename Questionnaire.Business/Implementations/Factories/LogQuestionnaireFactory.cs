using System;
using Questionnaire.Business.Definitions.Factories;
using Questionnaire.Business.Dtos.LogQuestionnaireDto;
using Questionnaire.Business.Enums;
using Questionnaire.Common.Entities;
using Questionnaire.DataAccess;
using Questionnaire.DataAccess.Repositories;

namespace Questionnaire.Business.Implementations.Factories
{
    public class LogQuestionnaireFactory : ILogQuestionnaireFactory
    {
        
        public LogQuestionnaireDto CreateLogQuestionnaireDto( FormSetting formSetting, string operations)
        {
            var operationsTypes = operations == "Delete" ? (int) OperationsType.Delete : (int) OperationsType.Add;
            
                var logQuestionnaireDto = new LogQuestionnaireDto
                {
                    FormId = formSetting.FormId,
                    Operations = operations,
                    OperationsType = operationsTypes,
                    CreateDate = DateTime.Now,
                    Descriptions = formSetting.Descriptions
                };
                return logQuestionnaireDto;
                
        }
        public LogQuestionnaire CreateLogQuestionnaire(LogQuestionnaireDto logQuestionnaireDto)
        {
            var logQuestionnaire = new LogQuestionnaire
            {
                OperationsType = logQuestionnaireDto.OperationsType,
                CreateDate = logQuestionnaireDto.CreateDate,
                FormId = logQuestionnaireDto.FormId,
                Operations = logQuestionnaireDto.Operations,
                Descriptions = logQuestionnaireDto.Descriptions
            };
            return logQuestionnaire;
        }
    }
}
