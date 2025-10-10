# Refatoração para Padrões (Refactoring to Patterns)

O livro *Refactoring to Patterns* (Joshua Kerievsky, 2004) não introduz novos padrões, mas mostra como transformar código legado ou mal estruturado em código mais limpo usando padrões já existentes.

## Exemplos de Refatorações

### 1. Código cheio de `if/else` → Replace Conditional with Polymorphism → Strategy

**Antes (com if/else):**
```python
class Shipping:
    def __init__(self, type):
        self.type = type

    def calculate(self, order):
        if self.type == "standard":
            return order * 1.0
        elif self.type == "express":
            return order * 1.5
