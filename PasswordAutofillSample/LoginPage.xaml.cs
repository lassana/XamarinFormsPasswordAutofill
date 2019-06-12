using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PasswordAutofillSample
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Handle_Clicked(object sender, System.EventArgs e)
        {
            username.IsEnabled = password.IsEnabled = login.IsEnabled = false;
            indicator.IsVisible = true;
            Task.Run(async () =>
            {
                await Task.Delay(1000);
                Device.BeginInvokeOnMainThread(() =>
                {
                    Xamarin.Forms.DependencyService.Get<ICrossAutofillManager>().Commit();
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                });
            });
        }

        private void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            login.IsEnabled = !string.IsNullOrWhiteSpace(username.Text) 
                && !string.IsNullOrWhiteSpace(password.Text);
        }

        private void Handle_UsernameCompleted(object sender, EventArgs e)
        {
            password.Focus();
        }
    }
}
