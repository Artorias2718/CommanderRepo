using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

        // GET api/commands/{i_oId}
        [HttpGet("{i_oId}", Name="GetCommandById")]
        public ActionResult<CommandRead> GetCommandById(int i_oId)
        {
            var oCommandItem = m_oRepository.GetCommandById(i_oId);
            return oCommandItem != null
            ? Ok(m_oMapper.Map<CommandRead>(oCommandItem))
            : NotFound();
        }

        // POST api/commands
        [HttpPost]
        public ActionResult<CommandRead> CreateCommand(CommandCreate i_oCommandCreate)
        {
            var oCommandModel = m_oMapper.Map<Command>(i_oCommandCreate);
            m_oRepository.CreateCommand(oCommandModel);
            m_oRepository.SaveChanges();

            var oCommandRead = m_oMapper.Map<CommandRead>(oCommandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = oCommandRead.Id }, oCommandRead);
            //return Ok(oCommandRead);
        }

        // PUT api/commands/{i_oId}
        [HttpPut("{i_oId}")]
        public ActionResult UpdateCommand(int i_oId, CommandUpdate i_oCommandUpdate)
        {
            var oCommandModelFromRepo = m_oRepository.GetCommandById(i_oId);
            if(oCommandModelFromRepo == null)
            {
                return NotFound();
            }

            m_oMapper.Map(i_oCommandUpdate, oCommandModelFromRepo);

            // The EF takes care of this for us, so
            // UpdateCommand is technically useless,
            // but let's leave it here in case
            // we ever have any custom Update code
            // that needs to run in a CommanderRepo implementation.
            m_oRepository.UpdateCommand(oCommandModelFromRepo);
            m_oRepository.SaveChanges();

            return NoContent();
        }

        // PATCH api/commands/{i_oId}
        [HttpPatch("{i_oId}")]
        public ActionResult PartialCommandUpdate(int i_oId, JsonPatchDocument<CommandUpdate> i_oPatchDoc)
        {
            var oCommandModelFromRepo = m_oRepository.GetCommandById(i_oId);
            if(oCommandModelFromRepo == null)
            {
                return NotFound();
            }

            var oCommandToPatch = m_oMapper.Map<CommandUpdate>(oCommandModelFromRepo);
            i_oPatchDoc.ApplyTo(oCommandToPatch, ModelState);

            if(!TryValidateModel(oCommandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            m_oMapper.Map(oCommandToPatch, oCommandModelFromRepo);
            m_oRepository.UpdateCommand(oCommandModelFromRepo);
            m_oRepository.SaveChanges();

            return NoContent();   
        }
    }
}