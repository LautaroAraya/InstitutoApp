using InstitutoApp.Views;
using InstitutoApp.Views.Commons;

namespace InstitutoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AddEditCarreraView();
        }
    }
}
