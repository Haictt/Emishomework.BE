using DPHai.Fresher032023.EmisHomework.BL.App.AppServices;
using DPHai.Fresher032023.EmisHomework.BL.App.Interfaces;
using DPHai.Fresher032023.EmisHomework.Common.Dto;
using DPHai.Fresher032023.EmisHomework.Common.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DPHai.Fresher032023.EmisHomework.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class ExerciseController : BaseController<Exercise, GetExerciseDto, PostExerciseDto, Filter>
    {
        protected readonly IExerciseService _exerciseService;
        public ExerciseController(IExerciseService exerciseService) : base(exerciseService)
        {
            _exerciseService = exerciseService;
        }

        /// <summary>
        /// Hàm lấy toàn bộ bài tập theo bộ lọc
        /// </summary>
        /// <param name="filter">bộ lọc</param>
        /// <returns></returns>
        [HttpGet("filter")]
        public async Task<IEnumerable<GetExerciseDto>> GetAllExerciseAsync([FromQuery] Filter filter)
        {
            return await _exerciseService.GetAllExerciseAsync(filter);
        }

        /// <summary>
        /// Hàm lấy tổng số bài tập theo bộ lọc
        /// </summary>
        /// <param name="filter">bộ lọc</param>
        /// <returns></returns>
        [HttpGet("total")]
        public async Task<int> GetTotalExerciseAsync([FromQuery] Filter filter)
        {
            return await _exerciseService.GetTotalExerciseAsync(filter);
        }

        /// <summary>
        /// Hàm thêm mới hoặc cập nhật 1 bài tập
        /// </summary>
        /// <param name="exercise">bài tập</param>
        /// <returns></returns>
        [HttpPost("upsert")]
        public async Task<IActionResult> UpsertExerciseAsync([FromBody] PostExerciseDto exercise)
        {
            return Ok(await _exerciseService.UpsertExerciseAsync(exercise));
        }
    }
}
