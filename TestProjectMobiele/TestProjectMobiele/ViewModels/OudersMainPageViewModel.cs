using Firebase.Auth;
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
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace TestProjectMobiele.ViewModels
{
	public class OudersMainPageViewModel : ViewModelBase
	{
        public ICommand ImageChildClicked { get; private set; }
        public ICommand ImageCameraClicked { get; private set; }
        private IPageDialogService dialogService;
        Gezin gezin;
        public OudersMainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService)
        {
            ImageChildClicked = new DelegateCommand(GoToTimeline);
            ImageCameraClicked = new DelegateCommand(ExecuteTakePhotoCommand);
            this.dialogService = dialogService;

        }

        private void GoToTimeline()
        {
            var p = new NavigationParameters();
            p.Add("gezin", gezin);
            NavigationService.NavigateAsync("TimelinePage", p);
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

            //Firebase
            //Gemaakt door Daan Vandebosch
            try
            {
                string ApiKey = "AIzaSyD41S0qRV0dw0c7aoqKGjsnw8m6hSdR8QI";
                string Bucket = "mobileapps-11044.appspot.com";
                string AuthEmail = "test@test.be";
                string AuthPassword = "test123";

                // of course you can login using other method, not just email+password
                var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

                //Firebase Upload
                // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
                var task = new FirebaseStorage(
                    Bucket,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    })
                    .Child("data")
                    .Child("random")
                    .Child("file.png")
                    .PutAsync(file.GetStream());

                // Track progress of the upload
                //task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                // await the task to wait until upload completes and get the download url
                var downloadUrl = await task;
                await dialogService.DisplayAlertAsync("Download Url", downloadUrl, "OK");

                //Firebase download
                Source = downloadUrl;
            }
            catch (Exception ex)
            {
                await dialogService.DisplayAlertAsync("Exception was thrown", ex.Message, "OK");
            }

            Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("gezin"))
            {
                gezin = (Gezin)parameters["gezin"];
            }
        }
    }
}
