using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class TestFunc
    {
        // constructor
        public TestFunc()
        {
            Console.WriteLine("Constructor Invoked!");
        }
        // finalizer
        ~ TestFunc()
        {
            Console.WriteLine("Destructed!");
        }

        // Test1
        enum Job : byte { Programmer = 0, Developer, Engineer}

        public static void Recruit()
        {
            Console.WriteLine("Result: " + (int)Job.Developer);
        }// end func

        // Test2
        public static IEnumerable MyCounter(int count, int step)
        {
            for (int i = 0; i < count; i += step)
            {
                if (i == 3)
                {
                    continue;
                }
                yield return i;
            }
        }// end func
       
        // Test3
        public static void Test3()
        {
            int iResult = 0;
            for (int i = 0; i < 10; i++)
            {
                switch (i % 3)
                {
                    case 0: iResult += 1;
                        break;
                    case 1: iResult -= 2;
                        break;
                    case 2: iResult += 3;
                        break;
                    case 3: iResult /= 4;
                        break;

                    default:
                        break;
                }
                
            }
            Console.WriteLine(iResult);
        }// end func

        //Test4
        public static void Test4()
        {
            int result = 0;
            string txt1 = "";

            throw new Exception("Error! exeption from Test4()");
            Console.WriteLine("OK!");
        }



    }// end cls


}
