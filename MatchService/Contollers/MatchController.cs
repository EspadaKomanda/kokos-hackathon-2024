using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Contollers.Requests;
using MatchService.Contollers.Requests.Match;
using MatchService.Contollers.Responses;
using MatchService.Contollers.Responses.Match;
using MatchService.Database.Models;
using MatchService.Exceptions;
using MatchService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace MatchService.Contollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchController : ControllerBase
    {
        //TODO: Add Logging
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }
        //FIXME: Add taking by pages
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IQueryable<Match>> GetAll()
        {
            try
            {
                return Ok(_matchService.GetAll());
            }
            catch (Exception ex)
            {
                if(ex is GetException)
                {
                    return StatusCode(503,"Database error: " + ex.Message);
                }

                return StatusCode(500,ex.Message);
                
            }

        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Match>> GetById(GetMatchByIdRequest request)
        {
            try
            {
                return Ok( await _matchService.FindById(request.MatchId));
            }
            catch (Exception ex)
            {
                if(ex is GetException)
                {
                    return StatusCode(503,"Database error: " + ex.Message);
                }

                return StatusCode(500,ex.Message);
                
            }
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<AddMatchResponse>> Add(AddMatchRequest request)
        {
            try
            {
                return Ok(new AddMatchResponse()
                {
                    success = await _matchService.Add(new Match()
                    {
                        Team1Id = request.Team1Id,
                        Team2Id = request.Team2Id,
                        StatusId = request.StatusId,
                        SheduledStart = request.SheduledStart,
                        EndedAt = request.EndedAt,
                        Result = request.Result,
                        StreamRecord = request.StreamRecord,
                        Json = request.Json
                    }),
                    error =""
                });
            }
            catch (Exception ex)
            {
                if(ex is AddException)
                {
                    return StatusCode(503,new AddMatchResponse()
                    {
                        success = false,
                        error = "Database error: "+ ex.Message
                    });
                }

                return StatusCode(500,new AddMatchResponse()
                {
                    success = false,
                    error = ex.Message
                });
                
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public ActionResult<DeleteMatchResponse> Delete(DeleteMatchRequest request)
        {
            try
            {
                return Ok(new DeleteMatchResponse(){
                    success= _matchService.Delete(_matchService.FindById(request.MatchId).Result),
                    error = ""
                });
            }
            catch (Exception ex)
            {
                if(ex is DeleteException)
                {
                    return StatusCode(503,new DeleteMatchResponse()
                    {
                        success = false,
                        error = "Database error: " + ex.Message
                    });
                }

                return StatusCode(500,new DeleteMatchResponse()
                {
                    success = false,
                    error = ex.Message
                });
                
            }
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult<UpdateMatchResponse> Update(UpdateMatchRequest request)
        {
            try
            {
                return Ok(new UpdateMatchResponse()
                {
                    success = _matchService.Update(new Match()
                    {
                        MatchId = request.MatchId,
                        Team1Id = request.Team1Id,
                        Team2Id = request.Team2Id,
                        StatusId = request.StatusId,
                        SheduledStart = request.SheduledStart,
                        EndedAt = request.EndedAt,
                        Result = request.Result,
                        StreamRecord = request.StreamRecord,
                        Json = request.Json
                    }),
                    error = ""
                });
            }
            catch (Exception ex)
            {
                if(ex is UpdateException)
                {
                    return StatusCode(503, new UpdateMatchResponse()
                    {
                        success = false,
                        error = "Database error: " + ex.Message
                    });
                }

                return StatusCode(500, new UpdateMatchResponse()
                {
                    success = false,
                    error = ex.Message
                });
                
            }
        }
    }
}