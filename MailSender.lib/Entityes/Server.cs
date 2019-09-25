﻿namespace MailSender.lib.Entityes
{
    public class Server
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int Port { get; set; } = 25;

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Description { get; set; }

    }

}
