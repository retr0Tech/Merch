using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MerchApp.ViewModels
{
    public class HomePageViewModel
    {
        protected INavigationService _navigationService;
        public DelegateCommand AddWorkOrderCommand { get; set; }
        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            AddWorkOrderCommand = new DelegateCommand(async () =>
            {
                await AddWorkOrder();
            });

            async Task AddWorkOrder()
            {
                await _navigationService.NavigateAsync(new Uri("/AddWorkOrderPage", UriKind.Relative));
            }
        }
    }
}
