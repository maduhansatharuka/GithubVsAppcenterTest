using Assessment.Test.Services;
using Assessment.Test.Services.Interfaces;
using Assessment.Test.ViewModels;
using Assessment.Test.Views;
using Assessment.Test.Views.Base;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assessment.Test
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Page page = Activator.CreateInstance(typeof(LoginView)) as Page;
            page.BindingContext = DependencyService.Get<LoginViewModel>();
            MainPage = page;

            
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=244e7463-de05-4d1c-ba12-074955ad619c;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
