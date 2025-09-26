// Entidade raiz do agregado
public class Pedido {
    public Guid Id { get; private set; }
    public List<ItemPedido> Itens { get; private set; } = new();

    public Pedido() {
        Id = Guid.NewGuid();
    }

    // Regra de negócio (invariante): quantidade deve ser positiva
    public void AdicionarItem(string nome, int quantidade) {
        if (quantidade <= 0)
            throw new InvalidOperationException("Quantidade deve ser maior que zero.");

        Itens.Add(new ItemPedido(nome, quantidade));
    }
}

// Entidade interna (não acessada diretamente pelo repositório)
public class ItemPedido {
    public string Nome { get; private set; }
    public int Quantidade { get; private set; }

    public ItemPedido(string nome, int quantidade) {
        Nome = nome;
        Quantidade = quantidade;
    }
}

// Repository trabalha sempre com o agregado completo (Pedido)
public interface IPedidoRepository {
    Pedido ObterPorId(Guid id);
    void Salvar(Pedido pedido);
}

//O Pedido é o Agregado.

//A regra "quantidade > 0" é o Invariante.

//O Repository nunca salva só ItemPedido, sempre o Pedido completo, garantindo consistência.