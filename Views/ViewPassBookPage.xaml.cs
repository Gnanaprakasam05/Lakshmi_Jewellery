using LJ.Services;
using LJ.ViewModels;

namespace LJ.Views;

public partial class ViewPassBookPage : ContentPage
{


    private readonly HttpServices httpServices;

    private PassBookViewModel viewModel;
    public ViewPassBookPage(string propertyId, HttpServices httpServices)
    {
        InitializeComponent();

        BindingContext = viewModel =  new PassBookViewModel(propertyId, httpServices);

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        viewModel.GetChitCustomerViewPassbook();
        viewModel.GetCustomerViewPassbook();
    }
}