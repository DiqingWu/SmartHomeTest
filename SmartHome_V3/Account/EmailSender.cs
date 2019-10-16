using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Windows.Forms;

namespace SmartHome_V3
{
    public class EmailSender
    {
        private SmtpClient SmtpServer;
        string email;
        public EmailSender()
        {
            SmtpServer = new SmtpClient(Constants.EmailServer);

            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Port = Constants.STMP_port; ;
            //SmtpServer.Credentials = new System.Net.NetworkCredential("smarthomepandaservice@gmail.com", "SmartPanda123");
            SmtpServer.Credentials = new System.Net.NetworkCredential(Constants.WorkEmail, Constants.WorkPassword);
            SmtpServer.EnableSsl = true;
        }
        public bool SendEmail(string email, int number) //"your_email_address@gmail.com"
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(email);
                mail.To.Add(email);
                mail.IsBodyHtml = true;
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL \nVerifiy numer is:" + number;
                //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public bool SendEmail(string email, string word) //"your_email_address@gmail.com"
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(email);
                mail.To.Add(email);
                mail.IsBodyHtml = true;
                mail.Subject = "Test Mail";
                mail.Body = "Your Password is: " + word;
                //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public static int VerifyNumberGenerator()
        {
            // make some random 4 digit number
            Random ran = new Random();
            return ran.Next(1000, 9999);
        }
    }
}
