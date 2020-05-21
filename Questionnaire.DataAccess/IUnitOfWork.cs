using System;
using Questionnaire.DataAccess.Repositories;

namespace Questionnaire.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IQuestionnaireRepository QuestionnaireRepository { get; }
        IFormSettingRepository FormSettingRepository { get; }
        ILogQuestionnaireRepository LogQuestionnaireRepository { get; }
        void Commit();
    }
}