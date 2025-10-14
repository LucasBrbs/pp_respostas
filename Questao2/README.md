# Refactoring to Patterns (Joshua Kerievsky, 2004)

O livro **Refactoring to Patterns** mostra como transformar código legado ou mal estruturado em código mais limpo e flexível, aplicando padrões de projeto conhecidos.
A seguir, são apresentados dois exemplos práticos de refatoração com seus respectivos padrões de projeto resultantes.

---

## 1. Substituir Conditional por Polymorphism → Padrão **Strategy**

### Antes da refatoração

O código original possuía vários blocos `if/else` para determinar o tipo de cálculo do frete.
Esse tipo de estrutura torna o código rígido e difícil de manter, já que qualquer novo tipo de frete exige alterar a classe existente.

```python
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

### Depois da refatoração (usando Strategy)

A refatoração substitui os condicionais por polimorfismo.
Cada tipo de frete é encapsulado em uma classe que implementa a mesma interface, facilitando a adição de novos comportamentos sem modificar código existente.

```python
from abc import ABC, abstractmethod

class EstrategiaFrete(ABC):
    @abstractmethod
    def calcular(self, pedido):
        pass

class FreteNormal(EstrategiaFrete):
    def calcular(self, pedido):
        return pedido * 1.0

class FreteExpresso(EstrategiaFrete):
    def calcular(self, pedido):
        return pedido * 1.5

class FreteInternacional(EstrategiaFrete):
    def calcular(self, pedido):
        return pedido * 2.0

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

**Benefício:**
A lógica condicional foi eliminada. Agora, novos tipos de frete podem ser criados apenas adicionando novas classes de estratégia, sem alterar o código existente.

---

## 2. Mudar Embellishment para Decorator → Padrão **Decorator**

### Antes da refatoração

A classe `Relatorio` possuía várias responsabilidades adicionais (adicionar borda, negrito, etc.), violando o princípio da responsabilidade única.
Esses métodos extras dificultavam a manutenção e a extensão do código.

```python
class Relatorio:
    def gerar(self):
        return "Relatório base"

    def gerar_com_borda(self):
        return "====\n" + self.gerar() + "\n===="

    def gerar_em_negrito(self):
        return "**" + self.gerar() + "**"
```

### Depois da refatoração (usando Decorator)

O comportamento adicional foi movido para classes separadas chamadas **decoradores**.
Cada decorador adiciona uma funcionalidade sem alterar o código da classe base.

```python
class RelatorioBase:
    def gerar(self):
        return "Relatório base"

class DecoradorRelatorio:
    def __init__(self, relatorio):
        self.relatorio = relatorio

    def gerar(self):
        return self.relatorio.gerar()

class BordaDecorator(DecoradorRelatorio):
    def gerar(self):
        return "====\n" + self.relatorio.gerar() + "\n===="

class NegritoDecorator(DecoradorRelatorio):
    def gerar(self):
        return "**" + self.relatorio.gerar() + "**"

# Exemplo de uso
relatorio = NegritoDecorator(BordaDecorator(RelatorioBase()))
print(relatorio.gerar())
```

**Benefício:**
O padrão **Decorator** permite adicionar ou remover funcionalidades dinamicamente, sem alterar a classe principal.
O código torna-se mais modular e fácil de estender.

---

## Conclusão

Essas duas refatorações demonstram como padrões de projeto podem melhorar o design de código:

* **Replace Conditional with Polymorphism (Strategy):** substitui estruturas condicionais por classes especializadas.
* **Move Embellishment to Decorator (Decorator):** move responsabilidades adicionais para decoradores reutilizáveis.

Ambas as abordagens reduzem acoplamento, aumentam coesão e facilitam a evolução do sistema.
