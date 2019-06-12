using Xamarin.Forms;

namespace PasswordAutofillSample
{
    public class AutofillEffect : RoutingEffect
    {
        public AutofillContentType Type { get; set; }

        public AutofillEffect() : base("PasswordAutofillSample." + nameof(AutofillEffect))
        {
        }
    }
}
