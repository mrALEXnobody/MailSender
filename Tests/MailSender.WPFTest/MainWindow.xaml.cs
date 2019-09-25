using System;
using System.Windows;
using System.Net.Mail;
using System.Security;
using System.Net;

namespace MailSender.WPFTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendButton_OnClick(object sender, RoutedEventArgs e)
        {
            var host = "smtp.mail.ru";
            var port = 25;

            var userName = UserNameEditor.Text;
            var password = PasswordEditor.SecurePassword;

            var msg = "Hello World!!! " + DateTime.Now.ToString();

            using (var client=new SmtpClient(host, port)) 
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(userName, password);

                using (var message=new MailMessage())
                {
                    message.From = new MailAddress("scorp_predateur@mail.ru", "Александр");
                    message.To.Add(new MailAddress("fun_account@mail.ru", "ALEX"));
                    message.Subject = "Заголовок письма от " + DateTime.Now.ToString();
                    message.Body = msg;
                    //message.Attachments.Add(new Attachment());

                    try
                    {
                        client.Send(message);
                        MessageBox.Show("Почта успешно отправлена", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            } 
        }
    }
}
