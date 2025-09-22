# 🏗️ Questão 5 - Orientação a Objetos

Esta questão introduz conceitos fundamentais de programação orientada a objetos (POO) através de exemplos práticos e simulações.

## 🎯 Objetivos de Aprendizagem

- Conceitos básicos de POO
- Tipos anônimos em C#
- Simulação de classes e objetos
- Encapsulamento básico
- Modelagem de dados do mundo real
- Estados e comportamentos de objetos

## 📋 Itens Implementados

### 1. 👤 Classe Pessoa
- **Funcionalidade**: Modela uma pessoa com nome e idade
- **Conceitos**: Tipos anônimos, validação de maioridade
- **Entrada**: Nome e idade
- **Saída**: Dados da pessoa e status de maioridade
- **POO**: Representação básica de entidade

### 2. 🏦 Sistema de Conta Bancária
- **Funcionalidade**: Simula operações bancárias básicas
- **Conceitos**: Estado (saldo), comportamentos (depósito/saque)
- **Entrada**: Valores para operações
- **Saída**: Saldo atualizado e confirmações
- **POO**: Encapsulamento de dados e operações

### 3. 🛍️ Catálogo de Produtos
- **Funcionalidade**: Exibe lista de produtos com propriedades
- **Conceitos**: Coleções de objetos, propriedades múltiplas
- **Entrada**: Nenhuma (dados pré-definidos)
- **Saída**: Lista formatada de produtos
- **POO**: Estruturas de dados complexas

## 🔧 Como Usar

1. Execute o programa principal
2. Escolha a opção "5" no menu
3. Selecione um dos 3 itens disponíveis
4. Interaja conforme solicitado

## 💡 Conceitos de C# Utilizados

### Tipos Anônimos:
```csharp
var pessoa = new { Nome = nome, Idade = idade };
var produto = new { Nome = "Notebook", Preco = 2500.00, Categoria = "Eletrônicos" };
```

### Arrays de Objetos:
```csharp
var produtos = new[]
{
    new { Nome = "Notebook", Preco = 2500.00, Categoria = "Eletrônicos" },
    new { Nome = "Mouse", Preco = 50.00, Categoria = "Acessórios" }
};
```

### Controle de Estado:
```csharp
double saldo = 1000.00;  // Estado do objeto
saldo += valor;          // Modificação do estado
```

## 📚 Exemplos de Execução

### Classe Pessoa:
```
Digite seu nome: João
Digite sua idade: 25
Pessoa criada: João, 25 anos
✅ Maior de idade
```

### Conta Bancária:
```
Saldo atual: R$ 1000,00
Digite o valor para operação: 250
1. Depósito | 2. Saque
1
✅ Depósito realizado! Novo saldo: R$ 1250,00
```

### Catálogo de Produtos:
```
📋 Lista de Produtos:
1. Notebook - R$ 2500,00 (Eletrônicos)
2. Mouse - R$ 50,00 (Acessórios)  
3. Teclado - R$ 150,00 (Acessórios)
```

## 🏗️ Conceitos de POO Demonstrados

### 1. **Encapsulamento**
- Dados (saldo) e operações (depósito/saque) juntos
- Validação interna (saldo insuficiente)

### 2. **Abstração**
- Pessoa: nome + idade + maioridade
- Conta: saldo + operações bancárias
- Produto: nome + preço + categoria

### 3. **Modelagem de Dados**
```csharp
// Pessoa
{ Nome: string, Idade: int }

// Produto  
{ Nome: string, Preco: double, Categoria: string }
```

## 💰 Sistema Bancário - Regras

### Operações Disponíveis:
1. **Depósito**: Adiciona valor ao saldo
2. **Saque**: Remove valor (se houver saldo)

### Validações:
- ✅ Saque apenas com saldo suficiente
- ✅ Valores numéricos válidos
- ✅ Exibição formatada da moeda (R$ X,XX)

## 🛒 Produtos do Catálogo

| Produto  | Preço    | Categoria   |
|----------|----------|-------------|
| Notebook | R$ 2500  | Eletrônicos |
| Mouse    | R$ 50    | Acessórios  |
| Teclado  | R$ 150   | Acessórios  |

## 🎓 Nível de Dificuldade
**Intermediário/Avançado** - Fundamentos de POO

## 🚀 Próximos Passos

Para evolução em POO, considere implementar:

1. **Classes reais** (não tipos anônimos)
2. **Construtores** e **propriedades**
3. **Herança** e **polimorfismo**
4. **Interfaces** e **abstrações**
5. **Modificadores de acesso** (private, public, protected)

## 💡 Conceitos Avançados Relacionados

- **SOLID Principles**
- **Design Patterns**
- **Dependency Injection**
- **Unit Testing**

---
*Parte do projeto PP Quest - Sistema de Questões em C#*
