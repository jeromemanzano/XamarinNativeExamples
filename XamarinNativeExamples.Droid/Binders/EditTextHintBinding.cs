﻿using System;
using Android.Widget;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;

namespace XamarinNativeExamples.Droid.Binders
{
    public class EditTextHintBinding : MvxConvertingTargetBinding
    {
        protected EditText EditText => Target as EditText;
        public override Type TargetType => typeof(string);
        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

        public EditTextHintBinding(EditText target)
            : base(target)
        {
        }

        protected override void SetValueImpl(object target, object value)
        {
            if (value != null && target is EditText editText)
            {
                editText.Hint = value as string;
            }
        }
    }
}