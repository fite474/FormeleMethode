using System;
using System.Collections.Generic;
using System.Text;

namespace Formele_Methoden.Operators
{
	class OneOperator : IRegexOperator
	{
		private string condition;

		public OneOperator(string condition)
		{
			this.condition = condition;
		}

		public List<string> GetLanguage(int maxLength, Regex left, Regex right)
		{
			List<string> result = new List<string>() {};

			if(maxLength >= 1)
			{
				result.Add(condition);
			}

			return result;
		}

		public string GetExpression(Regex left, Regex right)
		{
			return condition;
		}
	}
}
