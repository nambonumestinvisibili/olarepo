using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ConsoleApp1
{
    public class SmtpFacade
    {
        public virtual void Send( 
            string from, 
            string to, 
            string subject, 
            string body, 
            Stream attachment, 
            string attachmentMimeType,
            string password
            )
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com") {
                Port = 587, Credentials = new NetworkCredential(from, password), EnableSsl = true
            };

            Attachment atm = new Attachment(attachment, attachmentMimeType);
            MailMessage msg = new MailMessage(from, to, subject, body);
            msg.Attachments.Add(atm);

            smtpClient.Send(msg);
            smtpClient.Dispose();
        }
    }
}
