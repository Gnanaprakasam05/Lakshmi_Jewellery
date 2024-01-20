using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using LJ.Models;
using LJ.Services;
using Newtonsoft.Json;
namespace LJ.Views;

public partial class LoginPage : ContentPage
{
    private readonly HttpServices httpServices;

    private readonly IHttpClientFactory _httpClientFactory;

    private static string corporate_name = "ljgold";
    public LoginPage(HttpServices _httpServices = null)
	{
		InitializeComponent();

        httpServices = _httpServices;

        Loaded += PhoneNumber_Loaded;
    }

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();

    //    Loaded += PhoneNumber_Loaded;
    //}
    private void PhoneNumber_Loaded(object sender, EventArgs e)
    {
        txtPhoneNumber.Focus();
       
    }    private void OtpNumber_Loaded(object sender, EventArgs e)
    {
        Enter_OTP.Focus();
       
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
     propertyName: nameof(Text),
     returnType: typeof(string),
     declaringType: typeof(LoginPage),
     defaultValue: null,
     defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
     propertyName: nameof(Placeholder),
     returnType: typeof(string),
     declaringType: typeof(LoginPage),
     defaultValue: null,
     defaultBindingMode: BindingMode.OneWay);
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set { SetValue(TextProperty, value); }
    }
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set { SetValue(PlaceholderProperty, value); }
    }
    private void txtEntryFocused(Object sender, FocusEventArgs e)
    {
        phoneNumber.FontSize = 16;
        phoneNumber.TranslateTo(0, -29, 80, easing: Easing.Linear);
    }
    private void txtFocused(Object sender, FocusEventArgs e)
    {
        enterOtp.FontSize = 16;
        enterOtp.TranslateTo(0, -29, 80, easing: Easing.Linear);
    }
    private void txtEntry_UnFocused(Object sender, FocusEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
        {
            phoneNumber.FontSize = 16;
            phoneNumber.TranslateTo(0, -29, 80, easing: Easing.Linear);
        }
        else
        {
            phoneNumber.FontSize = 19;
            phoneNumber.TranslateTo(0, 0, 80, easing: Easing.Linear);
        }
    }
    private void txtUnFocused(Object sender, FocusEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Enter_OTP.Text))
        {
            enterOtp.FontSize = 16;
            enterOtp.TranslateTo(0, -29, 80, easing: Easing.Linear);
        }
        else
        {
            enterOtp.FontSize = 19;
            enterOtp.TranslateTo(0, 0, 80, easing: Easing.Linear);
        }
    }

    public async void Login_Clicked(object sender, EventArgs e)
    {

        try
        {

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            NetworkAccess accessType = Connectivity.Current.NetworkAccess;

            if (accessType != NetworkAccess.Internet)

            {
                var toast = Toast.Make("No Internet Connection");
                await toast.Show(cancellationTokenSource.Token);
            }
            else if (txtPhoneNumber.Text != null)


            {
                var formcontent = new FormUrlEncodedContent(new[]
                              {
                                    new KeyValuePair<string,string>("corporate_name",corporate_name),
                                    new KeyValuePair<string,string>("user_name",txtPhoneNumber.Text),
                                    new KeyValuePair<string,string>("password",txtPhoneNumber.Text),
                            });
                var httpClient = httpServices.HttpClient;
                var response = await httpClient.PostAsync(ApiUrl.Api + "api/customer_signin", formcontent);
                var jsonResult = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = JsonConvert.DeserializeObject<User>(jsonResult);

                    Preferences.Set("accessToken", result.Token);
                    Preferences.Set("MobileNumber", result.UserData.MobileNo);

                    Preferences.Set("name", result.UserData.Name);
                    Preferences.Set("ledger_name", result.UserData.LedgerName);
                    Preferences.Set("address", result.UserData.Address1 + " " + result.UserData.Address2+ " " + result.UserData.Address3);
                    Preferences.Set("code", result.UserData.Code);
                    Preferences.Set("email_id", result.UserData.EmailId);
                    Preferences.Set("dob", result.UserData.Dob);
                    Preferences.Set("wedding_anniversary_date", result.UserData.WeddingAnniversaryDate);
                    Preferences.Set("place", result.UserData.Place);



                    if (result.Message == "Success")
                    {
                        PhoneNumber.IsVisible = false;
                        OTP.IsVisible = true;
                        LoginButton.IsVisible = false;
                        OTPButton.IsVisible = true;

                        OtpNumber_Loaded(null, null);
                        try
                        {
                            var rand = (new Random().Next(1000, 9999)).ToString();
                            var apiUrl = $"https://beyondmobile.org/api/otp.php?authkey=374188As7FNNiJb62284f0dP1&mobile=91{txtPhoneNumber.Text}&message=Dear customer Use OTP {rand} to login to Lakshmi jewellery customer portal.&sender=LJPSMS&otp={rand}&DLT_TE_ID=1707164681574855347";
                            Preferences.Set("random", rand);
                            using (var httpClient1 = new HttpClient())
                            {
                                var responses = await httpClient.PostAsync(apiUrl, null);

                            }

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Error", ex.Message, "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Alert", result.Message, "OK");
                    }
                }
                else if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    var toast = Toast.Make("Can't access In-House App from Outside");
                    await toast.Show(cancellationTokenSource.Token);
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var result = JsonConvert.DeserializeObject<User>(jsonResult);
                    var toast = Toast.Make($"{result.Message}");
                    await toast.Show(cancellationTokenSource.Token);
                }
                else
                {
                    var toast = Toast.Make("Error");
                    await toast.Show(cancellationTokenSource.Token);
                }
            }
            else
            {
                var toast = Toast.Make("Invalid Credentials");
                await toast.Show(cancellationTokenSource.Token);
            }
        }
        catch (Exception ex)
        {

        }
    }
    public async void OTP_Clicked(object sender, EventArgs e)
    {
        var value = Preferences.Get("random", string.Empty);



        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        try
        {
            if (Enter_OTP.Text != null)
            {


                if (Enter_OTP.Text == value)
                {


                    await Shell.Current.GoToAsync(state: "//DashBoard");

                    var toast = Toast.Make("Loged in successfully");
                    await toast.Show(cancellationTokenSource.Token);

                    if (IsCheck.IsChecked == true)
                    {
                        var GetAccessToken = Preferences.Get("accessToken", string.Empty);
                        Preferences.Set("Token", GetAccessToken);
                    }
                    else
                    {
                        Preferences.Clear("Token");
                        Preferences.Remove("Token");
                        Preferences.Remove("accessToken");
                    }

                }
                else
                {
                    var toast = Toast.Make("Enter Valid OTP");
                    await toast.Show(cancellationTokenSource.Token);
                }
            }
            else
            {
                var toast = Toast.Make("Invalid Credentials");
                await toast.Show(cancellationTokenSource.Token);
            }
        }
        catch(Exception ex)
        {

        }
    }
    public bool CloseApp = true;


    protected override bool OnBackButtonPressed()
    {
        Device.BeginInvokeOnMainThread(async () =>
        {
            bool result = await this.DisplayAlert("Attention!", "Do you want to exit?", "Yes", "No");
            if (result)
            {
                CloseApp = false;
                Application.Current.Quit();
            }

        });

        return CloseApp;
    }

}