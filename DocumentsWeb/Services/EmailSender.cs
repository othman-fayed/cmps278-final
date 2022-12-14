using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace DocumentsWeb.Services
{
	public class EmailSender : IEmailSender
	{
		public async Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("CMPS278", "omf02@aub.edu.lb"));
			message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", email));
			message.Subject = subject;

			message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
			{
				Text = htmlMessage
			};

			using (var client = new SmtpClient())
			{
				await client.ConnectAsync("smtp-relay.sendinblue.com", 587, false);

				// Note: only needed if the SMTP server requires authentication
				await client.AuthenticateAsync("omf02@aub.edu.lb", "9c4pGmvJ7yh1UXWI");

				await client.SendAsync(message);
				await client.DisconnectAsync(true);
			}
		}
	}
}
