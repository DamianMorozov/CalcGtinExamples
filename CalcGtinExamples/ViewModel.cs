using System;
using System.ComponentModel;
using System.Linq;
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

        public int GetEanCheckDigitV1(string code)
        {
            int sum = 0;
            int evenSum = 0;
            int currentDigit = 0;
            for (var pos = 0; pos <= 12; ++pos)
            {
                int.TryParse(code[pos].ToString(), out currentDigit);
                if (pos % 2 == 0)
                    evenSum += currentDigit;
                else
                    sum += currentDigit;
            }

            sum += 3 * evenSum;
            int.TryParse(code[13].ToString(), out currentDigit);
            //var isValid = (10 - (sum % 10)) % 10 == currentDigit;
            return (10 - (sum % 10)) % 10;
        }

        public int GetEanCheckDigitV2(string ean)
        {
            var sum = 0;
            var digit = 0;
            // Calculate the checksum digit here.
            for (var i = ean.Length; i >= 1; i--)
            {
                digit = Convert.ToInt32(ean.Substring(i - 1, 1));
                // This appears to be backwards but the 
                // EAN-13 checksum must be calculated
                // this way to be compatible with UPC-A.
                if (i % 2 == 0)
                { 
                    // odd  
                    sum += digit * 3;
                }
                else
                { 
                    // even
                    sum += digit * 1;
                }
            }
            return (10 - sum % 10) % 10;
        }

        public int GetGtinCheckDigitV1(string code)
        {
            var sum = 0;
            for (var i = 0; i < code.Length; i++)
            {
                var n = int.Parse(code.Substring(code.Length - 1 - i, 1));
                sum += i % 2 == 0 ? n * 3 : n;
            }
            return sum % 10 == 0 ? 0 : 10 - sum % 10;
        }

        public int GetGtinCheckDigitV2(string code)
        {
            var sum = 0;
            var list = code.Reverse().ToArray();
            for (var i = 0; i < list.Length; i++)
            {
                var n = (int)Char.GetNumericValue(list[i]);
                sum += i % 2 == 0 ? n * 3 : n;
            }
            return sum % 10 == 0 ? 0 : 10 - sum % 10;
        }

        public int GetGtinCheckDigitV3(string code)
        {
            var sum = code.Reverse().Select((c, i) => (int)char.GetNumericValue(c) * (i % 2 == 0 ? 3 : 1)).Sum();
            return (10 - sum % 10) % 10;
        }

        public string GetGtin(string code, EnumGtinVariant gtinVariant)
        {
            if (code.Length != 13)
                return string.Empty;
            switch (gtinVariant)
            {
                case EnumGtinVariant.Var2:
                    return $"{code}{GetGtinCheckDigitV2(code)}";
                case EnumGtinVariant.Var3:
                    return $"{code}{GetGtinCheckDigitV3(code)}";
            }
            return $"{code}{GetGtinCheckDigitV1(code)}";
        }

        #endregion
    }

    public enum EnumGtinVariant
    {
        Var1,
        Var2,
        Var3,
    }
}
