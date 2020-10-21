using UIKit;
using XamarinNativeExamples.Core.ViewModels.Text.Items;
using XamarinNativeExamples.iOS.Controls;
using XamarinNativeExamples.iOS.Views.Base;
using MvvmCross.Binding.BindingContext;
using XamarinNativeExamples.iOS.Helpers;
using XamarinNativeExamples.iOS.Utils;
using MvvmCross.Platforms.Ios.Binding.Views;

namespace XamarinNativeExamples.iOS.Views.Text
{
    public partial class TextFilterViewController : BaseItemViewController<TextFilterItemViewModel>
    {
        private AccordionView _accordion;
        private MvxPickerViewModel _pickerModel;

        public TextFilterViewController() : base("TextFilterViewController")
        {
        }

        protected override void InitializeControls()
        {
            base.InitializeControls();

            var filterPicker = new UIPickerView();
            _pickerModel = new FilterMvxPickerViewModel(filterPicker, FilterInputPickerTextField);
            filterPicker.BackgroundColor = UIColor.White;
            filterPicker.Model = _pickerModel;
            filterPicker.ShowSelectionIndicator = true;

            FilterInputPickerTextField.InputView = filterPicker;

            FilterInputPickerTextField.Text = StringHelper.StringResource("SelectFilter");

            InputTextField.Placeholder = StringHelper.StringResource("TextTypeHint");

            ContainerView.RemoveFromSuperview();

            _accordion = new AccordionView();
            _accordion.TranslatesAutoresizingMaskIntoConstraints = false;

            View.AddSubview(_accordion);

            _accordion.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
            _accordion.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;
            _accordion.TopAnchor.ConstraintEqualTo(View.TopAnchor).Active = true;
            _accordion.BottomAnchor.ConstraintEqualTo(View.BottomAnchor).Active = true;

            _accordion.SetContent(ContainerView);
        }

        protected override void BindControls()
        {
            base.BindControls();

            var set = this.CreateBindingSet<TextFilterViewController, TextFilterItemViewModel>();
            set.Bind(_accordion).For(v => v.TitleLabel).To(vm => vm.Title);
            set.Bind(_accordion).For(v => v.Open).To(vm => vm.CellOpen);
            set.Bind(_accordion.Toggle).For(v => v.Command).To(vm => vm.ToggleFoldStateCommand);

            set.Bind(DescriptionLabel).To(vm => vm.Description);

            set.Bind(InputTextField).To(vm => vm.InputText);
            set.Bind(InputTextField).For("Filter").To(vm => vm.Regex);

            set.Bind(_pickerModel).For(v => v.ItemsSource).To(vm => vm.Filters);
            set.Bind(_pickerModel).For(v => v.SelectedChangedCommand).To(vm => vm.FilterSelectedCommand);

            set.Apply();
        }

        protected override void ApplyTheme()
        {
            base.ApplyTheme();

            _accordion.ApplyTheme(Themes.Text.AccordionTheme);
        }
    }
}

