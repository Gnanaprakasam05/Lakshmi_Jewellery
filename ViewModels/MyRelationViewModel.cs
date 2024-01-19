using LJ.Models;
using LJ.Services;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Windows.Input;

namespace LJ.ViewModels
{

    public class MyRelationViewModel : BaseViewModel
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


        private string ID;

        public string Title1 = "Due Weight";

        public string Title2 = "Due Amount";
        public bool IsHomeRefreshing { get; set; }

        public string RelationID { get; set; }
        public ObservableCollection<MyRelationModel> RelationData { get; set; } = new ObservableCollection<MyRelationModel>();

        public ObservableCollection<Datum> PayNow { get; set; } 
        public MyRelationViewModel(string id = null, HttpServices _httpServices = null) 
        {

            ID = id;

            PayNow = new ObservableCollection<Datum>();

            httpServices = _httpServices;
        }

        public ICommand RefreshData => new Command(async () =>
        {
            IsBusy = true;
            await Task.Delay(2000);
            RelationData.Clear();
            GetChitCustomerViewPassbook();
            IsBusy = false;
        });
      
        public async void GetChitCustomerViewPassbook()
        {

            try
            {
                RelationData.Clear();

                try
                {
                    var current = Connectivity.NetworkAccess;

                    string Id = Preferences.Get("Id", "");

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

                    foreach (var data in Result.Index)
                    {
                        if (data.MonthlyDue == "0")
                        {
                            RelationData.Add(new MyRelationModel
                            {
                                Id = data.Id,
                                TransactionId = data.TransactionId,
                                ChitCodeId = data.ChitCodeId,
                                TransactionDate = data.TransactionDate,
                                JoinDate = data.JoinDate,
                                TransactionTime = data.TransactionTime,
                                CustomerId = data.CustomerId,
                                ChitSchemeId = data.ChitSchemeId,
                                ChitCode = data.ChitCode,
                                CustomerName = data.CustomerName,
                                ChitSchemeName = data.ChitSchemeName,
                                NoOfMonths = data.NoOfMonths,
                                MonthlyDue = data.MonthlyDueWeight,
                                BonusMonth = data.BonusMonth,
                                SchemeBased = data.SchemeBased,
                                IsArchive = data.IsArchive,
                                TotalPaidAmount = data.TotalPaidAmount,
                                PendingDues = data.PendingDues,
                                SetActive = data.SetActive,
                                MaturityDate = data.MaturityDate,

                                Title = Title1,
                            });


                        }
                        if (data.MonthlyDueWeight == "0")
                        {
                            RelationData.Add(new MyRelationModel
                            {
                                Id = data.Id,
                                TransactionId = data.TransactionId,
                                ChitCodeId = data.ChitCodeId,
                                TransactionDate = data.TransactionDate,
                                JoinDate = data.JoinDate,
                                TransactionTime = data.TransactionTime,
                                CustomerId = data.CustomerId,
                                ChitSchemeId = data.ChitSchemeId,
                                ChitCode = data.ChitCode,
                                CustomerName = data.CustomerName,
                                ChitSchemeName = data.ChitSchemeName,
                                NoOfMonths = data.NoOfMonths,
                                BonusMonth = data.BonusMonth,
                                SchemeBased = data.SchemeBased,
                                IsArchive = data.IsArchive,
                                TotalPaidAmount = data.TotalPaidAmount,
                                PendingDues = data.PendingDues,
                                SetActive = data.SetActive,
                                MaturityDate = data.MaturityDate,
                                Title = Title2,
                                MonthlyDue = data.MonthlyDue,
                            });

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

        public async Task<ObservableCollection<Datum>> GetChitCustomerCollectionDueListData( string Relation_ID)
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


                        foreach (var data in Result.Data.OrderBy(x => x.DueNo).ToList())
                        {


                            if (data.Id == Relation_ID)
                            {
                               
                                if (data.DueWeight == "0.000")
                                {

                                    PayNow.Add(new Datum
                                    {
                                        DueNo = data.DueNo,
                                        PaidAmount = data.PaidAmount,
                                        DueDate = data.DueDate,

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
                                        DueDate = data.DueDate,
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
