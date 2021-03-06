﻿using System.Threading.Tasks;
using MvvmCross.Commands;
using XamarinNativeExamples.Core.Properties;

namespace XamarinNativeExamples.Core.ViewModels.Button.Items
{
    public class ButtonEnableItemViewModel : CellItemViewModel
    {
        private IMvxCommand _clickCommand;
        public IMvxCommand ClickCommand
        {
            get => _clickCommand ?? (_clickCommand = new MvxCommand(ProcessClick));
        }

        private int _clickCount;
        public int ClickCount
        {
            get => _clickCount;
            private set => SetProperty(ref _clickCount, value);
        }

        private bool _buttonEnabled;
        public bool ButtonEnabled
        {
            get => _buttonEnabled;
            private set => SetProperty(ref _buttonEnabled, value);
        }

        public string ButtonText => Resources.TryMe;

        public string ClickLabel => Resources.ClickCountLabel;

        public override Task Initialize()
        {
            InvokeOnMainThread(() =>
            {
                Title = Resources.ButtonEnableHeader;
                ButtonEnabled = true;
            });

            return base.Initialize();
        }

        private void ProcessClick()
        {
            InvokeOnMainThread(() => ClickCount++);
        }
    }
}
