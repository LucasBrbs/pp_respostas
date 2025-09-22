using System;
using System.Data.SqlClient;

// Entidade
// entidade modelo com dados padrões
public class User
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}

// Interface DAO com o método salvar 
public interface IUserDAO
{
    void Salvar(User user);
}

// Implementação DAO usado para persistência
// criaçao da implementacao do dao 
public class UserDAOImpl : IUserDAO
{
    private readonly SqlConnection _connection;

    public UserDAOImpl(SqlConnection connection)
    {
        _connection = connection;
    }

    // funcao básica para inserir no banco de dados nome e email do usuario quando criado
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

// Uso no programa padrão
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

// nesse caso o dao terceiriza várias criacóes que teriam que ser feitas dentro do programa principal separando a lógica 
// de persistência de dados da lógica de negócio do aplicativo.