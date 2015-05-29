using System;

namespace ConsoleApplication1
{
    class ClsVirtual
    {
    }

    class A
    {
        public virtual void Test()
        {
            Console.WriteLine("A.Test");
        }
    }

    class B : A
    {
        public override void Test()
        {
            Console.WriteLine("B.Test");
        }
    }

}
