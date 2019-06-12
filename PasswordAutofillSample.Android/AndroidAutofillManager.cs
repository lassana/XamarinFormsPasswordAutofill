using System;
using Android.Views.Autofill;
using Android.App;
using Android.OS;
using PasswordAutofillSample.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidAutofillManager))]
namespace PasswordAutofillSample.Droid
{
    public class AndroidAutofillManager : ICrossAutofillManager
    {
        public void Commit()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var manager = (AutofillManager)Application.Context.GetSystemService(Java.Lang.Class.FromType(typeof(AutofillManager)));
                manager.Commit();
            }
        }
    }
}
