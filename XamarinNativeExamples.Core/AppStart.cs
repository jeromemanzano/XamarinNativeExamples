using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using XamarinNativeExamples.Core.ViewModels.Home;

namespace XamarinNativeExamples.Core
{
    public class AppStart : MvxAppStart
    {
        public AppStart(IMvxApplication application, IMvxNavigationService navigationService) 
            : base(application, navigationService)
        {
        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            return NavigationService.Navigate<HomeViewModel>();
        }
    }
}
