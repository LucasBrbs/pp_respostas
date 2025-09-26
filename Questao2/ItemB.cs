// Código legado
public class Relatorio {
    public string Gerar() {
        return "Relatório básico";
    }

    public string GerarComRodape() {
        return Gerar() + "\nRodapé do relatório";
    }

    public string GerarComCabecalho() {
        return "Cabeçalho\n" + Gerar();
    }
}

// Componente
public interface IRelatorio {
    string Gerar();
}

// Componente concreto
public class RelatorioBasico : IRelatorio {
    public string Gerar() => "Relatório básico";
}

// Decorator abstrato
public abstract class RelatorioDecorator : IRelatorio {
    protected readonly IRelatorio _relatorio;
    protected RelatorioDecorator(IRelatorio relatorio) {
        _relatorio = relatorio;
    }
    public abstract string Gerar();
}

// Concrete Decorators
public class RelatorioComRodape : RelatorioDecorator {
    public RelatorioComRodape(IRelatorio relatorio) : base(relatorio) {}
    public override string Gerar() => _relatorio.Gerar() + "\nRodapé do relatório";
}

public class RelatorioComCabecalho : RelatorioDecorator {
    public RelatorioComCabecalho(IRelatorio relatorio) : base(relatorio) {}
    public override string Gerar() => "Cabeçalho\n" + _relatorio.Gerar();
}

// com isso é possível compor dinacmicamente 
var relatorio = new RelatorioComRodape(new RelatorioComCabecalho(new RelatorioBasico()));
Console.WriteLine(relatorio.Gerar());




// Move Embellishment to Decorator → Decorator
// Essa refatoração remove responsabilidades extras de uma classe principal e as
// move para decorators. O padrão Decorator permite adicionar funcionalidades de
// forma dinâmica e combinável, mantendo o código limpo e desacoplado.
