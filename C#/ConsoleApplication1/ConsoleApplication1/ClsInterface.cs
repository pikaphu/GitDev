using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ClsInterface
    {
        ClsInterface()
        {

        }
    }

    interface IShape
    {
        double X { get; set; }
        double Y { get; set; }
        double Z { get; set; }
        void Draw();
        void Dispose();
    }

    class IBox : IShape
    {
        private double _mX, _mY, _mZ;

        public double X
        {
            set { _mX = value; }
            get { return _mX; }
        }

        public double Y
        {
            set { _mY = value; }
            get { return _mY; }
        }

        public double Z
        {
            set { _mZ = value; }
            get { return _mZ; }
        }
        
        //public void BoxCollider() {}
        public void Draw() { }

        public void Draw(int i) { }

        public void Dispose() { }

    }

}
