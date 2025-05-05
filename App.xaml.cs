using Microsoft.Extensions.DependencyInjection;
using Schedule.View;

namespace Schedule
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            var homePage = serviceProvider.GetService<HomePage>();
            MainPage = new NavigationPage(homePage);
        }
    }
}
