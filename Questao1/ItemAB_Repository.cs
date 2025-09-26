/*
   User Repository
   Responsável por gerenciar a persistência de usuários.
   é mais uma camada de abstração que decide quando usar o Data Mapper ou o DAO.
   Não faz a traducao dos dados, apenas decide quando buscar e salvar dados
*/

using System;
using System.Data.SqlClient;

// Entidade
public class User
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}

// Mapper (tradutor objeto <-> banco)
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

// Repository (orquestra o uso do Mapper e aplica regras)
public class UserRepository
{
    private UserMapper _mapper;
    public UserRepository(UserMapper mapper) => _mapper = mapper;

    public void Registrar(User user)
    {
        // Exemplo de regra de negócio simples
        if (string.IsNullOrEmpty(user.Email))
            throw new Exception("Email é obrigatório!");

        _mapper.Insert(user); // chama o mapper para salvar
    }

    public User ObterUsuario(int id)
    {
        return _mapper.FindById(id); // chama o mapper para buscar
    }
}

// Uso no Main
class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost;Database=MinhaBase;User Id=usuario;Password=senha;";

        using var conn = new SqlConnection(connectionString);
        conn.Open();

        var repo = new UserRepository(new UserMapper(conn));

        var novoUser = new User { Nome = "Lucas", Email = "lucas@email.com" };
        repo.Registrar(novoUser); // salva usuário com regra

        var user = repo.ObterUsuario(1); // busca usuário
        Console.WriteLine(user.Nome);
    }
}
