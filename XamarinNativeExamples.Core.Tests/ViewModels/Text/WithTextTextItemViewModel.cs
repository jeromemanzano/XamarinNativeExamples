using NUnit.Framework;
using XamarinNativeExamples.Core.ViewModels.Text.Items;
using XamarinNativeExamples.Core.Properties;

namespace XamarinNativeExamples.Core.Tests.ViewModels.Text
{
    [TestFixture]
    public class WithTextTextItemViewModel : BaseItemViewModelTest<TextTextItemViewModel>
    {
        [Test]
        public void Title_Should_Use_TextTextHeader()
        {
            Assert.AreEqual(Resources.TextTextHeader, ViewModel.Title);
        }
        
        protected override TextTextItemViewModel CreateViewModel()
        {
            return new TextTextItemViewModel();
        }
    }
}