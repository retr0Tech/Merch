using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MerchApp.Views;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using System.Threading;

namespace MerchApp.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand RegisterCommand { get; set; }
        public DelegateCommand ForgotPasswordCommand { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public string Result { get; set; }


        public string DisplayError { get; set; }
        protected INavigationService _navigationService;

        
        public LoginPageViewModel(INavigationService navigationService)
        {
            //var x = User.Email;
            //var y = User.Password;
           _navigationService = navigationService;
            LoginCommand = new DelegateCommand(async () =>
            {
                if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(Password))
                {
                    Result = "Debe llenar todos los campos";
                    Thread.Sleep(2000);
                    Result = string.Empty;
                }
                else
                {
                    await Login();
                }
                
            });

            async Task Login()
            {
                await _navigationService.NavigateAsync(new Uri("/HomeMasterDetailPage/NavigationPage/HomePage", UriKind.Absolute));
            }

            RegisterCommand = new DelegateCommand(async () =>
            {
                await Register();
            });

            async Task Register()
            {
                await _navigationService.NavigateAsync(new Uri("RegisterPage", UriKind.Relative));
            }

            ForgotPasswordCommand = new DelegateCommand(async () =>
            {
                await ForgotPassword();
            });

            async Task ForgotPassword()
            {
                await _navigationService.NavigateAsync(new Uri("PasswordResetPage", UriKind.Relative));
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
