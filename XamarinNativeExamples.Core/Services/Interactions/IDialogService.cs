﻿
using System.Threading.Tasks;
using XamarinNativeExamples.Core.Properties;

namespace XamarinNativeExamples.Core.Services.Interactions
{
    public interface IDialogService
    {
        void ShowDialog(string title, string message, string okButton);

        Task ShowDialogAsync(string title, string message, string okButton);

        void ShowNotification(string message, NotificationLength length);
    }
}
