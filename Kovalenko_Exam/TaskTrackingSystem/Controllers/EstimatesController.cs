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
    public class EstimatesController : ControllerBase
    {
        private readonly IEstimateService _es;
        public EstimatesController(IEstimateService estimateService)
        {
            this._es = estimateService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EstimateModel>> GetAll()
        {
            return Ok(_es.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstimateModel>> GetById(int id)
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
        public async Task<ActionResult> Update(EstimateModel estimateModel)
        {
            if (estimateModel == null)
            {
                return BadRequest();
            }
            try
            {
                await _es.UpdateAsync(estimateModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] EstimateModel estimateModel)
        {
            if (estimateModel == null)
            {
                return BadRequest();
            }

            try
            {
                await _es.AddAsync(estimateModel);
                return CreatedAtAction(nameof(Add), estimateModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
