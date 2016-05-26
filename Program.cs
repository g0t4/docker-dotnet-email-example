using System;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ConsoleApplication
{
    public class Program
    {
        static IConfigurationRoot _Config;

        public static void Main(string[] args)
        {
            _Config = new ConfigurationBuilder()
                .AddEnvironmentVariables("MAILER_")
                .Build();

            Console.WriteLine("Hello World!");

            var emailMessage = new MimeMessage();

            emailMessage.To.Add(new MailboxAddress("Wes Higbee", "wes@weshigbee.com"));
            emailMessage.From.Add(new MailboxAddress("Pax", "pax@weshigbee.com"));
            emailMessage.Subject = "Treats";
            emailMessage.Body = new TextPart("plain") { Text = "Please order more treats, we are out" };

            var emailTask = SendEmailAsync(emailMessage);
            Task.WaitAll(emailTask);
        }

        public static async Task SendEmailAsync(MimeMessage email)
        {
            using (var client = new SmtpClient())
            {
                client.LocalDomain = "weshigbee.com";
                var server = _Config["SMTP_SERVER_HOST"];
                Console.WriteLine("Connecting to SMTP server: " + server);
                var port = Convert.ToInt32(_Config["SMTP_SERVER_PORT"]);
                Console.WriteLine("on port: " + port);
                await client.ConnectAsync(server, port, SecureSocketOptions.None)
                    .ConfigureAwait(false);
                await client.SendAsync(email).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }

}
