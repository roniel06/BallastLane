using BallastLane.Business.Services.Core;
using BallastLane.Infrastructure.Models.Core;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BallastLane.Api.Controllers.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity, TService> : ControllerBase
        where TEntity : BaseModel, new()
        where TService : IBaseService<TEntity>
    {

        private readonly TService _service;

        public BaseController(TService service)
        {
            _service = service;
        }

        /// <summary>
        /// Creates a record.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(TEntity entity)
        {
            if (entity != null && ModelState.IsValid)
            {
                var result = await _service.CreateAsync(entity);
                if (result != null) return Ok(result);
                return BadRequest("Something Went Wrong Creating the entity.");
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Gets all existing and not deleted records.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            if (result.Count() > 0) return Ok(result);
            return NoContent();
        }

        /// <summary>
        /// Gets a record by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([Required] int id)
        {
            if (id > 0)
            {
                var result = await _service.GetByIdAsync(id);
                if (result != null) return Ok(result);
                return NoContent();
            }
            return BadRequest("The Id Should be greater than Zero");
        }

        /// <summary>
        /// Updates the record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(TEntity entity)
        {
            if(entity != null && ModelState.IsValid)
            {
                var result = await _service.UpdateAsync(entity);
                if (result != null && entity is TEntity) return Ok(result);
                return BadRequest("Something went wrong updating the entity");
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Deletes the record
        /// </summary>
        /// <param name="id">The id of the record</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var result = await _service.DeleteAsync(id);
                if (result) return Ok(result);
                return BadRequest("Something went wrong updating the entity");
            }
            return BadRequest("The Id Should be greater than Zero");
        }
    }
}
