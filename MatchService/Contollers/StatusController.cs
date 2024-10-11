using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Contollers.Requests.Status;
using MatchService.Contollers.Responses.Status;
using MatchService.Database.Models;
using MatchService.Exceptions;
using MatchService.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatchService.Contollers
{
    public class StatusController : ControllerBase
    {
        //TODO: Add Logging
        private readonly IStatusService _statusService;
        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }
        [HttpGet]
        [Route("getall")]
        public ActionResult<IQueryable<Status>> GetAll()
        {
            try
            {
                return Ok(_statusService.GetAll());
            }
            catch(Exception ex)
            {
                if(ex is GetException)
                {
                    return StatusCode(503,"Database error: " + ex.Message);
                }

                return StatusCode(500,ex.Message);
            }
        }
        [HttpGet]
        [Route("getbyid/{statusId}")]
        public async Task<ActionResult<Status>> GetById(long statusId)
        {
            try
            {
                return Ok( await _statusService.FindById(statusId));
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
        [Route("add")]
        public async Task<ActionResult<AddStatusResponse>> Add([FromBody]AddStatusRequest request)
        {
            try
            {
                return Ok(new AddStatusResponse()
                {
                    success = await _statusService.Add(new Status()
                    {
                        Name = request.Name
                    }),
                    error = ""
                });
            }
            catch (Exception ex)
            {
                if(ex is AddException)
                {
                    return StatusCode(503,new AddStatusResponse()
                    {
                        success = false,
                        error = "Database error: " + ex.Message
                    });
                }

                return StatusCode(500,new AddStatusResponse()
                {
                    success = false,
                    error = ex.Message
                });
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult<UpdateStatusResponse> Update([FromBody]UpdateStatusRequest request)
        {
            try
            {
                return Ok(new UpdateStatusResponse()
                {
                    success = _statusService.Update(new Status()
                    {
                        StatusId = request.StatusId,
                        Name = request.Name
                    }),
                    error = ""
                });
            }
            catch (Exception ex)
            {
                if(ex is UpdateException)
                {
                    return StatusCode(503,new UpdateStatusResponse()
                    {
                        success = false,
                        error = "Database error: " + ex.Message
                    });
                }

                return StatusCode(500,new UpdateStatusResponse()
                {
                    success = false,
                    error = ex.Message
                });
            }
            
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult<DeleteStatusResponse> Delete([FromBody]DeleteStatusRequest request)
        {
            try
            {
                return Ok(new DeleteStatusResponse()
                {
                    success = _statusService.Delete(_statusService.FindById(request.StatusId).Result),
                    error = ""
                });
            }
            catch (Exception ex)
            {
                if(ex is DeleteException)
                {
                    return StatusCode(503,new DeleteStatusResponse()
                    {
                        success = false,
                        error = "Database error: " + ex.Message
                    });
                }

                return StatusCode(500,new DeleteStatusResponse()
                {
                    success = false,
                    error = ex.Message
                });
                
            }
        }
    }
}