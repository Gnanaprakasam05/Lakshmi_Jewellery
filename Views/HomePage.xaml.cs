
using LJ.Models;
using LJ.Services;
using LJ.ViewModels;
using Microsoft.Maui;
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
    private DateTime lastTapTime = DateTime.MinValue;
    private bool isProcessing = false;

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

    private async void LogoutNavigation(Object sender, EventArgs e)
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

        if (isProcessing)
            return;

        try
        {
            isProcessing = true;

            DateTime now = DateTime.Now;
            TimeSpan elapsed = now - lastTapTime;

            if (elapsed < TimeSpan.FromMilliseconds(300))
            {

                var button = (Frame)sender;
                var view = (Index)button.BindingContext;
                await Navigation.PushAsync(new MyRelationPage(view.Id, httpServices));
            }
            else
            {
                var button = (Frame)sender;
                var view = (Index)button.BindingContext;
                await Navigation.PushAsync(new MyRelationPage(view.Id, httpServices));
            }

            lastTapTime = now;
        }
        finally
        {
            isProcessing = false;
        }
        
    }
 
    private async void CustomChitSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

      
        var view = ((CollectionView)sender).SelectedItem as CustomerChitList;

        if (view == null)
            return;

        if (isProcessing)
            return;

        try
        {
            isProcessing = true;

            DateTime now = DateTime.Now;
            TimeSpan elapsed = now - lastTapTime;

            if (elapsed < TimeSpan.FromMilliseconds(300))
            {

                await Navigation.PushAsync(new MyRelationPage(view.CustomerId, httpServices));
            }
            else
            {
                await Navigation.PushAsync(new MyRelationPage(view.CustomerId, httpServices));
            }

            lastTapTime = now;
        }
        finally
        {
            isProcessing = false;
        }

        ((CollectionView)sender).SelectedItem = null;


        //await Navigation.PushAsync(new MyRelationPage(view.CustomerId, httpServices));
    }
}