using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Common.Entities
{
    public class Questionnaires
    {
        [Key]
        public int Id { get; set; }
        public int FormId { get; set; }
        public int RId { get; set; }
        public string Title { get; set; }
        public string Answer { get; set; }

    }
}
