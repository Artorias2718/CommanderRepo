using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private CommanderContext m_oContext;

        public SqlCommanderRepo(CommanderContext i_oContext)
        {
            m_oContext = i_oContext;
        }
        public IEnumerable<Command> GetAllCommands()
        {
            return m_oContext.Commands.ToList();
        }

        public Command GetCommandById(int i_nId)
        {
            return m_oContext.Commands.FirstOrDefault(p => p.Id == i_nId);
        }

        public void CreateCommand(Command i_oCmd)
        {
            if(i_oCmd == null)
            {
                throw new ArgumentNullException(nameof(i_oCmd));
            }

            m_oContext.Commands.Add(i_oCmd);
        }

        public void UpdateCommand(Command i_oCmd)
        {
            // ...Nothing...
        }

        public void DeleteCommand(Command i_oCmd)
        {
            if(i_oCmd == null)
            {
                throw new ArgumentNullException(nameof(i_oCmd));
            }
            
            m_oContext.Commands.Remove(i_oCmd);
            SaveChanges();
        }

        public bool SaveChanges()
        {
            return m_oContext.SaveChanges() >= 0;
        }
    }
}