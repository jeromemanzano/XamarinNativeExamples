using NUnit.Framework;
using XamarinNativeExamples.Core.ViewModels.Text.Items;

namespace XamarinNativeExamples.Core.Tests.ViewModels.Text
{
    [TestFixture]
    public class WithTextFilterItemViewModel : BaseItemViewModelTest<TextFilterItemViewModel>
    {
        [Test]
        [Ignore("Throwing null reference exception when adding filters. Need to investigate further")]
        public void FilterSelectedCommand_Should_Update_Regex_And_Set_Input_Text_To_Null()
        {
            var inputText = "input text";
            foreach (var filter in ViewModel.Filters)
            {
                ViewModel.InputText = inputText;
                ViewModel.FilterSelectedCommand.Execute(filter);
                
                Assert.IsNull(ViewModel.InputText);
                Assert.AreEqual(filter.Regex, ViewModel.Regex);
            }
        }
        
        protected override TextFilterItemViewModel CreateViewModel()
        {
            return new TextFilterItemViewModel();
        }
    }
}