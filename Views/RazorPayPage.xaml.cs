using LJ.Models;
using LJ.Services;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace LJ.Views;
public class ResponseRazorpaySuccessMessage
{
    [JsonProperty("success")]
    public bool Success;
}

public partial class RazorPayPage : ContentPage
{


    private readonly HttpServices httpServices;


    private static string amount { get; set; }
    private static string currency { get; set; }
    private static string receipt { get; set; }

    private static string apiKey = "rzp_test_Gyt3Usf1nNi9Rr";

    private static string apiSecret = "alnHJbZrsnM9IPUl1SsrNEza";

    private static string email = Preferences.Get("Email", string.Empty);

    private static string name = Preferences.Get("CustomerName", string.Empty);

    private static string mobile = Preferences.Get("Mobile", string.Empty);
    public RazorPayPage(HttpServices _httpServices)
    {

      
        InitializeComponent();


        this.httpServices = _httpServices;

        Loaded += RazorPay_Loaded;


        myWebView.Source = new HtmlWebViewSource
        {
            Html = @"<HTML>
                          <HEAD>
                                
                          </HEAD>
                          <BODY >
                            <script src=""https://checkout.razorpay.com/v1/checkout.js""></script>
                            <script>
                                    var temp=[];
                                    openpaymentscreen(value);

                                    function  openpaymentscreen(value)
                                    {


                                        const inputString = value;
                                        const splitValues = inputString.split(',');
                                        var Name = splitValues[0];
                                        var Amount = splitValues[1];
                                        var Email = splitValues[2];
                                        var Key = splitValues[3];
                                        var Order_Id = splitValues[4];
                                        var Currency =splitValues[5];
                                        var Mobile = splitValues[6];
                                        var email = splitValues[2];
                                        var ApiSecret = splitValues[7];


                                    var options = {

                                                        ""key"": Key, 

                                                        ""amount"": Amount, 

                                                        ""currency"": ""INR"",

                                                        ""name"": Name, 

                                                        ""description"": ""Test Transaction"",

                                                        ""image"": ""https://s3.amazonaws.com/rzp-mobile/images/rzp.png"",

                                                        ""order_id"": Order_Id,

                                                      ""handler"": function (response){
                                                       var Razorpay_Id = response.razorpay_payment_id;
                                                       var Razorpay_Order_Id =  response.razorpay_order_id;
                                                       var Razorpay_Signature =  response.razorpay_signature;

var urlName = ""https://eneqd3r9zrjok.x.pipedream.net/"";

                                                                if (typeof(Razorpay_Id) == ""undefined"" ||  Razorpay_Id < 1) {
                                                                  Error()
                                                                } 
                                                                else 
                                                                {
                                                                Success(urlName);
                                                                }


                                                             },

                                                        ""prefill"": { 

                                                            ""name"": Name, 
                                                            ""email"": email ,

                                                            ""contact"": Mobile
                                                                     },
                                                        ""notes"": {
                                                            ""address"": ""Razorpay Corporate Office""
                                                                   },
                                                        ""theme"": {
                                                            ""color"": ""#3399cc""
                                                                   }
                                                     };

function Success(urlName)
{
       //temp[0]=response.razorpay_signature;
   

  var value = urlName;
callc(value);

}
function Error()
{

}

                                                             var rzp1 = new Razorpay(options);

                                                                        rzp1.on('payment.failed', function (response){
                                                                                //response.error.code;
                                                                                //response.error.description;
                                                                                //response.error.source;
                                                                                //response.error.step;
                                                                                //response.error.reason;
                                                                                //response.error.metadata.order_id;
                                                                                //response.error.metadata.payment_id;
        //alert(response.error.code);
        //alert(response.error.description);
        //alert(response.error.source);
        //alert(response.error.step);
        //alert(response.error.reason);
        alert(response.error.metadata.order_id);
        alert(response.error.metadata.payment_id);
                                                                        });

                                
                                                                        


                                                             rzp1.open();
                                                             e.preventDefault();

                                           
                                                          

                                       }

function callc(value)
{
var urlName = value;
window.location.href = urlName;

}                         



                            </script>
                          </BODY>
                     </HTML>"
        };

    }

    private async void RazorPay_Loaded(object sender, EventArgs e)
    {

        string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int randomLength = 6;
        int minNumber = 100000;
        int maxNumber = 999999;

        StringBuilder refNoBuilder = new StringBuilder();
        Random random = new Random();

        for (int i = 0; i < randomLength; i++)
        {
            int randomIndex = random.Next(characters.Length);
            char randomChar = characters[randomIndex];
            refNoBuilder.Append(randomChar);
        }

        int randomNumber = random.Next(minNumber, maxNumber);

        refNoBuilder.Append(randomNumber);

        string refNo = refNoBuilder.ToString();

        string credentials = $"{apiKey}:{apiSecret}";

        string base64Credentials = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(credentials));

        var GetAmount = Preferences.Get("DueAmount", string.Empty);
        decimal decimalValue = decimal.Parse(GetAmount);
        int IntAmount = (int)decimalValue;

        amount = (IntAmount * 100).ToString();
        currency = "INR";
        receipt = refNo;
        var formcontent = new FormUrlEncodedContent(new[]
                         {
                                            new KeyValuePair<string,string>("amount",amount),
                                            new KeyValuePair<string,string>("currency",currency),
                                            new KeyValuePair<string,string>("receipt",receipt),
        });

        var httpClient = httpServices.HttpClient;
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Credentials);
        var request = await httpClient.PostAsync("https://api.razorpay.com/v1/orders", formcontent);
        var jsonResult = await request.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<RazorpayModel>(jsonResult);

        Preferences.Set("ID", result.Id);
        Preferences.Set("Amount", result.Amount);
        Preferences.Set("Currency", result.Currency);
        Preferences.Set("Receipt", result.Receipt);
        Preferences.Set("CreatedAt", result.CreatedAt);
        Preferences.Set("Status", result.Status);
        Preferences.Set("OfferId", result.OfferId);

        string SendName = Preferences.Get("CustomerName", string.Empty);
        string Amount = Preferences.Get("Amount", string.Empty);
        string Email = Preferences.Get("Email", string.Empty); ;
        string key = "rzp_test_Gyt3Usf1nNi9Rr";
        string order_id = Preferences.Get("ID", string.Empty);
        string Currency = Preferences.Get("Currency", string.Empty);
        string Mobile = Preferences.Get("Mobile", string.Empty);
        var Status = Preferences.Get("Status", string.Empty);
        string ApiSecret = "alnHJbZrsnM9IPUl1SsrNEza";
        // Execute JavaScript function in the WebView


        var res = await myWebView.EvaluateJavaScriptAsync(
         $"openpaymentscreen('{SendName},{Amount},{Email},{key},{order_id},{Currency},{Mobile},{ApiSecret}')");

        //if (res == "Success")
        //{
        //    await DisplayAlert("message", res, "OK");
        //}
        //else
        //{
        //    await DisplayAlert("Error"," ", "OK");
        //}



        //await DisplayAlert("Message", res, "Ok");
        //getData(res);

        //if(Status == "created")
        //{

        //    var ChitSchemeId = Preferences.Get("ChitSchemeId", string.Empty);
        //    var CollectionId = Preferences.Get("CollectionId", string.Empty);
        //    var CustomerId = Preferences.Get("CustomerId", string.Empty);
        //    var DueNo = Preferences.Get("DueNo", string.Empty);
        //    var Id = Preferences.Get("Id", string.Empty);







        //    Dictionary<string, string> formData = new Dictionary<string, string>
        //    {
        //        {"txn_no", order_id},
        //        {"card_holder_name", SendName},
        //        {"paid_amount", Amount},
        //        {"transaction_details[0][chit_scheme_id]", ChitSchemeId},
        //        {"transaction_details[0][collection_id]", CollectionId},
        //        {"transaction_details[0][customer_id]", CustomerId},
        //        {"transaction_details[0][due_no]", DueNo},
        //        {"transaction_details[0][id]", Id}
        //    };


        //    var content = new FormUrlEncodedContent(formData);


        //        var storeHttpClient = _httpClientFactory.CreateClient();
        //       storeHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("accessToken", string.Empty));
        //        var storeRequest = await storeHttpClient.PostAsync(ApiUrl.Api + "api/store_payment_details", content);
        //        var storeJsonResult = await storeRequest.Content.ReadAsStringAsync();
        //        var Result = JsonConvert.DeserializeObject<ResponseStorePaymentDetails>(storeJsonResult);


        //}

        //await Navigation.PopAsync();

    }
    private async void RazorpaySuccessPayment(object sender, WebNavigatingEventArgs e)
    {
        var urlParts = e.Url;


        e.Cancel = true;

        var ReceiveHttpClient = httpServices.HttpClient;
        var ReceiveRequest = await ReceiveHttpClient.GetAsync(urlParts);
        var ReceiveJsonResult = await ReceiveRequest.Content.ReadAsStringAsync();
        var ReceiveResult = JsonConvert.DeserializeObject<ResponseRazorpaySuccessMessage>(ReceiveJsonResult);

        if (ReceiveResult.Success == true)
        {
            var ChitSchemeId = Preferences.Get("ChitSchemeId", string.Empty);
            var CollectionId = Preferences.Get("CollectionId", string.Empty);
            var CustomerId = Preferences.Get("CustomerId", string.Empty);
            var DueNo = Preferences.Get("DueNo", string.Empty);
            var Id = Preferences.Get("Id", string.Empty);
            var order_id = Preferences.Get("ID", string.Empty);
            var SendName = Preferences.Get("CustomerName", string.Empty);
            var Amount = Preferences.Get("Amount", string.Empty);
            Dictionary<string, string> formData = new Dictionary<string, string>
            {
                {"txn_no", order_id},
                {"card_holder_name", SendName},
                {"paid_amount", Amount},
                {"transaction_details[0][chit_scheme_id]", ChitSchemeId},
                {"transaction_details[0][collection_id]", CollectionId},
                {"transaction_details[0][customer_id]", CustomerId},
                {"transaction_details[0][due_no]", DueNo},
                {"transaction_details[0][id]", Id}
            };
            var content = new FormUrlEncodedContent(formData);
            var storeHttpClient = httpServices.HttpClient;
            storeHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("accessToken", string.Empty));
            var storeRequest = await storeHttpClient.PostAsync(ApiUrl.Api + "api/store_payment_details", content);
            var storeJsonResult = await storeRequest.Content.ReadAsStringAsync();
            var Result = JsonConvert.DeserializeObject<StorePaymentDetailsModel>(storeJsonResult);
            if (Result.Message == "Success.")
            {
                await Navigation.PopAsync();
            }

        }




    }


    //public async void getData(string res)
    //{
    //    await DisplayAlert("Message inside MAUI", res, "OK");

    //}
    //private async void WebViewToMaui(object sender, EventArgs e)
    //{
    //    var result = await myWebView.EvaluateJavaScriptAsync("RazorpayPaymentSuccessMessage()");

    //    await DisplayAlert("Message inside MAUI", result, "OK");
    //}
}