

using System;

namespace ConsoleApp
{
    public class Person {

    }


    //SRP - Narusza; dwie odpowiedzialności
    public abstract class PersonRegistry {
        //1 stopień swobody - 
        public abstract List<Person> GetPersons(){

        }
        //2 stopień swobody
        public virtual void Notify(){

        }
    }
    //po 1 stopniu swobody
    public class XMLPersonRegistry : PersonRegistry {

    }

    public class SqlPersonRegistry : PersonRegistry {

    }

    //po 2 stopniu swobody
    public class EmailPersonReqgistry : PersonRegistry {

    }

    public class SmsPersonRegistry : PersonRegistry {

    }

    //



    public abstract class PersonRegistry {

        protected PersonNotifier notifier;
        public PersonRegistry(PersonNotifier notifier){
            this.notifier = notifier;
        }

        public abstract IEnumerable<Person> GetPersons(){

        }

        public void Notify() {
            foreach(var person in GetPersons()){
                this.notifier.Notify(this.GetPersons());

                //2                         1               STOPIEN SWOBODY
            }
        }
    }
    //po 2 stopniu
    public abstract class PersonNotifier {
        public abstract void Notify(IEnumerable<Person> persons){

        }
    }

    public class XMLPersonRegistry : PersonRegistry {
        //konstruktor
        public XMLPersonRegistry(PersonNotifier notifier) : base(notifier){

        }

        public override IEnumerable<Person> GetPersons(){
 //           ...
        }
    }

    public class SmtpPerdonNotifier : PersonNotifier {
        public override void Notify(IEnumerable<Person> persons)
        {
             //...
        }
    }


    public class Program
    {
        public static void Main(string[] args)
        {
  
  
            Console.WriteLine("Hello World!");

            PersonRegistry registry = new XMLPersonRegistry(new SmtpPerdonNotifier());

        }
    }
}