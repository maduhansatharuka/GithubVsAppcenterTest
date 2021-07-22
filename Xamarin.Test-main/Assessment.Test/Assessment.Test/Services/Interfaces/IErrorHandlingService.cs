using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Test.Services.Interfaces
{
    public interface IErrorHandlingService
    {
        void LogException(Exception pEx, bool pShowUser = false, [System.Runtime.CompilerServices.CallerMemberName] string pCaller = "");
    }
}
