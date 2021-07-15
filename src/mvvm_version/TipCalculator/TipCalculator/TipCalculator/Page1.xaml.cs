using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipCalculator;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tip_Splitter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public int value;

        public Page1(int value)
        {
            InitializeComponent();
            this.value = value;
      
            var vm = new Page1ViewModel(value);
            BindingContext = vm;

            


        }
        


   
    }
}