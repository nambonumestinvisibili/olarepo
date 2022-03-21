using System;

namespace ConsoleApp
{
    public class Program
    {
        public class Originator {
            private int state;

            public int GetState(){
                return state;
            }

            public vois SetState (int state){
                this.state = state;
            }

            public Memento CreateMemento(){
                Memento m = new Memento();
                m.SetState(GetState());
                return m;
            }           

            public void RestoreMemento(Memento m){
                    this.state = m.GetState();
            }
        }

        public class Memento {
            private int state;

            public int GetState(){
                return state;
            }

            public vois SetState (int state){
                this.state = state;
            }
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}