using LJ.Services;
using LJ.Views;

namespace LJ
{
    public partial class AppShell : Shell
    {
        public AppShell(HttpServices _httpServices)
        {
            InitializeComponent();


            var accessToken = Preferences.Get("accessToken", string.Empty);

            if (string.IsNullOrEmpty(accessToken))
            {
                MyAppShell.CurrentItem = loginPage;
            }
            else
            {
                MyAppShell.CurrentItem = dashBoard;
            }
         
            loginPage.ContentTemplate = new DataTemplate(() => new LoginPage(_httpServices));
            HomePage.ContentTemplate = new DataTemplate(() => new HomePage(_httpServices));
            ProfilePage.ContentTemplate = new DataTemplate(() => new ProfilePage(_httpServices));
        }
    }
}
