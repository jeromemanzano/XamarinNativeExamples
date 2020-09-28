using System.Text.RegularExpressions;
using Foundation;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using UIKit;

namespace XamarinNativeExamples.iOS.Bindings
{
    public class TextFieldFilterBinding : MvxConvertingTargetBinding<UITextField, string>
    {
        private CustomUITextFieldDelegate _textFieldDelegate;

        public TextFieldFilterBinding(UITextField target)
            : base(target)
        {
            _textFieldDelegate = new CustomUITextFieldDelegate();
            target.Delegate = _textFieldDelegate;
        }

        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

        protected override void SetValueImpl(UITextField target, string value)
        {
            if (target == null)
            {
                return;
            }

            if (value?.Length > 0 && _textFieldDelegate != null)
            {
                _textFieldDelegate.Regex = new Regex(value);
            }
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            if (isDisposing)
            {
                if (Target != null)
                {
                    Target.Delegate?.Dispose();
                    Target.Delegate = null;
                }
            }
        }

        class CustomUITextFieldDelegate : UITextFieldDelegate 
        {
            public Regex Regex { get; set; }

            public override bool ShouldChangeCharacters(UITextField textField, NSRange range, string replacementString)
            {
                if (Regex != null)
                {
                    return Regex.IsMatch($"{textField.Text}{replacementString}");
                }

                return true;
            }
        }
    }
}