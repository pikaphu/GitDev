using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCA1
{
    class Class1 : TestEvent
    {
        public Class1() : base()
        {
            Console.WriteLine("Called from Default Constr");
        }

        public Class1(string arg) : this()
        {
            Console.WriteLine("Called from Constr1");
        }

        public Class1(string arg1, int arg2) : this("Constr2")
        {
            Console.WriteLine("Called from Constr2");
        }
    }
}
