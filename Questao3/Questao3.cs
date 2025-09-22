using System;
using System.Collections.Generic;
using System.Linq;

namespace PpQuest
{
    public class Questao3
    {
        public static void ExecutarQuestao3()
        {
            Console.Clear();
            Console.WriteLine("📊 QUESTÃO 3 - ARRAYS E LISTAS");
            Console.WriteLine("==============================");
            Console.WriteLine("1. Soma de Elementos do Array");
            Console.WriteLine("2. Buscar Elemento na Lista");
            Console.WriteLine("3. Ordenação de Números");
            Console.WriteLine("==============================");
            
            Console.Write("Escolha um item (1-3): ");
            string? item = Console.ReadLine();
            
            switch (item)
            {
                case "1":
                    SomaArray();
                    break;
                case "2":
                    BuscarElemento();
                    break;
                case "3":
                    OrdenarNumeros();
                    break;
                default:
                    Console.WriteLine("❌ Item inválido!");
                    break;
            }
        }

        static void SomaArray()
        {
            Console.WriteLine("\n➕ SOMA DE ELEMENTOS DO ARRAY");
            int[] numeros = { 10, 20, 30, 40, 50 };
            int soma = 0;
            
            Console.WriteLine($"Array: [{string.Join(", ", numeros)}]");
            foreach (int num in numeros)
            {
                soma += num;
            }
            Console.WriteLine($"Soma total: {soma}");
        }
        
        static void BuscarElemento()
        {
            Console.WriteLine("\n🔍 BUSCAR ELEMENTO NA LISTA");
            List<string> frutas = new List<string> { "Maçã", "Banana", "Laranja", "Uva", "Manga" };
            
            Console.WriteLine($"Lista de frutas: {string.Join(", ", frutas)}");
            Console.Write("Digite uma fruta para buscar: ");
            string? busca = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(busca))
            {
                bool encontrada = frutas.Contains(busca, StringComparer.OrdinalIgnoreCase);
                Console.WriteLine(encontrada ? $"✅ {busca} foi encontrada!" : $"❌ {busca} não foi encontrada.");
            }
        }
        
        static void OrdenarNumeros()
        {
            Console.WriteLine("\n📊 ORDENAÇÃO DE NÚMEROS");
            int[] numeros = { 64, 34, 25, 12, 22, 11, 90 };
            
            Console.WriteLine($"Array original: [{string.Join(", ", numeros)}]");
            Array.Sort(numeros);
            Console.WriteLine($"Array ordenado: [{string.Join(", ", numeros)}]");
        }
    }
}
