using System;
using System.Collections.Generic;

namespace Formele_Methoden
{
	class Program
	{
		static void Main(string[] args)
		{
			//(a | bc) b+ (ac | bc)
			Regex a = new Regex("a");
			Regex b = new Regex("b");
			Regex c = new Regex("c");
			Regex bc = b.Dot(c);
			Regex ac = a.Dot(c);

			// (a|bc)
			Regex r1 = a.Or(bc);
			// b+
			Regex r2 = b.Plus();
			// (ac | bc)
			Regex r3 = ac.Or(bc);

			// (a | bc)b+
			Regex r4 = r1.Dot(r2);

			// (a | bc) b+ (ac | bc)
			Regex r5 = r4.Dot(r3);




			Console.WriteLine(r4.GetExpression() + "\n");

			List<string> language = r4.GetLanguage(4);
			language.Sort((x, y) => { return x.Length - y.Length; });

			foreach (string word in language)
			{
				Console.WriteLine(word);
			}
		}
	}
}
