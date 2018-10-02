using System;
using System.Collections.Generic;
using System.Text;

namespace Infuse.Test.TestData
{
    enum Gender
    {
        Male,
        Female
    }

    interface IPerson
    {
        string Name { get; set; }
        Gender PersonGender { get; set; }
        void Say(string msg);
        string Listen();
    }


}
