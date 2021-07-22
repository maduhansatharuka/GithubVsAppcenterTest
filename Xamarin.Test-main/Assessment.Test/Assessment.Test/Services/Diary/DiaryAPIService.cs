using Assessment.Test.Models;
using Assessment.Test.Services.Diary;
using Assessment.Test.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(DiaryAPIService))]
namespace Assessment.Test.Services.Diary
{
    public class DiaryAPIService : IDiaryAPIService
    {
        #region Constructors & initialisation

        public DiaryAPIService(
            IHttpRequestProviderService pHttpRequestProviderService)
        {
            httpRequestProviderService = pHttpRequestProviderService;
            _constructor();
        }
        public DiaryAPIService()
        {
            httpRequestProviderService = DependencyService.Get<IHttpRequestProviderService>();
            _constructor();
        }
        private void _constructor()
        {

        }

        #endregion

        #region Services

        private readonly IHttpRequestProviderService httpRequestProviderService;

        #endregion

        #region Methods
        public async Task<HttpResponseMessage> AddNewDiary(DiaryModel diaryModel)
        {
            HttpResponseMessage info;
            try
            {
                string URL = Constants.BaseURL;
                info = await httpRequestProviderService.PostAsync(URL, diaryModel);
            }
            catch (Exception)
            {
                throw;
            }
            return info;
        }
        #endregion
    }
}
