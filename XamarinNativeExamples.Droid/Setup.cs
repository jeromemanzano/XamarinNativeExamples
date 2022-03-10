using Android.Widget;
using Com.Ramotion.Foldingcell;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Converters;
using MvvmCross.IoC;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Presenters;
using Serilog;
using Serilog.Extensions.Logging;
using XamarinNativeExamples.Core;
using XamarinNativeExamples.Core.Services.Interactions;
using XamarinNativeExamples.Droid.Binders;
using XamarinNativeExamples.Droid.Converters;
using XamarinNativeExamples.Droid.Services;

namespace XamarinNativeExamples.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {
        protected override void InitializeFirstChance(IMvxIoCProvider iocProvider)
        {
            base.InitializeFirstChance(iocProvider);
            iocProvider.RegisterSingleton<IDialogService>(() => Mvx.IoCProvider.IoCConstruct<DialogService>());
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

        protected override ILoggerProvider CreateLogProvider()
        {
            return new SerilogLoggerProvider();
        }

        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }
    }
}