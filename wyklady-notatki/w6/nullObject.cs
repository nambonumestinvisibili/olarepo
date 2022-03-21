using System;


//zwalnia z testów if na null:
//kiedy? z fabryką 
//gdy parametr nie pasuje do workera, 
//strategie
//1zamiast np wyjątki - trzeba się z tym zmierzyć, 
//kod klienta musi to obsłużyć jakoś 
//2 zwróć null, niewygoda dla klienta, trzeba sprawdzić
//czy wyrzuca null
//3 użycie NullObject 

//kiedy użyteczne?
//dla fabryk logujących, śledzących ścieżki przepływy

//NULL classes symbolize default behavior and default
 //behavior can be any value and not compulsorily ZERO.
 // NULL classes are domain specific and not technical 
 //specific. It’s very much possible that default discount
 // can be 0.1 as shown in the below code. So creating a
 // class makes more sense than just technically checking 
 //NULLs and returning zero value.


//https://www.codeproject.com/Articles/1042674/NULL-Object-Design-Pattern#NULLcheckexistenceVSDefaultBehavior

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            OperationFactory = OperationFactory.Create();
            IOperation operation = factory.Create(-1);
            operation.DoWork();
        }
    }

    public interface IOperation {
        void DoWork();
    }
    public class ConcreteOperation : IOperation{
        public void DoWork(){
            //work...
        }
    }
    public class OperationFactory(){
        public IOperation Create(int n){
            if (n > 0){
                return new ConcreteOperation();
            }
            return new NullOperation();
        }
    }

    public class NullOperation : IOperation{
        public void DoWork();
    }
}



//Iterator
//Composite - struktury drzewiaste, expression (jezyk), html 
//sam nie wnosi zbyt wiele

abstract class Tree {

}

class TreeLeaf : Tree {

}

class TreeNode : Tree {
    Tree lrft; // <--- może to być treenode albo treeleaf
    Tree right;
}

//chodzi o to, że treenode i treeleaf to Composity, muszą dziedziczyć
//po jednym jakimś IComposite i mogą to być różne rzeczy, ale jednak
//Tree

