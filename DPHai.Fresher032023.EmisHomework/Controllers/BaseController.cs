using DPHai.Fresher032023.EmisHomework.BL.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DPHai.Fresher032023.EmisHomework.API.Controllers
{
    [ApiController]
    public abstract class BaseController<TEntity, TEntityGetDto, TEntityPostDto, TEntityFilter> : ControllerBase
    {
        protected readonly IBaseService<TEntity, TEntityGetDto, TEntityPostDto, TEntityFilter> _baseService;
        public BaseController(IBaseService<TEntity, TEntityGetDto, TEntityPostDto, TEntityFilter> baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// Hàm lấy toàn bộ bản ghi
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<IEnumerable<TEntityGetDto>> GetAllAsync()
        {
            return await _baseService.GetAllAsync();
        }

        /// <summary>
        /// Hàm lấy 1 bản ghi theo Id
        /// </summary>
        /// <param name="id">Id bản ghi</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual async Task<TEntityGetDto> GetOneAsync(Guid id)
        {
            return await _baseService.GetOneAsync(id);
        }

        /// <summary>
        /// Hàm xóa các bàn ghi theo id list
        /// </summary>
        /// <param name="ids">List id</param>
        /// <returns></returns>
        [HttpDelete]
        public virtual async Task<IActionResult> DeleteAsync([FromBody] Guid[] ids)
        {
            return Ok(await _baseService.DeleteAsync(ids));
        }
    }
}
