using JobApp.Models;
using JobApp.Services;
using JobSearch.domain.Models;
using JobSearchDomain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Start : ContentPage
    {
        private JobService _service;
        private ObservableCollection<Job> _listOfJobs;
        private SearchParams searchParams;
        private int _listOfJobsFirstRequest;
        public Start()
        {
            InitializeComponent();
            _service = new JobService();
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

        private async void Search(object sender, EventArgs e)
        {
            string word = txtPesquisa.Text;
            string cityState = txtCidade.Text;

            searchParams = new SearchParams() { Word = word, CityState = cityState, NumberOfPage = 1 };

            ResponseService<List<Job>> responseService = await _service.GetJobs(searchParams.Word, searchParams.CityState, searchParams.NumberOfPage);

            if (responseService.IsSuccess)
            {
                //Colocar dentro da colection view
                _listOfJobs = new ObservableCollection<Job>(responseService.Data);
                _listOfJobsFirstRequest = _listOfJobs.Count;
                ListOfJobs.ItemsSource = _listOfJobs;
                ListOfJobs.RemainingItemsThreshold = 1;
            }
            else
            {
                await DisplayAlert("Erro!", "Oops! Ocorreu em erro inesperado! Tente novamente mais tarde!", "OK");
            }
        }

        private async void InfinitySearch(object sender, EventArgs e)
        {
            ListOfJobs.RemainingItemsThreshold = -1;
            searchParams.NumberOfPage++;

            //TODO: BUG - MANTER AS PALAVRAS PESQUISADAS INICIALMENTE
            string word = txtPesquisa.Text;
            string cityState = txtCidade.Text;

            ResponseService<List<Job>> responseService = await _service.GetJobs(searchParams.Word, searchParams.CityState, searchParams.NumberOfPage);

            if (responseService.IsSuccess)
            {
                //Colocar dentro da colection view
                var listTemp = responseService.Data;
                foreach(var item in listTemp)
                {
                    _listOfJobs.Add(item);
                }               
                if(_listOfJobsFirstRequest == listTemp.Count)
                {
                    ListOfJobs.RemainingItemsThreshold = 0;
                }
                else
                {
                    ListOfJobs.RemainingItemsThreshold = -1;
                }
            }
            else
            {
                await DisplayAlert("Erro!", "Oops! Ocorreu em erro inesperado! Tente novamente mais tarde!", "OK");
                ListOfJobs.RemainingItemsThreshold = 0;
            }
        }
    }
}