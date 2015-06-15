using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    class Program
    {   
        static void Main(string[] args)
        {
          

            Console.ReadKey();
        }

        static void Class1_test(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                int num = Int32.Parse(args[i]);
                Console.WriteLine("result: " + Class1.Calc(num));
            }
        }

        static void Lambda_test()
        {

        }

    }// end cls

}
