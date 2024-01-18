using LJ.Models;
using LJ.Services;
using LJ.ViewModels;

namespace LJ.Views;

public partial class MyRelationPage : ContentPage
{
    private readonly HttpServices httpServices;

    private MyRelationViewModel viewModel;

    private ChechBackModel ChechBackModel;

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
        await Navigation.PushAsync(new PayNowPage(view.Id, httpServices));
    }
}