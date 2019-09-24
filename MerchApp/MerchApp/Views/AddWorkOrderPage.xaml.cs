using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MerchApp.ViewModels;

namespace MerchApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddWorkOrderPage : ContentPage
    {
        public AddWorkOrderPage()
        {
            InitializeComponent();
            //BindingContext = new AddWorkOrderPageViewModel();
        }
    }
}