public class Program
{
    public static void Main()
    {
        Foo foo = new Foo();
        Foo foo2 = new Foo();

        //wskazujemy na dwa rozne obszary w pamieci
        //ale chcemy dostawac jeden i ten sam obiekt,
        //nie chcemy umozliwiac powstawania wiecej niz jednej instancji
        //po co?
        //do czynienia z klasa techniczna, pomost dostepowy do skomplikwoanej infrastruktury
        //o ktorej wiemy ze nie wymaga wiecej niz jednego egzemplarza
        //plik konfiguracyjny ta struktura, ktory jest w zasobach
        //niezmienny przez caly czas zycia aplikacji
        //czytany jest tylkor az
        //konstruowanie obiektu jest dosyc kosztowne,
        //mozemy sobie na to pozwolic na starcie aplikacji
        //ale od tego momentu chce miec gwarancje ze pozniej juz nikt nigdy nie
        //utworzy kolejnego takiego obiektu np przez nieuwage, niemiejtnosc
        //singleton rozwiazuje to
        //utowrzenie dwoch obiektow bedzie wskazywalo na to samo miejsce w pamieci
        //obiekty są "wspołdzielone"

    }
}

public class Foo
{
    public string Data;
}

public class FooSingleton
{ //nie sprawdzi sie na serwerach, gdzie mamy rownolegle zadanie
    private static FooSingleton _instance;
    public static FooSingleton Instance()
    {
        if (_instance == null)
        {
            //jednokrotne, kosztowne
            _instance = new FooSingleton();
        }
        return _instance;
    }
}
//moze sie stac ze utworza się dwa
//test nie przewidzi środowiska wielowątkowego. jak takie pisać? później
//Singleton z czasem życia godzina (np cache był na godzinę) -- jak test/ wrócimy

//podwójne sprawdzenie i blokada = wzorzec kreowania DOUBLE CHECK AND LOCK
public class FooSingleton2
{
    private static FooSingleton _instance;
    //potrzebujemy wspoldzielonego obiektu, ktorego referencja do niego
    //bedzie nam sluzyla jako straznik sekcji krytycznej kodu, do ktorej poszczegolne
    //watki nie beda mogly wejsc nie majac wlaścicielstwa tej referencji
    private static object _lock = new object();
    public static FooSingleton Instance()
    {
        if (_instance == null)
        {
            lock (_lock) // nadal dwa wywlaszczone watki ktore zatrzymaja się na tym zamku zadziałają tak że pierwszy z nich wchodzi do takiej blokady bo od razu moze uzyskac wlascicielstwo wspoldzielonego obiektu, inicjuje  drugi czeka, ale za chwile przechodzi przez tę kolejkę oczekiwania drugi trzeci czwarty, stąd potrzebne nam jest podwójne sprawdzenie:
            {
                if (_instance == null){

                    _instance = new FooSingleton();
                }
            }
        }
        return _instance;
    }
}





[TestClass]
public class UnitTests
{
    [TestMethod]
    public void Test()
    {
        Foo foo = new Foo();
        Foo foo2 = new Foo2();
        Assert.AreEqual(foo, foo2);
    }
}

//w 1 warunku, chronimy kod kliencji przed przypadkiem w  ktriym z jakiegos powodu po przejscu takim pozytywnym przez sekcje singleton jest juz zainicjowany, przypadek duzo pozniejsyzch wywolan, ktore mozemy już odsiać
//w srodowisku wielowatkowym wiele watkow wejdzie w tym samym czasie do tego ifa do srodka
//wsszystkie sie zatrzymaja na tym locku, tylko 1 z nich wejdzie do srodaka, singletona jeszcze nie ma,
//singleton jest inicjowany, już Jest! w tym momencie wpuszczany jest przez lock drugi wątek i wejdzie do środak i zainicjuje
//drugą instancję
//ale tego nie zrobi bo mamy jeszcze jednego ifa w środku!, to dal tych zablokowanych jest ten warunek
//czyli na dobra sprawe 1 if nie jest mega potrzrbny, ale wtedy wiele watkow staneloby na locku, 
//a sprawdzenie nastepowaloby synchronicznie
//1 if zalatwia lepsza efektywnosc wykonania


//PYTANIA
//czas zycia
//np co godzine wygada cahce, singleton powinien odnowicc sie,
//np mozemy chciec zeby singleton byl unikalny w obrebie jenego watku 
// prosta implementacja nam nie odpowaida na te pytania
// ale latwo sobie rozszerzenie impl ktora bd ok, wiec czas zycia ok - wystarczy dodac pare ifow
// czas zycia - ok

// argumenty inicjalizacyjne
// latwa sytuacja, argumenty inicj. sa puste. sama klasa i metoda nie maja argumentow
// moze byc wiecej plikow konfig, wiec moga byc potrzebne parametry
// wiele parametrow - co teraz? trudniej
// 

// najw problem
// singleton zawsze zwraca obiekt konkretnego typu
//zawsze wywolujemy tak: FooSingleton.Instance()
// co za tym idzie, zawsze dostaniemy obirkt typu FOOsingleton
// a jaki inny typ moglby zwracac niby?
// zaimplementowana klasa o swojej funkcjonalnosci the method, another method, nie spelnia w ktoryms momenciie oczekiwan klienta
// mozna sobie wyobrazic ze singleton moglby zwraca obiekt innego typu - podklasy, albo obiekt implementujacy ten sam interfejs
// do ktorego byc moze czesc implementacji bd delegowana
// ale jak sprawic zeby zwracanie innych obiektow z singletona moglo by byc wygodnie zaimpl.
// Jak zrobc zeby singleton zwracal cala rodzine obiektow, z ktorych kazdy z nich dopasowuj sie jakos do tych argumentow
// singleton = zeby zwracal rozne impl w zalezonosci od argumentow 
// przestajemy myslec o singletonie!
// dochodzimy do konsturkcji Fabryki
// nie mamy jednej wspoldzielonej instancji, ani jednego typu  

public class FooFactory {
    public void TheMethod(){

    }
    public void AnotherMethod() {

    }

    public static FooFactory Create(string path, string a, int n){
        //jeden wielki if na parametry ktory adresuje te wszystkie waatpliwosci przy singletonie
        //czas zycia ok
        //parametry truniej
        // singleton zwraca rozne impl w zaleznosci od argumentow
        //roznice miedzy factory a singleton:
        //singleton to te prstsze przypadki gdy nie zwracamy uwagi na niusane typu czas zycia czy parametry
        //tam gdziejest wiecej niuansow, -> fabryka
        //fABRYKA POZWALA klientowi inicjowac instancje obiektów.
        //ale po co?
        //czemu, moze lepiej zwyczajnie new?
        //

    }
}


public class FooFactory {
    public void TheMethod(){

    }
    public void AnotherMethod() {

    }

    public static IFoo Create(){ //stare: //public static FooFactory Create(){
        return new FooFactory();
        //jeden wielki if na parametry ktory adresuje te wszystkie waatpliwosci przy singletonie
        //czas zycia ok
        //parametry truniej
        // singleton zwraca rozne impl w zaleznosci od argumentow
        //roznice miedzy factory a singleton:
        //singleton to te prstsze przypadki gdy nie zwracamy uwagi na niusane typu czas zycia czy parametry
        //tam gdziejest wiecej niuansow, -> fabryka
        //fABRYKA POZWALA klientowi inicjowac instancje obiektów.
        //ale po co?
        //czemu, moze lepiej zwyczajnie new?
        //NAJWIEKSZA ROZNICA MIEDZY kodem klieckim ktory uzywa fabryki, a ktory new

    }
}



[TestClass]
public class UnitTests
{
    [TestMethod]
    public void Test()
    {
        FooFactory foo = FooFactory.Create(); //nie wiąze klienta z niczym, typ zwracany przez fabrykę nie musi
        // być wtedy konkretnego typu, tylko implementuje interfejs
        //np IFoo, i klientawtedy nie ochodzi, nic nie będziemy musieli zmieniać w kodzie klienckim, nawet jeśli się zmieni
        //implementacja, typ, cokolwiek w metodzie create

        //zaleta: konstuckaj dynamiczna, wewnatrz create mozemy mieć warunki, możemy zwracać różne typy implementujące IFOO
        //FABRYKI: duzo bezpieczniejssze
        //tam gdzie mozemy umyc singletona, da sie lepiej napisac Fabrykę


        FooFactory foo2 = new FooFactory(); //new zawsze wiąże klienta z konkretnym typem
        Assert.AreEqual(foo, foo2);
    }
}

public interface IFoo {

}


//tutaj fabryka: produkcja różnych typów na podstawie parametrów, te typy mają implemetować jeden wspólny interfejs (ISR!)


//otwarta fabryka ------------------------------------------------------
//open-closed, otwarta na rozszerzenia, zamknieta na modyfikacje (dostarcza funkcjonalnosci)



public interface IEngine {


}

public class Engine1 : IEngine {

}

public class Engine2 : IEngine {
    
}

public class EngineFactory{ //ok dobry kod, ale jest CLOSED
    public IEngine Create(string Param){
        if (Param == "directx"){
            return new Engine1();
        }
        else if (Param == "openg1") return new Engine2();

        throw new ArgumentNullException();
    }
}



[TestClass]
public class UnitTests
{
    [TestMethod]
    public void Test()
    {
        IEngine engine = new EngineFactory().Create('openg1');
        Assert.IsNotNull(engine);
    }
}


//Klienci zauważają w bibliotece brak, są w stanie sami go udsotępnić we własnym zakresie, nowy silnik, inna implementacja
//ale nie możemy dostarczyć do niej nowego typu
//zawssze można się wróicć i powiedzieć proszę mi dopisać w Create jeszcze jednego ifa
//ale tych ifów może być tysiące, i nie o to chodzi zebys ty to poprawial, niech uzytkownicy tego kodu to robią

//tym razem fabryka deleguje zadanie wykonstruowania obiektu konkretnego typu, fabryka organizuje

public interface IFactoryWorker {
    bool AcceptsParameters(string Parameter);
    IEngine Create();
}




public class EngineFactory{ //ok dobry kod, ale jest CLOSED
    private List<IFactoryWorker> _workers = new List<IFactoryWorker>();
    public IEngine Create(string Param){
        foreach ( var worker in _workers){
            if (worker.AcceptsParameters(Param)){
                return worker.Create(parameter);
            }
        }
    }
    public Add()...
}

public class Engine1Worker : IFactoryWorker {
    public bool AcceptsParameters (string parameter) => return parameter == 'xxx';
}


//klient moze dostraczyc sam niezaleznej implementacji engine i workera, i dodac go do fabryki; korzystac!



[TestClass]
public class UnitTests
{
    [TestMethod]
    public void Test()
    {

    }
}
