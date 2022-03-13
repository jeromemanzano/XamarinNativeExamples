using NUnit.Framework;
using XamarinNativeExamples.Core.ViewModels.Button.Items;

namespace XamarinNativeExamples.Core.Tests.ViewModels.Button
{
    [TestFixture]
    public class WithButtonClickItemViewModel : BaseItemViewModelTest<ButtonClickItemViewModel>
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

        [Test]
        public void LongClickCommand_Should_Increase_LongClickCount([Random(1,10,5)]int longClickCount)
        {
            for (int i = 0; i < longClickCount; i++)
            {
                ViewModel.LongClickCommand.Execute();
            }
            
            Assert.AreEqual(longClickCount, ViewModel.LongClickCount);
        }

        protected override ButtonClickItemViewModel CreateViewModel()
        {
            return new ButtonClickItemViewModel();
        }
    }
}