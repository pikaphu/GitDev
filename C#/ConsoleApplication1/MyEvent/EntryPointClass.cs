using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventSample;

namespace MyEvent
{
    /// <summary>
    ///     Class for the entry point
    /// </summary>
    public class EntryPointClass
    {
        static void Main(string[] a_strArgs)
        {
            

            Console.ReadKey();
        }

        static void Call_TestOperator()
        {
            TestOperator topt0, topt1, topt2;
            topt0 = new TestOperator(0,0);
            topt1 = new TestOperator(1,1);
            topt2 = new TestOperator(2,2);

            topt0 = topt1 * topt2;

           Console.WriteLine(topt0.D_testRange1 + " : " + topt0.D_testRange2 );
        }

        /// <summary>
        /// TestSwitch.cs
        /// </summary>
        static void Call_TestSwitch()
        {
            TestSwitch tsw = new TestSwitch();

            tsw.SWHandler += new SwitchHandler(SimpleEvent_Engaged);

            tsw.SWHandler2 += new SwitchHandler2(SimpleEvent_Engaged);

            tsw.I_switcher = 2;

            Console.WriteLine("Switch {0} is {1}", tsw.I_switcher, tsw.B_isTurnOn);

            
            Console.ReadKey();
        }
        
        /// <summary>
        /// test TestEvent from TestEvent.cs
        /// </summary>
        static void Call_TestEvent()
        {
            // using EventSample ns;
            TestEvent testEv = new TestEvent();

            testEv.ID = 1;
            testEv.Name = "Pikachu";

            // Here...
            // This is saying when the event fire, the method added to event are called too.
            // note that we cannot use =
            // is only += to add methods to event or -= do retire a event
            testEv.Engaged += new MyHandler(SimpleTestEvent_Engaged);

            // make attention here...
            // when I assign true to this property, 
            // the event Engaged will be called
            // when event is called, all method that it have, are called!
            testEv.IsEngaged = true;

            Console.ReadLine();

            return;
        }

        //------------------------------------

        /// <summary>
        ///     Event handler for the registered "engaged" event
        /// </summary>
        /// <param name="sender">
        ///     Event sender
        /// </param>
        static void SimpleTestEvent_Engaged(TestEvent sender)
        {
            Console.WriteLine("The TestEvent {0} is running!", sender.Name);
        }
        static void SimpleEvent_Engaged()
        {
            Console.WriteLine("The SimpleEvent is Enagaged!");
        }
        static void SimpleEvent_Engaged(string str)
        {
            Console.WriteLine("The SimpleEvent {0} is Enagaged!", str);
        }

    }// end cls
}// end ns
