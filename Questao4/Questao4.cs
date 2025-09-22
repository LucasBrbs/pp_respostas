using System;
using System.Linq;

namespace PpQuest
{
    public class Questao4
    {
        public static void ExecutarQuestao4()
        {
            Console.Clear();
            Console.WriteLine("⚙️ QUESTÃO 4 - FUNÇÕES E MÉTODOS");
            Console.WriteLine("================================");
            Console.WriteLine("1. Fatorial de um Número");
            Console.WriteLine("2. Sequência de Fibonacci");
            Console.WriteLine("3. Validação de CPF");
            Console.WriteLine("================================");
            
            Console.Write("Escolha um item (1-3): ");
            string? item = Console.ReadLine();
            
            switch (item)
            {
                case "1":
                    CalcularFatorial();
                    break;
                case "2":
                    SequenciaFibonacci();
                    break;
                case "3":
                    ValidarCPF();
                    break;
                default:
                    Console.WriteLine("❌ Item inválido!");
                    break;
            }
        }

        static void CalcularFatorial()
        {
            Console.WriteLine("\n❗ FATORIAL DE UM NÚMERO");
            Console.Write("Digite um número: ");
            if (int.TryParse(Console.ReadLine(), out int numero) && numero >= 0)
            {
                long fatorial = 1;
                for (int i = 1; i <= numero; i++)
                {
                    fatorial *= i;
                }
                Console.WriteLine($"{numero}! = {fatorial}");
            }
            else
            {
                Console.WriteLine("❌ Digite um número inteiro positivo!");
            }
        }
        
        static void SequenciaFibonacci()
        {
            Console.WriteLine("\n🌀 SEQUÊNCIA DE FIBONACCI");
            Console.Write("Quantos termos deseja ver? ");
            if (int.TryParse(Console.ReadLine(), out int termos) && termos > 0)
            {
                int a = 0, b = 1;
                Console.Write($"Fibonacci({termos} termos): {a}");
                
                for (int i = 1; i < termos; i++)
                {
                    Console.Write($", {b}");
                    int temp = a + b;
                    a = b;
                    b = temp;
                }
                Console.WriteLine();
            }
        }
        
        static void ValidarCPF()
        {
            Console.WriteLine("\n🆔 VALIDAÇÃO DE CPF");
            Console.Write("Digite um CPF (apenas números): ");
            string? cpf = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(cpf) && cpf.Length == 11 && cpf.All(char.IsDigit))
            {
                Console.WriteLine($"✅ CPF {cpf} tem formato válido!");
                // Aqui poderia implementar a validação completa dos dígitos verificadores
            }
            else
            {
                Console.WriteLine("❌ CPF inválido! Digite 11 dígitos.");
            }
        }
    }
}
