using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MerchApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainCapturaDeActivosPage : TabbedPage
    {
        public MainCapturaDeActivosPage()
        {
            InitializeComponent();
            BindingContext = new MainCapturaDeActivosViewModel();
        }
    }
}
