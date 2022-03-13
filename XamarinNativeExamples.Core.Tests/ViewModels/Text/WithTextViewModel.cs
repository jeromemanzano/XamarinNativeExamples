using NUnit.Framework;
using XamarinNativeExamples.Core.ViewModels.Text;
using XamarinNativeExamples.Core.Properties;

namespace XamarinNativeExamples.Core.Tests.ViewModels.Text
{
    [TestFixture]
    public class WithTextViewModel : BasePageViewModelTest<TextViewModel>
    {
        [Test]
        public void Title_Should_Use_TextTitle()
        {
            Assert.AreEqual(Resources.TextTitle, ViewModel.Title);
        }
        
        protected override TextViewModel CreateViewModel()
        {
            return new TextViewModel(null, null, null);
        }
    }
}