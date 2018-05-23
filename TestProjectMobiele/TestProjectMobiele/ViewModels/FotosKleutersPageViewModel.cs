using Firebase.Storage;
using Plugin.Media;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
            StorageTest(file.Path);

            Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }
        private async void StorageTest(string path)
        {
            // Get any Stream — it can be FileStream, MemoryStream or any other type of Stream
            var stream = File.Open(@path, FileMode.Open);

            // Construct FirebaseStorage with path to where you want to upload the file and put it there
            var task = new FirebaseStorage("mobileapps-11044.appspot.com")
             .Child("Kleuters")
             .Child("file.png")
             .PutAsync(stream);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // Await the task to wait until upload is completed and get the download url
            var downloadUrl = await task;
        }
    }
}
