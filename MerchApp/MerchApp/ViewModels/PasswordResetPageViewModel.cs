using MerchApp.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MerchApp.ViewModels
{
    public class PasswordResetPageViewModel : INotifyPropertyChanged
    {
        #region Binding Properties
        public DelegateCommand ResetPasswordCommand { get; set; }
        protected INavigationService _navigationService;

        public event PropertyChangedEventHandler PropertyChanged;

        public string EmailEntry { get; set; }
        public string Result { get; set; }
        #endregion

        public PasswordResetPageViewModel()
        {
            ResetPasswordCommand = new DelegateCommand(async () =>
            {
                try { 
                    var current = Connectivity.NetworkAccess;
                    if (current == NetworkAccess.Internet)
                    {
                        if (string.IsNullOrEmpty(EmailEntry))
                        {
                            Result = "All Fields are required";
                        }
                        else if (!IsValidEmail(EmailEntry))
                        {
                            Result = "Invalid Email";
                        }
                        else if(!LoginPageViewModel.UsersList.Any(x => x.Email == EmailEntry))
                        {
                            Result = "Email not resgistered";
                        }
                        else
                        {
                            string password;
                            password = LoginPageViewModel.UsersList.Select(x => x.Password).Where(p => LoginPageViewModel.UsersList.Any(y => y.Email == EmailEntry)).First();
                            try
                            {
                                MailMessage mail = new MailMessage();
                                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                                mail.From = new MailAddress("replydont73@gmail.com");
                                mail.To.Add(EmailEntry);
                                mail.Subject = "PasswordReset";
                                mail.Body = $"Your Password is: {password}, Dont tell anyone ( ͡° ͜ʖ ͡°)";

                                SmtpServer.Port = 587;
                                SmtpServer.UseDefaultCredentials = false;
                                #region Private
                                SmtpServer.Credentials = new System.Net.NetworkCredential("replydont73@gmail.com", "A1B2c3d4");
                                #endregion
                                SmtpServer.EnableSsl = true;

                                SmtpServer.Send(mail);
                                await App.Current.MainPage.DisplayAlert("Warning", "Password Email Sent!", "ok");
                            }
                            catch (Exception ex)
                            {
                                await App.Current.MainPage.DisplayAlert("Error", ex.ToString(), "ok");
                            }
                            await Reset();
                        }
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
            });
        }

        

        async Task Reset()
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
