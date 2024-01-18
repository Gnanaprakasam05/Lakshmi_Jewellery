
using LJ.Services;
using LJ.ViewModels;

namespace LJ.Views;

public partial class PayNowPage : ContentPage
{
    private PayNowViewModel viewModel;

    private readonly HttpServices httpServices;
    public PayNowPage(string propertyId, HttpServices _httpServices)
	{
		InitializeComponent();

        this.httpServices = _httpServices;

       
        BindingContext = viewModel = new PayNowViewModel(propertyId, httpServices);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        viewModel.GetChitCustomerCollectionDueList();
        viewModel.GetChitCustomerViewPassbook();
    }
 
    private async void RazorPay(Object sender, EventArgs args)
    {

        await Navigation.PushAsync(new RazorPayPage(httpServices));
    }
}