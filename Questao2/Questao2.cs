using System;

namespace PpQuest
{
    public class Questao2
    {
        public static void ExecutarQuestao2()
        {
            Console.Clear();
            Console.WriteLine("🔄 QUESTÃO 2 - ESTRUTURAS DE CONTROLE");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Verificar Número Par/Ímpar");
            Console.WriteLine("2. Maior de Três Números");
            Console.WriteLine("3. Classificação por Idade");
            Console.WriteLine("=====================================");
            
            Console.Write("Escolha um item (1-3): ");
            string? item = Console.ReadLine();
            
            switch (item)
            {
                case "1":
                    VerificarParImpar();
                    break;
                case "2":
                    MaiorTresNumeros();
                    break;
                case "3":
                    ClassificacaoIdade();
                    break;
                default:
                    Console.WriteLine("❌ Item inválido!");
                    break;
            }
        }

        static void VerificarParImpar()
        {
            Console.WriteLine("\n🔢 VERIFICAR PAR/ÍMPAR");
            Console.Write("Digite um número: ");
            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                string resultado = numero % 2 == 0 ? "PAR" : "ÍMPAR";
                Console.WriteLine($"O número {numero} é {resultado}");
            }
            else
            {
                Console.WriteLine("❌ Número inválido!");
            }
        }
        
        static void MaiorTresNumeros()
        {
            Console.WriteLine("\n🏆 MAIOR DE TRÊS NÚMEROS");
            Console.Write("Digite o primeiro número: ");
            if (int.TryParse(Console.ReadLine(), out int num1))
            {
                Console.Write("Digite o segundo número: ");
                if (int.TryParse(Console.ReadLine(), out int num2))
                {
                    Console.Write("Digite o terceiro número: ");
                    if (int.TryParse(Console.ReadLine(), out int num3))
                    {
                        int maior = Math.Max(Math.Max(num1, num2), num3);
                        Console.WriteLine($"O maior número é: {maior}");
                    }
                }
            }
        }
        
        static void ClassificacaoIdade()
        {
            Console.WriteLine("\n👶 CLASSIFICAÇÃO POR IDADE");
            Console.Write("Digite sua idade: ");
            if (int.TryParse(Console.ReadLine(), out int idade))
            {
                string classificacao = idade switch
                {
                    < 12 => "Criança",
                    < 18 => "Adolescente",
                    < 60 => "Adulto",
                    _ => "Idoso"
                };
                Console.WriteLine($"Classificação: {classificacao}");
            }
        }
    }
}
