using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Common.Entities;

namespace Questionnaire.DataAccess.Repositories
{
    public interface ILogQuestionnaireRepository
    {
        LogQuestionnaire AddLogQuestionnaire(LogQuestionnaire logQuestionnaire);
    }
}
