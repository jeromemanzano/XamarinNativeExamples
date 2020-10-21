using Android.Widget;
using Com.Ramotion.Foldingcell;
using MvvmCross;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Converters;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Presenters;
using XamarinNativeExamples.Core;
using XamarinNativeExamples.Core.Services.Interactions;
using XamarinNativeExamples.Droid.Binders;
using XamarinNativeExamples.Droid.Converters;
using XamarinNativeExamples.Droid.Services;

namespace XamarinNativeExamples.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterSingleton<IDialogService>(() => Mvx.IoCProvider.IoCConstruct<DialogService>());
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
            registry.RegisterCustomBindingFactory<EditText>("Hint", view => new EditTextHintBinding(view));
        }

        protected override void FillValueConverters(IMvxValueConverterRegistry registry)
        {
            base.FillValueConverters(registry);

            registry.AddOrOverwrite("CheckIconConverter", new BoolToCheckIconConverter());
        }
    }
}