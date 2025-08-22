namespace Inventroy_Manager.Commands.Add
{
    internal class CommandAddColumn(Manager setManager) : AbstractCommand(setManager)
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
            command.CommandText = split.Length == 2 ? $"ALTER TABLE {split[0]} ADD COLUMN {split[1]};" : $"ALTER TABLE {split[0]} ADD COLUMN {split[1]} {split[2]};";
            command.ExecuteNonQuery();
        }

        internal override string GetSimpleHelp()
        {
            return "Adds a column to a item table.";
        }

        internal override void Help(string args)
        {
            Console.WriteLine(@"Usage: add column <type name> <column name> [data type]
Adds a column to an existing table.
Data Types: INT, REAL, TEXT");
        }
    }
}