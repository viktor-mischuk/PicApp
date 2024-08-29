using Xamarin.Forms;
using PicApp.Pages;
using System.IO;

namespace PicApp
{
    public partial class App : Application
    {
        public App(string path)
        {
            InitializeComponent();
            var files = Directory.GetFiles(path);
            //MainPage = new MainPage();
            MainPage = new NavigationPage(new LoginPage(path));
            //MainPage = new NavigationPage(new ImagesPage(path));
            //MainPage = new SelectedImagePage();
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
