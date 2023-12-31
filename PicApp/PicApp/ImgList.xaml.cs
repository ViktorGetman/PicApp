﻿using PicApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImgList : ContentPage
    {
        public ObservableCollection<ImgModel> Photos {get; set; }

        public ImgList()
        {
            InitializeComponent();
            Photos = new ObservableCollection<ImgModel>();
            LoadDirectoryImg();
        }
        private void LoadDirectoryImg()
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
                        var img = new ImgModel()
                        {
                            Name= Path.GetFileName(file),
                            CreateDateTime= File.GetCreationTime(file),
                            ImagePath=file,
                        };
                        Photos.Add(img);
                    }

                    // Обновите отображение

                    ImgListView.ItemsSource = null;
                    ImgListView.ItemsSource = Photos;
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок выбора директории
                Console.WriteLine("Unable to pick directory: " + ex.Message);
            }
        }
        private void OnOpenClicked(object sender, EventArgs e)
        {
            try
            {
                var selectedPhoto = ImgListView.SelectedItem as ImgModel;

                if (ImgListView.SelectedItem == null)
                {
                    DisplayAlert("Ошибка", "Выберите картинку", "Ок");
                    return;
                }
                Navigation.PushAsync(new GalleryPage(selectedPhoto));

            }
            catch (Exception)
            {
                DisplayAlert("Ошибка", "Произошла непредвиденная ошибка", "Ок");
            }
        }

            private void OnDeleteClicked(object sender, EventArgs e)
        {
            try
            {
                var selectedPhoto = ImgListView.SelectedItem as ImgModel;
                if (ImgListView.SelectedItem == null)
                {
                    DisplayAlert("Ошибка", "Выберите картинку", "Ок");
                    return;
                }
                
                Photos.Remove(selectedPhoto);
                if (!File.Exists(selectedPhoto.ImagePath))
                {
                    return;
                }
                File.Delete(selectedPhoto.ImagePath);
            }
            catch (Exception) 
            {
                DisplayAlert("Ошибка", "Произошла непредвиденная ошибка", "Ок");
            }
        }
    }
}