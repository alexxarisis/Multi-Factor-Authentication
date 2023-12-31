using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace API.Models.Services.MFA
{
    public class EmailService : IMFAService
    {
        private readonly string host;
        private readonly int port;
        private readonly string username;
        private readonly string password;

        public EmailService()
        {
            var config = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").Build();

            host = config.GetSection("EmailService")["Host"];
            port = int.Parse(config.GetSection("EmailService")["TLSPort"]);
            username = config.GetSection("EmailService")["Username"];
            password = config.GetSection("EmailService")["Password"];
        }

        public void SendVerificationCode(string userEmail, int code)
        {
            var email = CreateEmail(userEmail, code);
            SendEmail(email);
        }

        private MimeMessage CreateEmail(string userEmail, int code)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(username));
            email.To.Add(MailboxAddress.Parse(userEmail));
            email.Subject = "Authorization Project - OTP!";
            email.Body = new TextPart(TextFormat.Plain)
            {
                Text = "Hi!\n\nThis is your new OTP: " + code
            };
            return email;
        }

        private void SendEmail(MimeMessage email)
        {
            try
            {
                using var smtp = new SmtpClient();
                smtp.Connect(host, port, MailKit.Security.SecureSocketOptions.Auto);
                smtp.Authenticate(username, password);
                smtp.Send(email);
                smtp.Disconnect(true);
            } catch (Exception) {
                throw;
            }
        }
    }
}
