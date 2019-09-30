﻿using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MailSender.lib.Services
{
    public class InMemoryRecipientsDataProvider : IRecipientsDataProvider
    {
        private readonly List<Recipient> _Recipients = new List<Recipient>();

        public int Create(Recipient recipient)
        {
            if (_Recipients.Contains(recipient)) return recipient.Id;
            recipient.Id = _Recipients.Count == 0 ? 1 : _Recipients.Max(r => r.Id) + 1;
            _Recipients.Add(recipient);
            return recipient.Id;
        }

        public void Edit(int id, Recipient item)
        {
            var db_item = GetById(id);
            if (db_item is null) return;
            db_item.Name = item.Name;
            db_item.Address = item.Address;
        }

        public IEnumerable<Recipient> GetAll() => _Recipients;

        public Recipient GetById(int id) => _Recipients.FirstOrDefault(r => r.Id == id);

        public bool Remove(int id)
        {
            var db_item = GetById(id);
            return _Recipients.Remove(db_item);
        }

        public void SaveChanges() { }
    }
}
