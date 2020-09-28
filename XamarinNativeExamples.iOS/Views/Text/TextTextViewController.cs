using UIKit;
using XamarinNativeExamples.Core.ViewModels.Text.Items;
using XamarinNativeExamples.iOS.Controls;
using XamarinNativeExamples.iOS.Helpers;
using XamarinNativeExamples.iOS.Views.Base;
using MvvmCross.Binding.BindingContext;
using XamarinNativeExamples.iOS.Utils;

namespace XamarinNativeExamples.iOS.Views.Text
{
    public partial class TextTextViewController : BaseItemViewController<TextTextItemViewModel>
    {
        private AccordionView _accordion;

        public TextTextViewController() : base("TextTextViewController")
        {
        }

        protected override void InitializeControls()
        {
            base.InitializeControls();

            DescriptionLabel.Text = StringHelper.StringResource("TextTextDescription");
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

            var set = this.CreateBindingSet<TextTextViewController, TextTextItemViewModel>();
            set.Bind(_accordion).For("TitleLabel").To(vm => vm.Title);
            set.Bind(_accordion).For("Open").To(vm => vm.CellOpen);
            set.Bind(_accordion.Toggle).For(v => v.Command).To(vm => vm.ToggleFoldStateCommand);

            set.Bind(InputDisplayButon).For("Title").To(vm => vm.Text).OneWay();

            set.Bind(InputTextField).To(vm => vm.Text);
            set.Bind(InputDisplayLabel).To(vm => vm.Text);

            set.Apply();
        }

        protected override void ApplyTheme()
        {
            base.ApplyTheme();

            _accordion.ApplyTheme(Themes.Text.AccordionTheme);
            InputDisplayButon.ApplyTheme(Themes.Text.ButtonTheme);
        }
    }
}

