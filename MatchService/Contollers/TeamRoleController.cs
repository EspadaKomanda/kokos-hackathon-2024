using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Contollers.Requests.TeamRole;
using MatchService.Contollers.Responses.TeamRole;
using MatchService.Database.Models;
using MatchService.Exceptions;
using MatchService.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatchService.Contollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamRoleController : ControllerBase
    {
        //TODO: Add logging
        private readonly ITeamRoleService _teamRoleService;

        public TeamRoleController(ITeamRoleService teamRoleService)
        {
            _teamRoleService = teamRoleService;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult<IQueryable<TeamRole>> GetAll()
        {
            try
            {
                return Ok(_teamRoleService.GetAll());
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
        [Route("getbyid/{teamRoleId}")]
        public ActionResult<TeamRole> GetById(long teamRoleId)
        {
            try
            {
                return Ok(_teamRoleService.FindById(teamRoleId));
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
        public async Task<ActionResult<AddTeamRoleResponse>> Add([FromBody]AddTeamRoleRequest request)
        {
            try
            {
                return Ok(new AddTeamRoleResponse()
                {
                    success = await _teamRoleService.Add(new TeamRole()
                    {
                        Name = request.Name
                    }),
                    error = ""
                });
            }
            catch (Exception ex)
            {
                if (ex is AddException)
                {
                    return StatusCode(503, new AddTeamRoleResponse()
                    {
                        success = false,
                        error = "Database error: " + ex.Message
                    });
                }
                return StatusCode(500, new AddTeamRoleResponse()
                {
                    success = false,
                    error = ex.Message
                });
            }
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult<DeleteTeamRoleResponse> Delete([FromBody]DeleteTeamRoleRequest request)
        {
            try
            {
                return Ok(new DeleteTeamRoleResponse()
                {
                    success = _teamRoleService.Delete(_teamRoleService.FindById(request.TeamRoleId).Result),
                    error = ""
                });
            }
            catch (Exception ex)
            {
                if (ex is DeleteException)
                {
                    return StatusCode(503, new DeleteTeamRoleResponse()
                    {
                        success = false,
                        error = "Database error: " + ex.Message
                    });
                }
                return StatusCode(500, new DeleteTeamRoleResponse()
                {
                    success = false,
                    error = ex.Message
                });
            }
            
        }
        [HttpPut]
        [Route("update")]
        public ActionResult<UpdateTeamRoleResponse> Update([FromBody]UpdateTeamRoleRequest request)
        {
            try
            {
                return Ok(new UpdateTeamRoleResponse()
                {
                    success = _teamRoleService.Update(new TeamRole()
                    {
                        TeamRoleId = request.TeamRoleId,
                        Name = request.Name
                    }),
                    error = ""
                });
            }
            catch (Exception ex)
            {
                if (ex is UpdateException)
                {
                    return StatusCode(503, new UpdateTeamRoleResponse()
                    {
                        success = false,
                        error = "Database error: " + ex.Message
                    });
                }
                return StatusCode(500, new UpdateTeamRoleResponse()
                {
                    success = false,
                    error = ex.Message
                });
            }
        }
    }
}