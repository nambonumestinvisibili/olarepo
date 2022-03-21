using System;
using System.Collections.Generic;
using System.Text;
namespace Lista3
{
    class Zadanie3
    {
        // Poprzednia implementacja polegała silnie na implementacji klas, z których korzysta. Nie jest otwarta na rozszerzenia,
        // bo wymaga to zmiany implementacji składowych w CashRegister, z których chcielibyśmy skorzystać. 
        // W nowej implementacji wystraczy podmienić
        // w jednym miejscu (*) klasy implementujące interfejs, bez zmian w CashRegister
        // Więc CashRegister jest zamknięta na modyfikację i otwarta na rozszerznia
        
        //public static void Main(string[] args)
        //{
        //    ITax tax = new CurrentPolandTax();
        //    ITaxCalculator taxCalculator = new TaxCalculator(tax); //(*)
        //    ISortShopItemsService sortService = new SortByName();
        //    CashRegister cregister = new CashRegister(taxCalculator, sortService); //(*) lub tu

        //    string spozywcze = "spożywcze";
        //    string pieczywo = "pieczywo";
        //    Item[] items =
        //    {
        //        new Item(0.78, "Guma balonowa", spozywcze),
        //        new Item(2.71, "Chusteczki", "użytku codziennego"),
        //        new Item(5.60, "Chipsy Lays", spozywcze),
        //        new Item(9.50, "Parówki berlinki", spozywcze),
        //        new Item(3, "Chleb", pieczywo),
        //        new Item(0.75, "Bułka", pieczywo),
        //        new Item(3.60, "Muffin Wedel", pieczywo),

        //    };

        //    Console.WriteLine(cregister.CalculatePrice(items));
        //    cregister.PrintBill(items);

        //    ITax tax2 = new PreviousPolandTax();
        //    ITaxCalculator taxCalculator2 = new TaxCalculator(tax2);
        //    ISortShopItemsService sortService2 = new SortByCategory();
        //    CashRegister cregister2 = new CashRegister(taxCalculator2, sortService2);

        //    Console.WriteLine(cregister2.CalculatePrice(items));
        //    cregister2.PrintBill(items);

        //    Console.WriteLine("Zła implementacja");
        //    CashRegister2 cregister3 = new CashRegister2();
        //    cregister3.PrintBill(items);
        //}
    }

    public interface ITax
    {
        decimal GetTaxRate();
    }

    public class CurrentPolandTax : ITax
    {
        decimal Tax = (decimal)0.24;
        public decimal GetTaxRate()
        {
            return Tax;
        }
    }

    public class PreviousPolandTax : ITax
    {
        decimal Tax = (decimal)0.1;
        public decimal GetTaxRate()
        {
            return Tax;
        }
    }
    public interface ITaxCalculator
    {
        public decimal CalculateTax(decimal Price);
    }

    public class TaxCalculator : ITaxCalculator
    {
        ITax _taxService;
        public TaxCalculator(ITax taxService)
        {
            _taxService = taxService;
        }

        public decimal CalculateTax(decimal Price) { 
            return Price * _taxService.GetTaxRate(); 
        }
    }

    public class Item
    {
        public Item(double price, string name, string category)
        {
            Price = (decimal)price;
            Name = name;
            Category = category;
        }

        public decimal Price { get; }
        public string Name { get; }
        public string Category { get; }
    }

    public interface ISortShopItemsService
    {
        Item[] SortItems(Item[] items);
    }

    public class SortByName : ISortShopItemsService
    {
        public Item[] SortItems(Item[] items)
        {
            var lst = new List<Item>(items);
            lst.Sort((item1, item2) => item1.Name.CompareTo(item2.Name));
            return lst.ToArray();
        }
    }

    public class SortByCategory : ISortShopItemsService
    {
        public Item[] SortItems(Item[] items)
        {
            var lst = new List<Item>(items);
            lst.Sort((item1, item2) => item1.Category.CompareTo(item2.Category));
            return lst.ToArray();
        }
    }

    public class CashRegister
    {
        ITaxCalculator _taxCalculator;
        ISortShopItemsService _sortService;
        public CashRegister(ITaxCalculator taxCalculator, ISortShopItemsService sortService)
        {
            _taxCalculator = taxCalculator;
            _sortService = sortService;
        }


        public decimal CalculatePrice(Item[] Items)
        {
            decimal _price = 0;
            foreach (Item item in Items)
            {
                _price += item.Price + _taxCalculator.CalculateTax(item.Price);
            }
            return _price;
        }

        public void PrintBill(Item[] Items)
        {
            var items = _sortService.SortItems(Items);
            Console.WriteLine("---------------------------------------------------");
            foreach (var item in items)
                Console.WriteLine("kategoria {3} towar {0} : cena {1} + podatek {2}",
                    item.Name, item.Price, _taxCalculator.CalculateTax(item.Price), item.Category);
            Console.WriteLine("---------------------------------------------------");

        }
    }
    //---------------------------------------------------------------------------
    //zła implementacja
    //---------------------------------------------------------------------------
    public class TaxCalculator2
    {
        public decimal CalculateTax(decimal Price) { return Price * (decimal)0.22; }
    }
    public class CashRegister2
    {
        public TaxCalculator2 taxCalc = new TaxCalculator2();
        public decimal CalculatePrice(Item[] Items)
        {
            decimal _price = 0;
            foreach (Item item in Items)
            { 
                _price += item.Price + taxCalc.CalculateTax(item.Price);
            }
            return _price;
        }
        public void PrintBill(Item[] Items)
        {
            Console.WriteLine("-----------------------------------------");
            foreach (var item in Items)
                Console.WriteLine("towar {0} : cena {1} + podatek {2}",
                item.Name, item.Price, taxCalc.CalculateTax(item.Price));
            Console.WriteLine("-----------------------------------------");

        }
    }
}
