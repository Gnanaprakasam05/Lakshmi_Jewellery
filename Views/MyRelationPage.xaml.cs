using LJ.Models;
using LJ.Services;
using LJ.ViewModels;
using System.Collections.ObjectModel;

namespace LJ.Views;

public partial class MyRelationPage : ContentPage
{
    private readonly HttpServices httpServices;

    private MyRelationViewModel viewModel;

    private ChechBackModel ChechBackModel;

    public ObservableCollection<Datum> PayNowData { get; set; } = new ObservableCollection<Datum>();

    private string ID;
    public MyRelationPage(string id , HttpServices _httpServices )
	{
		InitializeComponent();

        httpServices = _httpServices;

        ChechBackModel = new ChechBackModel();

        ID = id;

        BindingContext = viewModel = new MyRelationViewModel(id,httpServices);
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();


        Preferences.Set("CustomerID", ID);

        viewModel.GetChitCustomerViewPassbook();

    
    }
 
    private async void ViewPassbook(Object sender, EventArgs args)
    {
        var button = (Button)sender;
        var view = (MyRelationModel)button.BindingContext;
        await Navigation.PushAsync(new ViewPassBookPage(view.Id, httpServices));
    }
    private async void PayNow(Object sender, EventArgs args)
    {

        var button = (Button)sender;
        var view = (MyRelationModel)button.BindingContext;

        PayNowData = await viewModel.GetChitCustomerCollectionDueListData(view.Id);

            Preferences.Set("DueAmount", PayNowData[0].PaidAmount);
            Preferences.Set("ChitSchemeId", PayNowData[0].ChitSchemeId);
            Preferences.Set("CollectionId", PayNowData[0].CollectionId);
            Preferences.Set("CustomerId", PayNowData[0].CustomerId);
            Preferences.Set("DueNo", PayNowData[0].DueNo);
            Preferences.Set("paynowId", PayNowData[0].Id);
          
        await Navigation.PushAsync(new RazorPayPage(httpServices));
    }
}