// Strategy
public interface IDescontoStrategy {
    double Calcular(double valor);
}

public class DescontoVip : IDescontoStrategy {
    public double Calcular(double valor) => valor * 0.8;
}

public class DescontoRegular : IDescontoStrategy {
    public double Calcular(double valor) => valor * 0.9;
}

public class SemDesconto : IDescontoStrategy {
    public double Calcular(double valor) => valor;
}

// Contexto
public class CalculadoraDesconto {
    private readonly IDescontoStrategy _strategy;
    public CalculadoraDesconto(IDescontoStrategy strategy) {
        _strategy = strategy;
    }
    public double Calcular(double valor) => _strategy.Calcular(valor);
}

// Replace Conditional with Polymorphism → Strategy
// Essa refatoração elimina cadeias de if/else criando uma hierarquia de classes
// com comportamentos diferentes, aplicando o padrão Strategy. O código fica mais
// flexível e fácil de estender sem precisar alterar o código existente.