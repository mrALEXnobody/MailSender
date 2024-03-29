﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IRecipientsDataProvider _RecipientsProvider;
        //1.11.00
        private string windowTitle = "Рассыльщик почты v0.1";

        public string WindowTitle
        {
            get => windowTitle;
            set => Set(ref windowTitle, value);
        }

        private ObservableCollection<Recipient> _Recipients = new ObservableCollection<Recipient>();

        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            set => Set(ref _Recipients, value);
        }

        #region SelectedRecipient : Recipient - Выбранный получатель

        /// <summary>Выбранный получатель</summary>
        private Recipient _SelectedRecipient;

        /// <summary>Выбранный получатель</summary>
        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }
        #endregion

        public ICommand RefreshDataCommand { get; }

        public ICommand SaveChangesCommand { get; }

        public MainWindowViewModel(IRecipientsDataProvider RecipientsProvider)
        {
            _RecipientsProvider = RecipientsProvider;

            RefreshDataCommand = new RelayCommand(OnRefreshDataCommandExecute, CanRefreshDataCommandExecute);
            SaveChangesCommand = new RelayCommand(OnSaveChangesCommandExecute);

            if (IsInDesignMode)
            {
                Recipients.Add(new Recipient { Id = 1, Name = "Recipient 1", Address = "recipient1@server.com" });
                Recipients.Add(new Recipient { Id = 2, Name = "Recipient 2", Address = "recipient2@server.com" });
            }
        }

        private void OnSaveChangesCommandExecute()
        {
            _RecipientsProvider.SaveChanges();
        }

        private bool CanRefreshDataCommandExecute() => true;

        private void OnRefreshDataCommandExecute()
        {
            RefreshData();
        }

        private void RefreshData()
        {
            var recipients = new ObservableCollection<Recipient>();
            foreach (var recipient in _RecipientsProvider.GetAll())
                recipients.Add(recipient);
            Recipients = null;
            Recipients = recipients;
        }
    }
}
