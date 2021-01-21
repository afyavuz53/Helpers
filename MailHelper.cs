using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Ava.UI.Helpers
{
    public class MailHelper
    {
        public static bool SendContact(ContactVM contact)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add("gönderilecekMail");
            msg.Subject = "Ava.com";
            msg.IsBodyHtml = true;
            msg.Body = string.Format("<!DOCTYPE html>< html >< head >< title > Ava.com </ title ></ head >< body >< p > İsim: {0}</ p >< p > E - Mail: {1}</ p >< p > Mesajı: {2}</ p ></ body ></ html > ",contact.Name,contact.Email,contact.Message);
            msg.From = new MailAddress("Gönderen mail", "Gösterilecek ad");

            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            NetworkCredential network = new NetworkCredential("gönderen mail", "şifre");
            client.Credentials = network;
            try
            {
                client.Send(msg);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
