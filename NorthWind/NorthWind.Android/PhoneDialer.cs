using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Telephony;
using NorthWind;
using Xamarin.Forms;
using Uri = Android.Net.Uri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace NorthWind.Droid
{
    public class PhoneDialer : iDialer
    {
        public bool Dial(string number)
        {
            var context = Forms.Context;
            if (context == null)
            {
                return false;
            }
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Uri.Parse("tel:" + number));
            if (IsIntentAvailable(context, intent))
            {
                context.StartActivity(intent);
                return true;
            }
            return false;
        }

        public static bool IsIntentAvailable(Context context, Intent intent)
        {
            var packageManager = context.PackageManager;
            var list = packageManager.QueryIntentServices(intent, 0).Union(packageManager.QueryIntentActivities(intent, 0));
            if (list.Any())
            {
                return true;

            }
            var manager = TelephonyManager.FromContext(context);
            return manager.PhoneType != PhoneType.None;

        }
    }
}