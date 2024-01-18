using LJ.Services;
using LJ.Views;

namespace LJ
{
    public partial class App : Application
    {
        public App(HttpServices _httpServices)
        {
            InitializeComponent();

            MainPage = new AppShell(_httpServices);

          
        }
    }
}
