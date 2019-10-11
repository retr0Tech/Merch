using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MerchApp.ViewModels
{
    public class OrderPageViewModel
    {
        protected INavigationService _navigationService;
        public DelegateCommand EditWorkOrderCommand { get; set; }

        public OrderPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            EditWorkOrderCommand = new DelegateCommand(async () =>
            {
                await AddWorkOrder();
            });

            async Task AddWorkOrder()
            {
                await _navigationService.NavigateAsync(new Uri("/HomeMasterDetailPage/NavigationPage/HomePage", UriKind.Relative));
            }
        }
    }
}
