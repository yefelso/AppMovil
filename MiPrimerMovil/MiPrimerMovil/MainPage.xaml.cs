using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MiPrimerMovil
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void Calculadora_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Calcualtor());
            await DisplayAlert("Mensaje", "Abriendo la calculadora...", "OK");

        }

        private void Salir_Clicked(object sender, EventArgs e)
        {
            // Manejar el evento del botón "Salir" aquí
            // Por ejemplo, puedes cerrar la aplicación o ejecutar cualquier otra lógica relacionada con la salida
            // Este es solo un ejemplo:
            DisplayAlert("Mensaje", "Cerrando la aplicación...", "OK");
        }
    }
}
