namespace Inventroy_Manager.Commands
{
    internal class CommandList(Manager setManager) : AbstractCommand(setManager)
    {
        internal override void Execute(string args)
        {
            if (args != "type")
            {
                Console.WriteLine("Invalid arguments. See 'help list' for usage.");
                return;
            }
            var command = manager.connection.CreateCommand();
            command.CommandText = "SELECT name FROM sqlite_master";
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
            }
        }

        internal override string GetSimpleHelp()
        {
            return "Lists data about the database.";
        }

        internal override void Help(string args)
        {
            Console.WriteLine(@"Usage: list type
Lists data about the database.");
        }
    }
}