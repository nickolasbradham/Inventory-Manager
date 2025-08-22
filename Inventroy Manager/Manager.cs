using Inventroy_Manager.Commands;
using Inventroy_Manager.Commands.Add;
using Inventroy_Manager.Commands.List;
using Inventroy_Manager.Commands.Remove;
using Microsoft.Data.Sqlite;
namespace Inventroy_Manager
{
    public class Manager
    {
        internal readonly Dictionary<string, AbstractCommand> commands = [];
        internal bool running = true;

        internal readonly SqliteConnection connection;
        private Manager(string dbPath)
        {
            commands.Add("add", new CommandAdd(this));
            commands.Add("remove", new CommandRemove(this));
            commands.Add("exit", new CommandExit(this));
            commands.Add("help", new CommandHelp(this));
            commands.Add("list", new CommandList(this));
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
                if (commands.TryGetValue(superCommand, out AbstractCommand? value))
                    value.Execute(input[split..].Trim());
                else
                    Console.WriteLine($"Unknown command '{superCommand}'. Use 'help' for a list of commands.");
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