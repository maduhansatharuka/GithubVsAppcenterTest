using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Test.Services.Interfaces
{
    public interface IStockAPIService
    {
        Task<T> AddStock<T>(string url);
    }
}
