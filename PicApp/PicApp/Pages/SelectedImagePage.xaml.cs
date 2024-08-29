using PicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedImagePage : ContentPage
    {
        public SelectedImagePage(UserImage photo)
        {
            InitializeComponent();
            //ImageSource iS = ImageSource.FromFile(photo.FilePath);
            selimage.Source = photo.Image.Source;


        }

       private  async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}