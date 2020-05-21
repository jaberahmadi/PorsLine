using System;
using System.Runtime.Serialization;

namespace Questionnaire.Common.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public int RuleId { get; set; }
        public EntityNotFoundException( int ruleId)
        {
            RuleId = ruleId;
        }

        public EntityNotFoundException(string message, int ruleId) : base(message)
        {
            RuleId = ruleId;
        }

        public EntityNotFoundException(string message, Exception innerException, int ruleId) : base(message, innerException)
        {
            RuleId = ruleId;
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }  
    } 

}
