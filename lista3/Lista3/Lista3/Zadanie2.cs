using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lista3
{
    class Zadanie2
    {
        //static void Main(string[] args)
        //{
        //    ReportPrinter rp = new ReportPrinter(
        //        new DataProvider(), //(*) wymagałoby zmiany, chcąc zmienić implementację
        //        new DataFormater(), 
        //        new Printer()
        //        );
        //    rp.PrintReport();

        //    //robiąc to zadanie nową implementację tworzyłem przy pomocy znajomej mi Dependency Inversion, co przy okazji załatwiło zadanie 7 
        //    //poprzednia implementacji wymagała od ReportPrintera, by wykonywał następujące operacje:
        //    //pobieranie danych, formatowanie danych, drukowanie danych, drukowanie reportu który sklada się z porpzednich akcji
        //    //narusza to SRP, ponieważ ReportPrinter miał 4 odpowiedzialności, które mogłyby ulec modyfikacji:
        //    //np dane można chcieć pobierać z innego źródła, sposób formatowania można zmienić, drukowanie danych może wymagać innej
        //    //konfiguracji z zewnętrznym urządzeniem
        //    //rozdzielając odpowiedzialności na 4 klasy, sprawiamy, że każda klasa ma własną odpowiedzialność
        //    //dodatkowo stosujemy DependencyInversion, przez co polegamy na abstrakcji, a nie na implemenctacji,
        //    //więc implementację można wymienić w każdym momencie, nie musząc wykonywać żadnych zmian w innych klasach (jedyna zmiana wymaga
        //    //podstawienia
        //    //obiektu implementującego interfejs w "klienckim kodzie" (*)
        //    //nie zawsze jednak refaktoryzacja kodu ze względu na zaburzone SRP spowoduje, że
        //    //będziemy musieli wyrzucić metody do innych klas, mogą istnieć metody, które współpracują z metodami w klasie (np prywatne metody)
        //    //trzeba rozsądnie podejść do refaktoryzacji i zastanowić się, które metody odpowiadają za wspólny cel, dopiero wtedy rozdzielić je
        //    //na poszczególne klasy z jedną odpowiedzialnością
        //}
    }

    public class ReportPrinterBad
    {
        private string Data;
        public string GetData()
        {
            return "Mock data some 1text Lorem I2psum Dolore3t sth sth";
        }
        public void FormatDocument()
        {
            var data = GetData();
            Data = Regex.Replace(data, @"\d", "");
        }
        public void PrintReport()
        {
            Console.WriteLine("Printing data started...");
            Console.WriteLine("Printing data finished");

        }
    }

    public class ReportPrinter
    {
        private readonly IDataProvider _dataProvider;
        private readonly IDataFormater _dataFormater;
        private readonly IPrinter _printer;
        public ReportPrinter(IDataProvider dprovider, IDataFormater dformater, IPrinter printer)
        {
            _dataFormater = dformater;
            _dataProvider = dprovider;
            _printer = printer;
        }

        public void PrintReport()
        {
            _printer.Print(_dataFormater.FormatData(_dataProvider.GetData()));
        }
    }

    public interface IDataProvider
    {
        string GetData();
    }

    public interface IDataFormater
    {
        string FormatData(string data);
    }

    public interface IPrinter
    {
        void Print(string data);
    }

    public class DataProvider : IDataProvider
    {
        public string GetData()
        {
            return "Very important business data";
        }
    }

    public class DataFormater : IDataFormater
    {
        public string FormatData(string data)
        {
            return data.ToUpper();
        }
    }

    public class Printer : IPrinter
    {
        public void Print(string data)
        {
            Console.WriteLine("Printing data...");
            Console.WriteLine("-------------------------------");
            Console.WriteLine(data); 
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Data printed successfully");
        }
    }
}
