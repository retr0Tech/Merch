using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MerchApp.Views;
using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;
using MerchApp.Models;
using SQLite;
using Xamarin.Essentials;
using System.Linq;

namespace MerchApp.ViewModels
{
    public class RegisterPageViewModel
    {
        #region Class Properties

        List<User> UsersList = new List<User>();

        #endregion

        #region Binging Properties
        public DelegateCommand RegisterCommand { get; set; }
        protected INavigationService _navigationService;
        public string FirstNameEntry { get; set; }
        public string LastNameEntry { get; set; }
        public string EmailEntry { get; set; }
        public string PasswordEntry { get; set; }
        public string ConfirmPassword { get; set; }
        public string Result { get; set; }
        #endregion

        public RegisterPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            var db = new SQLiteConnection(Preferences.Get("DB_PATH", ""));
            var querry = "SELECT * FROM User";
            try
            {
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
            RegisterCommand = new DelegateCommand(async () =>
            {
                if(string.IsNullOrEmpty(FirstNameEntry) ||
                string.IsNullOrEmpty(LastNameEntry) ||
                string.IsNullOrEmpty(EmailEntry) ||
                string.IsNullOrEmpty(PasswordEntry) ||
                string.IsNullOrEmpty(ConfirmPassword))
                {
                    Result = "You Need to fill all the fields";
                }
                else if(!string.IsNullOrEmpty(FirstNameEntry) &&
                !string.IsNullOrEmpty(LastNameEntry) &&
                !string.IsNullOrEmpty(EmailEntry) &&
                PasswordEntry != ConfirmPassword)
                {
                    Result = "The password dont match";
                }
                else if(!string.IsNullOrEmpty(FirstNameEntry) &&
                !string.IsNullOrEmpty(LastNameEntry) &&
                !string.IsNullOrEmpty(EmailEntry) &&
                UsersList.Any(x => x.Email == EmailEntry))
                {
                    Result = "This email is in use";
                }
                else if (!string.IsNullOrEmpty(FirstNameEntry) &&
                !string.IsNullOrEmpty(LastNameEntry) &&
                !string.IsNullOrEmpty(EmailEntry) &&
                !string.IsNullOrEmpty(PasswordEntry) &&
                !string.IsNullOrEmpty(ConfirmPassword) &&
                !IsValidEmail(EmailEntry))
                {
                    Result = "Invalid Email";
                }
                else
                {
                    User user = new User();
                    user.FirstName = FirstNameEntry;
                    user.LastName = LastNameEntry;
                    user.Email = EmailEntry;
                    user.Password = PasswordEntry;

                    db.Insert(user);
                    await Register();
                }
                
            });

            async Task Register()
            {
                await _navigationService.NavigateAsync(new Uri("/NavigationPage/LoginPage", UriKind.Absolute));
            }
            bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }

        }
    }
}
