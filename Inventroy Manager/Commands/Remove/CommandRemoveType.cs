namespace Inventroy_Manager.Commands.Remove
{
    internal class CommandRemoveType(Manager setManager) : AbstractCommand(setManager)
    {
        internal override void Execute(string args)
        {
            var command = manager.connection.CreateCommand();
            command.CommandText = $"DROP TABLE IF EXISTS {args};";
            command.ExecuteNonQuery();
        }

        internal override string GetSimpleHelp()
        {
            return "Deletes an item type and all items of that type.";
        }

        internal override void Help(string args)
        {
            Console.WriteLine("Usage: remove type <type name>");
        }
    }
}