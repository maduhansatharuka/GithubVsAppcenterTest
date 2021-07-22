using Assessment.Test.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assessment.Test.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView 
    {
        public HomeView()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                DependencyService.Get<IErrorHandlingService>()?.LogException(ex);
            }
        }
    }
}