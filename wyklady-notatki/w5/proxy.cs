using System;

namespace ConsoleApp
{

////jakis taki proxxy idk
    // public class Foo {
    //         public virtual void DoWork(){

    //         }
    // }

    // public class FooProxy : Foo {
    //     public override void DoWork()
    //     {
    //         //http
    //     }
    // }

////inny proxy - wirtualne
//konstrukcja jest trudna, odwlekamy tworzenie obiektu tak dlugo az naprawde potrzeba
    public class Foo {
            public virtual void DoWork(){

            }
    }

    public class FooProxy : Foo {
        private Foo _foo;               //klasyczna delegacja
        public override void DoWork()
        {
            if ( _foo == null){
                _foo = new Foo()

                _foo.DoWork();
            }
        }
        //często pomocnicza metoda
        private void EnsureCreated(){
            if (_foo == null) _foo = new Foo();
        }
    }
    

  ////
    

public class FooProxy : Foo {
        private Foo _foo;               //klasyczna delegacja
        public FooProxy(){
            _foo = new Foo(); //rezygnacja z kontroli tworzenia
        }
        public override void DoWork()
        {
            if (...) //UPPRAWNIENIA
            Log("...") //albo loGOwanie!
            return _foo.DowORK();
        }
        
    }


 //np Lazy to proxy
 Lazy<int> lazy = new Lazy<int>(
     () => { // tzw. metoda fabrykujaca
         //ksoztowne
         return 18
     }
 )   


 lazy.Value //dopiero teraz wywoluje sie metoda fabrykujaca

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}