﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.ViewPager.Widget;

namespace XamarinNativeExamples.Droid.Views.Token
{
    public class TokenPagerAdapter : PagerAdapter
    {
        private List<int> _items = new List<int>();
        public override int Count => _items.Count();

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