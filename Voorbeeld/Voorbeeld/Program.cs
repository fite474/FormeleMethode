using System;

namespace Voorbeeld
{
    class Program
    {
		static void Main(string[] args)
		{
			args = new[] { "Voorbeeld", "((ba*b)|(bb)|(aa))", "baaaaaabbbaa" };

			//((ba*b) | (bb)+ | (aa)+)+
			if (args.Length != 3)
			{
				Console.WriteLine("Call with the regex as an argument.");

				Environment.Exit(1);
			}

			RegexParser myRegexParser = new RegexParser(args[1]);

			// Creating a parse tree with the preprocessed regex
			ParseTree parseTree = myRegexParser.Expr();

			// Checking for a string termination character after
			// parsing the regex
			if (myRegexParser.Peek() != '\0')
			{
				Console.WriteLine("Parse error: unexpected char, got {0} at #{1}",

				myRegexParser.Peek(), myRegexParser.GetPos());

				Environment.Exit(1);
			}

			PrintTree(parseTree, 1);

			NFA nfa = NFA.TreeToNFA(parseTree);

			nfa.Show();

			DFA dfa = SubsetMachine.SubsetConstruct(nfa);

			dfa.Show();

			Console.Write("\n\n");

			Console.Write("Result: {0}", dfa.Simulate(args[2]));

			Console.ReadKey();

		}


		private static void PrintTree(ParseTree node, int offset)
		{
			if (node == null)
				return;

			for (int i = 0; i < offset; ++i)
				Console.Write(" ");

			switch (node.type)
			{
				case ParseTree.NodeType.Chr:
					Console.WriteLine(node.data);
					break;
				case ParseTree.NodeType.Alter:
					Console.WriteLine("|");
					break;
				case ParseTree.NodeType.Concat:
					Console.WriteLine(".");
					break;
				case ParseTree.NodeType.Question:
					Console.WriteLine("?");
					break;
				case ParseTree.NodeType.Star:
					Console.WriteLine("*");
					break;
			}

			Console.Write("");

			PrintTree(node.left, offset + 8);
			PrintTree(node.right, offset + 8);
		}
	}
}
