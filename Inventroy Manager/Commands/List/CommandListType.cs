namespace Inventroy_Manager.Commands.List
{
    internal class CommandListType(Manager setManager) : AbstractCommand(setManager)
    {
        private readonly static string HELP_TEXT = "Lists all item types (tables).";

        internal override void Execute(string args)
        {
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
            return HELP_TEXT;
        }

        internal override void Help(string args)
        {
            Console.WriteLine(HELP_TEXT);
        }
    }
}