﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MailSender.WPFTest
{
    /// <summary>
    /// Логика взаимодействия для WindowError.xaml
    /// </summary>
    public partial class WindowError : Window
    {
        public WindowError(Exception exeption)
        {
            InitializeComponent();

            this.Title = "Ошбка!";

            ExceptionError.Content = exeption.ToString();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}