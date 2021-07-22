using AutoMapper;
using IBM_TheaterWebAppi.Entities;
using IBM_TheaterWebAppi.ExternalsModels;
using IBM_TheaterWebAppi.Services.UnitsOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_TheaterWebAppi.Controllers
{
    [Route("theater")]
    [ApiController]
    [EnableCors]
    public class TheaterController : ControllerBase
    {
        private readonly ITheaterUnitOfWork _theaterUnit;
        private readonly IMapper _mapper;

        public TheaterController(ITheaterUnitOfWork theaterUnit,
            IMapper mapper)
        {
            _theaterUnit = theaterUnit ?? throw new ArgumentNullException(nameof(theaterUnit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }



        #region Theaters
        [HttpGet, Authorize]
        [Route("{id}", Name = "GetTheater")]
        public IActionResult GetTheater(Guid id)
        {
            var theaterEntity = _theaterUnit.Theaters.Get(id);
            if (theaterEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TheaterDTO>(theaterEntity));
        }

        [HttpGet, Authorize]
        [Route("", Name = "GetAllTheaters")]
        public IActionResult GetAllTheaters()
        {
            var theaterEntity = _theaterUnit.Theaters.Find(a => a.Deleted == false || a.Deleted == null);
            if (theaterEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<TheaterDTO>>(theaterEntity));
        }

        [HttpGet, Authorize]
        [Route("details/{id}", Name = "GetTheaterDetails")]
        public IActionResult GetBookDetails(Guid id)
        {
            var theaterEntity = _theaterUnit.Theaters.GetTheaterDetails(id);
            if (theaterEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TheaterDTO>(theaterEntity));
        }

        [Route("add", Name = "Add a new theater")]
        [HttpPost, Authorize]
        public IActionResult AddTheater([FromBody] TheaterDTO theater)
        {
            var theaterEntity = _mapper.Map<Theater>(theater);
            _theaterUnit.Theaters.Add(theaterEntity);

            _theaterUnit.Complete();

            _theaterUnit.Theaters.Get(theaterEntity.ID);

            return CreatedAtRoute("GetTheater",
                new { id = theaterEntity.ID },
                _mapper.Map<TheaterDTO>(theaterEntity));
        }
        #endregion Theaters



        #region Actors
        [HttpGet, Authorize]
        [Route("actor/{actorId}", Name = "GetActor")]
        public IActionResult GetActor(Guid actorId)
        {
            var actorEntities = _theaterUnit.Actors.Get(actorId);
            if (actorEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ActorDTO>(actorEntities));
        }

        [HttpGet, Authorize]
        [Route("actor", Name = "GetAllActors")]
        public IActionResult GetAllActors()
        {
            var actorEntities = _theaterUnit.Actors.Find(a => a.Deleted == false || a.Deleted == null);
            if (actorEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<ActorDTO>>(actorEntities));
        }

        [Route("actor/add", Name = "Add a new actor")]
        [HttpPost, Authorize]
        public IActionResult AddAuthor([FromBody] ActorDTO author)
        {
            var actorEntities = _mapper.Map<Actor>(author);
            _theaterUnit.Actors.Add(actorEntities);

            _theaterUnit.Complete();

            _theaterUnit.Actors.Get(actorEntities.ID);

            return CreatedAtRoute("GetActor",
                new { authorId = actorEntities.ID },
                _mapper.Map<ActorDTO>(actorEntities));
        }

        [Route("actor/{actorId}", Name = "Mark actor as deleted")]
        [HttpPut, Authorize]
        public IActionResult MarkAuthorAsDeleted(Guid actorId)
        {
            var actor = _theaterUnit.Actors.FindDefault(a => a.ID.Equals(actorId) && (a.Deleted == false || a.Deleted == null));
            if (actor != null)
            {
                actor.Deleted = true;
                if (_theaterUnit.Complete() > 0)
                {
                    return Ok("Actor " + actorId + " was deleted.");
                }
            }
            return NotFound();
        }
        #endregion Actors
    }
}
