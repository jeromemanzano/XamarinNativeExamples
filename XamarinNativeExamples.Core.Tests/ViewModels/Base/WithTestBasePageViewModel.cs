using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace XamarinNativeExamples.Core.Tests.ViewModels.Base
{
    [TestFixture]
    public class WithTestBasePageViewModel : BasePageViewModelTest<TestBasePageViewModel>
    {
        [Test]
        public async Task BackCommand_Should_Execute_NavigationService_Close()
        {
            await ViewModel.BackCommand.ExecuteAsync();
            
            NavigationService.Verify(service => service.Close(ViewModel, It.IsAny<CancellationToken>()), Times.Once);
        }
        
        protected override TestBasePageViewModel CreateViewModel()
        {
            return new TestBasePageViewModel(null, NavigationService.Object, null);
        }
    }
}