namespace Inventroy_Manager.Commands
{
    internal class CommandExit(Manager setManager) : AbstractCommand(setManager)
    {
        internal override void Execute(string args)
        {
            manager.running = false;
        }
    }
}