using System;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;
using XamarinNativeExamples.Core.ViewModels.Text.Items;

namespace XamarinNativeExamples.iOS.Views.Text
{
    public class FilterMvxPickerViewModel : MvxPickerViewModel
    {
        private readonly UITextField _textField;
        public FilterMvxPickerViewModel(UIPickerView pickerView, UITextField textField) : base(pickerView)
        {
            _textField = textField;
        }

        protected override string RowTitle(nint row, object item)
        {
            return ((FilterItemViewModel)item).Header;
        }

        public override void Selected(UIPickerView picker, nint row, nint component)
        {
            base.Selected(picker, row, component);

            _textField.ResignFirstResponder();

            var selectedFilter = SelectedItem as FilterItemViewModel;
            _textField.Text = $"{selectedFilter.Header} - {selectedFilter.Regex}";
        }
    }
}