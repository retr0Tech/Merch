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
        public DelegateCommand AddWorkOrderCommand { get; set; }
        protected INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            AddWorkOrderCommand = new DelegateCommand(async () =>
            {
                await AddWorkOrder();
            });

            async Task AddWorkOrder()
            {
                await _navigationService.NavigateAsync(new Uri("NavigationPage/AddWorkOrderPage", UriKind.Relative));
            }
        }
    }
}
