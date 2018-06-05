using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using TestProjectMobiele.Contracts;
//Gemaakt door Kaan Akpinar
namespace TestProjectMobiele.ViewModels
{
	public class LogInPageViewModel : ViewModelBase
    {
        public ICommand LoginKnopGedrukt { get; private set; }
        ILoadAllData dataConnection;
        public string TekstVak { get; set; }
        
        public LogInPageViewModel(INavigationService navigationService, ILoadAllData dataConnection) : base(navigationService)
        {
            this.dataConnection = dataConnection;
            try
            {
                LoginKnopGedrukt = new DelegateCommand(() =>
                {
                    foreach(Gezin g in Gezinnen)
                    {
                        if (TekstVak.ToUpper() == g.GezinsCode)
                        {
                            //NavigationService.NavigateAsync("OudersMainPage");
                            var p = new NavigationParameters();
                            p.Add("gezin", g);
                            NavigationService.NavigateAsync("OudersMainPage", p);
                        }
                    }
                });
            }
            catch
            {

            }
        }
        private IList<Gezin> gezinnen;
        public IList<Gezin> Gezinnen
        {
            get { return gezinnen; }
            set { SetProperty(ref gezinnen, value); }
        }
        //test andreytfytfvsdvds
        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            Gezinnen = await dataConnection.LoadGezinnen();
        }
    }
}
