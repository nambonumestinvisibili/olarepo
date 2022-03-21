class A {

}

class B : A {

}


class FactoryOfA() {


    public A Create(){
        //return new A() // ok the process is the same, we return A
        return new B() // B has better implementation than A somehow, we are flexible inchanging code
    }
}

//somewhere in code

A a = new A() // original we have toc= change every occurence in code, real bad practise
A a = new FactoryOfA().Create() // we get A, but really we get A, code maintenance is far better