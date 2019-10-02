﻿using MailSender.lib.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data
{
    public static class TestData
    {

        public static List<Server> Servers { get; } = new List<Server>
        {
            new Server { Id = 1, Name = "Mail", Host = "smtp.mail.ru", UserName = "UserName", Password = "Pass" },
            new Server { Id = 2, Name = "Yandex", Host = "smtp.yandex.ru", UserName = "UserName", Password = "Pass" },
            new Server { Id = 3, Name = "Gmail", Host = "smtp.gmail.com", Port = 465, UserName = "UserName", Password = "Pass" },
        };

        public static List<Sender> Senders { get; } = new List<Sender>
        {
            new Sender { Id = 1, Name = "Иванов", Address = "ivanov@yandex.ru" },
            new Sender { Id = 2, Name = "Петров", Address = "petrov@yandex.ru" },
            new Sender { Id = 3, Name = "Сидоров", Address = "sidorov@yandex.ru" }
        };

    }
}
