﻿using System;
using System.Threading;

namespace MailSender.ConsoleTest
{
    internal static class ThreadTests
    {
        public static void CheckThread()
        {
            var current_thread = Thread.CurrentThread;
            Console.WriteLine("Поток: \"{0}\"(id:{1}) запущен",
                current_thread.Name, current_thread.ManagedThreadId);
        }

        public static void Start()
        {
            Console.WriteLine($"Количество ядер: {Environment.ProcessorCount}");

            Thread current_thread = Thread.CurrentThread;
            current_thread.Name = "Главный поток";

            CheckThread();

            //System.Diagnostics.Process
            //var clock_thread = new Thread(new ThreadStart(ClockUpdater));
            var clock_thread = new Thread(ClockUpdater);
            clock_thread.Priority = ThreadPriority.Highest;
            clock_thread.Name = "Поток часов";
            clock_thread.IsBackground = true;
            clock_thread.Start();

            var message = "Hello world!";
            //var printer_thread = new Thread(new ParameterizedThreadStart(Printer));
            var printer_thread = new Thread(Printer);
            printer_thread.IsBackground = true;
            printer_thread.Name = "Поток принтера";
            //printer_thread.Start(message);

            var printer2_thread = new Thread(() => Printer(message));
            printer2_thread.Name = "Поток принтера 2";
            //printer2_thread.Start();

            var printer3 = new Printer3(message);
            var printer3_thread = new Thread(printer3.Print);
            printer3_thread.Name = "Поток принтера 3";
            printer3_thread.Start();

            Console.ReadLine();

            _IsClockEnable = false;
            if (!clock_thread.Join(200))
                clock_thread.Interrupt();

            //clock_thread.Abort();
            //clock_thread.Interrupt();
            //clock_thread.Join();

        }

        private static bool _IsClockEnable = true;

        private static void ClockUpdater()
        {
            CheckThread();

            try
            {
                while (_IsClockEnable)
                {
                    //Console.Title = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                    Console.Title = DateTime.Now.ToString("dd:MM:yyyy HH:mm:ss.ffff");

                    Thread.Sleep(100);
                }
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch(ThreadInterruptedException e)
            {
                Console.WriteLine(e);
                throw;
            }

            Console.WriteLine("Поток часов завершился");
        }

        private static void Printer(object obj)
        {
            CheckThread();

            var message = (string)obj;

            for (var i = 0; i < 20; i++)
            {
                Console.WriteLine("id:{0} - msg\"{1}\"", Thread.CurrentThread.ManagedThreadId, message);
                Thread.Sleep(100);
            }

            Console.WriteLine("Поток {0} завершен", Thread.CurrentThread.ManagedThreadId);
        }

        private static void Printer(string Message)
        {
            CheckThread();

            for (var i = 0; i < 20; i++)
            {
                Console.WriteLine("id:{0} - msg\"{1}\"", Thread.CurrentThread.ManagedThreadId, Message);
                Thread.Sleep(100);
            }

            Console.WriteLine("Поток {0} завершен", Thread.CurrentThread.ManagedThreadId);
        }
    }


    internal class Printer3
    {
        private string _Message;

        public Printer3(string Message) => _Message = Message;

        public void Print()
        {
            ThreadTests.CheckThread();

            for (var i = 0; i < 20; i++)
            {
                Console.WriteLine("id:{0} - msg\"{1}\"", Thread.CurrentThread.ManagedThreadId, _Message);
                Thread.Sleep(100);
            }

            Console.WriteLine("Поток {0} завершен", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
