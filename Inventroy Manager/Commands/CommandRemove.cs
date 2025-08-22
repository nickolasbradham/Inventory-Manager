namespace Inventroy_Manager.Commands
{
    internal class CommandRemove(Manager setManager) : AbstractCommand(setManager)
    {
        internal override void Execute(string args)
        {
            var split = args.Split(" ");
            if (split.Length != 2 || split[0] != "type")
            {
                Console.WriteLine("Invalid arguments. See 'help remove' for usage.");
                return;
            }
            var command = manager.connection.CreateCommand();
            command.CommandText = $"DROP TABLE IF EXISTS {split[1]};";
            command.ExecuteNonQuery();
        }

        internal override string GetSimpleHelp()
        {
            return "Removes data from the database.";
        }

        internal override void Help(string args)
        {
            Console.WriteLine(@"Usage: remove type <type name>
Removes an item from the database.");
        }
    }
}