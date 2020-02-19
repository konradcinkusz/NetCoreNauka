using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Infrastructure
{
    public abstract class AClass
    {
        public void Method1()
        {
            
        }
        public abstract void Method2();

        public virtual void Method3()
        {

        }
    }

    public class concreteClass : AClass
    {
        public override void Method2()
        {
            throw new NotImplementedException();
        }
        public override void Method3()
        {
            base.Method3();
        }

        public new void Method1() // przesłanianie
        {

        }
    }
}
