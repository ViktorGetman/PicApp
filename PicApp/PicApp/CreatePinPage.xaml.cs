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
                DisplayAlert("Ошибка", "Введите пинкод", "Ок");
                    
            }

            PinCodeManager.SavePinCode(pinCode);

            // Ваш код для сохранения пин-кода, например, в хранилище или на сервере.

            DisplayAlert("Сохранено", "Пин-код сохранен: " + pinCode, "ОК");

            Navigation.PushAsync(new PinPage());
        }

    }
}