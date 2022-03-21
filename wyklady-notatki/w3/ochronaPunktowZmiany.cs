//ochrona punktow zmiennosci

class Bar {

    public Foo Foo;
    //new!!! nie zmieni się, DAJ UZYTKOWNIKOWI INTERFEJS, KTORY SIE NIE BD ZMIENIAL
    public DoSomething(){
        this.Foo.DoSomething(); //kiedy mozesz zmienic implementacje tego
    }
}

class Foo {
    public DoSomething() {
        Qux.Baz.Do();
    }
}

//'client code':

Bar b = new Bar();
b.Foo.Qux.Baz.Do(); //bardzo złe, co jesli usuniemy referencje do Foo i zastapimy ja inna referencja, refaktor 
//calego kodu. ochronmy to
b.DoSomething(); //ale to si enie zmieni!
