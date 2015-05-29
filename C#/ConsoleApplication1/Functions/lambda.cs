using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    class Lambda
    {
        delegate void del_func();
        del_func del_handler;

        Func<string, int> myFunc = delegate (string str)
        {
            return int.Parse(str);
        };

        void testFunc()
        {
            //1
            int x = myFunc("2");
            //del_handler += new del_func(test1);

            //2
            Func<string, string> myFunc2 = str => (str + "!!!");
            myFunc2("test");

            //3
            Func<int, int, int> myMultifunc = (i, j) => i * j;

            //4
            Console.WriteLine(  );
        }
    }
}
