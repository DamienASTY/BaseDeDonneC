using System;
using MySql.Data.MySqlClient;

namespace DbAppCli.Controller;

/*  Cette classe sert à instancier la connexion pour ne pas répeter
    L'opération à chaque controller
 */
public class Factory
{
    private static string _connectionString = "server=localhost;database=Banque;user=root;password=";
    protected static MySqlConnection _connection;

    public static MySqlConnection init()
    {
        try
        {
            _connection = new MySqlConnection(_connectionString);
            _connection.Open();
            return _connection;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            return null;
        }
    }
    
    //Ferme la connexion (destructeur)
    ~Factory()
    {
        _connection.Close();
    }
}