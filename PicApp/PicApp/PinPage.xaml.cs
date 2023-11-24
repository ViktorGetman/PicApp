using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinPage : ContentPage
    {
        public PinPage()
        {
            InitializeComponent();

        }
        private void OnConfirmedClicked(object sender, EventArgs e)
        {
            string pinCode = pinEntry.Text;
            string originalPinCode = PinCodeManager.GetPinCode();
            if (originalPinCode == pinCode)
            {
                Navigation.PushAsync(new GalleryPage());

                return;
            }
                      

            DisplayAlert("Ошибка", "неверный пин-код", "Ok");

        }
    }
}