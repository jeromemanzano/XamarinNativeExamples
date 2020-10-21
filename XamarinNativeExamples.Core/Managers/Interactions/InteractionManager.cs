using System.Threading.Tasks;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.Services.Interactions;

namespace XamarinNativeExamples.Core.Managers.Interactions
{
    public class InteractionManager : IInteractionManager
    {
        private readonly IDialogService _dialogService;

        public InteractionManager(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public void ShowDialog(string message, string title = null, string okButton = null)
        {
            _dialogService.ShowDialog(title ?? Resources.OoopsTitle, message, okButton ?? Resources.Ok);
        }

        public Task ShowDialogAsync(string title, string message, string okButton = null)
        {
            return _dialogService.ShowDialogAsync(title ?? Resources.OoopsTitle, message, okButton ?? Resources.Ok);
        }

        public void ShowNotification(string message, NotificationLength length)
        {
            _dialogService.ShowNotification(message, length);
        }
    }
}
