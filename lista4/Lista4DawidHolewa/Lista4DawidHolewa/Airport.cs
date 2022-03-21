using System;
using System.Collections.Generic;
using System.Text;

namespace Lista4DawidHolewa
{
    //najpierw napisałem, potem przeczytałem zadanie
    //w przypadku gdyby ten ObjectPool nie byłby zaimplementowany jako singleton, 
    //to obsługa przypadku, gdy oddajemy obiekt nie do macierzystej puli nadal byłby
    //obsłużony - dzięki metodzie ReleasePlane oraz listom, w których pamiętamy wyprodukowane obiekty
    public class ObjectPool<T> where T: new()
    {
        private int _capacity;

        private List<T> ready = new List<T>();      

        private List<T> released = new List<T>();   

        private static ObjectPool<T> _instance;

        public static ObjectPool<T> Instance(int capacity)
        {
            if (_instance == null) _instance = new ObjectPool<T>(capacity);
            return _instance;
        }

        private ObjectPool(int capacity)
        {
            if (capacity <= 0) throw new ArgumentException();
            _capacity = capacity;
        }

        public T AcquireObject()
        {
            if (released.Count == _capacity) throw new ArgumentException();
            if (ready.Count == 0)
            {
                T newPlane = new T();
                ready.Add(newPlane);
            }

            var reusablePlane = ready[0];
            ready.Remove(reusablePlane);
            released.Add(reusablePlane);
            
            return reusablePlane;
        }

        public void ReleasePlane(T plane)
        {
            if (!released.Contains(plane)) throw new ArgumentException();
            released.Remove(plane);
            ready.Add(plane);
        }

        public static void Discredit()
        {
            _instance = null;
        }
    }

    public class Plane
    {

    }
}
