using System.IO;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PicApp.Models;
using System.Collections.ObjectModel;

namespace PicApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagesPage : ContentPage
    {
        public ObservableCollection<UserImage> UserImages { get; set; } = new ObservableCollection<UserImage>();
        public UserImage SelectedUserImage { get; set; }
        string PhotoPath;
        private string _path;
        public ImagesPage(string path)
        {
            InitializeComponent();
            _path = path;
            GetImages(_path);

            BindingContext = this;  


        }

          void GetImages(string path)
        {
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                var userImage = new UserImage()
                    {
                        Image = new Image
                        {
                            Source = ImageSource.FromFile(Path.GetFullPath(Path.Combine(path, file)))
                        },
                        FileName = Path.GetFileName(file),
                    };

                UserImages.Add(userImage);
            }
        }

        private void DeviceList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            SelectedUserImage = e.Item as UserImage;
            
        }

 
        private async void OpenImage_Button_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SelectedImagePage(SelectedUserImage));
        }

        private void DeleteImage_Button_Clicked(object sender, System.EventArgs e)
        {
            UserImages.Remove(SelectedUserImage);
        }
    }
}