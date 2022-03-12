using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using XamarinNativeExamples.Core.Managers.Interactions;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.ViewModels.Base;

namespace XamarinNativeExamples.Core.ViewModels.Button
{
    public class ButtonViewModel : BasePageViewModel
    {
        public override string Title => Resources.ButtonTitle;
        
        public ButtonViewModel(ILoggerFactory loggerFactory, 
            IMvxNavigationService navigationService,
            IInteractionManager interactionManager)
            :base(loggerFactory, navigationService, interactionManager)
        {
        }
    }
}
