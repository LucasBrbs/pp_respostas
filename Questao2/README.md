# Refatoração para Padrões (Refactoring to Patterns)

O livro *Refactoring to Patterns* (Joshua Kerievsky, 2004) não introduz novos padrões, mas mostra como transformar código legado ou mal estruturado em código mais limpo usando padrões já existentes.

## Exemplos de Refatorações

### 1. Código cheio de `if/else` → trocar condicional por polimorfismo

**Antes (com if/else):**
```python
class Frete:
    def __init__(self, tipo):
        self.tipo = tipo

    def calcular(self, pedido):
        if self.tipo == "padrao":
            return pedido * 1.0
        elif self.tipo == "expresso":
            return pedido * 1.5
        elif self.tipo == "internacional":
            return pedido * 2.5
        elif self.tipo == "urgente":
            return pedido * 3.0
        elif self.tipo == "economico":
            return pedido * 0.8
        else:
            return pedido  # frete padrão caso tipo não seja reconhecido


