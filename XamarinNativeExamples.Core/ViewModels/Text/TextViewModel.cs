using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using XamarinNativeExamples.Core.Managers.Interactions;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.ViewModels.Base;

namespace XamarinNativeExamples.Core.ViewModels.Text
{
    public class TextViewModel : BasePageViewModel
    {
        public override string Title => Resources.TextTitle;
        
        public TextViewModel(ILoggerFactory loggerFactory, 
            IMvxNavigationService navigationService,
            IInteractionManager interactionManager)
            :base(loggerFactory, navigationService, interactionManager)
        {
        }
    }
}
