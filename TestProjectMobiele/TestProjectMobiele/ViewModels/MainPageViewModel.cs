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

namespace TestProjectMobiele.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private LoadAllData dataConnection;
        public ICommand ImageHomeClicked { get; private set; }
        public ICommand ImageSchoolClicked { get; private set; }
        public MainPageViewModel(INavigationService navigationService, LoadAllData dataConnection) 
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

            PreFab preFab = new PreFab();
            foreach(Kleuter k in preFab.ReturnKleuters())
            {
                dataConnection.SaveItemAsync(k);
            }
            Task<List<Kleuter>> kl = dataConnection.LoadKleuters();
            test(kl);
        }
       
        private async Task<int> test(Task<List<Kleuter>> k)
        {
            List<Kleuter> kleu = await k;
            foreach (Kleuter kl in kleu)
            {
                string x = kl.Naam;
            }
            return 0;
        }

    }
}
