using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using AutoMapper;
using Commander.DTO;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo m_oRepository;
        private readonly IMapper m_oMapper;

        public CommandsController(ICommanderRepo i_oRepository, IMapper i_oMapper)
        {
            m_oRepository = i_oRepository;
            m_oMapper = i_oMapper;
        }

        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandRead>> GetAllCommands()
        {
            var oCommandItems  = m_oRepository.GetAllCommands();
            return Ok(m_oMapper.Map<IEnumerable<CommandRead>>(oCommandItems));
        }

        // GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<CommandRead> GetCommandById(int id)
        {
            var oCommandItem = m_oRepository.GetCommandById(id);
            return oCommandItem != null
            ? Ok(m_oMapper.Map<CommandRead>(oCommandItem))
            : NotFound();
        }
    }
}