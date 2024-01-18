using LJ.Models;
using LJ.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace LJ.ViewModels
{
    public class Model
    {

        public string Name { get; set; }
        public string SchemeName { get; set; }
        public string Code { get; set; }
        public string JoiningData { get; set; }
        public string MaturityData { get; set; }
    }
    public class PassBookViewModel : BaseViewModel
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






        public string Title1 = "Due Weight";
        public string Title2 = "Due Amount";

        public string Title3 = "Weight";
        public string Title4 = "";
        public string Title5 = ":";
        public string JoinDate { get; set; }
        public string DateFormate1 { get; set; }
        public string RelationID { get; set; }
        public string MaturityData { get; set; }
        public bool IsRefresh { get; set; }
        public ObservableCollection<ViewPassBookDataModel> ViewPassBook { get; set; } = new ObservableCollection<ViewPassBookDataModel>();
        public ObservableCollection<Model> ViewPass { get; set; } = new ObservableCollection<Model>();

        private string ID_Valuer;
        public PassBookViewModel(string id , HttpServices httpClientFactory)
        {
            httpServices = httpClientFactory;

            ID_Valuer = id;


        }


        public async void GetChitCustomerViewPassbook()
        {


            try
            {
                ViewPass.Clear();
                try
                {
                    string ID = Preferences.Get("CustomerID", string.Empty);

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
                                      new KeyValuePair<string,string>("search",ID),
                                       new KeyValuePair<string,string>("searchField",searchField1),
                                       new KeyValuePair<string,string>("show_only_current_chit",show_only_current_chit),
                            });
                        var httpClient = httpServices.HttpClient;
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("accessToken", string.Empty));
                        var request = await httpClient.PostAsync(ApiUrl.Api + "api/chit_customer_list", formcontent1);
                        var jsonResult = await request.Content.ReadAsStringAsync();
                        var Result = JsonConvert.DeserializeObject<ChitCustomerListModel>(jsonResult);

                            foreach (var data1 in Result.Index)
                            {

                                if (ID_Valuer == data1.Id)
                                {
                                    DateTime date1 = DateTime.Parse(data1.JoinDate);
                                    JoinDate = date1.ToString("dd-MM-yyyy");


                                    DateTime date2 = DateTime.Parse(data1.MaturityDate);
                                    MaturityData = date2.ToString("dd-MM-yyyy");

                                                       
                                    ViewPass.Add(new Model
                                    {
                                        Name = data1.CustomerName,
                                        SchemeName = data1.ChitSchemeName,
                                        Code = data1.ChitCode,
                                        JoiningData = JoinDate,
                                        MaturityData = MaturityData,
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
        
        public async void GetCustomerViewPassbook()
        {

            try
            {
                ViewPassBook.Clear();
                try
                {
                    var current = Connectivity.NetworkAccess;

                    if (current == NetworkAccess.Internet)
                    {
                        HttpContent formcontent = null;

                        var formcontent1 = new FormUrlEncodedContent(new[]
                           {
                                    new KeyValuePair<string,string>("chit_code_id",ID_Valuer),

                            });
                        var httpClient = httpServices.HttpClient;
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("accessToken", string.Empty));
                        var request = await httpClient.PostAsync(ApiUrl.Api + "api/chit_collection_pass_book", formcontent1);
                        var jsonResult = await request.Content.ReadAsStringAsync();
                        var Result = JsonConvert.DeserializeObject<List<ViewPassbookModel>>(jsonResult);

                        foreach (var data in Result)
                        {
                            DateTime date = DateTime.Parse(data.ReceiptDate);
                            DateFormate1 = date.ToString("dd-MM-yyyy");

                            if (data.DueAmount == "0.00")
                            {
                          
                              

                                ViewPassBook.Add(new ViewPassBookDataModel
                                {
                                    Id = data.Id,
                                    TransactionId = data.TransactionId,
                                    DetailId = data.DetailId,
                                    ReceiptNo = data.ReceiptNo,
                                    CollectionDate = data.CollectionDate,
                                    ReceiptDate = DateFormate1,
                                    CustomerId = data.CustomerId,
                                    CustomerName = data.CustomerName,
                                    ChitSchemeId = data.ChitSchemeId,
                                    ChitCodeId = data.ChitCodeId,
                                    ChitCodeName = data.ChitCodeName,
                                    InsNo = data.InsNo,
                                    ChitSchemeName = data.ChitSchemeName,
                                    Weight = data.Weight,
                                    TotalWeight = data.TotalWeight,
                                    Rate = data.Rate,
                                    SchemeBased = data.SchemeBased,
                                    PaymentType = data.PaymentType,
                                    TitleAmount_Weight = Title1,
                                    Title_Weight = Title3,
                                    Title_Colon = Title5,
                                    DueAmount = data.DueWeight,
                                });


                            }
                            if (data.DueWeight == "0.000")
                            {
                                ViewPassBook.Add(new ViewPassBookDataModel
                                {
                                    Id = data.Id,
                                    TransactionId = data.TransactionId,
                                    DetailId = data.DetailId,
                                    ReceiptNo = data.ReceiptNo,
                                    CollectionDate = data.CollectionDate,
                                    ReceiptDate = DateFormate1,
                                    CustomerId = data.CustomerId,
                                    CustomerName = data.CustomerName,
                                    ChitSchemeId = data.ChitSchemeId,
                                    ChitCodeId = data.ChitCodeId,
                                    ChitCodeName = data.ChitCodeName,
                                    InsNo = data.InsNo,
                                    ChitSchemeName = data.ChitSchemeName,
                                    Weight = data.Weight,
                                    TotalWeight = data.TotalWeight,
                                    Rate = data.Rate,
                                    SchemeBased = data.SchemeBased,
                                    PaymentType = data.PaymentType,
                                    TitleAmount_Weight = Title2,
                                    Title_Weight = Title4,
                                    Title_Colon = Title4,
                                    DueAmount = data.DueAmount,
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
    }
}
