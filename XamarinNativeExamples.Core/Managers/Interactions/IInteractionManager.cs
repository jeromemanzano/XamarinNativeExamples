using System.Threading.Tasks;
using XamarinNativeExamples.Core.Services.Interactions;

namespace XamarinNativeExamples.Core.Managers.Interactions
{
    public interface IInteractionManager
    {
        void ShowDialog(string message, string title = null, string okButton = null);

        Task ShowDialogAsync(string message, string title = null, string okButton = null);

        void ShowNotification(string message, NotificationLength length);
    }
}
