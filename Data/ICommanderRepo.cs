using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int i_nId);
        void CreateCommand(Command i_oCmd);
        void UpdateCommand(Command i_oCmd);
        void DeleteCommand(Command i_oCmd);
        bool SaveChanges();
    }
}