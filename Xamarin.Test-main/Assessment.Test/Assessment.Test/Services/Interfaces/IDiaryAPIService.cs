using Assessment.Test.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Test.Services.Interfaces
{
    public interface IDiaryAPIService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="diaryModel"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> AddNewDiary(DiaryModel diaryModel);
    }
}
