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

            //Alertar al usuario qeu si le da al boton de atras la orden no se salva

            async Task SaveWorkOrder()
            {
                await _navigationService.NavigateAsync(new Uri("MainMasterDetailPage/NavigationPage/OrderPage", UriKind.Relative));
            }

            //void ShowAlert()
            //{
            //    _pageDialog.DisplayActionSheetAsync("Alert", "Work order wont be saved", "Ok", "Cancel");
            //}
        }
    }
}
