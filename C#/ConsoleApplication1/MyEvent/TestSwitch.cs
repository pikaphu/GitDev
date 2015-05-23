using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvent
{
    // testing delegate understand
    delegate void SwitchHandler();

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
                }
            }
        }

        // dlg
        public SwitchHandler SWHandler;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TestSwitch()
        {
            Console.WriteLine("Switching Called");

            SWHandler += new SwitchHandler(SwitchEngaged);
            SWHandler += new SwitchHandler(ToggleLight);
        }

        // switch method
        private void SwitchEngaged()
        {
            Console.WriteLine("Switch Engaged!");
        }

        // switch method
        private void ToggleLight()
        {
            Console.WriteLine("Toggle Light!");
            b_isTurnOn = !b_isTurnOn;
        }

    }
}
