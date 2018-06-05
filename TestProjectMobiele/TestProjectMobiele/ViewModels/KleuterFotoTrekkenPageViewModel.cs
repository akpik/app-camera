using Plugin.Media;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using TestProjectMobiele.Contracts;
using Xamarin.Forms;

namespace TestProjectMobiele.ViewModels
{
	public class KleuterFotoTrekkenPageViewModel : ViewModelBase
	{
        Kleuter kleuter;
        Hoek hoek;
        ILoadAllData dataConnection;
        private IPageDialogService dialogService;
        public KleuterFotoTrekkenPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ILoadAllData dataConnection) : base(navigationService)
        {
            this.dataConnection = dataConnection;
            this.dialogService = dialogService;
            TakePhotoCommand = new DelegateCommand(ExecuteTakePhotoCommand);
        }
        public ICommand TakePhotoCommand { get; private set; }
        private ImageSource source;
        public ImageSource Source
        {
            get { return source; }
            set { SetProperty(ref source, value); }
        }
        private async void ExecuteTakePhotoCommand()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await dialogService.DisplayAlertAsync("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            await dialogService.DisplayAlertAsync("File Location", file.Path, "OK");

            Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }
        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("kleuter"))
            {
                kleuter = (Kleuter)parameters["kleuter"];
            }
            if (parameters.ContainsKey("hoek"))
            {
                hoek = (Hoek)parameters["hoek"];
            }
            await dialogService.DisplayAlertAsync("Geselecteerde kleuter", kleuter.Naam + " " + kleuter.VoorNaam +" Hoek", "OK");

        }
    }
}
