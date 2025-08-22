using Microsoft.Data.Sqlite;
namespace Inventory_Manager
{
    public class Manager
    {
        private static readonly char INPUT_START = '>';

        private readonly SqliteConnection connection;
        private Manager(string dbPath)
        {
            connection = new SqliteConnection($"Data Source={dbPath}");
        }

        private void Start()
        {
            connection.Open();
            string? command;
            Console.Write(INPUT_START);
            while ((command = Console.ReadLine()) != "exit")
            {
                switch (command)
                {
                    case "commands":
                        Console.WriteLine(@"Available commands:
    commands - Shows a list of available commands.
        exit - Quits the program.");
                        break;
                    case "": break;
                    default:
                        Console.WriteLine("Unknown command. Use 'commands' for a list of commands.");
                        break;
                }
                Console.Write(INPUT_START);
            }
        }

        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Must specify inventory file path.");
                return;
            }
            new Manager(args[0]).Start();
        }
    }
}