using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppManejoAPIs
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new AppManejoAPIs.Paginas.ConsumeAPI.PageAPI() ); //MainPage();
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
