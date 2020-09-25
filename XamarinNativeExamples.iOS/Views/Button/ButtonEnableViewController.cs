using UIKit;
using XamarinNativeExamples.Core.ViewModels.Button.Items;
using XamarinNativeExamples.iOS.Controls;
using XamarinNativeExamples.iOS.Helpers;
using XamarinNativeExamples.iOS.Views.Base;
using MvvmCross.Binding.BindingContext;
using XamarinNativeExamples.iOS.Utils;

namespace XamarinNativeExamples.iOS.Views.Button
{
    public partial class ButtonEnableViewController : BaseItemViewController<ButtonEnableItemViewModel>
    {
        private AccordionView _accordion;

        public ButtonEnableViewController() : base("ButtonEnableViewController")
        {
        }

        protected override void InitializeControls()
        {
            base.InitializeControls();

            DescriptionLabel.Text = StringHelper.StringResource("ButtonEnableDescription");
            EnableLabel.Text = StringHelper.StringResource("ButtonEnable");
            ClickButton.Enabled = ViewModel.ButtonEnabled;

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

            var set = this.CreateBindingSet<ButtonEnableViewController, ButtonEnableItemViewModel>();
            set.Bind(_accordion).For("TitleLabel").To(vm => vm.Title);
            set.Bind(_accordion).For("Open").To(vm => vm.CellOpen);
            set.Bind(_accordion.Toggle).For(v => v.Command).To(vm => vm.ToggleFoldStateCommand);

            set.Bind(ClickButton).For("Title").To(vm => vm.ButtonText);
            set.Bind(ClickButton).For(v => v.Enabled).To(vm => vm.ButtonEnabled).OneWay();
            set.Bind(ClickButton).To(vm => vm.ClickCommand);

            set.Bind(ClickLabel).To(vm => vm.ClickLabel);
            set.Bind(ClickCountLabel).To(vm => vm.ClickCount);

            set.Bind(EnableSwitch).To(vm => vm.ButtonEnabled);

            set.Apply();
        }

        protected override void ApplyTheme()
        {
            base.ApplyTheme();

            _accordion.ApplyTheme(Themes.Button.AccordionTheme);
            ClickButton.ApplyTheme(Themes.Button.ButtonTheme);
        }
    }
}

