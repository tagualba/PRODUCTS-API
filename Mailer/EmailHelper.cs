using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Threading.Tasks;
using Email.Service.SmtpSetting;
using Email.Service.Entity;

namespace Email.Service
{
    public interface IMailer
    {
        Task SendEmailAsync(SendEmailEntity sendEmailEntity);
    }

    public class Mailer : IMailer
    {
        private readonly SmtpSettings _smtpSettings;
        private readonly IWebHostEnvironment _env;
        
        public Mailer(IOptions<SmtpSettings> smtpSetting, IWebHostEnvironment env)
        {
            _smtpSettings = smtpSetting.Value;
            _env = env;
        }

        public async Task SendEmailAsync(SendEmailEntity sendEmailEntity)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
                message.To.Add(new MailboxAddress(sendEmailEntity.NameEmail, sendEmailEntity.Email));
                message.Subject = sendEmailEntity.Subject;
                message.Body =  new TextPart("html")
                {
                    Text = sendEmailEntity.Body
                };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    if (_env.IsDevelopment())
                    {
                        await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                    }
                    else
                    {
                        await client.ConnectAsync(_smtpSettings.Server);
                    }
                    await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                
            }
            catch (Exception msg)
            {
                throw new InvalidOperationException(msg.Message) ;
            }
        } 
    }


}
