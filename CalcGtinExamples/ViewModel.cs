using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CalcGtinExamples
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region Public and private fields and properties

        private string _ean;
        public string Ean
        {
            get => _ean;
            set
            {
                _ean = value;
                EanLength = _ean.Length;
                EanIsValid = _ean.Length == 13 ? "EAN is valid" : "EAN is invalid";
                OnPropertyRaised();
            }
        }

        private string _eanIsValid;
        public string EanIsValid
        {
            get => _eanIsValid;
            set
            {
                _eanIsValid = value;
                OnPropertyRaised();
            }
        }

        private int _eanLength;
        public int EanLength
        {
            get => _eanLength;
            set
            {
                _eanLength = value;
                OnPropertyRaised();
            }
        }

        private string _gtin;
        public string Gtin
        {
            get => _gtin;
            set
            {
                _gtin = value;
                GtinLength = _gtin.Length;
                OnPropertyRaised();
            }
        }

        private string _gtinIsValid;
        public string GtinIsValid
        {
            get => _gtinIsValid;
            set
            {
                _gtinIsValid = value;
                OnPropertyRaised();
            }
        }

        private int _gtinLength;
        public int GtinLength
        {
            get => _gtinLength;
            set
            {
                _gtinLength = value;
                OnPropertyRaised();
            }
        }

        #endregion

        #region Constructor and destructor

        public ViewModel()
        {
            Setup();
        }

        public void Setup()
        {
            Ean = "0000000000000";
            Gtin = string.Empty;
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyRaised([CallerMemberName] string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

        #endregion

        #region Public and private methods

        public void SetEan()
        {
            if (Ean.Equals("0000000000000"))
                Ean = "4002515289693";
            else if (Ean.Equals("4002515289693"))
                Ean = "4607100235866";
            else if (Ean.Equals("4607100235866"))
                Ean = "4607100235859";
            else if (Ean.Equals("4607100235859"))
                Ean = "4607100235408";
            else if (Ean.Equals("4607100235408"))
                Ean = "4607100234333";
        }

        public void ClearEan()
        {
            Ean = "0000000000000";
        }

        #endregion
    }
}
