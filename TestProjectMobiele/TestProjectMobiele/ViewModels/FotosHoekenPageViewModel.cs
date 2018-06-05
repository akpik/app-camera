using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProjectMobiele.ViewModels
{
	public class FotosHoekenPageViewModel : ViewModelBase
	{
        LoadAllData dataConnection;
        Kleuter kleuter;
        IPageDialogService dialogService;
        public FotosHoekenPageViewModel(INavigationService navigationService, IPageDialogService dialogService, LoadAllData dataConnection) : base(navigationService)
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
        //public async override void OnNavigatedTo(NavigationParameters parameters)
        //{
        //    Hoeken = await dataConnection.LoadHoeken();
            //if (parameters.ContainsKey("kleuter"))
            //    {
            //        kleuter = (Kleuter) parameters["kleuter"];
            //Name = kleuter.Name;
            //    }

    //}
}
}
