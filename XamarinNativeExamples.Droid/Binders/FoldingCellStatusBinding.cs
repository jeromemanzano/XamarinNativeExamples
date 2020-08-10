using System;
using Com.Ramotion.Foldingcell;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;

namespace XamarinNativeExamples.Droid.Binders
{
    public class FoldingCellStatusBinding : MvxConvertingTargetBinding
    {
        protected FoldingCell Layout => Target as FoldingCell;
        public override Type TargetType => typeof(bool);
        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

        public FoldingCellStatusBinding(FoldingCell target)
            : base(target)
        {
        }

        protected override void SetValueImpl(object target, object value)
        {
            var layout = target as FoldingCell;

            if (value is bool open)
            {
                if (open != layout.IsUnfolded)
                {
                    layout.Toggle(false);
                }
            }
        }
    }
}