public class BaseClass {
    public void TheMethod(){

    }
}
public class DerivedClass : BaseClass { }

public class Foo {
    public void TheMethod(){

    };
}

public interface ITheMethod {
    void TheMethod ();
}

public class  Program
{
    public static void Main(){
        DerivedClass c = new DerivedClass(); //dostęp do całego interfejsu
        BaseClass cc = new DerivedClass(); //dostęp do interfejsu BaseClass tylko, -> trzebaa zrzutować

    }

    public void DoSomething(BaseClass b){
        //do sth
        //Base i Foo nie saa ze soba powiazane,
        //nie mozemy skorzystac z Foo mimo ze moga wykonywac te same zadanie
        //lecz troche inaczej
        //dltego uzywmy Interfejsow
        //interfejs - kontrakt, zobowizanie, bez implementacji
        //mozna dziediczyc wiele interfejsow 
        // 

        
    }
    public void DoSomething(ITheMethod i){
        //
        //nie zawieszamy sie w konkretnym miejscu hierrchii obeiktowej dziedziczenia,
        //oczekiwamy konkretnego interfejsu
        //bardziej ogolny, uwalniaaaaaaaa od implementacji,
        //mozemy wrzucic rozne implementacje, z roznych poziomow hierarchii

    }

    //czy ma sens pusty interfejs? tak ,jakas zlozona struktura kodu nieznana struktura kodu w trakcie dzialania algorytmu jest poddawana
    //inspekcjia za pomoca reflekji i z calej takiej struktury musza byc wylawaine klasy ktore sie wjakis sposob roznia od innych,
    //znakowanie klas skladowych w ten sposob ------- ??


    //klasa abstrakcyjna
    //posrednia miedzy konrektna klasa a interfejsem,
    //rezerwuar wpsoldzielonego kodu,
    //moga sie pojawic jakies metody, ktore sa w calej hierarchii
    //nie mozna utworzyc instancji takiej klasy
    //chyba ze anonimowa -- staz!
    //
    
    
    //metoda abstrakcyjna w klasie abstrakcyjnej - nie ma impl. bedzie dziedziczona
    //potrzebna bedzie implementacja
    //
    // wtedy klasa absrtrakcyjna - zobowiazanie

    //czym sie rozni klasa+metoda absstrakcyjna (zero impl) od interfejsu?
    //klasa dziedziczaca po abstrakcyjnej klasie, moze miec tylko jedna nadrzedną klasę abstrakcyjną,
    //interfsjów kilka. 
    //



     
} 