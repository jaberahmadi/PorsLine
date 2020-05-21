using System.Collections.Generic;

namespace Questionnaire.Business.Dtos
{
    public class QuestionnaireDto
    {
        public IList<QuestionnaireBodyDto> Body { get; set; }
        public int LenResponders { get; set; }
        public IList<QuestionnaireHeaderDto> Header { get; set; }
    }
}
