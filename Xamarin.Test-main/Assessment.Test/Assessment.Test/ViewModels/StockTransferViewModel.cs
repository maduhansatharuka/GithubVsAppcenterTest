using Assessment.Test.Models;
using Assessment.Test.Services;
using Assessment.Test.Services.Diary;
using Assessment.Test.Utils;
using Assessment.Test.ViewModels;
using Assessment.Test.ViewModels.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

[assembly: Dependency(typeof(StockTransferViewModel))]
namespace Assessment.Test.ViewModels
{
    public class StockTransferViewModel : BaseViewModel
    {
        private ObservableCollection<StockTransferModel> listitems;

        public ObservableCollection<StockTransferModel> Listitems { get => listitems; set => SetProperty(ref listitems, value); }

        public StockTransferViewModel()
        {
            

            
            //listitems = new ObservableCollection<STRootModel>();
            //listitems.Add(new STRootModel { first_name = "A" });
            //listitems.Add(new STRootModel { first_name = "B" });
            //listitems.Add(new STRootModel { first_name = "C" });
            //listitems.Add(new StockTransferModel { first_name = "D" });
            //listitems.Add(new StockTransferModel { first_name = "E" });
            //listitems.Add(new StockTransferModel { first_name = "F" });
            //listitems.Add(new StockTransferModel { first_name = "APPLES" });

            getproducts();
        }

        public async void getproducts()
        {
            //IHttpRequestProviderService httpRequestProviderService = new HttpRequestProviderService();
            //STRootModel sTRootModel = await httpRequestProviderService.GetAsync();
            //Listitems = new ObservableCollection<StockTransferModel>(sTRootModel.Data);
            string url = "https://reqres.in/api/users?page=2";
            StockAPIService stockAPIService = new StockAPIService();
            STRootModel sTRootModel;
            sTRootModel = await stockAPIService.AddStock<STRootModel>(url);
            Listitems = new ObservableCollection<StockTransferModel>(sTRootModel.Data);

        }

        private ICommand _displaylable = null;
        //public ICommand DisplyLable => _displaylable = _displaylable ?? new Command(async () => await DisplyInfor());
        public ICommand DisplyLable => _displaylable = _displaylable ?? new Command<StockTransferModel>((parameter) => DisplyInfor(parameter));
        private async Task DisplyInfor(StockTransferModel produ)
        {
            string pro = produ.First_Name;
            App.Current.MainPage.DisplayAlert("Product",pro, AppConstants.Ok);
        }
    }
}
