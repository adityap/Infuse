namespace Infuse.Test.TestData
{
    class Chatroom : IChat
    {
        public string LastMessage { get ;  set ; }

        public Chatroom()
        {
        }

        public void Send(string msg)
        {
            LastMessage = msg;
        }

        public string Receive()
        {
            return LastMessage;
        }
    }
}
