using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiPrimerMovil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calcualtor : ContentPage
    {
        string currentNumber = string.Empty;
        string operation = string.Empty;
        double result = 0;
        string operacionActual = "";

        public Calcualtor()
        {
            InitializeComponent();
        }

        // Método de control de eventos para los botones de números
        private void Number_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentNumber += button.Text;
            resultLabel.Text = currentNumber;
            UpdateEjecutableLabel(); // Actualizar el Label Ejecutable
        }

        // Método de control de eventos para los botones de operadores
        private void Operator_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            result = double.Parse(currentNumber);
            currentNumber = string.Empty;
            UpdateEjecutableLabel(); // Actualizar el Label Ejecutable
        }

        // Método de control de eventos para el botón "="
        private void Equal_Clicked(object sender, EventArgs e)
        {
            double newNumber = double.Parse(currentNumber);
            switch (operation)
            {
                case "+":
                    result += newNumber;
                    break;
                case "-":
                    result -= newNumber;
                    break;
                case "*":
                    result *= newNumber;
                    break;
                case "/":
                    if (newNumber != 0)
                        result /= newNumber;
                    else
                        DisplayAlert("Error", "No se puede dividir por cero", "OK");
                    break;
            }
            resultLabel.Text = result.ToString();
            UpdateEjecutableLabel(); // Actualizar el Label Ejecutable
        }

        // Método de control de eventos para el botón "C" (clear)
        private void Clear_Clicked(object sender, EventArgs e)
        {
            currentNumber = string.Empty;
            operation = string.Empty;
            result = 0;
            resultLabel.Text = "0";
            UpdateEjecutableLabel(); // Actualizar el Label Ejecutable
        }

        // Método para actualizar el contenido del Label "Ejecutable"
        private void UpdateEjecutableLabel()
        {
            operacionActual = currentNumber + " " + operation;
            Ejecutable.Text = operacionActual;
        }
    }
}
