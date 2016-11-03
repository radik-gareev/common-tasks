using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Helpers
{
    public class Tree
    {
        public Tree Left;
        public Tree Right;
        public int Value;

        public Tree(int value)
        {
            Value = value;
        }
    }
}
