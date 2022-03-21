using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    public class PeopleRepo : ISubscriber<AddNewPersonEvent>, ISubscriber<ChangePersonEvent>
    {
        public EventAggregator eventAggregator; 

        private static List<Person> _people = new List<Person>() {
            new Person { ID=0, Firstname = "Angelika", Surname = "Kostecka", Birthday = "19.12.1999", Category = Category.Student, Address = "Chorwacka 68 Wrocław" },
            new Person { ID=1, Firstname = "Kuba", Surname = "Kowalczyk", Birthday = "11.12.1970", Category = Category.Teacher, Address = "Kazmierza 3 Racula" },
            new Person { ID=2, Firstname = "Dawid", Surname = "Holewa", Birthday = "14.03.1999", Category = Category.Student, Address = "Ogrodowa 11 Trzebiechów" }
        };

        public PeopleRepo(EventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            eventAggregator.AddSubscriber<AddNewPersonEvent>(this);
            eventAggregator.AddSubscriber<ChangePersonEvent>(this);

        }

        public List<Person> GetPeople()
        {
            return _people;
        }

        public List<Person> GetStudents()
        {
            return _people.Where(x => x.Category == Category.Student).ToList();
        }

        public List<Person> GetTeachers()
        {
            return _people.Where(x => x.Category == Category.Teacher).ToList();

        }

        
        public Person Find(string nameAndSurname)
        {
            var data = nameAndSurname.Split(" ");
            return _people.Where(x => x.Firstname == data[0] && x.Surname == data[1])
                .ToList()[0];
        }

        public void Handle(ChangePersonEvent Notification)
        {
            Person p = Find(Notification.OldPerson.Firstname + " " + Notification.OldPerson.Surname);
            p.Firstname = Notification.Person.Firstname;
            p.Surname = Notification.Person.Surname;
            p.Birthday = Notification.Person.Birthday;
            p.Address = Notification.Person.Address;
            p.Category = Notification.Person.Category;
            eventAggregator.Publish(new PersonChanged { Person = p});
        }

        public void Handle(AddNewPersonEvent Notification)
        {
            _people.Add(Notification.Person);
            eventAggregator.Publish(new PersonAdded { Person = Notification.Person});
        }
    }

    public enum Category {
        Teacher,
        Student
    }

    public enum DialogMode
    {
        Save,
        Change
    }
}
