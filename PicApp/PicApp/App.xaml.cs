using System;
using PicApp.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            string pinCode = PinCodeManager.GetPinCode();
            if(pinCode==null)
            {
                MainPage = new NavigationPage(new CreatePinPage());  
            }
            else
            {
                MainPage= new NavigationPage(new PinPage());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
