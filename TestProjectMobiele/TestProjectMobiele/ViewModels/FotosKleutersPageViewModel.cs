using Plugin.Media;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace TestProjectMobiele.ViewModels
{
	public class FotosKleutersPageViewModel : ViewModelBase
	{
        public ICommand ImageKleuterClicked { get; private set; }
        private IPageDialogService dialogService;
        public FotosKleutersPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            ImageKleuterClicked = new DelegateCommand(ExecuteTakePhotoCommand);
            this.dialogService = dialogService;
            Kleuters.Add(k);
        }

        private List<Kleuter> Kleuters = new List<Kleuter>();
        Kleuter k = new Kleuter
        {
            KleuterID = 0,
            VoorNaam = "Daan",
            Naam = "Vandebosch",
            SchoolID = 2,
            FotoPad = "FotoString",
            GezinsID = 4,
            KlasID = 4
        };
        

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
                CompressionQuality = 60,
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
    }
}
