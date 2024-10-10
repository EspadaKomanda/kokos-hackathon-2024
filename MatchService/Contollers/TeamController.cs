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

namespace MatchService.Contollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        //TODO: Add Logging
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        [Route("GetAll")]
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
        [Route("GetById")]
        public ActionResult<Team> GetById(GetTeamByIdRequest request)
        {
            try
            {
                return Ok(_teamService.FindById(request.TeamId));
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
        [Route("Add")]
        public async Task<ActionResult<AddTeamResponse>> Add(AddTeamRequest request)
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
        [Route("Update")]
        public ActionResult<UpdateTeamResponse> Update(UpdateTeamRequest request)
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
        [Route("Delete")]
        public ActionResult<DeleteTeamResponse> Delete(DeleteTeamRequest request)
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