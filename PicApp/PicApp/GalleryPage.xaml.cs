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
        public ObservableCollection<string> Photos { get; set; }

        public GalleryPage(List<ImgModel>)
        {
            InitializeComponent();

            // Пример заполнения коллекции фотографиями
            // ...
            Photos = new ObservableCollection<string>();
            photoCarouselView.ItemsSource = Photos;
        }

        // ...

        private void OnSelectDirectoryClicked(object sender, EventArgs e)
        {
            try
            {
                var result = "/storage/emulated/0/DCIM/Camera";

                ///"/storage/emulated/0/DCIM";

                if (result != null)
                {
                    // Обработка выбранной директории
                    string selectedDirectory = result;
                    // Загрузите все файлы из выбранной директории
                    var allFiles = Directory.GetFiles(selectedDirectory);

                    // Очистите текущую коллекцию фотографий
                    Photos.Clear();

                    // Добавьте все файлы в коллекцию
                    foreach (var file in allFiles)
                    {
                        Photos.Add(file);
                    }

                    // Обновите отображение

                    photoCarouselView.ItemsSource = null;
                    photoCarouselView.ItemsSource = Photos;
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок выбора директории
                Console.WriteLine("Unable to pick directory: " + ex.Message);
            }
        }
    }
}