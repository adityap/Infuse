using System;
using System.Collections.Generic;
using System.Text;

namespace Infuse.Test.TestData
{
    interface IChat
    {
        string LastMessage { get; set; }

        void Send(string msg);
        string Receive();
    }
}
