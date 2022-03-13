using NUnit.Framework;
using XamarinNativeExamples.Core.ViewModels;
using XamarinNativeExamples.Core.ViewModels.Base;

namespace XamarinNativeExamples.Core.Tests.ViewModels
{
    public abstract class BaseItemViewModelTest<TViewModel> where  TViewModel : CellItemViewModel
    {
        protected TViewModel ViewModel { get; private set; }

        [SetUp]
        public void InitializeTest()
        {
            Setup();
            ViewModel = CreateViewModel();
        }

        protected abstract TViewModel CreateViewModel();
        protected virtual void Setup(){}
    }
}