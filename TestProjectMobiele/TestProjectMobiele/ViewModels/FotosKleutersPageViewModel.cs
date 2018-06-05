using Firebase.Storage;
using Plugin.Media;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TestProjectMobiele.Contracts;
using Xamarin.Forms;

namespace TestProjectMobiele.ViewModels
{
	public class FotosKleutersPageViewModel : ViewModelBase
	{
        public ICommand ImageKleuterClicked { get; private set; }
        ILoadAllData dataConnection;
        private IPageDialogService dialogService;
        public FotosKleutersPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ILoadAllData dataConnection) : base(navigationService)
        {
            this.dataConnection = dataConnection;
            ImageKleuterClicked = new DelegateCommand(ExecuteTakePhotoCommand);
            this.dialogService = dialogService;
            //Kleuters = new ObservableCollection<Kleuter>();
        }
        private Kleuter selectedItem;
        public Kleuter SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (SetProperty(ref selectedItem, value) && selectedItem != null)
                {
                    var p = new NavigationParameters();
                    p.Add("kleuter", SelectedItem);
                    NavigationService.NavigateAsync("FotosHoekenPage", p);
                    SelectedItem = null;
                }
            }
        }

        private IList<Kleuter> kleuters;
        public IList<Kleuter>  Kleuters
        {
            get { return kleuters; }
            set { SetProperty(ref kleuters, value); }
        }

        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            Kleuters = await dataConnection.LoadKleuters();
        }
        

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
