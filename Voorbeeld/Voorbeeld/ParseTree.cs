using System;
using System.Collections.Generic;
using System.Text;

namespace Voorbeeld
{
    using input = System.Char;

    class ParseTree
    {
        public enum NodeType
        {
            Chr,
            Star,
            Question,
            Alter,
            Concat
        }

        public NodeType type;
        public input? data;
        public ParseTree left;
        public ParseTree right;

        public ParseTree(NodeType type_, input? data_, ParseTree left_, ParseTree right_)
        {
            type = type_;
            data = data_;
            left = left_;
            right = right_;
        }

    }
}

