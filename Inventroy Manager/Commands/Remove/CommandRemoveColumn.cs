namespace Inventroy_Manager.Commands.Remove
{
    internal class CommandRemoveColumn(Manager setManager) : AbstractCommand(setManager)
    {
        internal override void Execute(string args)
        {
            var split = args.Split(' ');
            if (split.Length < 2)
            {
                Console.WriteLine("Invalid arguments. See 'help add column' for usage.");
                return;
            }
            var command = manager.connection.CreateCommand();
            command.CommandText = $"ALTER TABLE {split[0]} DROP COLUMN {split[1]};";
            command.ExecuteNonQuery();
        }

        internal override string GetSimpleHelp()
        {
            return "Deletes a column from a table.";
        }

        internal override void Help(string args)
        {
            Console.WriteLine("Usage: remove column <table> <column>");
        }
    }
}