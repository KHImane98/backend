using API1.ViewModels;
using RazorEngine.Templating;
using System;
using System.Configuration;
using System.IO;
using System.Net.Mail;


namespace API1.Helpers
{
    public class EmailHelper
    {
        private static void Send(MailMessage email)
        {
            using (var client = new SmtpClient())
            {
                client.Send(email);
            }
        }
        [Obsolete]
        public static Tuple<string, bool> SendUserForgotPassword(string templatePath, UserEmailViewModel viewModel)
        {
            try
            {
                var templateService = new TemplateService();
                var emailHtmlBody = templateService.Parse(File.ReadAllText(templatePath), viewModel, null, null);
                var email = new MailMessage
                {
                    Body = emailHtmlBody.Replace("{Password}", viewModel.Password).Replace("{UserName}", viewModel.UserName),
                    IsBodyHtml = true,
                    Subject = viewModel.Subject,
                };
                email.To.Add(new MailAddress(viewModel.Email.Email, viewModel.Email.UserName));

                Send(email);

                return Tuple.Create("", true);
            }
            catch (Exception ex)
            {
                return Tuple.Create(ex.Message, false);
            }
        }

    }
}