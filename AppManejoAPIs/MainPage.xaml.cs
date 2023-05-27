using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppManejoAPIs
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage (string usuario, string clave)
        {
            InitializeComponent();
            Usuario = usuario;
            Clave = clave;
        }

        public string Usuario { get; private set; }
        public string Clave { get; private set; }


        private void Button_Clicked(object sender, EventArgs e)
        {
            //Cerramos la pagina actual y regresamos a la pagina anterior de la pila.
            Navigation.PopAsync();
        }
    }
}
