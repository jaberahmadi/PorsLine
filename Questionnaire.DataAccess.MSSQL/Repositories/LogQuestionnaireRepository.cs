using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elmah;
using Questionnaire.Common.Entities;
using Questionnaire.DataAccess.Repositories;

namespace Questionnaire.DataAccess.MSSQL.Repositories
{
    public class LogQuestionnaireRepository : ILogQuestionnaireRepository
    {
        private readonly QuestionnaireDbContext _context;

        public LogQuestionnaireRepository(QuestionnaireDbContext context)
        {
            _context = context;
        }
        public LogQuestionnaire AddLogQuestionnaire(LogQuestionnaire logQuestionnaire)
        {
            try
            {
                var result = _context.LogQuestionnaires.Add(logQuestionnaire);
                return result;

            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(new Exception("Exception Message: " + e.Message + " ,ErrorType:  AddLogQuestionnaire() has error"));

                return null;
            }

        }
    }
}
