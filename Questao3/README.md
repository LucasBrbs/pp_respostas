# 📊 Questão 3 - Arrays e Listas

Esta questão aborda estruturas de dados fundamentais em C#: arrays e listas, incluindo operações comuns de manipulação.

## 🎯 Objetivos de Aprendizagem

- Declaração e inicialização de arrays
- Uso de `List<T>` (Generic Collections)
- Iteração com `foreach`
- Métodos de busca e ordenação
- Manipulação de strings
- Comparações case-insensitive

## 📋 Itens Implementados

### 1. ➕ Soma de Elementos do Array
- **Funcionalidade**: Calcula a soma total dos elementos de um array
- **Conceitos**: Arrays, `foreach`, acumuladores
- **Entrada**: Array pré-definido `{10, 20, 30, 40, 50}`
- **Saída**: Soma total (150) e exibição do array

### 2. 🔍 Buscar Elemento na Lista
- **Funcionalidade**: Procura uma fruta em uma lista pré-definida
- **Conceitos**: `List<string>`, `Contains()`, `StringComparer.OrdinalIgnoreCase`
- **Entrada**: Nome de uma fruta
- **Saída**: Confirmação se foi encontrada ou não

### 3. 📊 Ordenação de Números
- **Funcionalidade**: Ordena um array de números em ordem crescente
- **Conceitos**: `Array.Sort()`, comparação antes/depois
- **Entrada**: Array pré-definido desordenado
- **Saída**: Array original e array ordenado

## 🔧 Como Usar

1. Execute o programa principal
2. Escolha a opção "3" no menu
3. Selecione um dos 3 itens disponíveis
4. Para busca de fruta, digite o nome desejado

## 💡 Conceitos de C# Utilizados

### Arrays:
```csharp
int[] numeros = { 10, 20, 30, 40, 50 };
Array.Sort(numeros);  // Ordena o array
```

### Listas Genéricas:
```csharp
List<string> frutas = new List<string> { "Maçã", "Banana", "Laranja" };
bool encontrada = frutas.Contains(busca, StringComparer.OrdinalIgnoreCase);
```

### Iteração:
```csharp
foreach (int num in numeros)
{
    soma += num;
}
```

### Formatação:
```csharp
string.Join(", ", array)  // Une elementos com vírgula
```

## 📚 Exemplos de Execução

### Soma do Array:
```
Array: [10, 20, 30, 40, 50]
Soma total: 150
```

### Busca na Lista:
```
Lista de frutas: Maçã, Banana, Laranja, Uva, Manga
Digite uma fruta para buscar: banana
✅ banana foi encontrada!
```

### Ordenação:
```
Array original: [64, 34, 25, 12, 22, 11, 90]
Array ordenado: [11, 12, 22, 25, 34, 64, 90]
```

## 🗂️ Estruturas de Dados

### Array (Fixo):
- **Tamanho**: Definido na criação
- **Tipo**: Homogêneo (todos do mesmo tipo)
- **Performance**: Acesso direto O(1)
- **Uso**: Quando o tamanho é conhecido

### List<T> (Dinâmica):
- **Tamanho**: Pode crescer/diminuir
- **Tipo**: Genérica (especificada em T)
- **Métodos**: Add, Remove, Contains, etc.
- **Uso**: Quando o tamanho varia

## 🎮 Lista de Frutas Disponíveis
- Maçã
- Banana  
- Laranja
- Uva
- Manga

## 🎓 Nível de Dificuldade
**Intermediário** - Estruturas de dados e algoritmos básicos

---
*Parte do projeto PP Quest - Sistema de Questões em C#*
