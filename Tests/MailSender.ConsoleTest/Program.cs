﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Потоки

            // ThreadTests.Start();

            //SynchronizationTests.Start();

            //ThreadPoolTests.Start();

            #endregion

            #region TPL

            //TPLTests.Start();

            #endregion

            //TaskTests.Start();

            //AsyncAwaitTests.Start();
            AsyncAwaitTests.StartAsync();

            Console.WriteLine("Главный поток завершён!");
            Console.ReadLine();
            Console.WriteLine("Программа завершена...");
        }

        
    }
}
