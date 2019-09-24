using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MerchApp.Views;
using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;

namespace MerchApp.ViewModels
{
    public class RegisterPageViewModel
    {
        public DelegateCommand RegisterCommand { get; set; }
        protected INavigationService _navigationService;
        public RegisterPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            RegisterCommand = new DelegateCommand(async () =>
            {
                //Codigo que guarda el usuario registrado
                await Register();
            });

            async Task Register()
            {
                await _navigationService.NavigateAsync(new Uri("/MasterDetailPage", UriKind.Absolute));
            }

        }
    }
}
