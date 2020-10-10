﻿using System.Threading.Tasks;
using MvvmCross.Commands;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.ViewModels.Base;
using XamarinNativeExamples.Core.ViewModels.Button;
using XamarinNativeExamples.Core.ViewModels.Http;
using XamarinNativeExamples.Core.ViewModels.Text;

namespace XamarinNativeExamples.Core.ViewModels.Home
{
    public class HomeViewModel : BasePageViewModel
    {
        public override string Title => Resources.HomeTitle;
        public string ButtonTitle => Resources.ButtonTitle;
        public string TextTitle => Resources.TextTitle;
        public string RestTitle => Resources.RestTitle;
        public string UserInterfaceHeader => Resources.UserInterfaceHeader;
        public string ConnectivityHeader => Resources.ConnectivityHeader;

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

        private IMvxCommand _openRestCommand;
        public IMvxCommand OpenRestCommand
        {
            get => _openRestCommand ?? (_openRestCommand = new MvxAsyncCommand(OpenRest));
        }

        private Task OpenButton() 
        {
            return Navigation.Navigate<ButtonViewModel>();
        }

        private Task OpenText()
        {
            return Navigation.Navigate<TextViewModel>();
        }

        private Task OpenRest() 
        {
            return Navigation.Navigate<HttpViewModel>();
        }
    }
}
