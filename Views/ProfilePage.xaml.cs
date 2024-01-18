using LJ.Models;
using LJ.Services;
using LJ.ViewModels;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using Index = LJ.Models.Index;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace LJ.Views;

public partial class ProfilePage : ContentPage
{
    public ObservableCollection<ProfileModel> ProfileData { get; set; } = new ObservableCollection<ProfileModel>();

    private readonly HttpServices httpServices;

    private HomeViewModel viewModel;

    private ChechBackModel ChechBackModel;
    public string WAD { get; set; }
    public string DOB { get; set; }

    public ProfilePage(HttpServices _httpServices = null)
    {

        InitializeComponent();

        httpServices = _httpServices;
        ChechBackModel = new ChechBackModel();
        BindingContext = viewModel = new HomeViewModel(httpServices);
    
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
            await viewModel.GetProfileCustomerList();

        try
        {

            var WAD_data = Preferences.Get("wedding_anniversary_date", string.Empty);
            var DOB_data = Preferences.Get("dob", string.Empty);

            if (WAD_data == "0000-00-00")
            {
                string reversedstr = WAD_data;
                char[] stringarray = reversedstr.ToCharArray();
                Array.Reverse(stringarray);
                WAD = new string(stringarray);
            }
            else
            {
                DateTime date = DateTime.Parse(WAD_data);
                WAD = date.ToString("dd-MM-yyyy");
            }

            if (DOB_data == "0000-00-00")
            {
                string reversed = DOB_data;
                char[] stringar = reversed.ToCharArray();
                Array.Reverse(stringar);
                DOB = new string(stringar);
            }
            else
            {
                DateTime date = DateTime.Parse(DOB_data);
                DOB = date.ToString("dd-MM-yyyy");
            }

            lblName.Text = Preferences.Get("name", string.Empty);
            lblLedgerName.Text = Preferences.Get("ledger_name", string.Empty);
            lblAddress1.Text = Preferences.Get("address", string.Empty);
            lblCode.Text = Preferences.Get("code", string.Empty);
            lblDob.Text = DOB;
            lblEmailId.Text = Preferences.Get("email_id", string.Empty);
            lblMobileNo.Text = Preferences.Get("MobileNumber", string.Empty);
            lblNoOfRunningChit.Text = Preferences.Get("NOC", string.Empty);
            lblPlace.Text = Preferences.Get("place", string.Empty);
            lblWeddingAnniversaryDate.Text = WAD;

        }
        catch (Exception ex)
        {

        }



        viewModel.NetworkError();
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