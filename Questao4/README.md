# ⚙️ Questão 4 - Funções e Métodos

Esta questão explora conceitos avançados de programação relacionados a funções, algoritmos recursivos/iterativos e validação de dados.

## 🎯 Objetivos de Aprendizagem

- Criação e uso de métodos estáticos
- Algoritmos iterativos (loops)
- Sequências matemáticas
- Validação de dados (CPF)
- Uso de `long` para números grandes
- LINQ básico com `All()`

## 📋 Itens Implementados

### 1. ❗ Fatorial de um Número
- **Funcionalidade**: Calcula o fatorial de um número (n!)
- **Conceitos**: Loop `for`, acumulador, tipo `long`
- **Entrada**: Número inteiro positivo
- **Saída**: Resultado do fatorial
- **Exemplo**: 5! = 5 × 4 × 3 × 2 × 1 = 120

### 2. 🌀 Sequência de Fibonacci
- **Funcionalidade**: Gera os primeiros N termos da sequência de Fibonacci
- **Conceitos**: Algoritmo iterativo, variáveis temporárias
- **Entrada**: Quantidade de termos desejados
- **Saída**: Sequência completa
- **Padrão**: 0, 1, 1, 2, 3, 5, 8, 13, 21...

### 3. 🆔 Validação de CPF
- **Funcionalidade**: Valida formato básico de CPF (11 dígitos)
- **Conceitos**: `string.All()`, `char.IsDigit`, LINQ
- **Entrada**: CPF (apenas números)
- **Saída**: Confirmação se formato é válido
- **Nota**: Implementa apenas validação de formato, não dígitos verificadores

## 🔧 Como Usar

1. Execute o programa principal
2. Escolha a opção "4" no menu
3. Selecione um dos 3 itens disponíveis
4. Insira os valores solicitados

## 💡 Conceitos de C# Utilizados

### Tipos de Dados:
```csharp
long fatorial = 1;  // Para números grandes
int numero, termos;  // Para contadores
```

### Algoritmo Iterativo (Fatorial):
```csharp
for (int i = 1; i <= numero; i++)
{
    fatorial *= i;
}
```

### Sequência de Fibonacci:
```csharp
int a = 0, b = 1;
int temp = a + b;
a = b;
b = temp;
```

### LINQ para Validação:
```csharp
cpf.All(char.IsDigit)  // Verifica se todos são dígitos
```

## 📚 Exemplos de Execução

### Fatorial:
```
Digite um número: 5
5! = 120
```

### Fibonacci:
```
Quantos termos deseja ver? 8
Fibonacci(8 termos): 0, 1, 1, 2, 3, 5, 8, 13
```

### Validação CPF:
```
Digite um CPF (apenas números): 12345678901
✅ CPF 12345678901 tem formato válido!
```

## 🔢 Fórmulas e Algoritmos

### Fatorial:
```
n! = n × (n-1) × (n-2) × ... × 2 × 1
0! = 1 (por definição)
```

### Fibonacci:
```
F(0) = 0
F(1) = 1
F(n) = F(n-1) + F(n-2) para n > 1
```

### Validação CPF:
- **Comprimento**: Exatamente 11 caracteres
- **Formato**: Apenas dígitos (0-9)
- **Nota**: Validação completa incluiria dígitos verificadores

## 🚀 Complexidade Algoritmica

- **Fatorial**: O(n) - Linear
- **Fibonacci**: O(n) - Linear (versão iterativa)
- **Validação CPF**: O(n) - Linear (onde n = 11)

## 🎓 Nível de Dificuldade
**Intermediário/Avançado** - Algoritmos e validação de dados

## 💭 Possíveis Melhorias

1. **Fatorial**: Implementar versão recursiva
2. **Fibonacci**: Memoização para otimização
3. **CPF**: Validação completa com dígitos verificadores
4. **Todos**: Tratamento mais robusto de erros

---
*Parte do projeto PP Quest - Sistema de Questões em C#*
