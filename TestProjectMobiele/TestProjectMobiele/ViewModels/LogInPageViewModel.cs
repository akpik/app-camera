using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace TestProjectMobiele.ViewModels
{
	public class LogInPageViewModel : ViewModelBase
    {
        public ICommand LoginKnopGedrukt { get; private set; }
        public string TekstVak { get; set; }
        public LogInPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            LoginKnopGedrukt = new DelegateCommand(() =>
            {
                
                if (TekstVak.ToUpper() == "OUDER")
                {
                    NavigationService.NavigateAsync("OudersMainPage");
                }
                else if (TekstVak.ToUpper() == "LERAAR")
                {
                    NavigationService.NavigateAsync("FotosKleutersPage");
                }
            });
        }
        //test andreytfytfvsdvds
    }
}
