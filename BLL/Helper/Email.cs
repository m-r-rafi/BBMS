using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace BLL.Helper
{
    public class Email
    {
        public static bool SendEmail(string To, string subject, string body)
        {
            MailMessage message = new MailMessage();
            try
            {
                message.From = new MailAddress("rahmanrafi254@gmail.com");
                message.Subject = subject;
                message.To.Add(new MailAddress(To));
                message.Body = "<html><body> " + body + " </body></html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("rahmanrafi254@gmail.com", "liekyeeohidtgiib"),
                    EnableSsl = true,
                };

                smtpClient.Send(message);
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }
    }
}