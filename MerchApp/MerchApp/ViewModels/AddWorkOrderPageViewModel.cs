using MerchApp.Models;
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
        public Ticket WorkOrder { get; set; }
        //IPageDialogService _pageDialog;
        public AddWorkOrderPageViewModel(INavigationService navigationService, IPageDialogService pageDialog)
        {
            _navigationService = navigationService;
            SaveWorkOrderCommand = new DelegateCommand(async () =>
            {
                if (string.IsNullOrEmpty(WorkOrder.ticketNum) ||
                string.IsNullOrEmpty(WorkOrder.Modelo))
                {
                    await App.Current.MainPage.DisplayAlert("Error", "You need to fill the required fiels (*)", "ok");
                }
                else
                {
                    HomePageViewModel.WorkOrderList.Add(WorkOrder);
                }
                await SaveWorkOrder();
            });

            async Task SaveWorkOrder()
            {
                await _navigationService.NavigateAsync(new Uri("/HomeMasterDetailPage/NavigationPage/HomePage/OrderPage", UriKind.Absolute));
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
