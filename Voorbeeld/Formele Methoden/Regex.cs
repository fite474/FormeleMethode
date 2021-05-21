using System;
using System.Collections.Generic;
using System.Text;
using Formele_Methoden.Operators;

namespace Formele_Methoden
{

	enum RegexOperator
	{
		ONE, PLUS, STAR, OR, DOT
	}

	class Regex
	{
		public IRegexOperator RegexOperator { get; private set; }

		private Regex left;
		private Regex right;

		public Regex() : this("")
		{
		}

		public Regex(string condition)
		{
			this.RegexOperator = new OneOperator(condition);
			left = null;
			right = null;
		}

		public Regex Plus()
		{
			Regex result = new Regex();
			result.RegexOperator = new PlusOperator();
			result.left = this;
			return result;
		}

		public Regex Star()
		{
			Regex result = new Regex();
			result.RegexOperator = new StarOperator();
			result.left = this;
			return result;
		}

		public Regex Or(Regex other)
		{
			Regex result = new Regex();
			result.RegexOperator = new OrOperator();
			result.left = this;
			result.right = other;
			return result;
		}

		public Regex Dot(Regex other)
		{
			Regex result = new Regex();
			result.RegexOperator = new DotOperator();
			result.left = this;
			result.right = other;
			return result;
		}

		public string GetExpression()
		{
			return RegexOperator.GetExpression(left, right);
		}

		public List<string> GetLanguage(int maxLength)
		{
			return RegexOperator.GetLanguage(maxLength, left, right);
		}
	}
}
