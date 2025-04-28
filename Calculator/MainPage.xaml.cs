using System;
using Microsoft.Maui.Controls;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        string currentEntry = "";
        string operatorEntry = "";
        double firstNumber = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        async void OnNumberClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            // Animacja kliknięcia
            await button.ScaleTo(0.9, 50);
            await button.ScaleTo(1.0, 50);

            currentEntry += button.Text;
            Display.Text = currentEntry;
        }

        async void OnOperatorClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            // Animacja kliknięcia
            await button.ScaleTo(0.9, 50);
            await button.ScaleTo(1.0, 50);

            if (!string.IsNullOrEmpty(currentEntry))
            {
                firstNumber = double.Parse(currentEntry);
                operatorEntry = button.Text;
                currentEntry = "";
            }
        }

        async void OnEqualClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            // Animacja kliknięcia
            await button.ScaleTo(0.9, 50);
            await button.ScaleTo(1.0, 50);

            if (string.IsNullOrEmpty(currentEntry))
                return;

            double secondNumber = double.Parse(currentEntry);
            double result = 0;

            try
            {
                switch (operatorEntry)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "×":
                        result = firstNumber * secondNumber;
                        break;
                    case "÷":
                        if (secondNumber == 0)
                            throw new DivideByZeroException();
                        result = firstNumber / secondNumber;
                        break;
                }

                Display.Text = result.ToString();
                currentEntry = result.ToString();
            }
            catch (DivideByZeroException)
            {
                Display.Text = "Błąd: dzielenie przez zero";
                currentEntry = "";
            }
        }

        async void OnClearClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            // Animacja kliknięcia
            await button.ScaleTo(0.9, 50);
            await button.ScaleTo(1.0, 50);

            firstNumber = 0;
            currentEntry = "";
            operatorEntry = "";
            Display.Text = "0";
        }
    }
}
