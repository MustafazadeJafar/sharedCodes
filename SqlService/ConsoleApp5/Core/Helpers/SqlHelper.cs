using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp5.Core.Helpers;

public static class SqlHelper
{
    private const string _connectionString = @"Server = DESKTOP-SQ42S7L\SQLEXPRESS;Database = AzMB101_Jafar_ServiceDB;Trusted_Connection=true";
    
    public static string QGetAll(string table) => "SELECT * FROM " + table;
    public static string QGetById(string table, int id) => "SELECT * FROM " + table + "WHERE ID = " + id;
    public static string QDeleteById(string table, int id) => "DELETE " + table + "WHERE ID = " + id;
    public static string QInsert(string table, string[] values)
    {
        string query = $"INSERT INTO {table} VALUES(";
        for (int i = 0; i < values.Length; i++)
        {
            query += values[i] + ", ";
        }
        return query + ")";
    }

    public static DataTable GetDatas(string query)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        DataTable dt = new DataTable();
        using SqlDataAdapter sda = new SqlDataAdapter(query, connection);

        sda.Fill(dt);
        connection.Close();
        return dt;
    }
    public static int Exec(string query)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand command = new SqlCommand(query, connection);

        int result = command.ExecuteNonQuery();
        connection.Close();
        return result;
    }
}