using PicApp.Models;
using System;
using System.Collections.Specialized;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PicApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private string _path;
        public UserInfo UserInfo { get; set; }
        public string InviteMessage = String.Empty;
        public LoginPage(string path)
        {
            InitializeComponent();
            _path = path;
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            if (App.Current.Properties.TryGetValue("CurrentUser", out object user))
            {
                UserInfo = user as UserInfo;
                PinCodeEntry.Placeholder = "Введите пин-код";
            }
            else
            {
                UserInfo = new UserInfo();
                PinCodeEntry.Placeholder = "Установите пин-код";
                App.Current.Properties.Add("CurrentUser", UserInfo);
            }
            base.OnAppearing();
        }


        private async void loginButton_Clicked(object sender, EventArgs e)
        {
            if (PinCodeEntry.Text is null)
            {
                PinCodeEntry.Placeholder = "Введите пин-код";
                PinCodeEntry.PlaceholderColor = Color.Red;
                return;
            }

            if (IsDigit(PinCodeEntry.Text))
            {
                int pincode = Int32.Parse(PinCodeEntry.Text);

                if(UserInfo.PinCode == -100)
                {
                    UserInfo.PinCode = pincode;
                    await Navigation.PushAsync(new ImagesPage(_path));
                }
                else if(UserInfo.PinCode == pincode)
                {
                    await Navigation.PushAsync(new ImagesPage(_path));
                }

                PinCodeEntry.Text = String.Empty;
            }
        }
        private bool IsDigit(string str)
        {
            bool res = true;
            str.ForEach(x =>
            {
                if (!Char.IsDigit(x)) res = false;
            });
            return res;
        }
    }
}