using System;

namespace Questionnaire.Common.Exceptions
{
    public class MyArgumentNullException : ArgumentNullException
    { 
        public int RuleId { get; set; } 
        public MyArgumentNullException(int rule)
        {
            this.RuleId = rule;
        } 
        
    }
}