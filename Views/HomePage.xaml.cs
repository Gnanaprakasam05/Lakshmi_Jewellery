
using LJ.Models;
using LJ.Services;
using LJ.ViewModels;
using Microsoft.Maui.Controls;
using System.Diagnostics;
using Index = LJ.Models.Index;

namespace LJ.Views;

public partial class HomePage : ContentPage
{
    private readonly HttpServices httpServices;

    private HomeViewModel viewModel;

    private ChechBackModel ChechBackModel;
    public HomePage(HttpServices httpClientFactory)
	{
		InitializeComponent();

        httpServices = httpClientFactory;



        BindingContext = viewModel = new HomeViewModel(httpServices);
         
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();



     
            viewModel.GetCustomerList();
      
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

        public async void LogoutNavigation(Object sender, EventArgs e)
        {
            bool result = await this.DisplayAlert("Log Out!", "Do you want to Log Out?", "Yes", "No");
            if (result)
            {
                Preferences.Remove("accessToken");

            await Shell.Current.GoToAsync(state: "//MainPage");
            //await Navigation.PushModalAsync(new LoginPage(httpServices));
        }  
     
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var button = (Frame)sender;
        var view = (Index)button.BindingContext;
        await Navigation.PushAsync(new MyRelationPage(view.Id,httpServices));
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

        //var selectedItem = e.CurrentSelection as Index;
        //if (e.CurrentSelection != null)
        //{
        //    // Get the selected item
        //    var selectedItem = e.CurrentSelection as Index;

        //    // Perform navigation or any other action based on the selected item
        //    Navigation.PushAsync(new MyRelationPage(selectedItem.Id , httpServices));

        //    // Clear the selection
        //    selectedItem = null;
        //}
        //else
        //{
        //    return;
        //}
    }
}