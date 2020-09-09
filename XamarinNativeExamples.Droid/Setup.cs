using Com.Ramotion.Foldingcell;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platforms.Android.Core;
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

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);

            registry.RegisterCustomBindingFactory<FoldingCell>("FoldingCellOpen", view => new FoldingCellStatusBinding(view));

        }
    }
}