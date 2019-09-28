using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MerchApp.ViewModels
{
    public class AddWorkOrderPageViewModel
    {
        public DelegateCommand SaveWorkOrderCommand { get; set; }
        protected INavigationService _navigationService;
        //IPageDialogService _pageDialog;
        public AddWorkOrderPageViewModel(INavigationService navigationService, IPageDialogService pageDialog)
        {
            _navigationService = navigationService;
            SaveWorkOrderCommand = new DelegateCommand(async () =>
            {
                await SaveWorkOrder();
            });


            async Task SaveWorkOrder()
            {
                await _navigationService.NavigateAsync(new Uri("MainMasterDetailPage/NavigationPage/OrderPage", UriKind.Relative));
            }

            //Display alert if user press back button
            //Alertar al usuario qeu si le da al boton de atras la orden no se salva
            //protected override bool OnBackButtonPressed()
            //{
            //    Device.BeginInvokeOnMainThread(async () => {
            //        var result = await this.DisplayAlert("Alert!", "Do you really want to exit?", "Yes", "No");
            //        if (result) await this.Navigation.PopAsync(); // or anything else
            //    });

            //    return true;
            //}

        }
    }
}
