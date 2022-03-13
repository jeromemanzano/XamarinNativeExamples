using NUnit.Framework;
using XamarinNativeExamples.Core.ViewModels.Button.Items;

namespace XamarinNativeExamples.Core.Tests.ViewModels.Button
{
    [TestFixture]
    public class WithButtonEnableItemViewModel : BaseItemViewModelTest<ButtonEnableItemViewModel>
    {
        [Test]
        public void ClickCommand_Should_Increase_ClickCount([Random(1,10,5)]int clickCount)
        {
            for (int i = 0; i < clickCount; i++)
            {
                ViewModel.ClickCommand.Execute();
            }
            
            Assert.AreEqual(clickCount, ViewModel.ClickCount);
        }
        
        protected override ButtonEnableItemViewModel CreateViewModel()
        {
            return new ButtonEnableItemViewModel();
        }
    }
}