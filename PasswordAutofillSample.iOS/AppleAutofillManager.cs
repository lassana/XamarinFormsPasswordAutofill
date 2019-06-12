using PasswordAutofillSample.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(AppleAutofillManager))]
namespace PasswordAutofillSample.iOS
{
    public class AppleAutofillManager : ICrossAutofillManager
    {
        public void Commit()
        {
            // Do nothing.
            // We expect iOS to do everything on its own.
        }
    }
}
