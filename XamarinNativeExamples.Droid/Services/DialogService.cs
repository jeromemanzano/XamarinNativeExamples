using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using AndroidX.AppCompat.App;
using MvvmCross.Platforms.Android;
using XamarinNativeExamples.Core.Services.Interactions;

using AlertDialog = XamarinNativeExamples.Droid.Views.Dialogs.AlertDialogFragment;

namespace XamarinNativeExamples.Droid.Services
{
    public class DialogService : IDialogService
    {
        private readonly IMvxAndroidCurrentTopActivity _topActivityService;

        private AppCompatActivity CurrentActivity => _topActivityService.Activity as AppCompatActivity;

        public DialogService(IMvxAndroidCurrentTopActivity topActivityService)
        {
            _topActivityService = topActivityService;
        }

        public void ShowDialog(string title, string message, string okButton)
        {
            var alertDialog = AlertDialog.NewInstance(title, message, okButton, null);

            Application.SynchronizationContext.Post(_ =>
            {
                if (CurrentActivity != null)
                {
                    alertDialog.Show(CurrentActivity.SupportFragmentManager, nameof(alertDialog));
                }
            }, null);
        }

        public Task ShowDialogAsync(string title, string message, string okButton)
        {
            var alertDialog = AlertDialog.NewInstance(title, message, okButton, null);

            Application.SynchronizationContext.Post(_ =>
            {
                if (CurrentActivity != null)
                {
                    alertDialog.Show(CurrentActivity.SupportFragmentManager, nameof(alertDialog));
                }

            }, null);

            return alertDialog.DailogTask;
        }

        public void ShowNotification(string message, NotificationLength length)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                if (CurrentActivity != null)
                {
                    var toastLength = length == NotificationLength.Short ? ToastLength.Short : ToastLength.Long;
                    Toast.MakeText(CurrentActivity, message, toastLength)?.Show();
                }
            }, null);
        }
    }
}