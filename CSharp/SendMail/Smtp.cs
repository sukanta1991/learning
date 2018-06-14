using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace mailApp
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new System.Net.Mail.MailAddress("from@mail.com");
            msg.To.Add("from@mail.com");
            msg.CC.Add("cc@mail.com");
            msg.Subject = "subText";
            msg.Body = "BodyText";
          //  msg.Attachments.Add(new System.Net.Mail.Attachment(@"F:/directory/file.ext"));
            System.Net.Mail.SmtpClient SmtpMail = new System.Net.Mail.SmtpClient("194.12.7.64"); //smtp mail server

            // Send mail
            SmtpMail.Send(msg);
        }
    }
}
