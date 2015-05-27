using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvent
{
    // testing delegate for understanding
    delegate void SwitchHandler();
    delegate void SwitchHandler2(string str);
    delegate void SwitchHandler3(string str, int i);
    delegate void SwitchHandler4(EventArgs e);


    class TestSwitch
    {
        private bool b_isTurnOn = false;
        private int i_switcher = 0;
        
        public bool B_isTurnOn
        {
            get
            {
                return b_isTurnOn;
            }

            set
            {
                b_isTurnOn = value;
            }
        }

        public int I_switcher
        {
            get
            {
                return i_switcher;
            }

            set
            {
                i_switcher = value;

                if (i_switcher > 0)
                {
                    //call dlg
                    SWHandler();

                    if (i_switcher == 2)
                    {
                        RaiseSW2();
                        System.Windows.Forms.KeyPressEventArgs e =
                            new System.Windows.Forms.KeyPressEventArgs(Console.ReadKey(true).KeyChar);
                        SWhandler4(e);
                    }
                }
            }
        }// end I_switcher

        //private readonly Dictionary<string, Action<string>> _lookupTable = new Dictionary<string, Action<string>>
        //{
        //    {"campaigns", post}
        //    {"somethingElse", doSomethingElse}
        //    {"tryIt", val => doSomethingWithVal(val)}
        //};
        //_lookupTable["foo"]("bar");

        // dlg
        public SwitchHandler SWHandler;


        // using dictionary store events
        private Dictionary<string, Delegate> eventTable = new Dictionary<string, Delegate>();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TestSwitch()
        {
            Console.WriteLine("Switching Called");

            SWHandler += new SwitchHandler(SwitchEngaged);
            SWHandler += new SwitchHandler(ToggleLight);

            SWhandler4 += new SwitchHandler4(EventToggle);

            eventTable.Add("event1", null);
            eventTable.Add("event2", null);
        }

        // add, remove
        public event SwitchHandler2 SWHandler2
        {
            add
            {
                eventTable["event2"] = (SwitchHandler2)eventTable["event2"] + value;
            }
            remove
            {
                eventTable["event2"] = (SwitchHandler2)eventTable["event2"] - value;
            }
        }
        public event SwitchHandler3 SWHandler3
        {
            add
            {
                eventTable["event3"] = (SwitchHandler3)eventTable["event2"] + value;
            }
            remove
            {
                eventTable["event3"] = (SwitchHandler3)eventTable["event2"] - value;
            }
        }

        public event SwitchHandler4 SWhandler4;

        void RaiseSW2()
        {
            SwitchHandler2 sw2;
            if (null != (sw2 = (SwitchHandler2)eventTable["event2"]))
            {
                sw2("test");
            }
        }

        void RaiseSW3()
        {
            SwitchHandler3 sw3;
            if (null != (sw3 = (SwitchHandler3)eventTable["event3"]))
            {
                sw3("test", 0);
            }
        }

        // switch method1
        private void SwitchEngaged()
        {
            Console.WriteLine("Switch Engaged!");
        }

        // switch method2
        private void ToggleLight()
        {
            Console.WriteLine("Toggle Light!");
            b_isTurnOn = !b_isTurnOn;
        }

        // switch method3
        private void EventToggle(EventArgs e)
        {
            Console.WriteLine("Event toggle");
        }

    }
}
