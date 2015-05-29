using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvent
{
    class TestOperator
    {
        // variable
        private double d_testRange1, d_testRange2;

        public double D_testRange1
        {
            get
            {
                return d_testRange1;
            }

            set
            {
                d_testRange1 = (double)value;
            }
        }

        public double D_testRange2
        {
            get
            {
                return d_testRange2;
            }

            set
            {
                d_testRange2 = value;
            }
        }

        // constructor
        public TestOperator()
        {
            new TestOperator(0, 0);
        }
        public TestOperator(int i1, int i2)
        {
            d_testRange1 = i1;
            d_testRange2 = i2;
        }

        // process
        public static TestOperator operator +(TestOperator t1, TestOperator t2)
        {
            return new TestOperator() {
                d_testRange1 = t1.d_testRange1 + t2.d_testRange1,
                d_testRange2 = t1.d_testRange2 + t2.d_testRange2
            };
        }

        public static TestOperator operator *(TestOperator t1, TestOperator t2)
        {
            return new TestOperator() {
                d_testRange1 = t1.d_testRange1 * t2.d_testRange1,
                d_testRange2 = t2.d_testRange2 * -t2.d_testRange2
            };
        }

        public static explicit operator string(TestOperator t)
        {
            // we should be overloading the ToString() method, but this is just a demonstration
            return t.d_testRange1.ToString() + " + " + t.d_testRange2.ToString() + "i";
        }


        public static implicit operator double(TestOperator d)
        {
            return d.d_testRange1 + d.d_testRange2 + 0.05d;
        }

    }// end cls
}// end ns
