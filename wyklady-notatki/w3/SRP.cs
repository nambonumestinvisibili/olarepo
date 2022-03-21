//SRP 
//Zadna klasa nie moze byc modyfikowana z wiecej niz 1 powodu
//czemu?
//bo zmieniajac z wiecej niz jednego 
//-rzutuje to na klienta , im wiecej powodow do zmiany tym wiecej wersji , czesciej trzeba taka klase
//uaktualniac, co daje np trzy rozne wersje bibliotyki ze zmienionymi sygnaturami, niedobrze
 // bo te powody sa niezalezne, wiece wtstepuja czesto ppb z jednakowym natezeniem 
 // zbyt ryzykowne, zeby taka zwielokrotniona odpowiedzialnosc utrzymywac


//cZY IMPLEMENTOWANIE DWOCH INTEFEJSOW NARUSZA ODPOWIEDZIALNOSC? nei wiadomo trzeba uwazac 

//IReader, IWriter, obiekt B implementuje IR, iW,
//czy zle? niekoniecznie, bo B czyta i zapisuje jakas jedna rzecz (powod do zmiany bd tylko 1)


//OPEN CLOSED
// zamknięta na modyfikacje otwarta na rozszerzenia, sposób:
public class TaxCalculator {
    public count(double price){
        return 0.22 * price;

    }
}

// nie jest zamknięta na modyfikację, przecież podatki sie zmieniają

// daj użytkownikowi możliwość rozszerzenia:
//pozwol mu zaimplementowac to:

//to jest uzaleznienie od abstrakcji zaamiast iimplementacji - Dependency INVERSION
public interface ITax {
    double GetTaxRate();
}
//wrzuc jako interfafce do tego
public class TaxCalculator {
    public count(double price, ITax tax){
        return tax.GetTaxRate() * price;
        
    }
}


//cgyba pubilczne metody w c# powinny miec virtual, bo jest to niezgodne z OCP, utrudnia dziedziczenie