using Inventroy_Manager.Commands;
using Microsoft.Data.Sqlite;
namespace Inventroy_Manager
{
    public class Manager
    {
        public bool running = true;

        private readonly Dictionary<string, AbstractCommand> commands = [];
        private readonly SqliteConnection connection;
        private Manager(string dbPath)
        {
            commands.Add("exit", new CommandExit(this));
            connection = new SqliteConnection($"Data Source={dbPath}");
        }

        private void Start()
        {
            connection.Open();
            string? input;
            do
            {
                Console.Write('>');
                input = Console.ReadLine();
                if (input == null) return;
                var split = input.IndexOf(' ');
                if (split == -1) split = input.Length;
                var superCommand = input[..split];
                if (!commands.ContainsKey(superCommand))
                {
                    Console.WriteLine("Unknown command.");
                    continue;
                }
                commands[superCommand].Execute(input[split..]);
            } while (running);
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