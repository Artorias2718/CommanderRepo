using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Commander.Data;
using Commander.Models;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo m_oRepository;

        public CommandsController(ICommanderRepo i_oRepository)
        {
            m_oRepository = i_oRepository;
        }

        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var oCommandItems  = m_oRepository.GetAllCommands();
            return Ok(oCommandItems);
        }

        // GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var oCommandItem = m_oRepository.GetCommandById(id);
            return Ok(oCommandItem);
        }
    }
}