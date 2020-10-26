using System.Threading.Tasks;
using XamarinNativeExamples.Core.Services.Interactions;

namespace XamarinNativeExamples.iOS.Services
{
    public class DialogService : IDialogService
    {
        public void ShowDialog(string title, string message, string okButton)
        {
            throw new System.NotImplementedException();
        }

        public Task ShowDialogAsync(string title, string message, string okButton)
        {
            throw new System.NotImplementedException();
        }

        public void ShowNotification(string message, NotificationLength length)
        {
            throw new System.NotImplementedException();
        }
    }
}