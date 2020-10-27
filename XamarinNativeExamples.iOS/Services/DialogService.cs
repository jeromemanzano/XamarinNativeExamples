using System.Linq;
using System.Threading.Tasks;
using UIKit;
using XamarinNativeExamples.Core.Services.Interactions;

namespace XamarinNativeExamples.iOS.Services
{
    public class DialogService : IDialogService
    {
        private UIViewController PresentationController
        {
            get
            {
                var rootNavigation = (UINavigationController)UIApplication.SharedApplication.KeyWindow.RootViewController;
                var lastVC = rootNavigation.ViewControllers.Last();
                if (lastVC.PresentedViewController != null)
                    return lastVC.PresentedViewController;
                if (lastVC.ModalViewController != null)
                    return lastVC.ModalViewController;
                return lastVC;
            }
        }

        public void ShowDialog(string title, string message, string okButton)
        {

            var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create(okButton, UIAlertActionStyle.Default, action =>
            {
                alertController.DismissViewControllerAsync(true);
            }));

            PresentationController?.PresentViewController(alertController, true, null);
        }

        public Task ShowDialogAsync(string title, string message, string okButton)
        {
            var tcs = new TaskCompletionSource<bool>();

            var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create(okButton, UIAlertActionStyle.Default, action =>
            {
                alertController.DismissViewControllerAsync(true);
                tcs.TrySetResult(true);
            }));

            PresentationController?.PresentViewController(alertController, true, null);

            return tcs.Task;
        }

        public void ShowNotification(string message, NotificationLength length)
        {
            throw new System.NotImplementedException();
        }
    }
}