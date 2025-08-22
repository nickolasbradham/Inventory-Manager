
namespace Inventroy_Manager.Commands
{
    internal abstract class AbstractCommand(Manager setManager)
    {
        protected readonly Manager manager = setManager;

        internal abstract void Execute(string args);
        internal abstract void Help();
        internal abstract string GetSimpleHelp();
    }
}