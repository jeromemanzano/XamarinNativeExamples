using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Android.Text;
using Android.Widget;
using Java.Lang;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using Object = Java.Lang.Object;

namespace XamarinNativeExamples.Droid.Binders
{
    public class EditTextFilterBinding : MvxConvertingTargetBinding
    {
        protected EditText EditText => Target as EditText;
        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;
        public override Type TargetType => typeof(string);

        public EditTextFilterBinding(object target) : base(target)
        {
        }

        protected override void SetValueImpl(object target, object value)
        {
            var editText = (EditText)target;

            var filters = new List<IInputFilter>() { new RegexFilter(value as string) };

            editText.SetFilters(filters.ToArray());
        }
    }

    public class RegexFilter : Object, IInputFilter
    {
        private readonly Regex _regex;
        public RegexFilter(string regex)
        {
            _regex = new Regex(regex);
        }

        public ICharSequence FilterFormatted(ICharSequence source, int start, int end, ISpanned dest, int dstart, int dend)
        {
            string val = dest.ToString().Insert(dstart, source.ToString());
            if (_regex.Match(val).Value.Equals(val))
            {
                return source;
            }

            return new Java.Lang.String(string.Empty);
        }
    }
}