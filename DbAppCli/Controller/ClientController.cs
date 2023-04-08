using MySql.Data.MySqlClient;

namespace DbAppCli.Controller;

public class ClientController: Factory
{
    private MySqlConnection _connection = init();
    
    //Cette méthode liste tout les clients de la banque
    public void getClients()
    {
        string query = "SELECT * FROM client";

        MySqlCommand command = new MySqlCommand(query, _connection);
        
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine("ID : "+reader.GetString(0)+" ; first_name : "+reader.GetString(1)+" ; last_name : "+reader.GetString(2)+" ; email : "+reader.GetString(3)+" ; phone : "+reader.GetString(4));
        }
        closeReader(reader);
    }
    
    //Cette méthode list un client selon un critère bien défini
    public void getClient(string selector, string selectorValue)
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
                getClients();
                break;
        }
        
        MySqlCommand command = new MySqlCommand(query, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine("ID : "+reader.GetString(0)+" ; first_name : "+reader.GetString(1)+" ; last_name : "+reader.GetString(2)+" ; email : "+reader.GetString(3)+" ; phone : "+reader.GetString(4));
        }
        closeReader(reader);
    }
    
    //Crée un nouveau client
    public void createClient(string[] values)
    {
        if (values.Length-1 != 3)
        {
            Console.WriteLine("Erreur trop ou trop peu de champs");
        }
        else
        {
            string query = "INSERT INTO client (first_name, last_name, email, phone) VALUES ('" + MySqlHelper.EscapeString(values[0]) + "','" + MySqlHelper.EscapeString(values[1]) + "','" + MySqlHelper.EscapeString(values[2]) + "','" + MySqlHelper.EscapeString(values[3]) + "')";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.ExecuteNonQuery();
            //values 2 est l'email
            getClient("email", values[2]);
        }
    }
    
    //Cette fonction met à jour les données first_name et last_name d'un client
    public void updateClient(int id, string[] values)
    {
        string query = "UPDATE client SET first_name = '" + values[0] + "', last_name = '"+values[1]+"' WHERE ID = "+id;
        MySqlCommand command = new MySqlCommand(query, _connection);

        query = "SELECT * FROM client WHERE ID = " + id;
        
        MySqlCommand command2 = new MySqlCommand(query, _connection);
        MySqlDataReader reader = command2.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine("ID : "+reader.GetString(0)+" ; first_name : "+reader.GetString(1)+" ; last_name : "+reader.GetString(2)+" ; email : "+reader.GetString(3)+" ; phone : "+reader.GetString(4));
        }
        closeReader(reader);
    }

    public void deleteClient(int id)
    {
        string query = "DELETE FROM client WHERE ID = " + id;
        MySqlCommand command = new MySqlCommand(query, _connection);
        command.ExecuteNonQuery();
        getClients();
    }

    public void closeReader(MySqlDataReader reader)
    {
        if (reader != null)
        {
            reader.Close();
        }
    }
}