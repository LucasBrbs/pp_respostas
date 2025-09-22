using System;

namespace PpQuest
{
    public class Questao5
    {
        public static void ExecutarQuestao5()
        {
            Console.Clear();
            Console.WriteLine("🏗️ QUESTÃO 5 - ORIENTAÇÃO A OBJETOS");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Classe Pessoa");
            Console.WriteLine("2. Sistema de Conta Bancária");
            Console.WriteLine("3. Catálogo de Produtos");
            Console.WriteLine("===================================");
            
            Console.Write("Escolha um item (1-3): ");
            string? item = Console.ReadLine();
            
            switch (item)
            {
                case "1":
                    ClassePessoa();
                    break;
                case "2":
                    ContaBancaria();
                    break;
                case "3":
                    CatalogoProdutos();
                    break;
                default:
                    Console.WriteLine("❌ Item inválido!");
                    break;
            }
        }

        static void ClassePessoa()
        {
            Console.WriteLine("\n👤 CLASSE PESSOA");
            Console.Write("Digite seu nome: ");
            string? nome = Console.ReadLine();
            Console.Write("Digite sua idade: ");
            
            if (int.TryParse(Console.ReadLine(), out int idade))
            {
                var pessoa = new { Nome = nome, Idade = idade };
                Console.WriteLine($"Pessoa criada: {pessoa.Nome}, {pessoa.Idade} anos");
                Console.WriteLine(pessoa.Idade >= 18 ? "✅ Maior de idade" : "❌ Menor de idade");
            }
        }
        
        static void ContaBancaria()
        {
            Console.WriteLine("\n🏦 SISTEMA DE CONTA BANCÁRIA");
            double saldo = 1000.00;
            
            Console.WriteLine($"Saldo atual: R$ {saldo:F2}");
            Console.Write("Digite o valor para operação: ");
            
            if (double.TryParse(Console.ReadLine(), out double valor))
            {
                Console.WriteLine("1. Depósito | 2. Saque");
                string? operacao = Console.ReadLine();
                
                switch (operacao)
                {
                    case "1":
                        saldo += valor;
                        Console.WriteLine($"✅ Depósito realizado! Novo saldo: R$ {saldo:F2}");
                        break;
                    case "2":
                        if (valor <= saldo)
                        {
                            saldo -= valor;
                            Console.WriteLine($"✅ Saque realizado! Novo saldo: R$ {saldo:F2}");
                        }
                        else
                        {
                            Console.WriteLine("❌ Saldo insuficiente!");
                        }
                        break;
                }
            }
        }
        
        static void CatalogoProdutos()
        {
            Console.WriteLine("\n🛍️ CATÁLOGO DE PRODUTOS");
            var produtos = new[]
            {
                new { Nome = "Notebook", Preco = 2500.00, Categoria = "Eletrônicos" },
                new { Nome = "Mouse", Preco = 50.00, Categoria = "Acessórios" },
                new { Nome = "Teclado", Preco = 150.00, Categoria = "Acessórios" }
            };
            
            Console.WriteLine("📋 Lista de Produtos:");
            for (int i = 0; i < produtos.Length; i++)
            {
                var produto = produtos[i];
                Console.WriteLine($"{i + 1}. {produto.Nome} - R$ {produto.Preco:F2} ({produto.Categoria})");
            }
        }
    }
}
