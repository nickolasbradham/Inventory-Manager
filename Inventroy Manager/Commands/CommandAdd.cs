using Inventroy_Manager.Commands.Add;
using Microsoft.Data.Sqlite;

namespace Inventroy_Manager.Commands
{
    internal class CommandAdd : AbstractCommand
    {
        internal readonly Dictionary<string, AbstractCommand> destinations = [];

        internal CommandAdd(Manager setManager) : base(setManager)
        {
            destinations.Add("type", new CommandAddType(setManager));
        }

        internal override void Execute(string args)
        {
            var split = args.IndexOf(' ');
            if (split == -1) split = args.Length;
            var destination = args[..split];
            if (destinations.TryGetValue(destination, out AbstractCommand? value))
                value.Execute(args[split..].Trim());
            else
                Console.WriteLine($"Unknown destination '{destination}'. Use 'help add' for a list of destinations.");
        }

        internal override string GetSimpleHelp()
        {
            return "Adds to existing database.";
        }

        internal override void Help(string args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(@"Usage: add <addition type> <addition name>.
Adds to the database.
Available Types:");
                foreach (var kv in destinations)
                {
                    Console.WriteLine($"{kv.Key,6} - {kv.Value.GetSimpleHelp()}");
                }
                Console.WriteLine("Use 'help add <type>' to get detailed info on add in relation to a type.");
            }
            else
            {
                var split = args.IndexOf(' ');
                if (split == -1) split = args.Length;
                if (destinations.TryGetValue(args[..split], out AbstractCommand? value))
                    value.Help(args[split..].Trim());
                else
                    Console.WriteLine($"Unknown destination '{args}'. Use 'help add' for a list of destinations.");
            }
        }
    }
}