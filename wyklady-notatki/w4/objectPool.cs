
public class Program {
    public static void Main() {

    }
}


// object pool - fabryka która kontroluje liczbę wydawanych instancji
// techniczna motywacja - kod korzysta z zew infra doste do elementow tej infra jest ograniczony jakimis zasobami niezaleznie od kodu ktorego uzywamy
// polaczenie kodu klienckiego z obiektami bazodanowymi
// zeby nie powtarzac negocjacji tozsamosci za kazdym razem 
// tylko zeby polaczenie zapamietac na chwile 
// zapamietanie jest kosztowne - utrzymanie p serwer i aplikacje kliencka 
// utrzymanie otwartego kanalu komunikacyjnego 
// liczbe takich przechowywanych obiektow trzeba kontrolowac, 

public class ObjectPool {
    
    // // ObjectPool mógłby być singletonem (zazwyczaj jest)
    // private static ObjectPool _instance;
    // public static ObjectPool Instance(){
    //     if (_instance == null){
    //         _instance = new ObjectPool(1);
    //     }
    //     return _instance;
    // }
    private int _capacity;
    private List<Reusable> ready = new List<Reusable>(); //magazyn obiektow gotowych do wydania
    private List<Reusable> reused = new List<Reusable>(); 
 
    public ObjectPool( int capacity ) { //jak duzy ma byc rezerwuar obiektow
        if (capacity <= 0) {
            throw new ArgumentException();
        }
        _capacity = capacity;
    }

    public Reusable AcquireReusable(){
        // return new Reusable(); // bez limitu, za kazdym razem nowe -> :(
        if (released.Count() == this._capacity){
            throw new ArgumentException();
        }
        if (ready.Count() == 0){
            Reusable newReusable = new Reusable();
            ready.Add(newReusable); //zapewnienie istnienie co najmniej jednego obiektu w puli

        }
        var reusable = ready[0];
        ready.Remove(reusable);
        released.Add(reusable);
        return reusable;

    }

    public void ReleaseReusable(Reusable reusable){
        if (!released.Containts(reusable)){
            throw new ArgumentException();
        }
        released.remove(reusable);
        ready.Add(reusable);
    }
}

//obiekty wydawane przez fabryke - Resuable
//po wykorzystaniu tych obiektow maja one wrocic do fabryki, zeby 
// mogly byc wykorzystane przez kolejnych klientow

public class Reusable {

}


[TestClass]
public class UnitTest {
    public void InvalidCapacity(){
        Assert.ThrowsException<ArgumentExcepion>(
            () => {
                ObjectPool opool = new ObjectPool();               
            }
        )
    }

    public void ValidCapacity(){
        ObjectPool pool = new ObjectPool(1);
        Reusable reusable = opool.AcquireReusable();
        
        Assert.IsNotNull(reusable);
    }

    public void CapacityDepleted(){
        ObjectPool pool = new ObjectPool(1);
        Reusable reusable = opool.AcquireReusable();
        
        Assert.ThrowsException<ArgumentException>(
            () => {
                Reusable r2 = pool.AcquireReusable();
            }
        )
    }
    public void ReuseObject(){
        ObjectPool pool = new ObjectPool(1);
        Reusable reusable = opool.AcquireReusable();
        
        pool.ReleaseReusable(reusable);

        Reusable reusable2 = pool.AcquireReusable();

        Assert.AreEqual(reusable, reusable2);
    }

    public void ReleaseInvalidReusable(){
        ObjectPool pool = new ObjectPool(1);
        Reusable reusable = new Reusable();

        Assert.ThrowsException<ArgumentException>(
            () => {
                pool.ReleaseReusable(reusable);
            }
        )
    }
}


//być może że w objectPool mamy singletona tak naprawde, bo jesttylko jeden obiekt

//jak uprościć skomplikowaną implementacje gdy object pool jest singletonem
// bo bysmy musieli
// ObjectPool.Instance().Acquire();
//ObjectPool.Instance().Release(re);


public class ReusableWrapper {
    //deleguje wywołania wszystkich metod do Reusable
    //wie gdzie jest Pool
    // wie jak wywolac ReleaseReusable na Pool
    public ReusableWrapper(){
        //wie gdzie jest pool 
        //tworzy Reusable korzystjac z Pool
    }
    public void Release({
        //wraca reusable do pool
    })
}
//wtedy mozemy zrobic = new ReusableWrapper() //latwiejszy interfejs klienta, nie musi wiedziec
//o tym jak zaimplementowane jest

