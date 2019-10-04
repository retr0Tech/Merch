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

namespace MerchApp.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand RegisterCommand { get; set; }
        public DelegateCommand ForgotPasswordCommand { get; set; }

        public string DisplayError { get; set; }
        protected INavigationService _navigationService;

        public LoginPageViewModel()
        {
            LoginCommand = new DelegateCommand(async () =>
            {
                await Login();
            });

            async Task Login()
            {
                await _navigationService.NavigateAsync(new Uri("NavigationPage/HomeMasterDetailPage", UriKind.Absolute));
            }

            RegisterCommand = new DelegateCommand(async () =>
            {
                await Register();
            });

            async Task Register()
            {
                await _navigationService.NavigateAsync(new Uri("NavigationPage/RegisterPage", UriKind.Relative));
            }

            ForgotPasswordCommand = new DelegateCommand(async () =>
            {
                await ForgotPassword();
            });

            async Task ForgotPassword()
            {
                await _navigationService.NavigateAsync(new Uri("NavigationPage/PasswordResetPage", UriKind.Relative));
            }
        }
        public LoginPageViewModel(INavigationService navigationService)
        {
            //var x = User.Email;
            //var y = User.Password;
           _navigationService = navigationService;
            LoginCommand = new DelegateCommand(async () =>
            {
                await Login();
            });

            async Task Login()
            {
                await _navigationService.NavigateAsync(new Uri("NavigationPage/HomeMasterDetailPage", UriKind.Absolute));
            }

            RegisterCommand = new DelegateCommand(async () =>
            {
                await Register();
            });

            async Task Register()
            {
                await _navigationService.NavigateAsync(new Uri("NavigationPage/RegisterPage", UriKind.Relative));
            }

            ForgotPasswordCommand = new DelegateCommand(async () =>
            {
                await ForgotPassword();
            });

            async Task ForgotPassword()
            {
                await _navigationService.NavigateAsync(new Uri("NavigationPage/PasswordResetPage", UriKind.Relative));
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
