namespace Inventroy_Manager.Commands
{
    internal class CommandHelp(Manager setManager) : AbstractCommand(setManager)
    {
        internal override void Execute(string args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Available commands:");
                foreach (var kv in manager.commands)
                {
                    Console.WriteLine($"{kv.Key,6} - {kv.Value.GetSimpleHelp()}");
                }
                Console.WriteLine("Use 'help <command>' to get detailed info on a command.");
            }
            else
            {
                var split = args.IndexOf(' ');
                if (split == -1) split = args.Length;
                if (manager.commands.TryGetValue(args[..split], out AbstractCommand? value))
                    value.Help(args[split..].Trim());
                else
                    Console.WriteLine($"Unknown command '{args}'. Use 'help' for a list of commands.");

            }
        }

        internal override string GetSimpleHelp()
        {
            return "Prints help text.";
        }

        internal override void Help(string args)
        {
            Console.WriteLine("Shows help text. Use 'help <command>' to get detailed info on a command.");
        }
    }
}