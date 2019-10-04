﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    internal static class SynchronizationTests
    {
        private static readonly List<string> _Messages = new List<string>();

        public static void Start()
        {
            //var threads = new Thread[10];

            //for (var i = 0; i < threads.Length; i++)
            //{
            //    var i0 = i;
            //    threads[i] = new Thread(() => Printer($"Message {i0}"));
            //}

            //Array.ForEach(threads, thread => thread.Start());

            //Mutex mutex = new Mutex(true, "Имя мютекса");
            //mutex.WaitOne();
            //mutex.ReleaseMutex();

            //var semaphore = new Semaphore(0, 5, "Имя семафора");

            //semaphore.WaitOne();

            //// Критическая секция

            //semaphore.Release();

            //var manual_event = new ManualResetEvent(false);
            //var auto_event = new AutoResetEvent(false);

            //var test_threads = Enumerable
            //    .Range(0, 5)
            //    .Select(i => new Thread(
            //    () =>
            //    {
            //        Console.WriteLine("Поток {0} ожидает запуска...", Thread.CurrentThread.ManagedThreadId);
            //        auto_event.WaitOne();

            //        Console.WriteLine($"Поток {i}");
            //        Console.WriteLine("Поток {0} завершился", Thread.CurrentThread.ManagedThreadId);

            //        auto_event.Reset();
            //    })).ToArray();

            //foreach (var thread in test_threads)
            //    thread.Start();

            //Console.WriteLine("Потоки ожидают запуска...");
            //Console.ReadLine();

            //auto_event.Set();

            //Console.ReadLine();

            //auto_event.Set();

            //Console.ReadLine();

            //auto_event.Set();

            var concurent_dict = new ConcurrentDictionary<string, List<string>>();


        }

        private static readonly object _SyncRoot = new object();

        private static void Printer(string Message)
        {
            ThreadTests.CheckThread();

            for (var i = 0; i < 20; i++)
            {
                lock (_SyncRoot)
                //lock (_Messages)
                {
                    Console.Write("id:{0} ", Thread.CurrentThread.ManagedThreadId);
                    Console.Write("- msg({0}) ", i);
                    Console.WriteLine("\"{0}\"", Message);
                    _Messages.Add(Message);
                }
                Thread.Sleep(100);

                //try
                //{
                //    Monitor.Enter(_SyncRoot);

                //    Console.Write("id:{0} ", Thread.CurrentThread.ManagedThreadId);
                //    Console.Write("- msg({0}) ", i);
                //    Console.WriteLine("\"{0}\"", Message);
                //    _Messages.Add(Message);
                //}
                //finally
                //{
                //    if (Monitor.IsEntered(_SyncRoot))
                //        Monitor.Exit(_SyncRoot);
                //}
                //Thread.Sleep(100);
            }
            Console.WriteLine("Поток {0} завершен", Thread.CurrentThread.ManagedThreadId);
        }
    }

    [Synchronization]
    internal class Logger : ContextBoundObject
    {
        private string _FilePath;

        public string FilePath
        {
            get => _FilePath;
            set
            {
                if (!File.Exists(value))
                    throw new FileNotFoundException("Файл не существует", value);
                _FilePath = value;
            }
        }

        public Logger(string FilePath) => _FilePath = FilePath;

        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void Log(string Message)
        {
            //lock (this)
            File.AppendAllText(_FilePath, Message);
        }

    }


}
