# 🔄 Questão 2 - Estruturas de Controle

Esta questão explora estruturas de controle fundamentais em C#, incluindo condicionais e comparações.

## 🎯 Objetivos de Aprendizagem

- Estruturas condicionais (if/else)
- Operadores de comparação
- Operador módulo (%)
- Switch expressions (C# moderno)
- Lógica booleana
- Validação de entrada

## 📋 Itens Implementados

### 1. 🔢 Verificar Número Par/Ímpar
- **Funcionalidade**: Determina se um número é par ou ímpar
- **Conceitos**: Operador módulo (%), operador ternário
- **Entrada**: Um número inteiro
- **Saída**: "PAR" ou "ÍMPAR"

### 2. 🏆 Maior de Três Números
- **Funcionalidade**: Encontra o maior valor entre três números
- **Conceitos**: `Math.Max()`, comparações aninhadas
- **Entrada**: Três números inteiros
- **Saída**: O maior número

### 3. 👶 Classificação por Idade
- **Funcionalidade**: Classifica pessoa por faixa etária
- **Conceitos**: Switch expressions, comparações de ranges
- **Entrada**: Idade em anos
- **Saída**: Classificação (Criança/Adolescente/Adulto/Idoso)

## 🔧 Como Usar

1. Execute o programa principal
2. Escolha a opção "2" no menu
3. Selecione um dos 3 itens disponíveis
4. Insira os dados solicitados

## 💡 Conceitos de C# Utilizados

- `int.TryParse()` - Conversão segura para inteiros
- Operador módulo: `%` - Resto da divisão
- `Math.Max()` - Função para encontrar o maior valor
- **Switch expressions** (C# 8.0+):
  ```csharp
  string result = idade switch
  {
      < 12 => "Criança",
      < 18 => "Adolescente",
      < 60 => "Adulto",
      _ => "Idoso"
  };
  ```
- Operador ternário: `condition ? valueIfTrue : valueIfFalse`
- Comparações: `==`, `<`, `>`, `<=`, `>=`

## 📚 Exemplos de Execução

### Par/Ímpar:
```
Digite um número: 7
O número 7 é ÍMPAR
```

### Maior de Três:
```
Digite o primeiro número: 15
Digite o segundo número: 8
Digite o terceiro número: 23
O maior número é: 23
```

### Classificação por Idade:
```
Digite sua idade: 16
Classificação: Adolescente
```

## 🧠 Lógica Implementada

### Verificação Par/Ímpar:
```csharp
string resultado = numero % 2 == 0 ? "PAR" : "ÍMPAR";
```

### Faixas Etárias:
- **0-11 anos**: Criança
- **12-17 anos**: Adolescente  
- **18-59 anos**: Adulto
- **60+ anos**: Idoso

## 🎓 Nível de Dificuldade
**Iniciante/Intermediário** - Estruturas de controle básicas

---
*Parte do projeto PP Quest - Sistema de Questões em C#*
