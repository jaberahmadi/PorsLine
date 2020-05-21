using System;
using System.Data.SqlClient;
using Elmah;
using Questionnaire.DataAccess.MSSQL.Migrations;
using Questionnaire.DataAccess.MSSQL.Repositories;
using Questionnaire.DataAccess.Repositories;

namespace Questionnaire.DataAccess.MSSQL
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly QuestionnaireDbContext context;

        private IQuestionnaireRepository questionnaireRepository;
        private IFormSettingRepository formSettingRepository;
  
        private ILogQuestionnaireRepository logQuestionnaireRepository;


        public SqlUnitOfWork()
        {
            var temp = typeof(System.Data.Entity.SqlServer.SqlFunctions);
            context = new QuestionnaireDbContext();
        }
        public void Commit()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(new Exception("Exception Message: " + e.Message + " ,ErrorType:  save change exception"));

            }
        }
        public void Dispose()
        {
            context?.Dispose();
        }

        public IQuestionnaireRepository QuestionnaireRepository =>
            questionnaireRepository ?? (questionnaireRepository = new QuestionnaireRepository(context));
        public IFormSettingRepository FormSettingRepository =>
            formSettingRepository ?? (formSettingRepository = new FormSettingRepository(context));
        public ILogQuestionnaireRepository LogQuestionnaireRepository =>
            logQuestionnaireRepository ?? (logQuestionnaireRepository = new LogQuestionnaireRepository(context));
    }
}