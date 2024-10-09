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

namespace MatchService.Contollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        //TODO:Add Logging
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        [Route("GetAll")]
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

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Player>> GetById(GetPlayerByIdRequest request)
        {
            try
            {
                return Ok(await _playerService.FindById(request.PlayerId));
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
        public async Task<ActionResult<AddPlayerResponse>> Add(AddPlayerRequest request)
        {
            try
            {
                return Ok(new AddPlayerResponse()
                {
                    success = await _playerService.Add(new Player()
                    {
                        TeamId = request.TeamId,
                        UserId = request.UserId,
                        TeamRoleId = request.TeamRoleId
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

        [HttpPut]
        [Route("Update")]
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
                        TeamRoleId = request.TeamRoleId
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
        [Route("Delete")]
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