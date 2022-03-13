using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using XamarinNativeExamples.Core.Managers.Interactions;
using XamarinNativeExamples.Core.ViewModels.Base;

namespace XamarinNativeExamples.Core.Tests.ViewModels.Base
{
    public class TestBasePageViewModel : BasePageViewModel
    {
        public TestBasePageViewModel(ILoggerFactory loggerFactory, 
            IMvxNavigationService navigationService,
            IInteractionManager interactionManager)
            :base(loggerFactory, navigationService, interactionManager)
        {
        }
    }
}