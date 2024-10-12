using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Contollers.Requests.Team;
using MatchService.Contollers.Responses.Team;
using MatchService.Database.Models;
using MatchService.Exceptions;
using MatchService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatchService.Contollers
{
    [ApiController]
    [Route("teams")]
    public class TeamController : ControllerBase
    {
        //TODO: Add Logging
        private readonly ITeamService _teamService;
        private readonly IMatchService _matchService;
        private readonly IStatusService _statusService;
        public TeamController(ITeamService teamService, IMatchService matchService, IStatusService statusService)
        {
            _teamService = teamService;
            _matchService = matchService;
            _statusService = statusService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IQueryable<Team>> GetAll()
        {
            try
            {
                return Ok(_teamService.GetAll());
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
        [Route("{teamId}")]
        public ActionResult<Team> GetById(long teamId)
        {
            try
            {
                return Ok(_teamService.FindById(teamId));
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
        [Route("{teamId}/matches")]
        public ActionResult<Team> GetByIdMatches(long teamId)
        {
            try
            {
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
        [HttpGet]
        [Route("{teamId}/matches/{isWin}")]
        public ActionResult<Team> GetByIdMatchesWin(long teamId, bool isWin)
        {
            try
            {
                if(isWin)
                {
                    long winStatus = _statusService.GetAll().Where(x => x.Name == "Win").Select(x => x.StatusId).FirstOrDefault();
                    return Ok(_matchService.GetAll().Where(x =>( x.Team1Id == teamId || x.Team2Id == teamId) && x.StatusId == winStatus));
                }
                else
                {
                    long loseStatus = _statusService.GetAll().Where(x => x.Name == "Lose").Select(x => x.StatusId).FirstOrDefault();
                    return Ok(_matchService.GetAll().Where(x => (x.Team1Id == teamId || x.Team2Id == teamId) && x.StatusId == loseStatus));
                }
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
        [Route("")]
        public async Task<ActionResult<AddTeamResponse>> Add([FromBody]AddTeamRequest request)
        {
            try
            {
                return Ok(new AddTeamResponse()
                {
                    success = await _teamService.Add(new Team()
                    {
                        Name = request.Name,
                        Players = request.Players,
                        Matches = request.Matches
                    }),
                    error = ""
                });
            }
            catch (Exception ex)
            {
                if (ex is AddException)
                {
                    return StatusCode(503, new AddTeamResponse()
                    {
                        success = false,
                        error = "Database error: " + ex.Message
                    });
                }

                return StatusCode(500, new AddTeamResponse()
                {
                    success = false,
                    error = ex.Message
                });
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult<UpdateTeamResponse> Update([FromBody]UpdateTeamRequest request)
        {
            try
            {
                return Ok(new UpdateTeamResponse()
                {
                    success = _teamService.Update(new Team()
                    {
                        TeamId = request.TeamId,
                        Name = request.Name,
                        Players = request.Players,
                        Matches = request.Matches
                    }),
                    error = ""
                });
            }
            catch (Exception ex)
            {
                if (ex is UpdateException)
                {
                    return StatusCode(503, new UpdateTeamResponse()
                    {
                        success = false,
                        error = "Database error: " + ex.Message
                    });
                }
                return StatusCode(500, new UpdateTeamResponse()
                {
                    success = false,
                    error = ex.Message
                });
            }

        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult<DeleteTeamResponse> Delete([FromBody]DeleteTeamRequest request)
        {
            try
            {
                return Ok(new DeleteTeamResponse()
                {
                    success = _teamService.Delete(_teamService.FindById(request.TeamId).Result),
                    error = ""
                });
            }
            catch (Exception ex)
            {
                if (ex is DeleteException)
                {
                    return StatusCode(503, new DeleteTeamResponse()
                    {
                        success = false,
                        error = "Database error: " + ex.Message
                    });
                }
                return StatusCode(500, new DeleteTeamResponse()
                {
                    success = false,
                    error = ex.Message
                });
            }   
            
        }
        
    }
}