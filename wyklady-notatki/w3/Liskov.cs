
class A {
    //x >= 0
    public virtual Foo(int x)
    {
        return sth; 
    }
    //
}

class B : A {
    //has to have rither the same parameter constraint: x >= 0
    //or wearker x > -2
    //we cant take away functionality in child classes
    public override Foo(){

    }
    //zwraccające wyniki tak samo, musżę być takie same, lub mieć więcej funkcjonalności,
    //nie możemy nie oczekiwać innych wyników niż W A
    
}


//code 
A obj = new B(); // B : A
obj.Foo(); //we expect sth from B based on A