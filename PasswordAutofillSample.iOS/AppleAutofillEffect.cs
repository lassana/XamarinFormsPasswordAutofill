using System.Linq;
using Foundation;
using PasswordAutofillSample.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("PasswordAutofillSample")]
[assembly: ExportEffect(typeof(AppleAutofillEffect), "AutofillEffect")]
namespace PasswordAutofillSample.iOS
{
    public class AppleAutofillEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var effect = (AutofillEffect)Element.Effects.FirstOrDefault(e => e is AutofillEffect);
            if (effect != null
                && UIDevice.CurrentDevice.CheckSystemVersion(11, 0)
                && Control is UITextField textField)
            {
                switch (effect.Type)
                {
                    case AutofillContentType.None:
                        textField.TextContentType = NSString.Empty;
                        break;
                    case AutofillContentType.Username:
                        textField.TextContentType = UITextContentType.Username;
                        break;
                    case AutofillContentType.Password:
                        textField.TextContentType = UITextContentType.Password;
                        break;
                    case AutofillContentType.Email:
                        textField.TextContentType = UITextContentType.EmailAddress;
                        break;
                }
            }
        }

    protected override void OnDetached()
    {
        if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0) 
                && Control is UITextField textField)
        {
            textField.TextContentType = NSString.Empty;
        }
    }
    }
}