using System.Collections.Generic;
using Questionnaire.Common.Entities;

namespace Questionnaire.DataAccess.Repositories
{
    public interface IQuestionnaireRepository
    {
        IEnumerable<Questionnaires> FindQuestionnaireListForDelete(int formId);
        Questionnaires Add(Questionnaires questionnaire);
        IEnumerable<Questionnaires> AddList(List<Questionnaires> questionnaireList);
        IEnumerable<Questionnaires> DeleteQuestionnaireList(IEnumerable<Questionnaires> questionnaireList);

    }
}
