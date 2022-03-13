using System.Threading.Tasks;
using NUnit.Framework;

namespace XamarinNativeExamples.Core.Tests.ViewModels.Base
{
    [TestFixture]
    public class WithTestBaseResultPageViewModel : BasePageViewModelTest<TestBaseResultPageViewModel>
    {
        [Test]
        public void On_ViewDestroy_Should_Not_Throw_When_CloseCompletionSource_Is_Null_And_View_Finishing_Is_True()
        {
            Assert.DoesNotThrow(() => ViewModel.ViewDestroy(true));
            Assert.IsNull(ViewModel.CloseCompletionSource);
        }

        [Test]
        public void On_ViewDestroy_Should_Cancel_CloseCompletionSource_When_ViewFinishing_Is_True([Values]bool viewFinishing)
        {
            ViewModel.CloseCompletionSource = new TaskCompletionSource<object>();
            
            ViewModel.ViewDestroy(viewFinishing);
            Assert.AreEqual(viewFinishing ? TaskStatus.Canceled : TaskStatus.WaitingForActivation, ViewModel.CloseCompletionSource.Task.Status);
        }

        protected override TestBaseResultPageViewModel CreateViewModel()
        {
            return new TestBaseResultPageViewModel(null, null, null);
        }
    }
}