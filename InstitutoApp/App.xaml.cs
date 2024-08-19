using InstitutoApp.Views;

namespace InstitutoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CarrerasView();
        }
    }
}
