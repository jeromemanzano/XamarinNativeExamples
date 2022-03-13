using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using XamarinNativeExamples.Core.Managers.Stocks;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.ViewModels.Base;
using XamarinNativeExamples.Core.ViewModels.Token;

namespace XamarinNativeExamples.Core.Tests.ViewModels.Token
{
    [TestFixture]
    public class WithTokenViewModel : BasePageViewModelTest<TokenViewModel>
    {
        private Mock<IStockManager> _stockManager;

        [Test]
        public async Task Initialize_Should_Set_TestTextButton_To_Test_And_Enable_ApiTextEnabled()
        {
            await ViewModel.Initialize();
            Assert.AreEqual(Resources.Test, ViewModel.TestButtonText);
            Assert.IsTrue(ViewModel.ApiTextEnabled);
        }
        
        [Test]
        public async Task When_Token_Is_Not_Valid_SaveCommand_Should_Execute_ValidateTokenAsync()
        {
            var apiToken = Guid.NewGuid().ToString();
            ViewModel.TokenValid = false;
            ViewModel.ApiToken = apiToken;
            
            await ViewModel.SaveCommand.ExecuteAsync();
            
            _stockManager.Verify(manager => manager.ValidateTokenAsync(apiToken), Times.Once);
        }

        [Test]
        public async Task When_Token_Validated_Should_Set_TestButtonText_To_Save_And_Set_ApiTextEnabled_ShowSuccess_ShowFailed_TokenValid([Values]bool validated)
        {
            var apiToken = Guid.NewGuid().ToString();
            ViewModel.TokenValid = false;
            ViewModel.ApiToken = apiToken;
            _stockManager.Setup(manager => manager.ValidateTokenAsync(apiToken)).ReturnsAsync(validated);

            await ViewModel.SaveCommand.ExecuteAsync();
            
            Assert.AreEqual(validated ? Resources.Save : Resources.Test, ViewModel.TestButtonText);
            Assert.AreEqual(validated, ViewModel.TokenValid);
            Assert.AreNotEqual(validated, ViewModel.ApiTextEnabled);
            Assert.AreEqual(validated, ViewModel.ShowSuccess);
            Assert.AreNotEqual(validated, ViewModel.ShowFailed);
        }

        [Test]
        public async Task When_Token_Is_Valid_SaveCommand_Should_Execute_UpdateToken_And_Close()
        {
            var apiToken = Guid.NewGuid().ToString();
            ViewModel.TokenValid = true;
            ViewModel.ApiToken = apiToken;

            await ViewModel.SaveCommand.ExecuteAsync();
            
            _stockManager.Verify(manager => manager.UpdateTokenAsync(apiToken), Times.Once);
            NavigationService
                .Verify(service => service.Close(ViewModel, 
                    It.Is<NavigationResult>(result => result.Success == true), 
                    It.IsAny<CancellationToken>()), Times.Once);
        }
        
        protected override TokenViewModel CreateViewModel()
        {
            _stockManager = new Mock<IStockManager>();
            
            return new TokenViewModel(null, NavigationService.Object, _stockManager.Object, null);
        }
    }
}