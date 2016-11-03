using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Helpers
{
    public class LinkedList
    {
        public LinkedList Next;

        public int Value;

        public LinkedList(int value)
        {
            Value = value;
        }

        public LinkedList(int value, LinkedList node)
        {
            Value = value;
            Next = node;
        }
    }
}
