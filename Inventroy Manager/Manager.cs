using Inventroy_Manager.Commands;
using Microsoft.Data.Sqlite;
namespace Inventroy_Manager
{
    public class Manager
    {
        internal readonly Dictionary<string, AbstractCommand> commands = [];
        internal bool running = true;

        private readonly SqliteConnection connection;
        private Manager(string dbPath)
        {
            commands.Add("exit", new CommandExit(this));
            commands.Add("help", new CommandHelp(this));
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
                if (superCommand == "") continue;
                if (!commands.ContainsKey(superCommand))
                {
                    Console.WriteLine($"Unknown command '{superCommand}'. Use 'help' for a list of commands.");
                    continue;
                }
                commands[superCommand].Execute(input[split..].Trim());
                Console.WriteLine();
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