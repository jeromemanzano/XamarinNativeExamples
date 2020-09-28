using Android.Widget;
using Com.Ramotion.Foldingcell;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Presenters;
using XamarinNativeExamples.Core;
using XamarinNativeExamples.Droid.Binders;

namespace XamarinNativeExamples.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            return new CustomPresenter();
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);

            registry.RegisterCustomBindingFactory<FoldingCell>("FoldingCellOpen", view => new FoldingCellStatusBinding(view));
            registry.RegisterCustomBindingFactory<EditText>("EditTextFilter", view => new EditTextFilterBinding(view));
        }
    }
}