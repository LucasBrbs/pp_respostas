# 🧠 Comparação entre DAO, Data Mapper e Repository com exemplos em C#

Este README contém toda a explicação conceitual, comparativa e prática dos padrões **DAO**, **Data Mapper** e **Repository**, além de um exemplo sobre **Agregado e Invariantes** no contexto de **DDD (Domain-Driven Design)**.

---

## 🧩 Questão 1

### a) Compare-os no nível conceitual.

A diferença principal entre eles é que o **DAO** separa as persistências do negócio com o banco de dados (persistência).  
O **Data Mapper** apenas **traduz** o objeto para o banco e **necessita de um Repository/Service**, ou seja, requer **mais uma camada de abstração**.  

O **Repository**, por sua vez, é usado como uma **camada de abstração para os dois casos**.  
Ele organiza e expõe métodos amigáveis para a aplicação, podendo aplicar **regras de negócio** ou **validações** antes de persistir os dados.

---

### b) Ilustre as diferenças entre os mesmos em código.

---

# DAO

```csharp
using System;
using System.Data.SqlClient;

public class User
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}

public interface IUserDAO
{
    void Salvar(User user);
}

public class UserDAOImpl : IUserDAO
{
    private readonly SqlConnection _connection;

    public UserDAOImpl(SqlConnection connection)
    {
        _connection = connection;
    }

    public void Salvar(User user)
    {
        string sql = "INSERT INTO Users (Nome, Email) VALUES (@Nome, @Email)";
        using (SqlCommand cmd = new SqlCommand(sql, _connection))
        {
            cmd.Parameters.AddWithValue("@Nome", user.Nome);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.ExecuteNonQuery();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=localhost;Database=MinhaBase;User Id=usuario;Password=senha;";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            IUserDAO userDAO = new UserDAOImpl(conn);
            userDAO.Salvar(new User { Nome = "Lucas", Email = "lucas@email.com" });

            Console.WriteLine("Usuário salvo com sucesso!");
        }
    }
}

#Data Mapper
using System;
using System.Data.SqlClient;

public class User
{
    public string Nome { get; set; }
    public string Email { get; set; }
}

public class UserMapper
{
    private SqlConnection _conn;
    public UserMapper(SqlConnection conn) => _conn = conn;

    public void Insert(User user)
    {
        string sql = "INSERT INTO Users (Nome, Email) VALUES (@Nome, @Email)";
        using var cmd = new SqlCommand(sql, _conn);
        cmd.Parameters.AddWithValue("@Nome", user.Nome);
        cmd.Parameters.AddWithValue("@Email", user.Email);
        cmd.ExecuteNonQuery();
    }
}

class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost;Database=MinhaBase;User Id=usuario;Password=senha;";

        using var conn = new SqlConnection(connectionString);
        conn.Open();

        var mapper = new UserMapper(conn);
        mapper.Insert(new User { Nome = "Lucas", Email = "lucas@email.com" });

        Console.WriteLine("Usuário criado com sucesso!");
    }
}

# Repository 
using System;
using System.Data.SqlClient;

public class User
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}

public class UserMapper
{
    private SqlConnection _conn;
    public UserMapper(SqlConnection conn) => _conn = conn;

    public void Insert(User user)
    {
        string sql = "INSERT INTO Users (Nome, Email) VALUES (@Nome, @Email)";
        using var cmd = new SqlCommand(sql, _conn);
        cmd.Parameters.AddWithValue("@Nome", user.Nome);
        cmd.Parameters.AddWithValue("@Email", user.Email);
        cmd.ExecuteNonQuery();
    }

    public User FindById(int id)
    {
        string sql = "SELECT Id, Nome, Email FROM Users WHERE Id = @Id";
        using var cmd = new SqlCommand(sql, _conn);
        cmd.Parameters.AddWithValue("@Id", id);
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return new User
            {
                Id = (int)reader["Id"],
                Nome = reader["Nome"].ToString(),
                Email = reader["Email"].ToString()
            };
        }
        return null;
    }
}

public class UserRepository
{
    private UserMapper _mapper;
    public UserRepository(UserMapper mapper) => _mapper = mapper;

    public void Registrar(User user)
    {
        if (string.IsNullOrEmpty(user.Email))
            throw new Exception("Email é obrigatório!");
        _mapper.Insert(user);
    }

    public User ObterUsuario(int id)
    {
        return _mapper.FindById(id);
    }
}

class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost;Database=MinhaBase;User Id=usuario;Password=senha;";

        using var conn = new SqlConnection(connectionString);
        conn.Open();

        var repo = new UserRepository(new UserMapper(conn));

        var novoUser = new User { Nome = "Lucas", Email = "lucas@email.com" };
        repo.Registrar(novoUser);

        var user = repo.ObterUsuario(1);
        Console.WriteLine(user.Nome);
    }
}

# AGREGADO E INVARIANTES (DDD)
using System;
using System.Collections.Generic;

public class Pedido {
    public Guid Id { get; private set; }
    public List<ItemPedido> Itens { get; private set; } = new();

    public Pedido() {
        Id = Guid.NewGuid();
    }

    public void AdicionarItem(string nome, int quantidade) {
        if (quantidade <= 0)
            throw new InvalidOperationException("Quantidade deve ser maior que zero.");
        Itens.Add(new ItemPedido(nome, quantidade));
    }
}

public class ItemPedido {
    public string Nome { get; private set; }
    public int Quantidade { get; private set; }

    public ItemPedido(string nome, int quantidade) {
        Nome = nome;
        Quantidade = quantidade;
    }
}

public interface IPedidoRepository {
    Pedido ObterPorId(Guid id);
    void Salvar(Pedido pedido);
}
