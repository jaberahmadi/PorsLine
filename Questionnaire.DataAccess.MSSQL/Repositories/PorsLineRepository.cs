using System;
using System.Collections.Generic;
using System.Linq;
using Elmah;
using Questionnaire.Common.Entities;
using Questionnaire.DataAccess.Repositories;

namespace Questionnaire.DataAccess.MSSQL.Repositories
{
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        private QuestionnaireDbContext context;

        public QuestionnaireRepository(QuestionnaireDbContext context)
        {
            this.context = context;
        }

        public Questionnaires Add(Questionnaires questionnaire)
        {
            if (questionnaire == null)
            {
                return null;
            }
            return context.Questionnaires.Add(questionnaire);
        }

        public IEnumerable<Questionnaires> AddList(List<Questionnaires> questionnaireList)
        {
            try
            {
                if (questionnaireList==null)
                {
                    return null;
                }
                return context.Questionnaires.AddRange(questionnaireList);
            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(new Exception("Exception Message: " + e.Message + " ,ErrorType:  AddListQuestionnaires() has error"));

                return null;
            }

        }

        public IEnumerable<Questionnaires> DeleteQuestionnaireList(IEnumerable<Questionnaires> questionnaireList)
        {
            try
            {
                if (questionnaireList == null)
                {
                    return null;
                }
                return context.Questionnaires.RemoveRange(questionnaireList);
            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(new Exception("Exception Message: " + e.Message + " ,ErrorType:  DeleteQuestionnaireList() has error"));

                return null;
            }

        }

        public IEnumerable<Questionnaires> FindQuestionnaireListForDelete(int formId)
        {
            try
            {
                if (formId == null || formId==0)
                {
                    return null;
                }
                var result = context.Questionnaires.Where(x => x.FormId == formId).ToList();
                return result;
            }
            catch
            {
                ErrorSignal.FromCurrentContext().Raise(new Exception("Entity not found"));

                return null;
            }
        }
    }
}
