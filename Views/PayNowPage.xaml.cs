
using LJ.Models;
using LJ.Services;
using LJ.ViewModels;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;


namespace LJ.Views;

public partial class PayNowPage : ContentPage
{
    private PayNowViewModel viewModel;

    private readonly HttpServices httpServices;

    public ObservableCollection<Datum> PayNow { get; set; } = new ObservableCollection<Datum>();
    public PayNowPage(string propertyId, HttpServices _httpServices)
	{
		InitializeComponent();

        this.httpServices = _httpServices;
    
        BindingContext = viewModel = new PayNowViewModel(propertyId, httpServices);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        viewModel.GetChitCustomerViewPassbook();
        PayNow =  await viewModel.GetChitCustomerCollectionDueList();

        if(PayNow.Count == 1)
        {
            Preferences.Set("DueAmount", PayNow[0].PaidAmount);
            Preferences.Set("ChitSchemeId", PayNow[0].ChitSchemeId);
            Preferences.Set("CollectionId", PayNow[0].CollectionId);
            Preferences.Set("CustomerId", PayNow[0].CustomerId);
            Preferences.Set("DueNo", PayNow[0].DueNo);
            Preferences.Set("paynowId", PayNow[0].Id);
            await Navigation.PushModalAsync(new RazorPayPage(httpServices));
        }
      
    }
 
    private async void RazorPay(Object sender, EventArgs args)
    {

        var button = (Button)sender;
        var view = (Datum)button.BindingContext;


        Preferences.Set("DueAmount", view.PaidAmount);
        Preferences.Set("ChitSchemeId", view.ChitSchemeId);
        Preferences.Set("CollectionId", view.CollectionId);
        Preferences.Set("CustomerId", view.CustomerId);
        Preferences.Set("DueNo", view.DueNo);
        Preferences.Set("paynowId", view.Id);

        await Navigation.PushAsync(new RazorPayPage(httpServices));
    }
}