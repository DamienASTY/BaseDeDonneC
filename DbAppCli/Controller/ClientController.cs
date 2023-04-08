using MySql.Data.MySqlClient;

namespace DbAppCli.Controller;

public class ClientController: Factory
{
    private MySqlConnection _connection = init();
    
    //Cette méthode liste tout les clients de la banque
    public void GetClients()
    {
        string query = "SELECT * FROM client";

        MySqlCommand command = new MySqlCommand(query, _connection);
        
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine("ID : "+reader.GetString(0)+" ; first_name : "+reader.GetString(1)+" ; last_name : "+reader.GetString(2)+" ; email : "+reader.GetString(3)+" ; phone : "+reader.GetString(4));
        }
    }
    
    //Cette méthode list un client selon un critère bien défini
    public void GetClient(string selector, string selectorValue)
    {
        //selector est l'option de la clause WHERE et value la valeur de la clause.
        string query = "SELECT * FROM client";
        switch (selector)
        {
            case "ID":
                query += " WHERE ID = " + selectorValue;
                break;
            case "email":
                query += " WHERE email = '" + selectorValue + "'";
                break;
            case "phone":
                query += " WHERE phone = " + selectorValue;
                break;
            default:
                GetClients();
                break;
        }
        
        MySqlCommand command = new MySqlCommand(query, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine("ID : "+reader.GetString(0)+" ; first_name : "+reader.GetString(1)+" ; last_name : "+reader.GetString(2)+" ; email : "+reader.GetString(3)+" ; phone : "+reader.GetString(4));
        }
    }

    public void update(string id, string[] value)
    {
        
    }
}