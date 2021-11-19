using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DarkComics.Helpers.Methods
{
    public static class MailOpertions
    {
        public static void SendMessage(string mail,string message)
        {

            var client = new SmtpClient();

            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("orkhanaib@code.edu.az", "Orxan620");

            var mailMessage = new System.Net.Mail.MailMessage("orkhanaib@code.edu.az", mail);

            mailMessage.Subject = "Security Code For Registration";
            mailMessage.Body = message;
            mailMessage.Priority = MailPriority.High;
            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;

            client.Send(mailMessage);

            client.Dispose();
            
        }

        //public static string[] ReadMessage(System.Net.Mail.MailMessage message)
        //{

        //    var mailRepository = new ImapClient("imap.gmail.com", "orkhanaib@code.edu.az", "Orxan620", AuthMethods.Login, 993, true);

        //    var emailList = mailRepository.Search(SearchCondition.Subject(message.Subject));

        //    return emailList;
        //}
    }
}
