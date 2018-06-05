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

namespace TestProjectMobiele.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ILoadAllData dataConnection;
        public ICommand ImageHomeClicked { get; private set; }
        public ICommand ImageSchoolClicked { get; private set; }
        public MainPageViewModel(INavigationService navigationService, ILoadAllData dataConnection) 
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
                Laad();
            }
            catch(Exception ex)
            {
               
            }
           

            

            //Task<List<Kleuter>> kl = dataConnection.LoadKleuters();
            //test(kl);
        }

        private async void Laad()
        {
            PreFab preFab = new PreFab();
            List<Kleuter> test = preFab.ReturnKleuters();
            int i;
            foreach (Kleuter k in test)
            {
                i = await dataConnection.SaveItemAsync(k);
            }
        }
       
        private async void test(Kleuter k)
        {
            await dataConnection.SaveItemAsync(k);
        }
    }
}
