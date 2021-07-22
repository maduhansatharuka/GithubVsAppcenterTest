using Assessment.Test.Services;
using Assessment.Test.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(ErrorHandlingService))]
namespace Assessment.Test.Services
{
    public class ErrorHandlingService : IErrorHandlingService
    {
        public void LogException(Exception pEx, bool pShowUser = false, [System.Runtime.CompilerServices.CallerMemberName] string pCaller = "")
        {
            Debug.WriteLine(pEx);
        }
    }
}
