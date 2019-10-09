using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchApp.ViewModels
{
    public class OrderPageViewModel
    {
        protected INavigationService _navigationService;
        public OrderPageViewModel(INavigationService navigationService) 
        {
            _navigationService = navigationService;
        }
    }
}
