namespace mediator {


   public class ConcreteColleague1 {
        public ConcreteMediator mediator;

        public void Notify1( string state ){
            System.Console.WriteLine("colleague1::notify" + state);
        }

        public void RaiseNotificiation(string state){
            this.mediator.NotifyAll(this, state);
        }
    }

    public class ConcreteColleague2 {
        public ConcreteMediator mediator;

        public void Notify2( string state ){
            System.Console.WriteLine("colleague2::notify" + state);
        }
    }

 
    public class ConcreteMediator {
        public ConcreteColleague2 colleague2;
        public ConcreteColleague1 colleague1;

        public ConcreteMediator(){
            colleague1.mediator = this;
            colleague2.mediator = this;
        }

        public void NotifyAll(object sender, string state){
            if (sender == colleague1){
                colleague2.Notify2(state);
            }
            else {
                colleague1.Notify1(state);
            }
        }


    }

    public class Program {
        static void Main(string[] args) {
            ConcreteMediator mediator = new ConcreteMediator();
            mediator.colleague1.RaiseNotification("18");
        }
    }
}