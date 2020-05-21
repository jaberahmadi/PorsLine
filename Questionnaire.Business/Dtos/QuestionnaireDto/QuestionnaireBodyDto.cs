using System.Collections.Generic;

namespace Questionnaire.Business.Dtos
{
    public class QuestionnaireBodyDto
    {
        public IList<string> Data { get; set; }
        public int Rid { get; set; }
    }
}
