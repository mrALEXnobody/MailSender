using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// a. Первый — жестко заданные переменные в коде. 
// В строке new SmtpClient("smtp.yandex.ru", 25) таких две: "smtp.yandex.ru" — smtp-сервер и 25 — порт для него. 
// В коде много и других жестко заданных переменных: адреса почтовых ящиков, тексты писем, тексты ошибок и другое.

// Задание: добавить в проект WpfTestMailSender public static class без конструктора и методов.
// Определить в этом классе статические переменные и задать им значения. В коде использовать эти переменные вместо жестко заданных.

namespace MailSender.WPFTest
{
    public static class Server
    {
        public static string host = "smtp.mail.ru";
        public static int port = 25;
    }
}
