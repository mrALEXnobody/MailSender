using GalaSoft.MvvmLight;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private RecipientsDataProvider _RecipientsProvider;

        private string windowTitle = "Рассыльщик почты v0.1";

        public string WindowTitle
        {
            get => windowTitle;
            set => Set(ref windowTitle, value);
        }

        public ObservableCollection<Recipient> Recipients { get; } = new ObservableCollection<Recipient>();

        public MainWindowViewModel(RecipientsDataProvider RecipientsProvider)
        {
            _RecipientsProvider = RecipientsProvider;

            RefreshData();
        }

        private void RefreshData()
        {
            var recipients = Recipients;
            recipients.Clear();
            foreach (var recipient in _RecipientsProvider.GetAll())
                recipients.Add(recipient);
        }
    }
}
