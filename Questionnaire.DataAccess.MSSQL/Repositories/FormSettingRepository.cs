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
    public class FormSettingRepository : IFormSettingRepository
    {
        private QuestionnaireDbContext context;

        public FormSettingRepository(QuestionnaireDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<FormSetting> GetFormSettingList()
        {
            try
            {
                var result = context.FormSettings.ToList();
                return result;
            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(new Exception("Exception Message: " + e.Message + " ,ErrorType:  FormSettings.ToList() has error"));
                return null;
            }
        }
        public FormSetting FindDescriptions(int id)
        {
            try
            {
                if (id < 1)
                {
                    ErrorSignal.FromCurrentContext().Raise(new Exception("Exception Message: " + " ,ErrorType:  FindDescriptions() has error id<1"));
                    return null;
                }
                var result = context.FormSettings.FirstOrDefault(x => x.Id == id);
                return result;
            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(new Exception("Exception Message: " + e.Message + " ,ErrorType:  FindDescriptions() has error"));
                return null;
            }
        }
    }
}
