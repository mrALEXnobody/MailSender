﻿using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;
using System.Linq;

namespace MailSender.lib.Services
{
    public class InMemorySendersDataProvider : InDataProvider<Sender>, ISendersDataProvider
    {
        public InMemorySendersDataProvider()
        {
            _Items.AddRange(Enumerable.Range(1, 10).Select(i => new Sender
            {
                Id = i,
                Name = $"Отправитель {i}",
                Address = $"sender{i}@server.com"
            }));
        }

        public override void Edit(int id, Sender item)
        {
            var db_item = GetById(id);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
        }
    }
}
