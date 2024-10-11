using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Contollers.Requests.Player;
using MatchService.Contollers.Requestss.Player;
using MatchService.Contollers.Responses.Player;
using MatchService.Database.Models;
using MatchService.Exceptions;
using MatchService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatchService.Contollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        //TODO:Add Logging
        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;
        private readonly IMatchService _matchService;
        
        public PlayerController(IPlayerService playerService, ITeamService teamService, IMatchService matchService)
        {
            _playerService = playerService;
            _teamService = teamService;
            _matchService = matchService;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult<IQueryable<Player>> GetAll()
        {
            try
            {
                return Ok(_playerService.GetAll());
            }
            catch (Exception ex)
            {
                if (ex is GetException)
                {
                    return StatusCode(503, "Database error: " + ex.Message);
                }

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<AddPlayerResponse>> Add([FromBody]AddPlayerRequest request)
        {
            try
            {
                return Ok(new AddPlayerResponse()
                {
                    success = await _playerService.Add(new Player()
                    {
                        TeamId = request.TeamId,
                        UserId = request.UserId,
                        TeamRoleId = request.TeamRoleId,
                        Country = request.Country
                    }),
                    error = ""
                });
            }
            catch (Exception ex)
            {
                if (ex is AddException)
                {
                    return StatusCode(503, new AddPlayerResponse()
                    {
                        success = false,
                        error = "Database error: " + ex.Message
                    });
                }

                return StatusCode(500, new AddPlayerResponse()
                {
                    success = false,
                    error = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("getbyid/{playerId}")]
        public async Task<ActionResult<Player>> GetById(long playerId)
        {
            try
            {
                return Ok(await _playerService.FindById(playerId));
            }
            catch (Exception ex)
            {
                if (ex is GetException)
                {
                    return StatusCode(503, "Database error: " + ex.Message);
                }

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("getbyid/{playerId}/matches")]
        public  ActionResult<IQueryable<Match>> GetByIdMatches(long playerId)
        {
            try
            {
                long teamId = _teamService.GetAll().Include(x=>x.Players).Where(x => x.Players.Any(y => y.PlayerId == playerId)).Select(x => x.TeamId).FirstOrDefault();
                return Ok(_matchService.GetAll().Where(x => x.Team1Id == teamId || x.Team2Id == teamId));
            }
            catch (Exception ex)
            {
                if (ex is GetException)
                {
                    return StatusCode(503, "Database error: " + ex.Message);
                }

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [Route("update")]
        public ActionResult<UpdatePlayerResponse> Update(UpdatePlayerRequest request)
        {
            try
            {
                return Ok(new UpdatePlayerResponse()
                {
                    success = _playerService.Update(new Player()
                    {
                        PlayerId = request.PlayerId,
                        TeamId = request.TeamId,
                        UserId = request.UserId,
                        TeamRoleId = request.TeamRoleId,
                        Country = request.Country
                    }),
                    error = ""
                });
            }
            catch (Exception ex)
            {
                if (ex is UpdateException)
                {
                    return StatusCode(503, new UpdatePlayerResponse()
                    {
                        success = false,
                        error = "Database error: " + ex.Message
                    });
                }

                return StatusCode(500, new UpdatePlayerResponse()
                {
                    success = false,
                    error = ex.Message
                });
            }
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult<DeletePlayerResponse> Delete(DeletePlayerRequest request)
        {
            try
            {
                return Ok(new DeletePlayerResponse()
                {
                    success = _playerService.Delete(_playerService.FindById(request.PlayerId).Result),
                    error = ""
                });
            }
            catch (Exception ex)
            {
                if (ex is DeleteException)
                {
                    return StatusCode(503, new DeletePlayerResponse()
                    {
                        success = false,
                        error = "Database error: " + ex.Message
                    });
                }

                return StatusCode(500, new DeletePlayerResponse()
                {
                    success = false,
                    error = ex.Message
                });
            }
        }
    }
}