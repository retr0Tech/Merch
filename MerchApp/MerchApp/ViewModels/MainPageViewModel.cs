using MerchApp.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace MerchApp.ViewModels
{
    public class MainPageViewModel
    {
        protected INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService)
        {
        }
    }
}
