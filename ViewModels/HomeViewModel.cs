using CommunityToolkit.Maui.Alerts;
using LJ.Models;
using LJ.Services;
using Newtonsoft.Json;


using System.Collections.ObjectModel;
using System.Globalization;
using System.Net.Http.Headers;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Index = LJ.Models.Index;


namespace LJ.ViewModels
{

    public class HomeViewModel : BaseViewModel
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
        public string Letter { get; set; }
        public bool IsRefreshing { get; set; }
        public bool IsHomeRefreshing { get; set; }
        public string NOC { get; set; }
        public string DateFormate { get; set; }
        public ObservableCollection<Index> HomeData { get; set; }

        ObservableCollection<ProfileModel> stringCollection = new ObservableCollection<ProfileModel>();

        public ObservableCollection<ProfileModel> ProfileData { get; set; } = new ObservableCollection<ProfileModel>();
        public HomeViewModel(HttpServices _httpServices) 
        {
            httpServices = _httpServices;

            HomeData = new ObservableCollection<Index>();

         

            //stringCollection.Add(new ProfileModel
            //{
            //    PhoneNo = "31 - KVW-0.250grms",
            //    Address1= "2024-10-01",
            //});
      

        }
        private async void RefreshData()
        {
            IsBusy = true; 

            await Task.Delay(2000);
            HomeData.Clear();
            GetCustomerList();

            ProfileData.Clear();
            GetProfileCustomerList();

            IsBusy = false;

        }
        public async void NetworkError()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            NetworkAccess accessType = Connectivity.Current.NetworkAccess;

            if (accessType != NetworkAccess.Internet)

            {
                var toast = Toast.Make("No Internet Connection");
                await toast.Show(cancellationTokenSource.Token);
            }
        }
        private ICommand RefreshCommand => new Command(async () =>
        {
            IsBusy = true;

            await Task.Delay(2000);
            ProfileData.Clear();
            GetProfileCustomerList();
            IsBusy = false;
        });

        public ICommand HomeRefreshCommand => new Command(async () =>
        {
            IsBusy = true;
            await Task.Delay(2000);
            HomeData.Clear();
            GetCustomerList();
            IsBusy = false;
        });
        int sum = 0;
        public async Task GetProfileCustomerList()
        {
        
            string MobileNumber = Preferences.Get("MobileNumber", "");
            try
            {
                try
                {
                    var current = Connectivity.NetworkAccess;

                    if (current == NetworkAccess.Internet)
                    {
                        HttpContent formcontent = null;

                        formcontent = new FormUrlEncodedContent(new[]
                                     {
                                    new KeyValuePair<string,string>("CurrentPageNumber",CurrentPageNumber),
                                    new KeyValuePair<string,string>("PageSize",PageSize),
                                    new KeyValuePair<string,string>("dataType",dataType),
                                     new KeyValuePair<string,string>("is_search",is_search),
                                      new KeyValuePair<string,string>("search",MobileNumber),
                                       new KeyValuePair<string,string>("searchField",searchField),
                            });

                        var httpClient = httpServices.HttpClient;
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("accessToken", string.Empty));
                        var request = await httpClient.PostAsync(ApiUrl.Api + "api/customer_list", formcontent);
                        var jsonResult = await request.Content.ReadAsStringAsync();
                        var Result = JsonConvert.DeserializeObject<CustomerListModel>(jsonResult);

                        foreach (Index Data in Result.Index)
                        {
                            sum += int.Parse(Data.NoOfRunningChit);
                            
                        }
                    }
                    Preferences.Set("NOC", sum.ToString());
                }
                catch (Exception ex)
                {

                }
            } catch (Exception ex)
            {

            }
       
        }
        public async void GetCustomerList()
        {
            if (IsLoading)
                return;

            IsLoading = true;
          
            string MobileNumber = Preferences.Get("MobileNumber", "");

            try
            {
                HomeData.Clear();

                try
                {
                    var current = Connectivity.NetworkAccess;

                    if (current == NetworkAccess.Internet)
                    {
                        HttpContent formcontent = null;

                     
                         formcontent = new FormUrlEncodedContent(new[]
                                      {
                                    new KeyValuePair<string,string>("CurrentPageNumber",CurrentPageNumber),
                                    new KeyValuePair<string,string>("PageSize",PageSize),
                                    new KeyValuePair<string,string>("dataType",dataType),
                                    new KeyValuePair<string,string>("is_search",is_search),
                                    new KeyValuePair<string,string>("search",MobileNumber),
                                    new KeyValuePair<string,string>("searchField",searchField),
                                    new KeyValuePair<string,string>("mobile","1"),
                            });
                        
                        var httpClient = httpServices.HttpClient;
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("accessToken", string.Empty));
                        var request = await httpClient.PostAsync(ApiUrl.Api + "api/customer_list", formcontent);
                        var jsonResult = await request.Content.ReadAsStringAsync();
                        var Result = JsonConvert.DeserializeObject<CustomerListModel>(jsonResult);
                       

                        foreach (Index data in Result.Index)
                        {

                            for(int i = 0; i < data.CustomerChitList.Count; i++)
                            {

                                DateTime date1 = DateTime.Parse(data.CustomerChitList[i].DueDate);
                                var DueDate = date1.ToString("dd-MM-yyyy");
            
                                data.CustomerChitList[i].DueDate = DueDate;
                            
                                if (data.CustomerChitList[i].ScameBased == "2")
                                {
                                    data.CustomerChitList[i].PaidAmount = data.CustomerChitList[i].PaidAmount + "grms";
                                }
                                else
                                {
                                    string modifiedString = RemoveDecimalValues(data.CustomerChitList[i].PaidAmount);
                                    data.CustomerChitList[i].PaidAmount = modifiedString;
                                }



                            }


                            string value = data.Name;

                            data.Letter = value.Substring(0, 1);

                            Preferences.Set("Id", data.Id);
                         
                            Preferences.Set("Email", data.EmailId);
                            Preferences.Set("Mobile", data.MobileNo);

                    

                            HomeData.Add(data);

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
            finally
            {
                IsLoading = false;
            }

            static string RemoveDecimalValues(string input)
            {
                int decimalIndex = input.IndexOf('.');

                if (decimalIndex != -1)
                {
                    return input.Substring(0, decimalIndex);
                }

                return input;
            }




        }
}
}
