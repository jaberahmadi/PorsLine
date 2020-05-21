using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Composition
{
	public class TypeResolutionException : Exception
	{
		public TypeResolutionException()
		{
		}

		public TypeResolutionException(string message) : base(message)
		{
		}

		public TypeResolutionException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected TypeResolutionException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
