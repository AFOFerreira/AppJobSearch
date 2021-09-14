using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Start : ContentPage
    {
        public Start()
        {
            InitializeComponent();
        }

        private void btn_Visualize(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Visualize());
        }

        private void btn_RegisterJob(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterJob());
        }

        private void FocusPesquisa(object sender, EventArgs e)
        {
            txtPesquisa.Focus();
        }

        private void FocusCidade(object sender, EventArgs e)
        {
            txtCidade.Focus();
        }

        private void btn_Logout(object sender, EventArgs e)
        {
            App.Current.Properties.Remove("User");
            App.Current.SavePropertiesAsync();
            App.Current.MainPage = new Login();
        }
    }
}