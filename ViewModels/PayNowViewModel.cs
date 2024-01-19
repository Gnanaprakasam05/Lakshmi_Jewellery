using LJ.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LJ.Models;

namespace LJ.ViewModels
{
    public class PayNowDataModel
    {
        public string Name { get; set; }
        public string SchemeName { get; set; }
        public string Code { get; set; }

    }

    public class Value
    {
        public string Name { get; set; }
        public string SchemeName { get; set; }
        public string Code { get; set; }
        public string DueAmount_Weight { get; set; }
    }
    public class PayNowViewModel : BaseViewModel
    {
        private readonly HttpServices httpServices;

        private static string dataType = "str";
        private static string is_search = "1";
        private static string search = "7339293078";
        private static string searchField = "customers.mobile_no";
        public static string CurrentPageNumber = "1";
        public static string PageSize = "25";

        private static string search1 = "38526";
        private static string searchField1 = "customers.id";
        private static string show_only_current_chit = "1";
        public string RelationID { get; set; }
        public ObservableCollection<PayNowDataModel> PayNowData { get; set; } = new ObservableCollection<PayNowDataModel>();
        public ObservableCollection<Datum> PayNow { get; set; } = new ObservableCollection<Datum>();
        public string DateFormate1 { get; set; }
        public bool IsPaynowRefreshing { get; set; }

        public PayNowViewModel(string id, HttpServices httpClientFactory)
        {
            this.httpServices = httpClientFactory;

            RelationID = id;
            

        }

        public async void RefreshData()
        {
            IsBusy = true;

            await Task.Delay(2000);
            PayNow.Clear();
            PayNowData.Clear();
            GetChitCustomerCollectionDueList();
            GetChitCustomerViewPassbook();

            IsBusy = false;


        }
        public async void GetChitCustomerViewPassbook()
        {


            try
            {
                PayNowData.Clear();
                try
                {

                     //string ID = Preferences.Get("CustomerID", string.Empty);
                    var current = Connectivity.NetworkAccess;

                    if (current == NetworkAccess.Internet)
                    {
                        HttpContent formcontent = null;


                        var formcontent1 = new FormUrlEncodedContent(new[]
                                      {
                               new KeyValuePair<string,string>("CurrentPageNumber",CurrentPageNumber),
                                    new KeyValuePair<string,string>("PageSize",PageSize),
                                    new KeyValuePair<string,string>("dataType",dataType),
                                     new KeyValuePair<string,string>("is_search",is_search),
                                      new KeyValuePair<string,string>("search",Preferences.Get("CustomerID", string.Empty)),
                                       new KeyValuePair<string,string>("searchField",searchField1),
                                       new KeyValuePair<string,string>("show_only_current_chit",show_only_current_chit),
                            });
                        var httpClient = httpServices.HttpClient;
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("accessToken", string.Empty));
                        var request = await httpClient.PostAsync(ApiUrl.Api + "api/chit_customer_list", formcontent1);
                        var jsonResult = await request.Content.ReadAsStringAsync();
                        var Result = JsonConvert.DeserializeObject<CollectionPayNowModel>(jsonResult);


                        foreach (var data1 in Result.Index)
                        {

                            if (RelationID == data1.Id)
                            {
                                Preferences.Set("CustomerName", data1.CustomerName);


                                PayNowData.Add(new PayNowDataModel
                                {
                                    Name = data1.CustomerName,
                                    SchemeName = data1.ChitSchemeName,
                                    Code = data1.ChitCode,

                                });
                            }


                        }

                    }
                }
                catch (Exception ex)
                {

                }
            }
            catch (Exception ex)
            {

            }












        }
        public async Task<ObservableCollection<Datum>> GetChitCustomerCollectionDueList( )
        {

            try
            {
                PayNow.Clear();
                try
                {
                    var current = Connectivity.NetworkAccess;

                    if (current == NetworkAccess.Internet)
                    {
                        HttpContent formcontent = null;

                        string MobileNumber = Preferences.Get("MobileNumber", "");

                        var formcontent1 = new FormUrlEncodedContent(new[]
                                      {
                                    new KeyValuePair<string,string>("mobile_no",MobileNumber),

                            });
                        var httpClient = httpServices.HttpClient;
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("accessToken", string.Empty));
                        var request = await httpClient.PostAsync(ApiUrl.Api + "api/chit_customer_collection_due_list", formcontent1);
                        var jsonResult = await request.Content.ReadAsStringAsync();
                        var Result = JsonConvert.DeserializeObject<ChitCustomerCollectionDueListModel>(jsonResult);


                        foreach (var data in Result.Data.OrderBy( x => x.DueNo).ToList())
                        {


                            if (data.Id == RelationID)
                            {
                                DateTime date = DateTime.Parse(data.DueDate);
                                DateFormate1 = date.ToString("dd-MM-yyyy");


                                if (data.DueWeight == "0.000")
                                {
                                    

                                    PayNow.Add(new Datum
                                    {
                                        DueNo = data.DueNo,
                                        PaidAmount = data.PaidAmount,
                                        DueDate = DateFormate1,

                                        ChitSchemeId = data.ChitSchemeId,
                                        CollectionId = data.CollectionId,
                                        CustomerId = data.CustomerId,
                                        Id = data.Id,

                                    });
                                }
                                if (data.DueAmount == "0.00")
                                {
                                    

                                    PayNow.Add(new Datum
                                    {
                                        DueNo = data.DueNo,
                                        PaidAmount = data.PaidAmount,
                                        DueDate = DateFormate1,
                                    });
                                }
                            }
                        }
                    }
                }


                catch (Exception ex)
                {

                }
            }
            catch (Exception ex)
            {

            }

            return PayNow;
        }
    }
}
