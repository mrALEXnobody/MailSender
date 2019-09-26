using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender.Controls
{
    public partial class ListController
    {
        //public IEnumerable Items { get; set; }

        public static readonly DependencyProperty ItemsProperty 
            = DependencyProperty.Register();
        //0.40.39
        public ListController()
        {
            InitializeComponent();
        }
    }
}
