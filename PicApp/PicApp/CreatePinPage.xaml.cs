using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicApp.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatePinPage : ContentPage
    {

        public CreatePinPage()
        {
            InitializeComponent();

        }
        private void OnSaveClicked(object sender, EventArgs e)
        {
            string pinCode = pinEntry.Text;

            if(string.IsNullOrEmpty(pinCode))
            {
                DisplayAlert("Ошибка", "Введите пин-код", "Ок");
                    
                return;
            }
            if (pinCode.Length!=4)
            {
                DisplayAlert("Ошибка", "Пин-код должен состоять из четырех символов", "Ок");

                return;
            }

            PinCodeManager.SavePinCode(pinCode);

            // Ваш код для сохранения пин-кода, например, в хранилище или на сервере.

            DisplayAlert("Сохранено", "Пин-код сохранен", "ОК");

            pinEntry.Text = null;

            Navigation.PushAsync(new ImgList());
        }

    }
}