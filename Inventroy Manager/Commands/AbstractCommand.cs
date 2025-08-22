namespace Inventroy_Manager.Commands
{
    internal abstract class AbstractCommand(Manager setManager)
    {
        protected readonly Manager manager = setManager;

        internal abstract void Execute(string args);
    }
}