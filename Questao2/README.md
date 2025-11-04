Questão 2 – Refactoring to Patterns (Joshua Kerievsky, 2004)

O livro Refactoring to Patterns mostra como transformar código legado em um design mais limpo, aplicando padrões de projeto conhecidos.
A seguir, são apresentados três exemplos práticos de refatoração e seus respectivos padrões resultantes.

1. Replace Conditional with Polymorphism → Padrão Strategy

Antes da refatoração

O código original usa vários blocos if/else para definir o tipo de frete. Esse modelo é difícil de manter, pois qualquer novo tipo exige alterar a classe principal.

```csharp
class Frete:
    def __init__(self, tipo):
        self.tipo = tipo

    def calcular(self, pedido):
        if self.tipo == "normal":
            return pedido * 1.0
        elif self.tipo == "expresso":
            return pedido * 1.5
        elif self.tipo == "internacional":
            return pedido * 2.0
        else:
            raise ValueError("Tipo de frete inválido")
```

Depois da refatoração (usando Strategy)

Cada tipo de frete é uma classe separada, que implementa uma mesma interface.
Assim, é possível adicionar novos comportamentos sem modificar código existente.
```csharp
from abc import ABC, abstractmethod

# Interface comum para as estratégias
class EstrategiaFrete(ABC):
    @abstractmethod
    def calcular(self, pedido):
        pass

# Estratégia concreta para frete normal
class FreteNormal(EstrategiaFrete):
    def calcular(self, pedido):
        return pedido * 1.0

# Estratégia concreta para frete expresso
class FreteExpresso(EstrategiaFrete):
    def calcular(self, pedido):
        return pedido * 1.5

# Estratégia concreta para frete internacional
class FreteInternacional(EstrategiaFrete):
    def calcular(self, pedido):
        return pedido * 2.0

# Classe que utiliza a estratégia
class CalculadoraFrete:
    def __init__(self, estrategia: EstrategiaFrete):
        self.estrategia = estrategia

    def calcular(self, pedido):
        return self.estrategia.calcular(pedido)

# Exemplo de uso
pedido = 100
frete = CalculadoraFrete(FreteExpresso())
print(f"Valor do frete: {frete.calcular(pedido)}")
```

Benefício:
A lógica condicional desaparece, e novos tipos de frete são adicionados sem alterar a classe principal.

2. Move Embellishment to Decorator → Padrão Decorator

Antes da refatoração

A classe Relatorio possuía várias responsabilidades extras (negrito, borda, etc.), o que dificultava a manutenção.
```csharp
class Relatorio:
    def gerar(self):
        return "Relatório base"

    def gerar_com_borda(self):
        return "====\n" + self.gerar() + "\n===="

    def gerar_em_negrito(self):
        return "**" + self.gerar() + "**"
```

Depois da refatoração (usando Decorator)

As responsabilidades adicionais são movidas para decoradores independentes.
Cada um adiciona sua própria funcionalidade, sem alterar o código da classe base.

```csharp
# Classe base simples
class RelatorioBase:
    def gerar(self):
        return "Relatório base"

    # Métodos fluentes para encadear decoradores
    def com_borda(self):
        return BordaDecorator(self)

    def com_negrito(self):
        return NegritoDecorator(self)

# Classe abstrata de decorador
class DecoradorRelatorio:
    def __init__(self, relatorio):
        self.relatorio = relatorio

    def gerar(self):
        return self.relatorio.gerar()

# Decorador para borda
class BordaDecorator(DecoradorRelatorio):
    def gerar(self):
        return "====\n" + self.relatorio.gerar() + "\n===="

# Decorador para negrito
class NegritoDecorator(DecoradorRelatorio):
    def gerar(self):
        return "**" + self.relatorio.gerar() + "**"

# Exemplo de uso encadeado
relatorio = RelatorioBase().com_borda().com_negrito()
print(relatorio.gerar())
```

Benefício:
Permite adicionar ou remover funcionalidades dinamicamente. O código fica mais modular e segue o princípio da responsabilidade única.

