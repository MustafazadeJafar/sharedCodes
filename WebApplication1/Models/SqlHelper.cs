using System.Data.SqlClient;
using System.Data;

namespace WebApplication1.Models;

public static class SqlHelper
{
    private const string _connectionString = @"Server= DESKTOP-SQ42S7L\SQLEXPRESS;Database = AzMB101_Jafar_Testing1;Trusted_Connection=true";
    public static async Task<DataTable> GetDatas(string query)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        DataTable dt = new DataTable();
        using SqlDataAdapter sda = new SqlDataAdapter(query, connection);
        sda.Fill(dt);
        await connection.CloseAsync();
        return dt;
    }
   
    }