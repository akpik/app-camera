using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using TestProjectMobiele.Contracts;

namespace TestProjectMobiele.ViewModels
{
	public class FotosHoekenPageViewModel : ViewModelBase
	{
        Kleuter kleuter;
        ILoadAllData dataConnection;
        private IPageDialogService dialogService;
        public FotosHoekenPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ILoadAllData dataConnection) : base(navigationService)
        {
            this.dataConnection = dataConnection;
            this.dialogService = dialogService;
        }
        private IList<Hoek> hoeken;
        public IList<Hoek> Hoeken
        {
            get { return hoeken; }
            set { SetProperty(ref hoeken, value); }
        }
        private Hoek selectedItem;
        public Hoek SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (SetProperty(ref selectedItem, value) && selectedItem != null)
                {
                    var p = new NavigationParameters();
                    p.Add("hoek", SelectedItem);
                    p.Add("kleuter", kleuter);
                    NavigationService.NavigateAsync("KleuterFotoTrekkenPage", p);
                    SelectedItem = null;
                }
            }
        }
        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            Hoeken = await dataConnection.LoadHoeken();
            if (parameters.ContainsKey("kleuter"))
            {
                kleuter = (Kleuter)parameters["kleuter"];
            }
            await dialogService.DisplayAlertAsync("Geselecteerde kleuter", kleuter.Naam +" " +kleuter.VoorNaam, "OK");

        }
    }
}
