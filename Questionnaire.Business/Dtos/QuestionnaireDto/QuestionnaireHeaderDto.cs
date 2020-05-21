namespace Questionnaire.Business.Dtos
{
    public class QuestionnaireHeaderDto
    {
        public int ColType { get; set; }
        public object RelatedGroup { get; set; }
        public string Title { get; set; }
        public string CellType { get; set; }
        public int Id { get; set; }
        public bool Show { get; set; }
        public object RelatedGroupId { get; set; }
        public int? Qtype { get; set; }
        public int? AnswerType { get; set; }
    }
}
