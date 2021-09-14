using JobApp.Models;
using JobApp.Services;
using JobApp.Utility.Loading;
using JobSearch.domain.Models;
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
    public partial class RegisterJob : ContentPage
    {
        private JobService _service;
        public RegisterJob()
        {
            InitializeComponent();
            _service = new JobService();
        }

        private void Go_Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void Go_Send(object sender, EventArgs e)
        {
            //TODO - Adicionar Validação
            txtMessage.Text = string.Empty;
            User user = JsonConvert.DeserializeObject<User>(App.Current.Properties["User"].ToString());

            Job job = new Job()
            {
                Company = txtCompany.Text,
                JobTitle = txtJobTitle.Text,
                CityState = txtCityState.Text,
                ContractType = (rb_CLT.IsChecked)? "CLT":"PJ",
                InitialSalary = double.Parse(txtInitialSalaty.Text),
                FinalSalary = double.Parse(txtFinalSalary.Text),
                TecnologyTools = txtTecnologyTools.Text,
                CompanyDescription = txtCompanyDescription.Text,
                JoobDescription = txtJobDescription.Text,
                Benefits = txtBenefits.Text,
                EmailToSend = txtBenefits.Text,
                PublicationDate = DateTime.Now,
                UserId = user.Id

            };

            await Navigation.PushPopupAsync(new Loading());
            ResponseService<Job> responseService = await _service.AddJob(job);

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
            await Navigation.PopAsync();
        }
    }
}