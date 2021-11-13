using Microsoft.EntityFrameworkCore;
using Commander.Models;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        public DbSet<Command> Commands { get; set; }
        public CommanderContext(DbContextOptions<CommanderContext> i_oOpt) : base(i_oOpt) {}
    }
}