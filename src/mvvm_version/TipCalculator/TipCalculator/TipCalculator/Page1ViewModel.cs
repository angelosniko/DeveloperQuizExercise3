using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TipCalculator
{
   public class Page1ViewModel : ViewModelBase
    {

        private double _constvalue;
        private double _slidervalue;
        public List<KeyValuePair> NumberList { get; set; }

        public List<KeyValuePair> GetNumbers()
        {

            var keyvalue = new List<KeyValuePair>() {
            new KeyValuePair(){key=1,Value="1" },
            new KeyValuePair(){key=2,Value="2" },
            new KeyValuePair(){key=3,Value="3" },
            new KeyValuePair(){key=4,Value="4" },
            new KeyValuePair(){key=5,Value="5" },
            new KeyValuePair(){key=6,Value="6" },
             new KeyValuePair(){key=7,Value="7" },
              new KeyValuePair(){key=8,Value="8" },
               new KeyValuePair(){key=9,Value="9" },
                new KeyValuePair(){key=10,Value="10" }



            };

            return keyvalue;
        }
        public class KeyValuePair
        {
            public int key { get; set; }
            public String Value { get; set; }

        }

        public Page1ViewModel(double constvalue) {

            _constvalue = constvalue;
            NumberList = GetNumbers().OrderBy(a => a.key).ToList();

        }

        public string Text
        {
            get
            {
                    return (_constvalue * _slidervalue / 100).ToString();            
            }

            set
            {
                if (!string.IsNullOrEmpty(value)) {
                    var p = double.Parse(value);
                    var slidevalue = p / _constvalue * 100;
                    SliderValue = slidevalue;
                } 
                else { value="0"; }
            }
        }

        private KeyValuePair _selectItem;
        public KeyValuePair SelectectItem {

            get { 
                 
                return _selectItem; }

            set {
                if (_selectItem != value) {

                    _selectItem = value;
                    OnPropertyChanged(nameof(SelectectItem));
                    OnPropertyChanged(nameof(PriceValue));

                }
            
            }
        }


        public double PriceValue {


            get {
                var val = _constvalue * _slidervalue / 100;
                if (_selectItem != null)
                {

                    var val2 = Math.Round((val + _constvalue) / Convert.ToDouble(_selectItem.Value), 2); 
                    return val2;
                }
                else {


                    return 0;
                }
  

            }

            private set { 

            
            }
        }
        public double SliderValue
        {
            get { return _slidervalue; }
            set
            {
                _slidervalue = value;

                OnPropertyChanged(nameof(SliderValue));
                OnPropertyChanged(nameof(Text));
                OnPropertyChanged(nameof(PriceValue));

            }
        }
    }
}
