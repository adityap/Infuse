using System;
using System.Collections.Generic;
using System.Text;

namespace Infuse.Test.TestData
{
    public class NoPublicConstructor
    {
        internal NoPublicConstructor()
        { }
    }

    public class DependsOnNonPublicConstructorClass
    {

        public DependsOnNonPublicConstructorClass(NoPublicConstructor nop)
        { }
    }

    public class DependsOnMixedConstructorClass
    {

        public DependsOnMixedConstructorClass(PerfectlyNormalClass yes, NoPublicConstructor nop)
        { }
    }

    public class PerfectlyNormalClass
    {

        public PerfectlyNormalClass()
        { }
    }
}
