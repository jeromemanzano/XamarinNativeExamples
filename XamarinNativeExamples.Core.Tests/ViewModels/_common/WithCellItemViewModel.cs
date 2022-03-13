using NUnit.Framework;

namespace XamarinNativeExamples.Core.Tests.ViewModels._common
{
    [TestFixture]
    public class WithCellItemViewModel : BaseItemViewModelTest<TestCellItemViewModel>
    {
        [Test]
        public void ToggleFoldStateCommand_Should_Update_CellOpen()
        {
            var oldCellOpen = ViewModel.CellOpen;
            
            ViewModel.ToggleFoldStateCommand.Execute();
            
            Assert.AreNotEqual(oldCellOpen, ViewModel.CellOpen);
        }
        
        protected override TestCellItemViewModel CreateViewModel()
        {
            return new TestCellItemViewModel();
        }
    }
}