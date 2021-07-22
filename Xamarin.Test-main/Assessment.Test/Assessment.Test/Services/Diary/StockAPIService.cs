using Assessment.Test.Services.Diary;
using Assessment.Test.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Assessment.Test.Services.Diary
{
    
    public class StockAPIService : IStockAPIService
    {

        public StockAPIService()
        {

        }

        public async Task<T> AddStock<T>(string url)
        {
            T result = default;
            try
            {
                HttpRequestProviderService httpRequestProviderService = new HttpRequestProviderService();
                result = await httpRequestProviderService.GetAsync<T>(url);
            }

            catch (Exception ex){
            
            }
            
            return result;
        }
    }
}
