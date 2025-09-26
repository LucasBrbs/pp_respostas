/* Diferente do DAO este abstrai mais uma camada de complexidade
Data Mapper é responsável por transferir dados entre objetos e um banco de dados, mantendo-os independentes um do outro e do mapeamento de dados.
Ele atua como um intermediário que mapeia os dados do banco para os objetos do domínio e vice-versa, permitindo que os objetos do domínio permaneçam livres de detalhes de persistência.
Isso facilita a manutenção e a evolução do código, pois as mudanças na estrutura do banco de dados ou na lógica de negócio não afetam diretamente um ao outro.
*/

using System;
using System.Data.SqlClient;

// Entidade
public class User
{
    public string Nome { get; set; }
    public string Email { get; set; }
}

// Data Mapper simples
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

// Uso no Main
class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost;Database=MinhaBase;User Id=usuario;Password=senha;";

        using var conn = new SqlConnection(connectionString);
        conn.Open();

        var mapper = new UserMapper(conn);

        // Criar usuário
        mapper.Insert(new User { Nome = "Lucas", Email = "lucas@email.com" });

        Console.WriteLine("Usuário criado com sucesso!");
    }
}

// resumindo ele apenas faz a traducao dos dados do banco para o objeto e do objeto para o banco