﻿using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace MailSender.lib.Services
{
    public class Linq2SQLRecipientsDataProvider : IRecipientsDataProvider
    {
        private readonly Data.Linq2SQL.MailSenderDBDataContext _db;

        public Linq2SQLRecipientsDataProvider(Data.Linq2SQL.MailSenderDBDataContext db)
        {
            _db = db;
        }

        public IEnumerable<Recipient> GetAll() => _db.Recipient.ToArray().Select(r => new Recipient
        {
            Id = r.Id,
            Name = r.Name,
            Address = r.Address
        });
        
        public int Create(Recipient recipient)
        {
            if (recipient is null) throw new ArgumentNullException(nameof(recipient));
            if (recipient.Id != 0) return recipient.Id;

            var entity = new Data.Linq2SQL.Recipient
            {
                Name = recipient.Name,
                Address = recipient.Address
            };

            _db.Recipient.InsertOnSubmit(entity);
            SaveChanges();
            return recipient.Id;
        }

        public void SaveChanges() => _db.SubmitChanges();

        public Recipient GetById(int id)
        {
            var db_item = _db.Recipient.FirstOrDefault(r => r.Id == id);
            return db_item is null 
                ? null 
                : new Recipient
                {
                    Id = db_item.Id,
                    Name = db_item.Name,
                    Address = db_item.Address
                };
        }

        public void Edit(int id, Recipient item)
        {
            var db_item = _db.Recipient.FirstOrDefault(r => r.Id == id);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.Address = item.Address;

            SaveChanges();
        }

        public bool Remove(int id)
        {
            var db_item = _db.Recipient.FirstOrDefault(r => r.Id == id);
            if (db_item is null) return false;

            _db.Recipient.DeleteOnSubmit(db_item);
            SaveChanges();

            return true;
        }
    }
}
