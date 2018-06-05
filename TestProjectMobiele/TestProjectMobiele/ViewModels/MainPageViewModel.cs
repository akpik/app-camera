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
using TestProjectMobiele.Events;
using TestProjectMobiele.Data;

namespace TestProjectMobiele.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
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

            try
            {
                Prefab();           
            }
            catch(Exception ex)
            {
                string x = ex.Message;
            }



            Task<List<Kleuter>> kl = dataConnection.LoadKleuters();
            test(kl);
        }
       
        private async void Prefab()
        {
            LoadPreFab preFab = new LoadPreFab(dataConnection);
            preFab.SaveKleuters();
            
            //Kleuter k1 = new Kleuter
            //{
            //    Naam = "Daan123",
            //    VoorNaam = "Vancebosch",
            //};
            //i = await dataConnection.SaveItemAsync(k1);
            //Kleuter k2 = new Kleuter
            //{
            //    Naam = "Kaan123",
            //    VoorNaam = "Akpinar",
            //};
            //i = await dataConnection.SaveItemAsync(k2);

            //foreach (Kleuter k in test)
            //{
            //    int i = await dataConnection.SaveItemAsync(k);
            //}
        }
        private async void test(Task<List<Kleuter>> lijst)
        {
            List <Kleuter> kleuters = await lijst;
            foreach(Kleuter k in kleuters)
            {
                string x = k.VoorNaam + " " + k.Naam;
            }
        }
    }
}
