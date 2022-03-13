using NUnit.Framework;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.ViewModels.Button;

namespace XamarinNativeExamples.Core.Tests.ViewModels.Button
{
    [TestFixture]
    public class WithButtonViewModel : BasePageViewModelTest<ButtonViewModel>
    {
        [Test]
        public void Title_Should_Use_ButtonTitle()
        {
            Assert.AreEqual(Resources.ButtonTitle, ViewModel.Title);
        }

        protected override ButtonViewModel CreateViewModel()
        {
            return new ButtonViewModel(null, null, null);
        }
    }
}