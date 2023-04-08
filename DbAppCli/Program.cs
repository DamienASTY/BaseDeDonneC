using DbAppCli.Controller;

Console.WriteLine("MySQL - Damien Pelaez-Diaz");

/*
 * Les commandes à éxecuter afin d'avoir les résultat sur programme se
 * trouve dans cmd.sql
*/

ClientController clientController = new ClientController();
//clientController.GetClients();
clientController.GetClient("email", "bob.martin@example.com");