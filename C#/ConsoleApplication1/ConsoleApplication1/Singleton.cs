
namespace ConsoleApplication1
{
    class Singleton
    {
    }// end cls

    class SingletonObject
    {
        // this object have only itself instance.
        private static SingletonObject sgtObject;

        private SingletonObject()
        {
            // instantiate the object
        }
        
        public static SingletonObject getInstance()
        {
            if (sgtObject == null)
            {
                sgtObject = new SingletonObject();
            }
            return sgtObject;
        }
    }// end cls


    class SingletonObjectSync
    {
        // this object have only itself instance.
        public static SingletonObjectSync sgtObject;
        private static string lockObj = "Lock"; // Use for locking

        
        private SingletonObjectSync()
        {
            // instantiate the object
        }

        // force sync
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public static SingletonObjectSync getInstance()
        {
            if (sgtObject == null)
            {
                lock(lockObj)
                if (sgtObject == null)
                {
                    sgtObject = new SingletonObjectSync();
                }
            }
            return sgtObject;
        }
        
    }// end cls

}// end ns
