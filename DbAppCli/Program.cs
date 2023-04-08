using DbAppCli.Controller;

Console.WriteLine("MySQL - Damien Pelaez-Diaz");

/*
 * Les commandes à éxecuter afin d'avoir les résultat sur programme se
 * trouve dans cmd.sql
 *
 * Je n'ai pas poussé trop les choses pour pas perdre du temps inutilement.
 * Je par donc du principe qu'il n'y à pas de faute de frappes ou d'erreur commise par l'utilisateur
 *
 * Les commandes sont également prédéfini
*/

ClientController clientController = new ClientController();
string cmd;
while (true)
{
 cmd = "";
 Console.WriteLine("\nAffichez tout les clients : 1");
  Console.WriteLine("Affiche un client : 2");
  Console.WriteLine("Créer un client : 3");
  Console.WriteLine("Modifier un client : 4");
  Console.WriteLine("Supprimez un client : 5");
  Console.Write("You C> ");
  try
  {
   cmd = Console.ReadLine();
   switch (cmd)
   {
    case "1":
     clientController.getClients();
     break;
    case "2":
     clientController.getClient("email", "bob.martin@example.com");
     break;
    case "3":
     string[] values = new string[] { "Gérard", "Junio" };
     clientController.updateClient(1, values);
     break;
    case "4":
     string[] data = new string[] { "Jeanne", "D'arc", "jeannebrule@gmail.com", "0123456789" };
     clientController.createClient(data);
     break;
    case "5":
     clientController.deleteClient(1);
     break;
    default:
     clientController.getClients();
     break;
   }
  }
  catch (Exception e)
  {
   Console.WriteLine("Erreur : " + e.Message);
  }
}
