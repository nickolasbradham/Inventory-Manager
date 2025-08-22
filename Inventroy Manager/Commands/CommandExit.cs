namespace Inventroy_Manager.Commands
{
    internal class CommandExit(Manager setManager) : AbstractCommand(setManager)
    {
        internal override void Execute(string args)
        {
            manager.running = false;
        }

        internal override string GetSimpleHelp()
        {
            return "Exits the program.";
        }

        internal override void Help()
        {
            Console.WriteLine("Quits the program.");
        }
    }
}