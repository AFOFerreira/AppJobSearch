using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Visualize : ContentPage
    {
        public Visualize()
        {
            InitializeComponent();
        }

        private void Go_Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}