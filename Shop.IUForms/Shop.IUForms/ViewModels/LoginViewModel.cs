namespace Shop.IUForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Shop.IUForms.Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand => new RelayCommand(Login);

        public LoginViewModel()
        {
            this.Email = "fernandolucumi@gmail.com";
            this.Password = "hola1249";
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a password",
                    "Accept");
                return;
            }

            if(!this.Email.Equals("fernandolucumi@gmail.com") || !this.Password.Equals("hola1249")) 
            {
                await Application.Current.MainPage.DisplayAlert(
                 "Error",
                 "Email or password wrong",
                 "Accept");
                return;
            }
            //await Application.Current.MainPage.DisplayAlert(
            //      "Ok",
            //      "!Login Succesfully!",
            //      "Accept");         .      

            MainViewModel.GetInstance().Products = new ProductsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());
        }
    }
}
