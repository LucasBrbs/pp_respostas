using System;

namespace PpQuest
{
    public class Questao1
    {
        public static void ExecutarQuestao1()
        {
            Console.Clear();
            Console.WriteLine("QUESTÃO 1");
            Console.WriteLine("================================");
            Console.WriteLine("1. Calculadora Simples");
            Console.WriteLine("2. Conversão de Temperaturas");
            Console.WriteLine("3. Área de Formas Geométricas");
            Console.WriteLine("================================");
            
            Console.Write("Escolha um item (1-3): ");
            string? item = Console.ReadLine();
            
            switch (item)
            {
                case "1":
                    CalculadoraSimples();
                    break;
                case "2":
                    ConversaoTemperatura();
                    break;
                case "3":
                    AreaFormas();
                    break;
                default:
                    Console.WriteLine("❌ Item inválido!");
                    break;
            }
        }

        static void CalculadoraSimples()
        {
            Console.WriteLine("\n🧮 CALCULADORA SIMPLES");
            Console.Write("Digite o primeiro número: ");
            if (double.TryParse(Console.ReadLine(), out double num1))
            {
                Console.Write("Digite o segundo número: ");
                if (double.TryParse(Console.ReadLine(), out double num2))
                {
                    Console.WriteLine($"Soma: {num1} + {num2} = {num1 + num2}");
                    Console.WriteLine($"Subtração: {num1} - {num2} = {num1 - num2}");
                    Console.WriteLine($"Multiplicação: {num1} × {num2} = {num1 * num2}");
                    Console.WriteLine($"Divisão: {num1} ÷ {num2} = {(num2 != 0 ? (num1 / num2).ToString() : "Impossível dividir por zero")}");
                }
            }
            else
            {
                Console.WriteLine("❌ Números inválidos!");
            }
        }
        
        static void ConversaoTemperatura()
        {
            Console.WriteLine("\n🌡️ CONVERSÃO DE TEMPERATURA");
            Console.Write("Digite a temperatura em Celsius: ");
            if (double.TryParse(Console.ReadLine(), out double celsius))
            {
                double fahrenheit = (celsius * 9/5) + 32;
                double kelvin = celsius + 273.15;
                Console.WriteLine($"{celsius}°C = {fahrenheit:F2}°F = {kelvin:F2}K");
            }
            else
            {
                Console.WriteLine("❌ Temperatura inválida!");
            }
        }
        
        static void AreaFormas()
        {
            Console.WriteLine("\n📐 ÁREA DE FORMAS GEOMÉTRICAS");
            Console.WriteLine("1. Quadrado | 2. Retângulo | 3. Círculo");
            Console.Write("Escolha a forma: ");
            string? forma = Console.ReadLine();
            
            switch (forma)
            {
                case "1":
                    Console.Write("Digite o lado do quadrado: ");
                    if (double.TryParse(Console.ReadLine(), out double lado))
                        Console.WriteLine($"Área do quadrado: {lado * lado:F2}");
                    break;
                case "2":
                    Console.Write("Digite a largura: ");
                    if (double.TryParse(Console.ReadLine(), out double largura))
                    {
                        Console.Write("Digite a altura: ");
                        if (double.TryParse(Console.ReadLine(), out double altura))
                            Console.WriteLine($"Área do retângulo: {largura * altura:F2}");
                    }
                    break;
                case "3":
                    Console.Write("Digite o raio: ");
                    if (double.TryParse(Console.ReadLine(), out double raio))
                        Console.WriteLine($"Área do círculo: {Math.PI * raio * raio:F2}");
                    break;
            }
        }
    }
}
