using Android.App;
using Android.Content.PM;
using Android.OS;
using XamarinNativeExamples.Droid.Views.Base;
using AndroidX.ViewPager.Widget;
using XamarinNativeExamples.Core.ViewModels.Token;

namespace XamarinNativeExamples.Droid.Views.Token
{
    [Activity(Theme = "@style/TokenPageTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class TokenActivity : BaseActivity<TokenViewModel>
    {
        protected override int LayoutResource => Resource.Layout.activity_token;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var viewPager = FindViewById<ViewPager>(Resource.Id.view_pager);
            var adapter = new TokenPagerAdapter();
            adapter.AddView(Resource.Id.token_start);
            adapter.AddView(Resource.Id.token_register);
            adapter.AddView(Resource.Id.token_copy);
            adapter.AddView(Resource.Id.token_test);
            viewPager.OffscreenPageLimit = adapter.Count;
            viewPager.Adapter = adapter;
        }
    }
}