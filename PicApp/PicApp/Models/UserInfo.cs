using System.ComponentModel;

namespace PicApp.Models
{
    public class UserInfo : INotifyPropertyChanged
    {
        private int _pinCode = -100;
        public int PinCode
        {
            get => _pinCode;
            set
            {
                _pinCode = value;
                OnPropertyChanged("PinCode");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
