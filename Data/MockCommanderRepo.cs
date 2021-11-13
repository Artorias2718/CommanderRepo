using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>()
            {
                new Command { Id = 0, HowTo = "Boil an Egg", Line = "Boil Water", Platform = "Kettle & Pan" },
                new Command { Id = 1, HowTo = "Cut Bread", Line = "Get a Knife", Platform = "Knife & Chopping Board" },
                new Command { Id = 2, HowTo = "Make Cup of Tea", Line = "Place Teabag in Cup", Platform = "Kettle & Cup" },
            };

            return commands;
        }

        public Command GetCommandById(int i_nId)
        {
            return new Command{ Id = 0, HowTo = "Boil an Egg", Line = "Boil Water", Platform = "Kettle & Pan" };
        }
    }
}