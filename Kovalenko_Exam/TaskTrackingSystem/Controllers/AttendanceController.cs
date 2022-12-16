using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TaskTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _as;
        public AttendanceController(IAttendanceService attendanceService)
        {
            this._as = attendanceService;
        }

        /// <summary>
        /// Returns all tasks from db
        /// </summary>
        /// <returns>Status 200</returns>
        /// <example>GET: /api/assignments</example>
        [HttpGet]
        public ActionResult<IEnumerable<AttendanceModel>> GetAll()
        {
            return Ok(_as.GetAll());
        }
    }
}
