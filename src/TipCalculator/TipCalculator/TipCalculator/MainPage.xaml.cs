using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tip_Splitter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }



        private void MyButton_Clicked(object sender, EventArgs e)
        {
            var price = int.Parse(NameTextBox.Text);

            Application.Current.Properties["Name"] = NameTextBox.Text;
            Navigation.PushAsync(new Page1(price));

        }
    }
}
