using System;
using System.Collections.Generic;

// Note: You need to know some about delegate, properties and methods to understand this sample
namespace EventSample
{
    /// <summary>
    /// This delegate defines the signature of the appropriate method
    /// </summary>
    public delegate void MyHandler(TestEvent sender);

    /// <summary>
    ///     TestEvent class
    /// </summary>
    public class TestEvent
    {
    #region TestEvent Variable
        
        /// <summary>
        ///     Field for the info whether or not the TestEvent is engaged
        /// </summary>
        private bool m_bIsEngaged = false; // status
        /// <summary>
        ///     ID of the TestEvent
        /// </summary> 
        private int m_iID = -1;
        /// <summary>
        ///     Name of the TestEvent
        /// </summary>
        private String m_strName = null;

        /// <summary>
        ///     Accessor for the TestEvent ID
        /// </summary>
        public int ID
        {
            get
            {
                return m_iID;
            }

            set
            {
                m_iID = value;
            }

        }

        /// <summary>
        ///     Accessor for the TestEvent Name
        /// </summary>
        public string Name
        {
            get
            {
                return m_strName;
            }

            set
            {
                m_strName = value;
            }
        }

        /// <summary>
        ///     Accessor for the information about Employee engagement
        /// </summary>
        public bool IsEngaged
        {
            get
            {
                return m_bIsEngaged;
            }

            set
            {
                if (m_bIsEngaged == false && value == true)
                {
                    // here we fires event (call all the methods that it have)
                    // all times when IsEngaged is false and set to true;
                    Engaged(this);
                }

                m_bIsEngaged = value;
            }
        }

    #endregion

    #region TestEvent Method

        /// <summary>
        /// *** The our event *** 
        /// Is a collection of methods that will be called when it fires
        /// </summary>
        public event MyHandler Engaged;

        /// <summary>
        ///     Standard constructor
        /// </summary>
        public TestEvent()
        {
            // Here, we are adding a new method with appropriate signature (defined by delegate)
            // note: when a event not have any method and it was fired, it causes a exception!
            //       for all effects when programming with events, assign one private method to event
            //       or simply do a verification before fire it! --> if (event != null)
            this.Engaged += new MyHandler(this.OnEngaged);
        }

        /// <summary>
        ///     Event handler for the "engaged" event
        /// </summary>
        /// <param name="sender">
        ///     Sender object
        /// </param>
        private void OnEngaged(TestEvent sender)
        {
            Console.WriteLine("private void OnEngaged was called! this TestEvent is engaged now!");
        }

    #endregion

    }// end cls
}// end ns
