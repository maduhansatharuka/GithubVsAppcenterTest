using Assessment.Test.Models;
using Assessment.Test.ViewModels;
using Assessment.Test.ViewModels.Base;
using Assessment.Test.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

[assembly: Dependency(typeof(LoginViewModel))]
namespace Assessment.Test.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;



        //public Command cmdLogin { get; set; }
        
        public LoginViewModel()
        {
            //cmdLogin = new Command(gotoHomePage);
            //List<UserModel> userList = new List<UserModel>();
            //userList.Add(new UserModel { UserName = "user1", Password = "12345" });
            //userList.Add(new UserModel { UserName = "user2", Password = "54321" });
        }

        //private void gotoHomePage(object obj)
        //{
        //    if (login(userName, password))
        //    {
        //        //App.Current.MainPage.Navigation.PushAsync(new StockTransferView());
        //        //App app=new App();
        //        Page page = Activator.CreateInstance(typeof(StockTransferView)) as Page;
        //        page.BindingContext = DependencyService.Get<StockTransferViewModel>();
        //        //app.MainPage = page;
        //        App.Current.MainPage = page;

        //    }
        //    else
        //    {
        //        LoginMessage = "please enter valid username or password";
        //        TurnLoginMessage = true;
        //    }

        //}

        private ICommand _cmdLogin = null;
        public ICommand CmdLoging => _cmdLogin = _cmdLogin ?? new Command(async () => await Login());

        private async Task Login()
        {
            try
            {
                await GotoHomePage();
            }
            catch (Exception ex)
            {
                
            }
        }

        private async Task GotoHomePage()
        {
            List<UserModel> userList = new List<UserModel>();
            userList.Add(new UserModel { UserName = "user1", Password = "12345" });
            userList.Add(new UserModel { UserName = "user2", Password = "54321" });
            
            foreach (var user in userList)
            {
                if (UserName == user.UserName & Password == user.Password)
                {
                    Page page = Activator.CreateInstance(typeof(StockTransferView)) as Page;
                    page.BindingContext = DependencyService.Get<StockTransferViewModel>();
                    App.Current.MainPage = page;
                }
                else
                {
                    LoginMessage = "Please enter valid username or password";
                    TurnLoginMessage = true;
                }
            }
        }

        private string userName;
        public string UserName { get => userName; set=>SetProperty( ref userName, value); }

        private string password;
        public string Password { get => password; set => SetProperty(ref password, value); }

        private string loginMessage;
        public string LoginMessage { get => loginMessage; set => SetProperty(ref loginMessage, value); }

        private bool turnLoginMessage;
        public bool TurnLoginMessage { get => turnLoginMessage; set => SetProperty(ref turnLoginMessage, value); }


        //private string userName;
        //public string UserName
        //{
        //    get { return userName; }
        //    set
        //    {
        //        userName = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("userName"));
        //    }
        //}

        //private string loginMessage;
        //public string LoginMessage
        //{
        //    get { return loginMessage; }
        //    set
        //    {
        //        loginMessage = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LoginMessage"));
        //    }
        //}

        //private bool turnLoginMessage;
        //public bool TurnLoginMessage
        //{
        //    get { return turnLoginMessage; }
        //    set
        //    {
        //        turnLoginMessage = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TurnLoginMessage"));
        //    }
        //}


        //private string password;
        //public string Password
        //{
        //    get { return password; }
        //    set
        //    {
        //        password = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("password"));
        //    }
        //}

        //List<UserModel> userList = new List<UserModel>();
        //public bool login(string userName, string password)
        //{
        //    foreach (var user in userList)
        //    {
        //        if (userName == user.UserName & password == user.Password)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
