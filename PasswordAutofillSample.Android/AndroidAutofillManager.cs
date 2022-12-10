using Android.OS;
using Android.Views.Autofill;
using AndroidX.AppCompat.App;
using PasswordAutofillSample.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidAutofillManager))]
namespace PasswordAutofillSample.Droid
{
    public class AndroidAutofillManager : ICrossAutofillManager
    {
        public void Commit()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O
                && Xamarin.Essentials.Platform.CurrentActivity is AppCompatActivity activity)
            {
                var manager = (AutofillManager)activity.GetSystemService(Java.Lang.Class.FromType(typeof(AutofillManager)));
                manager.Commit();
            }
        }
    }
}
