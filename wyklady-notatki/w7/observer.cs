namespace x {


    public class Observable {
        private List<IObserver> observers;
        public void RegisterObserver(IObserver observer){

        }
        public void UnregisterObserver(IObserver observer){

        }

        public void NotifyAll(string data){
            foreach(var x in observers){
                x.Notify(state);
            }
        }
        
    }

    public interface IObserver {
        void Notify(string state);
    }

    public class Observer1: IObserver{
        public void Notify(string data){
            System.Console.WriteLine(  "Observer1: " + state);
        }
    }
    public class Observer2: IObserver{
        
    }


    //
    public delegate void ObserverDelegate(string state); //interfejs funkcjny

    public class ObservableC {
        //przyczepiamy liste funkcji
        public event ObserverDelegate ObserverDelegate; //lista dunkcji takiego typu

        public void NotifyAll(string state){
            // this.ObserverDelegate.GetInvocationList( );
            // lukier
            if (ObserverDelegate != null) {
                ObserverEvent(state) //wywoalanie wszystkich funkcji, typem
                //event jest typ listowy
            }
        }
 
        //wtedy w mainie: observable.ObserverEvent += observer1.Notify
        //wtedy w mainie: observable.ObserverEvent += observer1.Notify3
        //nie wymaga zgodnosci nazw
        //unregister -=
        //mozna dodac metode statyczna
        //wazny wzorzec

    }



















}