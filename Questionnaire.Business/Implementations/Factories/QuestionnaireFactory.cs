using Questionnaire.Business.Dtos;
using System.Collections.Generic;
using System.Linq;
using Questionnaire.Business.Definitions.Factories;
using Questionnaire.Common.Entities;

namespace Questionnaire.Business.Factories
{
    public class QuestionnaireFactory : IQuestionnaireFactory
    {
        public List<Questionnaires> CreateQuestionnaire(QuestionnaireDto questionnaireLDto, int formId)
        {
            var questionnaireList = new List<Questionnaires>();
            if (questionnaireLDto == null) return null;
            var listTitle = CreateQuestionnaireTitle(questionnaireLDto.Header);
            if (listTitle == null) return null;
            foreach (var item in questionnaireLDto.Body)
            {
                var i = 0;
                foreach (var item2 in item.Data)
                {
                    var questionnaire = new Questionnaires
                    {
                        FormId = formId,
                        RId = item.Rid,
                        Answer = item2,
                        Title = listTitle[i]
                    };
                    questionnaireList.Add(questionnaire);
                    i++;
                }
            }
            return questionnaireList;
        }

        private static List<string> CreateQuestionnaireTitle(IEnumerable<QuestionnaireHeaderDto> questionnaireHeaderDtos)
        {
            return questionnaireHeaderDtos?.Select(item
                => item.Title).ToList();
        }
    }
}
