using System;
using System.Collections.Generic;
using System.Text;

namespace Formele_Methoden.Operators
{
	class PlusOperator : IRegexOperator
	{

		public PlusOperator()
		{

		}

		public List<string> GetLanguage(int maxLength, Regex left, Regex right)
		{
			List<string> languageLeft = left.GetLanguage(maxLength-1);
			List<string> result = new List<string>(languageLeft);

			for(int i = 1; i < maxLength; i++)
			{
				// Make a temporary hashset to exclude duplicate elements in list
				HashSet<string> languageTemp = new HashSet<string>(result);
				foreach(string s1 in languageLeft)
				{
					foreach(string s2 in languageTemp)
					{
						result.Add(s1 + s2);
					}
				}
			}

			return result;
		}

		public string GetExpression(Regex left, Regex right)
		{
			string result = left.GetExpression();

			return result + '+';
		}
	}
}
