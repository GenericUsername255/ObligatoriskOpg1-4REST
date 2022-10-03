
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ObligatoriskOpg1_4.Managers;
using ObligatoriskOpg1_4.Models;
using Microsoft.AspNetCore.Http;

namespace ObligatoriskOpg1_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayersController : ControllerBase
    {
        //public class _manager = new FootballPlayersManager();
        private readonly FootballPlayersManager _manager = new FootballPlayersManager();

        // GET: api/<FootballPlayersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<FootballPlayer> Get()
        {
            return _manager.GetAll();
        }

        // GET api/<FootballPlayersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Get(int id)        {

            FootballPlayer footballPlayer =  _manager.GetById(id);
            if (_manager == null)
            {
                return NotFound("No such player id: " + id);
            }
            return Ok(footballPlayer);


        }

        // POST api/<FootballPlayersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer value)
        {
            try
            {
                FootballPlayer footballPlayerNew = _manager.Add(value);
                string uri = Url.RouteUrl(RouteData.Values) + "/" + footballPlayerNew.Id;
                return Created(uri, footballPlayerNew);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<FootballPlayersController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Put(int id, [FromBody] FootballPlayer value)
        {
            try
            {
                FootballPlayer footballPlayerUpdated = _manager.Update(id, value);
                if (footballPlayerUpdated == null)
                {
                    return NotFound("No such player id: " + id);
                }
                return Ok(footballPlayerUpdated);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<FootballPlayersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            FootballPlayer footballPlayerDeleted = _manager.Delete(id);
            if (footballPlayerDeleted == null) 
            {
                return NotFound("No such player id: " + id);
            }
            return Ok(footballPlayerDeleted);
        }
    }
}