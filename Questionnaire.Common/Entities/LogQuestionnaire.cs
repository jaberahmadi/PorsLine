using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Common.Entities
{
    public class LogQuestionnaire
    {
        [Key]
        public int Id { get; set; }
        public int FormId { get; set; }
        public int OperationsType { get; set; }
        [Required]
        public string Operations { get; set; }
        public DateTime CreateDate { get; set; }
        public string Descriptions { get; set; }
    }
}
