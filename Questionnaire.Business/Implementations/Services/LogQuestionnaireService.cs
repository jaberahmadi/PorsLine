using System;
using Elmah;
using Questionnaire.Business.Definitions.Factories;
using Questionnaire.Business.Definitions.Services;
using Questionnaire.Common.Entities;
using Questionnaire.DataAccess;

namespace Questionnaire.Business.Implementations.Services
{
    public class LogQuestionnaireService : ILogQuestionnaireService
    {
        private readonly ILogQuestionnaireFactory _logQuestionnaireFactory;
        private readonly IUnitOfWork _unitOfWork;

        public LogQuestionnaireService(ILogQuestionnaireFactory logQuestionnaireFactory, IUnitOfWork unitOfWork)
        {
            _logQuestionnaireFactory = logQuestionnaireFactory;
            _unitOfWork = unitOfWork;
        }

        public void InsertLogQuestionnaire(LogQuestionnaire logQuestionnaire)
        {
            var result = _unitOfWork.LogQuestionnaireRepository.AddLogQuestionnaire(logQuestionnaire);
            try
            {
                _unitOfWork.Commit();
            }
            catch
            {
                ErrorSignal.FromCurrentContext().Raise(new Exception("Entity null references"));

            }
        }

    }
}
