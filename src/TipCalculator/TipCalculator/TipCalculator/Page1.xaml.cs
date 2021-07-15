using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
           
           
        }

        private void PercentSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Slider_Label.Text = PercentSlider.Value.ToString()+"%";
            
            calculate();
            picker_SelectedIndexChanged(sender, e);
        




        }


        private void calculate() {
            
            var tipprice = (PercentSlider.Value * value) / 100;
           
            TipLabel.Text = String.Format("{0:0.00}", tipprice.ToString());

        }

        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var get = picker.Items[picker.SelectedIndex];
                var pp = Convert.ToDouble(get);
                var tipprice = (PercentSlider.Value * value) / 100;
                var PricePerPersonValue = Math.Round((value + tipprice) / pp,2);
                PricePerPerson.Text =  String.Format("{0:0.00}", PricePerPersonValue.ToString());
                
                calculate();


                

            }
            catch {  DisplayAlert("Alert","Please select number of people","OK"); }
       
        }

        private void TipLabel_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(TipLabel.Text))
            {
                Slider_Label.Text = "0";
                PercentSlider.Value = 0;





            }
            else {
                var parse = double.Parse(TipLabel.Text);
                var valParse = (parse / value) * 100;
                
                Slider_Label.Text = String.Format("{0:0.00}", valParse.ToString())+"%";
                PercentSlider.Value = valParse;

            }
           

        }
    }
}