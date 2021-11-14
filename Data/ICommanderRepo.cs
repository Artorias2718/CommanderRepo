using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        void CreateCommand(Command i_oCmd);
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int i_nId);
        bool SaveChanges();
    }
}