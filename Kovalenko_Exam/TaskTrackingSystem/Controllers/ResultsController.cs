using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TaskTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IResultService _rs;
        public ResultsController(IResultService resultService)
        {
            this._rs = resultService;
        }

        /// <summary>
        /// Returns all tasks from db
        /// </summary>
        /// <returns>Status 200</returns>
        /// <example>GET: /api/assignments</example>
        [HttpGet]
        public ActionResult<IEnumerable<ResultModel>> GetAll()
        {
            return Ok(_rs.GetAll());
        }
    }
}
