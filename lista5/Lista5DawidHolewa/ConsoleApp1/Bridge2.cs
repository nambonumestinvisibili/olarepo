using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public abstract class PersonRegistry2
    {
        protected PersonGetter _personGetter;
        protected IEnumerable<Person> _persons;

        public PersonRegistry2(PersonGetter personGetter)
        {
            _personGetter = personGetter;
            GetPersons();
        }

        public void GetPersons()
        {
             _persons = _personGetter.GetPersons();
        }

        public abstract void Notify();

        
    }

    public abstract class PersonGetter
    {
        public abstract IEnumerable<Person> GetPersons();
    }

    public class ConcretePersonGetter : PersonGetter
    {
        public override IEnumerable<Person> GetPersons()
        {
            return new List<Person> { new Person(), new Person(), new Person() };
        }
    }

    public class SmsPersonRegistry : PersonRegistry2
    {
        public SmsPersonRegistry(PersonGetter personGetter) : base(personGetter)
        {
            
        }
        public override void Notify()
        {
            foreach (var p in _persons)
            {
                Console.WriteLine("Person notified");
            }
        }
    }

    public class SmtpPersonRegistry : PersonRegistry2
    {
        public SmtpPersonRegistry(PersonGetter personGetter) : base(personGetter)
        {

        }
        public override void Notify()
        {
            foreach (var p in _persons)
            {
                Console.WriteLine("Person notified");
            }
        }
    }


}
