using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiPrimerMovil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
        public interface ICloseApp
        {
            void Close();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
