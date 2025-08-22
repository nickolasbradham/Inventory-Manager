using System.Data;

namespace Inventroy_Manager.Commands.List
{
    internal class CommandListColumn(Manager setManager) : AbstractCommand(setManager)
    {
        internal override void Execute(string args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Invalid arguments. See 'help list column' for usage.");
                return;
            }
            var command = manager.connection.CreateCommand();
            command.CommandText = $"PRAGMA table_info({args});";
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(1));
            }
        }

        internal override string GetSimpleHelp()
        {
            return "Lists all columns in a given item type (table).";
        }

        internal override void Help(string args)
        {
            Console.WriteLine(@"Usage: list column <item>
Lists the columns of a given item.");
        }
    }
}