using System;
delegate void Procedure();

class DelegateDemo2
{
    static Procedure someProcs = null;

    private static void AddProc()
    {
        int variable = 100;

        someProcs += new Procedure(delegate
        {
            Console.WriteLine(variable);
        });
    }

    public static void Test()
    {
        someProcs += new Procedure(delegate { Console.WriteLine("test"); });
        AddProc();
        someProcs();
        Console.ReadKey();
    }
}
