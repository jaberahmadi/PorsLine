using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Common.Entities
{
    public class FormSetting
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int FormId { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public int PeriodTime { get; set; }
        public string Descriptions { get; set; }
    }
}
