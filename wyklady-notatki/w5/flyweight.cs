using System;

class Board {
    //bardzo duża plansza 10000000x10000000 - bardzo duze zuzycie pamieci   
    
    private Dictionary<CheckerType, Checker> _cache = new Dictionary<CheckerType, Checker>();
    
    public void Draw() {}
    public Checker CreateChecker( CheckerType type){
            // nie musimy tworzyc milionow takich samych checkerow, wystarczy ze mamy jednego o konkretnym typie (tylko ten enum wyroznia jednego od drugi)
        if (!_cache.ContainsKey(type)){ //taka implementacja korzysta ze wspólnych instancji (referencja!)
            _cache.Add(type, new Checker(type));
        }
        return _cache[type];
    }
}
enum CheckerType { //cecha wyznaczajaca unikalnosc
    Pawn, 
    Knight
}

class Checker {
    //zawiera mapę bitową - zajmuje bardzo duzo miejsca w pamieci czy cos
    //kazdy checker wyglada tak samo (warcaby) wiec ma ta sama
    //mape bitowa - czyli nie kazdy musi ja miec, moga korzytsac ze wspolnego zasobu
    //(wczesniej kazdy mial wlasna)
    public Checker () {}
    // int x,y; //z kolei mamy problem z tym! nie tylko mapa bitowa jest wyznacznikiem, dodatkowo jeszcze 
    //zwracamy klientowi te sama instancje, wiec wiele razy namalowaloby sie w tym samym miejscu ten sam checker 
    public Checker(CheckerType type) {
        //zwracanko checkera = bierki
    }

    public void Draw(int X, int Y) {
        //uzyj mapy bitowej

        //to co nie jest wspoldzielonym stanem - x,y przekaz przez param
    }
}



namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}