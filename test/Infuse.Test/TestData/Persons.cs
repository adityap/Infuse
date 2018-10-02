using System;
using System.Collections.Generic;
using System.Text;

namespace Infuse.Test.TestData
{
    class PersonA : IPerson
    {
        protected IChat _talk;

        public string Name { get; set; }
        public Gender PersonGender { get; set; }

        public PersonA(IChat chat)
        {
            _talk = chat;
            Name = "A";
            PersonGender = Gender.Male;
            
        }

        public void Say(string msg)
        {
            _talk.Send(msg);
        }

        public string Listen()
        {
            return _talk.Receive();
        }
    }

    class PersonB : IPerson
    {
        protected IChat _talk;

        public string Name { get; set; }
        public Gender PersonGender { get; set; }

        public PersonB(IChat chat)
        {
            _talk = chat;
            Name = "B";
            PersonGender = Gender.Female;
        }

        public void Say(string msg)
        {
            _talk.Send(msg);
        }

        public string Listen()
        {
            return _talk.Receive();
        }
    }

    //class PersonA : Person
    //{
    //    public PersonA(IChat _talk)
    //        :base(_talk)
    //    {
    //        Name = "A";
    //        PersonGender = Gender.Male;
    //    }
    //}

    //class PersonB : Person
    //{
    //    public PersonB(IChat _talk)
    //        :base(_talk)
    //    {
    //        Name = "B";
    //        PersonGender = Gender.Female;
    //    }
    //}
}
