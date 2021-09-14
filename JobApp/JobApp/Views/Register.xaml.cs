using JobApp.Models;
using JobApp.Services;
using JobApp.Utility.Loading;
using JobSearchDomain.Models;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        private UserService userService;
        public Register()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void Go_Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void SaveAction(object sender, EventArgs e)
        {
            txtMessage.Text = string.Empty;
            string name = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;


            User user = new User() { Name = name, Email = email, Password = password };

            await Navigation.PushPopupAsync(new Loading());
            ResponseService<User> responseService = await userService.AddUser(user);

            if (responseService.IsSuccess)
            {

                App.Current.Properties.Add("User", JsonConvert.SerializeObject(responseService.Data));
                await App.Current.SavePropertiesAsync();
                App.Current.MainPage = new NavigationPage(new Start());
            }
            else
            {
                if (responseService.StatusCode == 400)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var dicKey in responseService.Errors)
                    {
                        foreach (var message in dicKey.Value)
                        {
                            sb.AppendLine(message);
                        }
                    }
                    txtMessage.Text = sb.ToString();

                }
                else
                    await DisplayAlert("Erro!", "Oops! Ocorreu em erro inesperado! Tente novamente mais tarde!", "OK");
            }
            await Navigation.PopAllPopupAsync();
        }
    }
}