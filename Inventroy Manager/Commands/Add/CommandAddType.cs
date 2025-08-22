namespace Inventroy_Manager.Commands.Add
{
    internal class CommandAddType(Manager setManager) : AbstractCommand(setManager)
    {
        private static readonly string HELP_TEXT = "Adds a new item type (table).";
        internal override void Execute(string args)
        {
            var command = manager.connection.CreateCommand();
            command.CommandText = $"CREATE TABLE {args} (id INTEGER PRIMARY KEY);";
            command.ExecuteNonQuery();
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