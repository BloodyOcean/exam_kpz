using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace TaskTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _es;
        public ExamsController(IExamService examService)
        {
            this._es = examService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ExamModel>> GetAll()
        {
            return Ok(_es.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExamModel>> GetById(int id)
        {
            return Ok(await _es.GetByIdAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _es.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(ExamModel examModel)
        {
            if (examModel == null)
            {
                return BadRequest();
            }
            try
            {
                await _es.UpdateAsync(examModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ExamModel examModel)
        {
            if (examModel == null)
            {
                return BadRequest();
            }

            try
            {
                await _es.AddAsync(examModel);
                return CreatedAtAction(nameof(Add), examModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
