public class BaseClass{
    public void Foo (string s){
        System.Console.WriteLine("foo");
    }
}

public class DerivedClass {
    public void Foo(string s){
        BaseClass delegated = new BaseClass();
        delegated.Foo(s);
    }
}

public class Program {
    public static void Main() {

    }
}

//MYSLIMY O DZIEdziczeniu, a odziedzicze, to bede mial dostep do tych samych funkcjonalnosci
//delegoeanie podobne w tym kontekscie
//nie wiazemy w hierarchie, korzystamy z delegowania
//pozyczam impl z innej klasy, nie ma problemu z przekazywaniem arg,
//jestem uwolniony od hierarchii dziedziczenia
//

public interface IFoo{
    void Foo(string s);
}

//z takiego interfejsu oba moga korzystac, mimo ze nei sa ze soba powiazane dziedziczeniem
//ani niczym innym w sumie
//delegowanie - techinczny subsytut relacji dziedziczenia
//- preferujemy DELEGOWANIE OVER DZIEDZICZENIE
//dlaczego - nie ma statycznej, nierozerwalnej wiezi w dziediczeniu
//ktora umozliwia dodatkowo dziedziczenie tylko z 1 klasy

//przewagi delegowania
//-delegowac do dwoch klas
//-druga klasa moze nawet nie implementowac tego samego intefejsu,
//druga klasa moze miec nawet metoda o innej nazwie
//-moge robic delegowanie wariantowe, zalezne od jakiegos warunku
// if () jedna delegacja, else druga delegacja (inna)
//-w statycznie kompilowanym daje nam namiastke wielodziedziczenia
//dynamicznego dziedziczenia, zaleznego tylko od warunku ktory resolbuje sie
//w runtime
//-mozliwosc zredukowania interfejsu: duga klasa nie musi miec tego samego interfesju,
//w dziedziczeniu moge tylko rozszerzac interfejs


//Summary: jesli zalezy nam tylko na reużywaniu kodu, lepiej jest delegować
//niż dziedziczyć
