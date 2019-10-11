using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MerchApp.Views;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using System.Threading;
using SQLite;
using Xamarin.Essentials;
using MerchApp.Models;
using System.Linq;

namespace MerchApp.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        #region Class Propeties

        public static List<User> UsersList = new List<User>();
        public static string currentUser;

        #endregion

        #region Binding Properties

        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand RegisterCommand { get; set; }
        public DelegateCommand ForgotPasswordCommand { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public string Result { get; set; }


        public string DisplayError { get; set; }
        protected INavigationService _navigationService;

        #endregion

        public LoginPageViewModel(INavigationService navigationService)
        {

           _navigationService = navigationService;
            var db = new SQLiteConnection(Preferences.Get("DB_PATH", ""));
            var querry = "SELECT * FROM User";
            try
            {
                //Ejecutamos el query.
                var register = db.Query<User>(querry);

                if (register.First().FirstName == null)
                {
                    //Dont do anything for now
                }
                else
                {
                    UsersList = register;
                }

            }
            catch
            {

            }

            LoginCommand = new DelegateCommand(async () =>
            {
                if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(Password))
                {
                    Result = "You Need to fill all the fields";
                }
                else
                {
                    for (int i = 0; i < UsersList.Count; i++)
                    {
                        if (UsersList[i].Email == email && UsersList[i].Password == Password)
                        {
                            currentUser = email;
                            db.Close();
                            email = string.Empty;
                            Password = string.Empty;
                            await Login();
                            return;
                        }
                    }

                    Result = "Incorrect email or password";
                    email = string.Empty;
                    Password = string.Empty;
                    return;
                    
                }
                

            });

            async Task Login()
            {
                await _navigationService.NavigateAsync(new Uri("/HomeMasterDetailPage/NavigationPage/HomePage", UriKind.Absolute));
            }

            RegisterCommand = new DelegateCommand(async () =>
            {
                await Register();
            });

            async Task Register()
            {
                await _navigationService.NavigateAsync(new Uri("RegisterPage", UriKind.Relative));
            }

            ForgotPasswordCommand = new DelegateCommand(async () =>
            {
                await ForgotPassword();
            });

            async Task ForgotPassword()
            {
                await _navigationService.NavigateAsync(new Uri("PasswordResetPage", UriKind.Relative));
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
