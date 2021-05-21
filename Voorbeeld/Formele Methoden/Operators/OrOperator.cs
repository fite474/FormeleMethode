using System;
using System.Collections.Generic;
using System.Text;

namespace Formele_Methoden.Operators
{
	class OrOperator : IRegexOperator
	{
		public OrOperator()
		{

		}

		public List<string> GetLanguage(int maxLength, Regex left, Regex right)
		{
			List<string> result = left.GetLanguage(maxLength - 1);
			result.AddRange(right.GetLanguage(maxLength - 1));

			return result;
		}

		public string GetExpression(Regex left, Regex right)
		{
			return '(' + left.GetExpression() + '|' + right.GetExpression() + ')';
		}
	}
}
