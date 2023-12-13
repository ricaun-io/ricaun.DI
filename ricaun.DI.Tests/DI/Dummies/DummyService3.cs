using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ricaun.DI.Tests.DI.Dummies
{
    public class DummyService3 : IDummyService3
    {
        private readonly IDummyService2 dummyService2;

        public DummyService3(
            IDummyService2 dummyService2
            )
        {
            this.dummyService2 = dummyService2;
        }
    }
}
