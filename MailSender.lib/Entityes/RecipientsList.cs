using MailSender.lib.Entityes.Base;
using System.Collections.Generic;

namespace MailSender.lib.Entityes
{
    public class RecipientsList : NamedEntity
    {
        public ICollection<Recipient> Recipients { get; set; }
    }
}
