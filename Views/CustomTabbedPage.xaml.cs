using LJ.Services;

namespace LJ.Views;

public partial class CustomTabbedPage : TabbedPage
{ 


    public CustomTabbedPage(HttpServices _httpServices) 
	{
		InitializeComponent();

        var homePage = new NavigationPage(new HomePage(_httpServices))
        {
            Title = "Home",
            IconImageSource = "house.png"
        };

        var ProfilePage = new NavigationPage(new ProfilePage(_httpServices))
        {
            Title = "Profile",
            IconImageSource = "user.png"
        };

        Children.Add(homePage);
        Children.Add(ProfilePage);
    }
}