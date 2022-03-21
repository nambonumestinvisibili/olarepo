using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    public class SmtpFacadeProxy : SmtpFacade
    {


        private readonly TimeSpan _start = new TimeSpan(8, 0, 0);
        private readonly TimeSpan _end = new TimeSpan(22, 0, 0);

        public SmtpFacadeProxy()
        {
           
        }

        private void EnsureTimeOk()
        {
            TimeSpan now = DateTime.Now.TimeOfDay;
            if (!(now > _start && now < _end))
            {
                throw new Exception("Cannot access between 22-8");
            }
        }

        public override void Send(string from, string to, string subject, string body, Stream attachment, string attachmentMimeType, string password)
        {
            EnsureTimeOk();
            base.Send(from, to, subject, body, attachment, attachmentMimeType, password);
        }
    }

    public class SmtpFacadeLoggingProxy : SmtpFacade
    {

        
        public SmtpFacadeLoggingProxy()
        {
        }

        public override void Send(string from, string to, string subject, string body, Stream attachment, string attachmentMimeType, string password)
        {
            string now = DateTime.Now.ToString();
            
            Console.WriteLine("DATE OF EXECUTION:\t" + now);
            Console.WriteLine("Method: Send");
            Console.WriteLine("PARAMETERS:");
            Console.WriteLine("\t FROM: " + from);
            Console.WriteLine("\t TO:" + to);
            Console.WriteLine("\t SUBJECT:" + subject);
            Console.WriteLine("\t BODY:" + body);
            if (attachment != null)
                Console.WriteLine("\t ATTATCHMENT:" + attachment.ToString());
            Console.WriteLine("\t ATTACHMENT MIME TYPE:" + attachmentMimeType);

            Console.WriteLine();

            try
            {
                base.Send(from, to, subject, body, attachment, attachmentMimeType, password);

                now = DateTime.Now.ToString();
                Console.WriteLine("DATE OF EXECUTION:\t" + now);
                Console.WriteLine("RETURNED: void");
                Console.WriteLine("Thrown no exceptions");
            }
            catch (Exception) {

                now = DateTime.Now.ToString();
                Console.WriteLine("DATE OF EXECUTION:\t" + now);
                Console.WriteLine("Exceptions have been thrown");
            }
        }
    }
}
