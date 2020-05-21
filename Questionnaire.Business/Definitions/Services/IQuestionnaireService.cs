using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using Questionnaire.Common.Entities;

namespace Questionnaire.Business.Definitions.Services
{
    public interface IQuestionnaireService
    {
        IEnumerable<Questionnaires> GetQuestionnaire(FormSetting formSetting, int index);
        void QuestionnaireTimer(Timer timer, FormSetting formSetting, int index);
        void CreateFormSettingForQuestionnaire();
        void PeriodQuestionnaireTimer();
    }
}
