using CommunityToolkit.Maui.Alerts;
using LJ.Models;
using LJ.Services;
using LJ.ViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;

namespace LJ.Views;

public partial class MyRelationPage : ContentPage
{
    private readonly HttpServices httpServices;

    private MyRelationViewModel viewModel;

    private ChechBackModel ChechBackModel;
    public ObservableCollection<MyRelationModel> RelationData { get; set; } = new ObservableCollection<MyRelationModel>();
    public ObservableCollection<Datum> PayNowData { get; set; } = new ObservableCollection<Datum>();

    private string ID;
    private DateTime lastTapTime = DateTime.MinValue;
    private bool isProcessing = false;

    public MyRelationPage(string id , HttpServices _httpServices )
	{
		InitializeComponent();

        httpServices = _httpServices;

        ChechBackModel = new ChechBackModel();

        ID = id;

        BindingContext = viewModel = new MyRelationViewModel(id,httpServices);
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();


        Preferences.Set("CustomerID", ID);

        await  viewModel.GetChitCustomerViewPassbook();

        viewModel.NetworkError();

    }

    public bool CloseApp = true;
   
    private async void ViewPassbook(Object sender, EventArgs args)
    {
        if (isProcessing)
            return;

        try
        {
            isProcessing = true;

            DateTime now = DateTime.Now;
            TimeSpan elapsed = now - lastTapTime;

            if (elapsed < TimeSpan.FromMilliseconds(300))
            {

                var button = (Button)sender;
                var view = (MyRelationModel)button.BindingContext;
                await Navigation.PushAsync(new ViewPassBookPage(view.Id, httpServices));
            }
            else
            {
                var button = (Button)sender;
                var view = (MyRelationModel)button.BindingContext;
                await Navigation.PushAsync(new ViewPassBookPage(view.Id, httpServices));
            }

            lastTapTime = now;
        }
        finally
        {
            isProcessing = false;
        }
       
    }
    private async void PayNow(Object sender, EventArgs args)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        if (isProcessing)
            return;

        try
        {
            isProcessing = true;

            DateTime now = DateTime.Now;
            TimeSpan elapsed = now - lastTapTime;

            if (elapsed < TimeSpan.FromMilliseconds(300))
            {
                var button = (Button)sender;
                var view = (MyRelationModel)button.BindingContext;

                PayNowData = await viewModel.GetChitCustomerCollectionDueListData(view.Id);

                if (PayNowData.Count != 0)
                {
                    Preferences.Set("DueAmount", PayNowData[0].PaidAmount);
                    Preferences.Set("ChitSchemeId", PayNowData[0].ChitSchemeId);
                    Preferences.Set("CollectionId", PayNowData[0].CollectionId);
                    Preferences.Set("CustomerId", PayNowData[0].CustomerId);
                    Preferences.Set("DueNo", PayNowData[0].DueNo);
                    Preferences.Set("paynowId", PayNowData[0].Id);

                    await Navigation.PushAsync(new RazorPayPage(httpServices));
                }
                else
                {
                  

                    var toast = Toast.Make("Current Payment Completed !");
                    await toast.Show(cancellationTokenSource.Token);
                }
            }
            else
            {
                var button = (Button)sender;
                var view = (MyRelationModel)button.BindingContext;

                PayNowData = await viewModel.GetChitCustomerCollectionDueListData(view.Id);

                if (PayNowData.Count != 0)
                {
                    Preferences.Set("DueAmount", PayNowData[0].PaidAmount);
                    Preferences.Set("ChitSchemeId", PayNowData[0].ChitSchemeId);
                    Preferences.Set("CollectionId", PayNowData[0].CollectionId);
                    Preferences.Set("CustomerId", PayNowData[0].CustomerId);
                    Preferences.Set("DueNo", PayNowData[0].DueNo);
                    Preferences.Set("paynowId", PayNowData[0].Id);

                    await Navigation.PushAsync(new RazorPayPage(httpServices));
                }
                else
                {
                 

                    var toast = Toast.Make("Current Payment Completed !");
                    await toast.Show(cancellationTokenSource.Token);
                }
            }

            lastTapTime = now;
        }
        finally
        {
            isProcessing = false;
        }

       
    }
}