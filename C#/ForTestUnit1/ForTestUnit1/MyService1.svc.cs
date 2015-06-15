using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ForTestUnit1
{
    [ServiceContract]
    public class MyService1
    {
        IService1 iserv = null;

        [OperationContract]
        public bool test1(string val)
        {
            return (val.Length > 2 && val.Length < 5 ? true : false);
        }

    }

}