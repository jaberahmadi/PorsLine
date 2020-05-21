using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Business.Dtos.LogQuestionnaireDto
{
    public class LogQuestionnaireDto
    {
        public int FormId { get; set; }
        public int OperationsType { get; set; }
        public string Operations { get; set; }
        public DateTime CreateDate { get; set; }
        public string Descriptions { get; set; }
    }
}
