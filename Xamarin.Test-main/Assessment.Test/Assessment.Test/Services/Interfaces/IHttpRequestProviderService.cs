using Assessment.Test.Models;
using Assessment.Test.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Test.Services
{
    public interface IHttpRequestProviderService
    {

        /// <summary>
        /// HTTP POST
        /// </summary>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostAsync(string url, object content);
        Task<T> GetAsync<T>(string url);
    }
}
