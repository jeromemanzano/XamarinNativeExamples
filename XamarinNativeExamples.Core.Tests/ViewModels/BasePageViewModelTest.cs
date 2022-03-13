using Moq;
using MvvmCross.Navigation;
using NUnit.Framework;
using XamarinNativeExamples.Core.Managers.Interactions;
using XamarinNativeExamples.Core.ViewModels.Base;

namespace XamarinNativeExamples.Core.Tests.ViewModels
{
    public abstract class BasePageViewModelTest<TViewModel> where  TViewModel : BasePageViewModel
    {
        protected TViewModel ViewModel { get; private set; }
        protected Mock<IMvxNavigationService> NavigationService { get; private set; }
        protected Mock<IInteractionManager> InteractionManager { get; private set; }

        [SetUp]
        public void InitializeTest()
        {
            NavigationService = new Mock<IMvxNavigationService>();
            InteractionManager = new Mock<IInteractionManager>();
            
            Setup();
            ViewModel = CreateViewModel();
        }

        protected abstract TViewModel CreateViewModel();
        protected virtual void Setup(){}
    }
}