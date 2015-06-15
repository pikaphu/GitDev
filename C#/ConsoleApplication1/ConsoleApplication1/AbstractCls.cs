using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    abstract class AbstractCls
    {
        protected int x, y, z;
        public abstract int X { get; }
        protected abstract int Y { get; }
        internal abstract int Z { get; }
        
        void XX() { }
        public abstract void YY();
    }

    class abst1 : AbstractCls
    {
        public override int X { get { return x = 1; } }

        protected override int Y { get { return y = -1; } }

        internal override int Z { get { return y = -1; } }
        

        public override void YY()
        {
            throw new NotImplementedException();
        }
        
    }
}
