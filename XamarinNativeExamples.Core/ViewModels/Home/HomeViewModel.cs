﻿using System.Threading.Tasks;
using MvvmCross.Commands;
using XamarinNativeExamples.Core.ViewModels.Base;
using XamarinNativeExamples.Core.ViewModels.Button;
using XamarinNativeExamples.Core.ViewModels.Text;

namespace XamarinNativeExamples.Core.ViewModels.Home
{
    public class HomeViewModel : BasePageViewModel
    {
        private IMvxCommand _openButtonCommand;
        public IMvxCommand OpenButtonCommand
        {
            get => _openButtonCommand ?? (_openButtonCommand = new MvxAsyncCommand(OpenButton));
        }

        private IMvxCommand _openTextCommand;
        public IMvxCommand OpenTextCommand
        {
            get => _openTextCommand ?? (_openTextCommand = new MvxAsyncCommand(OpenText));
        }

        private Task OpenButton() 
        {
            return Navigation.Navigate<ButtonViewModel>();
        }

        private Task OpenText()
        {
            return Navigation.Navigate<TextViewModel>();
        }
    }
}
