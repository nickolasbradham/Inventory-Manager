namespace Inventroy_Manager.Commands
{
    internal class CommandExit(Manager setManager) : AbstractCommand(setManager)
    {
        private static readonly string HELP_TEXT = "Exits the program.";

        internal override void Execute(string args)
        {
            manager.running = false;
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