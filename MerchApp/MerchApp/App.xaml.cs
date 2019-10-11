using MerchApp.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MerchApp.ViewModels;
using System.IO;
using Xamarin.Essentials;
using SQLite;
using MerchApp.Models;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MerchApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null): base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(new Uri("/NavigationPage/LoginPage", UriKind.Absolute));
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "XamlClass.db");
            Preferences.Set("DB_PATH", dbPath);
            Preferences.Set("VERSION", "1.28.5.19.1");
            var db = new SQLiteConnection(dbPath);

            db.CreateTable<User>();

            if ((Preferences.Get("FIRST_BOOT", true)))
            {
                User user = new User();

                user.FirstName = "Elliot";
                user.LastName = "Ruiz";
                user.Email = "elliot-ruizmelo@hotmail.com";
                user.Password = "1";

                db.Insert(user);

                //Indices de la Tabla
                Task.Factory.StartNew(() =>
                {
                    Debug.WriteLine("Creating indexes");
                    db.CreateIndex("User", "FirstName", true);
                    Debug.Write("Done! Creating indexes");
                });

                Preferences.Set("FIRST_BOOT", false);
            }
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<AddWorkOrderPage, AddWorkOrderPageViewModel>();
            containerRegistry.RegisterForNavigation<HomeMasterDetailPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<PasswordResetPage, PasswordResetPageViewModel>();
            containerRegistry.RegisterForNavigation<OrderPage, OrderPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
        }
    }
}
