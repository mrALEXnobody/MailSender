﻿using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MailSender.lib.Services
{
    public class InMemoryRecipientsDataProvider : InDataProvider<Recipient>, IRecipientsDataProvider
    {
        public override void Edit(int id, Recipient item)
        {
            var db_item = GetById(id);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
        }
    }
}