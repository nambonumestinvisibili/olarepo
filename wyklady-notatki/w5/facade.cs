using System;

namespace ConsoleApp
{

    public class SmtpClientFacade {
        public void Send(...){
            SmtpClient client = SmtpClient();
            MailMessage m = new MailMessage();
            client.Send(m);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            //klient korzysta z uproszczonego interfejsu
            //stworz se prosyszy obiekt
            new SmtpClientFacade();           


            //moze zrobic 
            IReadOnlyClient irc = new theObject();
            IReadWriteClient irwc = new theObject();
            //ale moze tez 
            theObject to = new theObject(); // niedobrze!

            //----->fabryka
            IReadOnlyClient irc = TheObjectFactory().CreateReadOnly();
            //klient nie utworzy sam juz theObject
        }
    }

    public interface IReadOnlyClient {
        int getData();
    }

    public interface IReadWriteClient {
        int getData();
        void setData(int data);
    }


    public class theObject : IReadOnlyClient, IReadWriteClient {
            //implementacja
    }

    public class TheObjectFactory {
        IReadOnlyClient Create() {
            //...
        }
    }
}