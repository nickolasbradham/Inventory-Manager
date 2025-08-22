using Inventroy_Manager.Commands.Add;

namespace Inventroy_Manager.Commands.List
{
    internal class CommandList: AbstractCommand
    {
        internal readonly Dictionary<string, AbstractCommand> destinations = [];

        internal CommandList(Manager setManager) : base(setManager)
        {
            destinations.Add("column", new CommandListColumn(setManager));
            destinations.Add("type", new CommandListType(setManager));
        }

        internal override void Execute(string args)
        {
            var split = args.IndexOf(' ');
            if (split == -1) split = args.Length;
            var destination = args[..split];
            if (destinations.TryGetValue(destination, out AbstractCommand? value))
                value.Execute(args[split..].Trim());
            else
                Console.WriteLine($"Unknown destination '{destination}'. Use 'help list' for a list of destinations.");
        }

        internal override string GetSimpleHelp()
        {
            return "Lists data about the database.";
        }

        internal override void Help(string args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(@"Usage: list <data type>.
Adds to the database.
Available Types:");
                foreach (var kv in destinations)
                {
                    Console.WriteLine($"{kv.Key,6} - {kv.Value.GetSimpleHelp()}");
                }
                Console.WriteLine("Use 'help list <type>' to get detailed info on list in relation to a type.");
            }
            else
            {
                var split = args.IndexOf(' ');
                if (split == -1) split = args.Length;
                if (destinations.TryGetValue(args[..split], out AbstractCommand? value))
                    value.Help(args[split..].Trim());
                else
                    Console.WriteLine($"Unknown destination '{args}'. Use 'help list' for a list of destinations.");
            }
        }
    }
}