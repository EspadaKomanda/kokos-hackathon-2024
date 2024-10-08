using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Contollers.Requests;
using MatchService.Database.Models;
using MatchService.Exceptions;
using MatchService.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatchService.Contollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }
        
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
                    return BadRequest("Database error: " + ex.Message);
                }
            }
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById(GetMatchByIdRequest request)
        {
            return Ok(_matchService.FindById(request.match_id));
        }
    }
}