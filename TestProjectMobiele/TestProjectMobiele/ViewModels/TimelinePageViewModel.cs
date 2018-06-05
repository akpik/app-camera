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
        Gezin gezin;
        Kleuter kleuter;
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
        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("gezin"))
            {
                gezin = (Gezin)parameters["gezin"];
            }
            await dialogService.DisplayAlertAsync("GezinsId", ""+gezin.GezinsID, "OK");
            foreach (Kleuter k in await dataConnection.LoadKleuters())
            {
                if(k.GezinsID == gezin.GezinsID)
                {
                    kleuter = k;
                }
            }
            string fotop = "";
            foreach (Foto f in await dataConnection.LoadFotos())
            {
                if (f.KleuterID == kleuter.KleuterID)
                {
                    Fotopaden.Add(f.FotoPad);
                    fotop += f.FotoPad;
                }
            }
            await dialogService.DisplayAlertAsync("Alle Fotopaden van dit gezin", fotop, "OK");

        }
    }
}
