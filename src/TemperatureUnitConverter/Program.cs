
using System.Collections.Immutable;
using UnitConverter.Models.Enumeration;
using UnitConverter.Models.Exceptions;
using UnitConverter.Services;

namespace UnitConverter
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            ImmutableList<ITemperatureConversionService> conversors = InitializeConversors();
            TemperatureConversionService temperatureConversionService = new(conversors);

            RegisterListenersForKeyboardEvents();


            bool justStarted = true;
            while (true)
            {
                try
                {

                    if (justStarted)
                    {
                        ShowStartingOutput();
                        justStarted = false;
                    }

                    ShowStartupInfo();



                    TemperatureUnits convertFrom = AskTheTemperatureUnit("Qual a unidade de conversão a partir da qual a temperatura será convertida?");
                    TemperatureUnits convertTo = AskTheTemperatureUnit("Qual a unidade de conversão para qual a temperatura será convertida?");
                    double temperatureValue = AskTheTemperatureValue();

                    double convertedValue = temperatureConversionService.ConvertTemperature(convertFrom, convertTo, temperatureValue);

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"A conversão de {temperatureValue} {convertFrom} para {convertTo} é {convertedValue}.");
                    Console.ResetColor();

                }
                catch (InvalidConversionException e)
                {
                    ShowErrorOutput($"Não é possível converter de {e.From} para {e.To}");
                }
                catch (Exception e)
                {
                    ShowErrorOutput($"Ocorreu um erro inesperado: {e.Message}.");
                }
            }


        }

        private static void ShowStartupInfo()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Pressione CTRL + C para sair.");
            Console.ResetColor();
        }


        private static void RegisterListenersForKeyboardEvents()
        {
            Console.CancelKeyPress += (sender, ev) =>
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Ctrl + C pressionado. Encerrando a aplicação...");
                Thread.Sleep(500);
                Console.WriteLine("Aplicação encerrada...");
                Console.ResetColor();
                Environment.Exit(0);
            };
        }

        private static void ShowStartingOutput()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Conversor de temperatura");
            Console.ResetColor();
        }

        private static TemperatureUnits AskTheTemperatureUnit(string question)
        {
            Console.WriteLine($"{question}");
            ShowTemperatureUnitsOptions();
            do
            {
                string? input = Console.ReadLine();

                if (Enum.TryParse(input, true, out TemperatureUnits value) && Enum.IsDefined(typeof(TemperatureUnits), value))
                {
                    return value;
                }

                ShowErrorOutput("Unidade de temperatura inválida, as unidades válidas são:");
                ShowTemperatureUnitsOptions();
            } while (true);

        }

        private static void ShowErrorOutput(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static double AskTheTemperatureValue()
        {
            Console.WriteLine("Qual o valor a ser convertido?");

            while (true)
            {
                string? input = Console.ReadLine();

                if (double.TryParse(input, out double value))
                {
                    return value;
                }

                ShowErrorOutput("Valor inválido. Por favor, insira um valor numérico válido.");
            }
        }

        private static void ShowTemperatureUnitsOptions()
        {
            Array values = Enum.GetValues(typeof(TemperatureUnits));
            foreach (var value in values)
            {
                Console.WriteLine($"Digite {(int)value} para {value}");
            }
        }

        private static ImmutableList<ITemperatureConversionService> InitializeConversors()
        {
            ImmutableList<ITemperatureConversionService> elements =
            [
                KelvinConversionService.Instance,
                FahrenheintConversionService.Instance,
                CelsiusConversionService.Instance
            ];
            return elements;
        }

    }
}
