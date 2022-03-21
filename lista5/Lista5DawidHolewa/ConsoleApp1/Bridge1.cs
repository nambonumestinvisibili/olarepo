using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Person {
        public override string ToString()
        {
            return "A Person";
        }
    }

    public abstract class PersonRegistry
    {
        protected PersonNotifier _personNotifier;

        public PersonRegistry(PersonNotifier personNotifier)
        {
            _personNotifier = personNotifier;
        }

        /// <summary>
        /// Pierwszy stopień swobody - różne wczytywanie
        /// </summary>
        public abstract List<Person> GetPersons();
        /// <summary>
        /// Drugi stopień swobody - różne użycie
        /// </summary>
        public void NotifyPersons()
        {
            _personNotifier.Notify(GetPersons());
        }
    }

    public abstract class PersonNotifier
    {
        public abstract void Notify(IEnumerable<Person> persons);
    }

    public class ConcretePersonNotifier : PersonNotifier
    {
        public override void Notify(IEnumerable<Person> persons)
        {
            foreach (var p in persons)
            {
                Console.WriteLine("Person notified");
            }
        }
    }

    public class XmlPersonRegistry : PersonRegistry
    {
        public XmlPersonRegistry(PersonNotifier personNotifier) : base(personNotifier)
        {
        }

        public override List<Person> GetPersons()
        {
            return new List<Person> { new Person(), new Person() };
        }
    }

    public class FilePersonRegistry : PersonRegistry
    {
        public FilePersonRegistry(PersonNotifier personNotifier) : base(personNotifier)
        {
        }

        public override List<Person> GetPersons()
        {
            return new List<Person> { new Person(), new Person(), new Person(), new Person() };
        }
    }


}
