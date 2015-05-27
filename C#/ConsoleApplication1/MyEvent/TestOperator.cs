using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvent
{
    class TestOperator
    {
        private double d_testRange1, d_testRange2;

        public static TestOperator operator +(TestOperator t1, TestOperator t2)
        {
            return t1 + t2;
        }
    }
}
