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
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
        }

        private void SendButton_OnClick(object sender, RoutedEventArgs e)
        {
            var host = Server.host;
            var port = Server.port;

            var userName = UserNameEditor.Text;
            var password = PasswordEditor.SecurePassword;

            var msg = MailBody.Text + " " + DateTime.Now.ToString();

            using (var client=new SmtpClient(host, port)) 
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(userName, password);

                using (var message=new MailMessage())
                {
                    message.From = new MailAddress("scorp_predateur@mail.ru", "Александр");
                    message.To.Add(new MailAddress("fun_account@mail.ru", "ALEX"));
                    message.Subject = MailHeader.Text + " " + DateTime.Now.ToString();
                    message.Body = msg;
                    //message.Attachments.Add(new Attachment());

                    try
                    {
                        client.Send(message);
                        MessageBox.Show("Почта успешно отправлена", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    catch (Exception error)
                    {
                        WindowError we = new WindowError(error);
                        we.ShowDialog();
                        //MessageBox.Show(error.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            } 
        }
    }
}
