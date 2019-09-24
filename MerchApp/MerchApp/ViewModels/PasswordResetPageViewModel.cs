using MerchApp.Views;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MerchApp.ViewModels
{
    public class PasswordResetPageViewModel
    {
        public DelegateCommand ResetPasswordCommand { get; set; }
        public PasswordResetPageViewModel()
        {
            ResetPasswordCommand = new DelegateCommand(async () =>
            {
                //Codigo resetea contrasena de usuario
                await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
            });
        }

    }
}
