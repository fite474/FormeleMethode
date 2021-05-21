using System;
using System.Collections.Generic;
using System.Text;

namespace Formele_Methoden.Operators
{
	class DotOperator : IRegexOperator
	{

		public DotOperator()
		{
		}

		public string GetExpression(Regex left, Regex right)
		{
			return left.GetExpression() + right.GetExpression();
		}

		public List<string> GetLanguage(int maxLength, Regex left, Regex right)
		{
			List<string> languageLeft = left.GetLanguage(maxLength -1);
			List<string> languageRight = right.GetLanguage(maxLength - 1);
			List<string> result = new List<string>();

			foreach(string leftWord in languageLeft)
			{
				foreach (string rightWord in languageRight)
				{
					result.Add(leftWord + rightWord);
				}
			}

			return result;
		}

	}
}
