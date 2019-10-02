﻿using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class InMemorySchedulerTasksDataProvider : InDataProvider<SchedulerTask>, ISchedulerTasksDataProvider
    {
        public override void Edit(int id, SchedulerTask item)
        {
            var db_item = GetById(id);
            if (db_item is null) return;

            db_item.Time = item.Time;
            db_item.Sender = item.Sender;
            db_item.Recipients = item.Recipients;
            db_item.Email = item.Email;
            db_item.Server = item.Server;
        }
    }
}
