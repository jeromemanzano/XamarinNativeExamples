using System.Collections.Generic;
using Android.Views;
using AndroidX.ViewPager.Widget;

namespace XamarinNativeExamples.Droid.Views.Token
{
    public class TokenPagerAdapter : PagerAdapter
    {
        private readonly List<int> _items = new ();
        public override int Count => _items.Count;

        public override bool IsViewFromObject(View view, Java.Lang.Object obj)
        {
            return view == obj;
        }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            return container.FindViewById(_items[position]);
        }

        public void AddView(int resourceId) 
        {
            _items.Add(resourceId);
        }
    }
}