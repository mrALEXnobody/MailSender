using MailSender.lib.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.WPFTest1
{
    class MainWindowViewModel : ViewModel
    {
        private string title = "Заголовок окна";

        public string Title
        {
            get => title;
            set
            {
                if (title == value) return;
                title = value;
                //OnPropertyChanged(nameof(Title));
                //OnPropertyChanged("Title");
                //OnPropertyChanged("TitleLength");
                OnPropertyChanged();
                OnPropertyChanged(nameof(TitleLength));
            }
        }

        public int TitleLength => Title?.Length ?? 0;

        private int offsetX = 10;

        public int OffsetX
        {
            get => offsetX;
            set => Set(ref offsetX, value);
        }

        private int offsetY = 10;

        public int OffsetY
        {
            get => offsetY;
            set => Set(ref offsetY, value);
        }

        #region Angle : double - Угол поворота

        /// <summary>Угол поворота</summary>
        private double angle;

        /// <summary>Угол поворота</summary>
        public double Angle
        {
            get => angle;
            set => Set(ref angle, value);
        }

        #endregion
    }
}
