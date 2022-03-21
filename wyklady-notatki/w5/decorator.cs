using System;

namespace ConsoleApp
{

    public abstract class BaseCoffee {
        public abstract int GetCost();
    }

    public class Coffee  : BaseCoffee{
        public override int GetCost(){
            return 1;
        }
    }

    public class IrishCoffee : BaseCoffee {
        public override int GetCost() {
            return 2;
        }
    }

    public class SugarCoffee : Coffee {

    }

    public class SugarIrishCoffee : IrishCoffee {

    }

    public class CreamCoffee : Coffee {

    }



    //hierarchia klas pęka w szwach
    //wyobraź sobie kawę irlandzką dosłodzoną dwa razy ze śmietanką: na każdy przypadek nowa klasa?
    //absuuurd
    //dekorator 
    //
    //r
    public class SugarCofee : BaseCoffee {
        private BaseCoffee _coffee;
        public SugarCofee( BaseCoffee coffee ){ //charakterystyczny konstruktor
            _coffee = coffee;
        }

        public override int GetCost() //dodaje funkcjonalnosci
        {
            return 1 + coffee.getCost();
        }
    }    

    public class DoubleCoffee : Coffee {
        private BaseCoffee _coffee;

        public DoubleCoffee( BaseCoffee coffee){
            _coffee = coffee;
        }
        public override int GetCost (){
            return 2 * _coffee.GetCost();
        }
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            //możemy łączyć w kombinacje jakieś podstawowe funkcjonalności, wcale ich nie mnożąć
            //dynamiczna konstrukcja nowych funkcjonalnosći z jakichś podstawowych!
            //w runtimie!

            BaseCoffee coffee = new DoubleCoffee(new SugarCoffee(new IrishCoffee())); 


            //często tworzymy fabrykę, która składa te 
            //rzeczy sobie
            //zamiast pozwalać klientowi coś psuć :p
            
        }
    }
}