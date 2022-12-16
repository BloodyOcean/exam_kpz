using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _ss;
        public StudentsController(IStudentService studentService)
        {
            this._ss = studentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentModel>> GetAll()
        {
            return Ok(_ss.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetById(int id)
        {
            return Ok(await _ss.GetByIdAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _ss.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(StudentModel studentModel)
        {
            if (studentModel == null)
            {
                return BadRequest();
            }
            try
            {
                await _ss.UpdateAsync(studentModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] StudentModel studentModel)
        {
            if (studentModel == null)
            {
                return BadRequest();
            }

            try
            {
                await _ss.AddAsync(studentModel);
                return CreatedAtAction(nameof(Add), studentModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
