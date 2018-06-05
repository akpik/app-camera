using Firebase.Auth;
using Firebase.Storage;
using Plugin.Media;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TestProjectMobiele.Contracts;
using Xamarin.Forms;

namespace TestProjectMobiele.ViewModels
{
	public class KleuterFotoTrekkenPageViewModel : ViewModelBase
	{
        //Gemaakt door Kaan Akpinar
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

            Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });

            
            int id = 0;
            foreach(Foto foto in await dataConnection.LoadFotos())
            {
                if (foto.FotoID >= id)
                {
                    id = foto.FotoID;
                }
            }

            //Firebase
            try
            {
                //Gemaakt door Daan Vandebosch
                string ApiKey = "AIzaSyD41S0qRV0dw0c7aoqKGjsnw8m6hSdR8QI";
                string Bucket = "mobileapps-11044.appspot.com";
                string AuthEmail = "test@test.be";
                string AuthPassword = "test123";

                var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

                var task = new FirebaseStorage(
                    Bucket,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    })
                    .Child("UCLL")
                    .Child("ICT")
                    .Child(kleuter.Naam + kleuter.KleuterID)
                    .Child((id + 1).ToString())
                    .PutAsync(file.GetStream());

                // Track progress of the upload
                //task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                // await the task to wait until upload completes and get the download url
                var downloadUrl = await task;
                await dialogService.DisplayAlertAsync("Download Url", "Picture Uploaded", "OK");

                //Firebase download
                Source = downloadUrl;

                while(downloadUrl == null || downloadUrl == "")
                {

                }
                //Database storage
                Foto f = new Foto
                {
                    FotoID = id+1,
                    KleuterID = kleuter.KleuterID,
                    FotoPad = downloadUrl,
                    Datum = DateTime.Now.ToString(),
                    HoekID = hoek.HoekID,
                };
                await dataConnection.SaveFotoAsync(f);
            }
            catch (Exception ex)
            {
                await dialogService.DisplayAlertAsync("Exception was thrown", ex.Message, "OK");
            }

        }
        //Gemaakt door Kaan Akpinar
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
            await dialogService.DisplayAlertAsync("Geselecteerde kleuter", kleuter.Naam + " " + kleuter.VoorNaam + " " + hoek.Naam, "OK");

        }
    }
}
