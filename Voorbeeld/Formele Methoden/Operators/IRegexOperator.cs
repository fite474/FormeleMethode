using System;
using System.Collections.Generic;
using System.Text;

namespace Formele_Methoden.Operators
{
	interface IRegexOperator
	{
		string GetExpression(Regex left, Regex right);
		List<string> GetLanguage(int maxLength, Regex left, Regex right);
	}
}
