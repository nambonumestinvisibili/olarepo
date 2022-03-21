using System;

namespace ConsoleApp
{

    public class Duck {
        public virtual void Quack() {
            System.Console.WriteLine("duck::quack");
        }
    }


    public class Dog { //alternatywna implmementacja która działa ale jest zaczepiona
    //na zupełnie innym interfejsie

        public void Bark() {
            System.Console.WriteLine("dog::bark");
        }
    }

    public class DogToDuckAdapter : Duck {
        Dog _dog;
        public DogToDuckAdapter( Dog dog ){
            _dog = dog;
        }

        public override void Quack()
        {
            this._dog.Bark();
        }
    }

    public class Program
    {

        public static void Main(string[] args)
        {

            //klient nadal potrzebuje kaczki bo jest skomplikowany
            //i zalezy od tego interfejsu
            //a potrzebujemy skorzystac z klasy ktora pochodzi z zupelnie innej rzezywwistosci
            //

            //z fabryki!!
            Duck duck = new Duck();
            Duck duck = new DogToDuckAdapter(new Dog()); //adapter zaaplikowany z fabryki
            duck.Quack();


            Console.WriteLine("Hello World!");
        }
    }
}