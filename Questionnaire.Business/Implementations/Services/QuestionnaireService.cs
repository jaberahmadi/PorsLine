using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using Questionnaire.Business.Definitions.Factories;
using Questionnaire.Business.Definitions.Services;
using Questionnaire.Business.Dtos;
using Questionnaire.Common.Entities;
using Questionnaire.DataAccess;
using RestSharp;
using System.Timers;
using Elmah;
using Timer = System.Timers.Timer;

namespace Questionnaire.Business.Implementations.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IQuestionnaireFactory _questionnaireFactory;
        private readonly ILogQuestionnaireFactory _logQuestionnaireFactory;
        private readonly ILogQuestionnaireService _logQuestionnaireService;
        private readonly IUnitOfWork _unitOfWork;
        private const int convertToMin = 60 * 1000;
        private const int intevalExternalTime = 10000;
        private object Key = true;
       private int _index = 1;

        private bool check = false;

        public QuestionnaireService(IQuestionnaireFactory questionnaireFactory, IUnitOfWork unitUnitOfWork, ILogQuestionnaireFactory logQuestionnaireFactory, ILogQuestionnaireService logQuestionnaireService)
        {
            _questionnaireFactory = questionnaireFactory;
            _unitOfWork = unitUnitOfWork;
            _logQuestionnaireFactory = logQuestionnaireFactory;
            _logQuestionnaireService = logQuestionnaireService;
        }

        public void PeriodQuestionnaireTimer()
        {
            var formSettings = _unitOfWork.FormSettingRepository.GetFormSettingList();
            int index = 1;
            foreach (var item in formSettings)
            {
                var timer = new Timer();

                QuestionnaireTimer(timer, item, index);
                index++;
            }

        }

        public void QuestionnaireTimer(Timer timer, FormSetting formSetting, int index)
        {
            if (formSetting.PeriodTime > 0)
            {
                timer.Interval = (convertToMin * formSetting.PeriodTime) + (intevalExternalTime * index);
            }
            else
            {
                timer.Interval = (convertToMin * 240);
                ErrorSignal.FromCurrentContext().Raise(new Exception("Exception Message: " + "ArgumentOutOfRangeException" + " ,ErrorType:  periodTime<0"));
            }


            timer.Elapsed += (sender, e) => MyElapsedMethod(sender, e, formSetting,index);


            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void MyElapsedMethod(object source, ElapsedEventArgs e, FormSetting formSetting,int index)
        {
            GetQuestionnaire(formSetting,index);

        }
        public void CreateFormSettingForQuestionnaire()
        {
            var formSettings = _unitOfWork.FormSettingRepository.GetFormSettingList();

            foreach (var item in formSettings)
            {

                lock (Key)
                {
                    Key = false;
                    GetQuestionnaire(item,0);
                }
            }


        }
        public IEnumerable<Questionnaires> GetQuestionnaire(FormSetting formSetting,int index)
        {
            if (check)
            {

                Thread.Sleep(_index*intevalExternalTime);

            }

            if (index>_index)
            {
                _index = index;
            }
            check = true;
            var test = formSetting.Descriptions;
            if (formSetting.FormId < 0 || string.IsNullOrEmpty(formSetting.Token)) return null;
            var url = $"https://survey.porsline.ir/api/surveys/{formSetting.FormId}/responses/";
            var restClient = new RestClient(url);
            var restRequest = new RestRequest()
            {
                RequestFormat = DataFormat.Json,
                Method = Method.POST
            };
            restRequest.AddHeader("Authorization", $"Token {formSetting.Token}");
            restRequest.AddHeader("Content-Type", "application/json;charset=UTF-8");
            restRequest.AddBody(new
            {
                from_date = "2000-10-10",
                to_date = "2100-10-10",
                page = 1,
                sort_obj = new { col_type = 3, id = 6, reverse = false },
                filter_obj = new { },
                pagination = false
            });
            var response = restClient.Execute(restRequest);
            var questionnaireDto = JsonConvert.DeserializeObject<QuestionnaireDto>(response.Content);
            var result = _questionnaireFactory.CreateQuestionnaire(questionnaireDto, formSetting.FormId);
            var deleteResult = DeleteExistQuestionnaireInDatabase(formSetting);
            if (!deleteResult)
            {
                Key = true;
                check = false;
                return null;
            }
            var entity = AddQuestionnaireToDatabase(result, formSetting);
            Key = true;
            check = false;
            return entity;
        }

        private bool DeleteExistQuestionnaireInDatabase(FormSetting formSetting)
        {
            var entities = _unitOfWork.QuestionnaireRepository.FindQuestionnaireListForDelete(formSetting.FormId);
            try
            {
                if (entities.Count() > 0) _unitOfWork.QuestionnaireRepository.DeleteQuestionnaireList(entities);
                _unitOfWork.Commit();
                var resultFormSetting = _unitOfWork.FormSettingRepository.FindDescriptions(formSetting.Id);
                var logQuestionnaireDto = _logQuestionnaireFactory.CreateLogQuestionnaireDto(resultFormSetting, "Delete");
                var logQuestionnaire = _logQuestionnaireFactory.CreateLogQuestionnaire(logQuestionnaireDto);
                if (entities.Count() > 0 && logQuestionnaire != null)
                {
                    _logQuestionnaireService.InsertLogQuestionnaire(logQuestionnaire);
                }
                return true;
            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(new Exception("Exception Message: " + e.Message + " ,ErrorType: Entity null references"));
                return false;
            }
        }

        private IEnumerable<Questionnaires> AddQuestionnaireToDatabase(List<Questionnaires> questionnaireList, FormSetting formSetting)
        {
            if (questionnaireList == null) return null;
            try
            {
                var entities = _unitOfWork.QuestionnaireRepository.AddList(questionnaireList);
                _unitOfWork.Commit();
                var resultFormSetting = _unitOfWork.FormSettingRepository.FindDescriptions(formSetting.Id);
                var logQuestionnaireDto = _logQuestionnaireFactory.CreateLogQuestionnaireDto(resultFormSetting, "Insert");

                var logQuestionnaire = _logQuestionnaireFactory.CreateLogQuestionnaire(logQuestionnaireDto);

                if (logQuestionnaire != null && entities.Count() > 0)
                {
                    _logQuestionnaireService.InsertLogQuestionnaire(logQuestionnaire);
                }

                return entities;
            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(new Exception("Exception Message: " + e.Message + " ,ErrorType: Insert logQuestionnaire"));

                return null;
            }
        }
    }
}

