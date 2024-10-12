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
using Microsoft.EntityFrameworkCore;

namespace MatchService.Contollers
{
    [ApiController]
    [Route("matches")]
    public class MatchController : ControllerBase
    {
        //TODO: Add Logging
        private readonly IMatchService _matchService;
        private readonly IStatusService _statusService;
        public MatchController(IMatchService matchService, IStatusService statusService)
        {
            _matchService = matchService;
            _statusService = statusService;
        }
        //FIXME: Add taking by pages
        [HttpGet]
        [Route("{pageNumber}")]
        public ActionResult<IQueryable<Match>> GetAll(int pageNumber)
        {
            try
            {
                return Ok(_matchService.GetAll(pageNumber));
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
        [Route("status/{statusId}")]
        public ActionResult<IQueryable<Match>> GetAllStatus(long statusId)
        {
            try
            {
                Status status = _statusService.FindById(statusId).Result;
                return Ok(_matchService.GetAll().Include(x=>x.Status).Where(x => x.Status == status));
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
        [Route("{matchId}")]
        public async Task<ActionResult<Match>> GetById(long matchId)
        {
            try
            {
                return Ok( await _matchService.FindById(matchId));
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
        [Route("")]
        public async Task<ActionResult<AddMatchResponse>> Add([FromBody]AddMatchRequest request)
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
        [Route("remove/{matchId}")]
        public ActionResult<DeleteMatchResponse> Delete(long matchId)
        {
            try
            {
                return Ok(new DeleteMatchResponse(){
                    success= _matchService.Delete(_matchService.FindById(matchId).Result),
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
        [Route("")]
        public ActionResult<UpdateMatchResponse> Update([FromBody]UpdateMatchRequest request)
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