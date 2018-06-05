using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using TestProjectMobiele;
using System.Threading.Tasks;
using System.IO;
using Firebase.Storage;
using TestProjectMobiele.Contracts;
using Prism.Events;
using TestProjectMobiele.Data;

namespace TestProjectMobiele.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        //Gemaakt door Kaan Akpinar
        private ILoadAllData dataConnection;
        public ICommand ImageHomeClicked { get; private set; }
        public ICommand ImageSchoolClicked { get; private set; }

        public MainPageViewModel(INavigationService navigationService, IEventAggregator ea, ILoadAllData dataConnection) 
            : base (navigationService)
        {
            Title = "Klas applicatie";
            this.dataConnection = dataConnection;

            ImageHomeClicked = new DelegateCommand(() =>
            {
                NavigationService.NavigateAsync("LogInPage");
            });

            ImageSchoolClicked = new DelegateCommand(() =>
             {
                  NavigationService.NavigateAsync("FotosKleutersPage");
             });

            //Gemaakt door Daan Vandebosch
            try
            {
                Prefab();           
            }
            catch(Exception ex)
            {
                string x = ex.Message;
            }



            Task<List<Kleuter>> kl = dataConnection.LoadKleuters();
        }
       
        private async void Prefab()
        {
            LoadPreFab preFab = new LoadPreFab(dataConnection);
            preFab.SaveKleuters();
        }
    }
}
