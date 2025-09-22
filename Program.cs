using System;

namespace PpQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Questões de PP");
            Console.WriteLine(new string('=', 50));
            
            bool continuar = true;
            
            while (continuar)
            {
                ExibirMenu();
                string? opcao = Console.ReadLine();
                
                switch (opcao)
                {
                    case "1":
                        Questao1.ExecutarQuestao1();
                        break;
                    case "2":
                        Questao2.ExecutarQuestao2();
                        break;
                    case "3":
                        Questao3.ExecutarQuestao3();
                        break;
                    case "4":
                        Questao4.ExecutarQuestao4();
                        break;
                    case "5":
                        Questao5.ExecutarQuestao5();
                        break;
                    case "0":
                        continuar = false;
                        Console.WriteLine("Fechando o programa");
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
                
                if (continuar)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        
        static void ExibirMenu()
        {
            Console.WriteLine("\n📋 MENU PRINCIPAL");
            Console.WriteLine("================");
            Console.WriteLine("1 - Questão 1");
            Console.WriteLine("2 - Questão 2");
            Console.WriteLine("3 - Questão 3");
            Console.WriteLine("4 - Questão 4");
            Console.WriteLine("5 - Questão 5");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("================");
            Console.Write("Escolha uma opção: ");
        }
    }
}
