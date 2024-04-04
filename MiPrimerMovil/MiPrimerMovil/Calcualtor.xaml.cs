using System;
using Xamarin.Forms;

namespace MiPrimerMovil
{
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

        private void Number_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentNumber += button.Text;
            resultLabel.Text = currentNumber;
            Ejecutable.Text += button.Text; // Agregar el número al label Ejecutable
        }

        private void punto_Clicked(object sender, EventArgs e)
        {
            if (!currentNumber.Contains("."))
            {
                currentNumber += ".";
                resultLabel.Text = currentNumber;
                Ejecutable.Text += "."; // Agregar el punto decimal al label Ejecutable
            }
        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            currentNumber = string.Empty;
            operation = string.Empty;
            result = 0;
            resultLabel.Text = "0";
            operacionActual = string.Empty;
            Ejecutable.Text = string.Empty; // Limpiar el label Ejecutable
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                PerformOperation();
                operation = "+";
                Ejecutable.Text += " + "; // Agregar el operador al label Ejecutable
            }
        }

        private void Subtract_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                PerformOperation();
                operation = "-";
                Ejecutable.Text += " - "; // Agregar el operador al label Ejecutable
            }
        }

        private void Multiply_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                PerformOperation();
                operation = "*";
                Ejecutable.Text += " * "; // Agregar el operador al label Ejecutable
            }
        }

        private void Divide_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                PerformOperation();
                operation = "/";
                Ejecutable.Text += " / "; // Agregar el operador al label Ejecutable
            }
        }

        private void Equal_Clicked(object sender, EventArgs e)
        {
            PerformOperation();
            resultLabel.Text = result.ToString();
            currentNumber = result.ToString();
            operation = string.Empty;
            operacionActual = string.Empty;
            Ejecutable.Text = operacionActual;
        }

        private void PerformOperation()
        {
            double newNumber = 0;
            if (!string.IsNullOrEmpty(currentNumber))
            {
                newNumber = double.Parse(currentNumber);
            }

            switch (operation)
            {
                case "+":
                    result += newNumber;
                    break;
                case "-":
                    result -= newNumber;
                    break;
                case "*":
                    if (result == 0)
                        result = newNumber;
                    else
                        result *= newNumber;
                    break;
                case "/":
                    if (newNumber != 0)
                        result /= newNumber;
                    else
                    {
                        DisplayAlert("Recordatorio", "No se puede dividir por cero", "OK");
                        return;
                    }
                    break;
                default:
                    result = newNumber;
                    break;
            }

            currentNumber = string.Empty;
        }

        private void Borrar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                currentNumber = currentNumber.Remove(currentNumber.Length - 1);
                resultLabel.Text = currentNumber;
            }
            else if (!string.IsNullOrEmpty(operacionActual))
            {
                if (operacionActual.EndsWith(" ") && operacionActual.Length > 1)
                {
                    operation = string.Empty;
                    operacionActual = operacionActual.Remove(operacionActual.Length - 3);
                }
                else
                {
                    operacionActual = operacionActual.Remove(operacionActual.Length - 1);
                }
                Ejecutable.Text = operacionActual;
            }
        }

        private async void Regresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
