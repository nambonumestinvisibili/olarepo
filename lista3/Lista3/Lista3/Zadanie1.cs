using System;
using System.Collections.Generic;
using System.Linq;

namespace Lista3
{
    class Zadanie1
    {
        //static void Main(string[] args)
        //{
        //    VehicleFactory vfactory = new VehicleFactory();
        //    vfactory.AddWorker(new TruckWorker());
        //    vfactory.AddWorker(new CarWorker());

        //    Vehicle c1 = vfactory.Product("Car", 7, 4);
        //    Vehicle c2 = vfactory.Product("Car", 7.3, 5);
        //    Vehicle c3 = vfactory.Product("Car", 5, 2);
        //    Vehicle t1 = vfactory.Product("Truck", 10, 230);
        //    Vehicle t2 = vfactory.Product("Truck", 11.3, 331);
        //    Vehicle t3 = vfactory.Product("Truck", 12.4, 431);

        //    Console.WriteLine(c1);
        //    Console.WriteLine(c2);
        //    Console.WriteLine(c3);
        //    Console.WriteLine(t1);
        //    Console.WriteLine(t2);
        //    Console.WriteLine(t3);


        //    //Polimorfizm: sposób liczenia kosztu podróży jest różny, dlatego
        //    //dziedziczymy z abstrakcyjnej Vehicle i overridujemy metodę w podklasach
        //    //Low Coupling: możemy łatwo dołożyć, usunąć, zmodyfikować workerów,
        //    //bez potrzeby zmiany reszty kodu, jest mniej zależności dzięki temu między klasami
        //    //Information Expert: Pojazdy same liczą swoje koszty podróży, bo tylko one
        //    //mają pełny dostęp do informacji potrzebnych do obliczenia tego kosztu
        //    //Creator: VehicleFactory ma dostęp do klas, które wykonują za nią tworzenie
        //    //obiektów, więc nie wiąże go to z konkretną implementację i umożliwia 
        //    //wariantowość implementacji tworzenia
        //    //Indirection: Unikamy obowiązku tworzenia wszystkich podobiektów w VehicleFactory,
        //    //dzięki przypisaniu workerom poszczególnych obowiązków, unikamy bezpośredniego
        //    //powiązania między obiektami, Workerzy są ściśle związani z obiektami które tworzą,
        //    //ale nie są w ogóle związani z klasą, która ich wykorzystuje
        //}
    }

    public abstract class Vehicle
    {
        public double mileageInLitersOver100KM;
        public Vehicle(double mileage)
        {
            mileageInLitersOver100KM = mileage;
        }
        public abstract double ComputeCostOfTravel(int km);
        public abstract override string ToString();
    }
    
    public class Truck : Vehicle
    {
        int Weight;

        public Truck(double mileage, int weight) : base(mileage)
        {
            Weight = weight;
        }

        public override double ComputeCostOfTravel(int km)
        {
            return mileageInLitersOver100KM * km * 5 + Weight/100 * 0.54 ;
        }

        public override string ToString()
        {
            return "(Truck) of mileage: " + mileageInLitersOver100KM + " of weight: " + Weight;
        }
    }

    public class Car : Vehicle
    {
        int CarCapacity;
        public Car(double mileage, int carCapacity) : base(mileage) 
        {
            CarCapacity = carCapacity;
        }
        public override double ComputeCostOfTravel(int km)
        {
            return mileageInLitersOver100KM * km * 4.8;
        }

        public override string ToString()
        {
            return "(Car) of mileage: " + mileageInLitersOver100KM + ", of capacity: " + CarCapacity;
        }
    }

    public class VehicleFactory
    {
        List<IFactoryWorker> Workers;

        public VehicleFactory()
        {
            Workers = new List<IFactoryWorker>();
        }

        public void AddWorker(IFactoryWorker worker)
        {
            Workers.Add(worker);
        }

        public Vehicle Product(string type, double mileage, int parameter2)
        {
            foreach (var worker in Workers){
                if (worker.ProductsType(type))
                {
                    return worker.Product(mileage, parameter2);
                }
            }
            throw new Exception("No worker for given class name");
        }
    }

    public interface IFactoryWorker
    {
        bool ProductsType(string Type);
        Vehicle Product(double mileage, int parameter2);
    }

    public class TruckWorker : IFactoryWorker
    {
        public Vehicle Product(double mileage, int weight)
        {
            return  new Truck(mileage, weight);
        }

        public bool ProductsType(string Type)
        {
            return Type.Equals("Truck");
        }
    }

    public class CarWorker : IFactoryWorker
    {
        public Vehicle Product(double mileage, int capacity)
        {
            return new Car(mileage, capacity);
        }

        public bool ProductsType(string Type)
        {
            return Type.Equals("Car");
        }        
    }



}
