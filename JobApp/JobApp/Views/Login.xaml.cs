using JobApp.Models;
using JobApp.Services;
using JobApp.Utility.Loading;
using JobSearch.domain.Models;
using JobSearchDomain.Models;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private UserService userService;
        public Login()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void btn_Register(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }

        private async void btn_Start(object sender, EventArgs e)
        {
            string email = Email.Text;
            string password = Senha.Text;

            await Navigation.PushPopupAsync(new Loading());
            ResponseService<User> responseService = await userService.GetUser(email, password);

            if (responseService.IsSuccess)
            {

                App.Current.Properties.Add("User", JsonConvert.SerializeObject(responseService.Data));
                await App.Current.SavePropertiesAsync();
                App.Current.MainPage = new NavigationPage(new Start());
            }
            else
            {
                if (responseService.StatusCode == 404)
                    await DisplayAlert("Erro!", "Nenhum usuário encontrado!", "OK");
                else
                    await DisplayAlert("Erro!", "Oops! Ocorreu em erro inesperado! Tente novamente mais tarde!", "OK");
            }
            await Navigation.PopAllPopupAsync();
        }
    }
}