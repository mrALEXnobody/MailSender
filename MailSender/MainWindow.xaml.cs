using MailSender.Controls;
using System;
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

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabItemsSwitcher_OnLeftButtonClick(object sender, EventArgs e)
        {
            if (!(sender is TabItemsSwitcher switcher)) return;

            if (MainTabControl.SelectedIndex == 0) return;

            MainTabControl.SelectedIndex--;

            if (MainTabControl.SelectedIndex == 0)
            {
                switcher.LeftButtonVisible = false;
            }
        }

        private void TabItemsSwitcher_OnRightButtonClick(object sender, EventArgs e)
        {
            if (!(sender is TabItemsSwitcher switcher)) return;

            var tab_count = MainTabControl.Items.Count;

            if (MainTabControl.SelectedIndex == tab_count - 1) return;

            MainTabControl.SelectedIndex++;

            if (MainTabControl.SelectedIndex == MainTabControl.Items.Count - 1)
            {
                switcher.RightButtonVisible = false;
            }
        }
    }
}
