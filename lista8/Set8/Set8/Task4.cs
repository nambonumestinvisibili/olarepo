using System;
using System.Collections.Generic;
using System.Text;

namespace Set8
{
    public class ATM
    {
        private IState _state;

        public ATM(IState state)
        {
            _state = state;
        }

        public void SetState(IState state)
        {
            _state = state;
        }


    }

    public interface IState
    {
        void ReadCard(string cardNumber);
        void Withdraw(int amount);
        void Finish();
    }

    public class AwaitingState : IState
    {
        private ATM _atm;
        public AwaitingState(ATM atm)
        {
            _atm = atm;
        }

        public void Finish()
        {
            
        }

        public void ReadCard(string cardNumber)
        {
            Console.WriteLine("Card is read successfully");
            _atm.SetState(new OperatingState(_atm));
        }

        public void Withdraw(int amount)
        {
            throw new Exception("No card injected!");
        }
    }

    public class OperatingState : IState
    {
        private ATM _atm;

        public OperatingState(ATM atm)
        {
            _atm = atm;
        }

        public void Finish()
        {
            _atm.SetState(new FinishingState(_atm));
        }

        public void ReadCard(string cardNumber)
        {
            throw new Exception("Card is already read and validated!");
        }

        public void Withdraw(int amount)
        {
            Console.WriteLine("Account state is decreased by {0} amount of PLN. Ejecting money", amount);
        }
    }

    public class FinishingState : IState
    {
        private ATM _atm;

        public FinishingState(ATM atm)
        {
            _atm = atm;
        }
        public void Finish()
        {
            Console.WriteLine("Ejecting card...");
            _atm.SetState(new AwaitingState(_atm));
        }

        public void ReadCard(string cardNumber)
        {
            throw new Exception("Currently processing previous transaction");
        }

        public void Withdraw(int amount)
        {
            throw new Exception("Currently processing previous transaction");
        }
    }







}
