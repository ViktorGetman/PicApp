using PicApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace PicApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GalleryPage : ContentPage
    {
        

        public GalleryPage(ImgModel photo)
        {
            InitializeComponent();

            ImageView.Source=photo.ImagePath;

            DateTimeLabel.Text= $"Дата создания фото: {photo.CreateDateTime}";

        }


    }
}