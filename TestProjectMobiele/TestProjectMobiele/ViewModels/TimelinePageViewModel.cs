using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace TestProjectMobiele.ViewModels
{
	public class TimelinePageViewModel : ViewModelBase
	{
        IPageDialogService dialogService;
        LoadAllData dataConnection;
        
        public TimelinePageViewModel(INavigationService navigationService, IPageDialogService dialogService, LoadAllData dataConnection) : base(navigationService)
        {
            this.dataConnection = dataConnection;
            this.dialogService = dialogService;
        }
        private IList<Foto> fotos;
        public IList<Foto> Fotos
        {
            get { return fotos; }
            set { SetProperty(ref fotos, value); }
        }
        private IList<string> fotopaden;
        public IList<string> Fotopaden
        {
            get { return fotopaden; }
            set { SetProperty(ref fotopaden, value); }
        }
        //public async override void OnNavigatedTo(NavigationParameters parameters)
        //{
        //    Fotos = await dataConnection.LoadFotos();
        //    foreach(Foto f in Fotos)
        //    {
        //        if(f.FotoPad == "")
        //        {
        //            Fotopaden.Add(f.FotoPad);
        //        }
        //    }

        //}
    }
}
