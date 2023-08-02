using DPHai.Fresher032023.EmisHomework.Common.Dto;
using DPHai.Fresher032023.EmisHomework.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.BL.App.Interfaces
{
    public interface IExerciseService : IBaseService<Exercise,GetExerciseDto,PostExerciseDto,Filter>
    {
        /// <summary>
        /// Hàm lấy toàn bộ bài tập theo bộ lọc
        /// </summary>
        /// <param name="filter">bộ lọc</param>
        /// <returns></returns>
        Task<IEnumerable<GetExerciseDto>> GetAllExerciseAsync(Filter filter);

        /// <summary>
        /// Hàm lấy tổng số bài tập theo bộ lọc
        /// </summary>
        /// <param name="filter">bộ lọc</param>
        /// <returns></returns>
        Task<int> GetTotalExerciseAsync(Filter filter);

        /// <summary>
        /// Hàm thêm mới hoặc cập nhật 1 bài tập
        /// </summary>
        /// <param name="exercise">bài tập</param>
        /// <returns></returns>
        Task<Guid?> UpsertExerciseAsync(PostExerciseDto exercise);
    }
}
