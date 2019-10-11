using MerchApp.Models;
using MerchApp.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MerchApp.ViewModels
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        #region Binding Properties

        IApiService apiService = new ApiService();
        protected INavigationService _navigationService;

        public event PropertyChangedEventHandler PropertyChanged;
        public static ObservableCollection<Ticket> WorkOrderList { get; set; }
        public DelegateCommand AddWorkOrderCommand { get; set; }
        public ICommand DeleteElementOrder { get; set; }

        #endregion

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            
            AddWorkOrderCommand = new DelegateCommand(async () =>
            {
                await AddWorkOrder();
            });
            LoadTickets().Wait();
            
            DeleteElementOrder = new Command<Ticket>(async (param) =>
            {
                WorkOrderList.Remove(param);
            });
            async Task AddWorkOrder()
            {
                await _navigationService.NavigateAsync(new Uri("/AddWorkOrderPage", UriKind.Relative));
            }
        }

        private async Task LoadTickets()
        {
            try
            {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {
                    var rate = await apiService.GetVariousTickets("20");
                    WorkOrderList = rate;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "You don't have internet connection", "Ok");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Unable to connect to the server", "Ok");
            }
        }
    }
}
