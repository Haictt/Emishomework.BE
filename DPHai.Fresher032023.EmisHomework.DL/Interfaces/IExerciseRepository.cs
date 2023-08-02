using DPHai.Fresher032023.EmisHomework.Common.Dto;
using DPHai.Fresher032023.EmisHomework.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.DL.Interfaces
{
    public interface IExerciseRepository : IBaseRepository<Exercise, Filter>
    {
        /// <summary>
        /// Hàm lấy toàn bộ bài tập theo bộ lọc
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IEnumerable<Exercise>> GetAllExerciseAsync(Filter filter);

        /// <summary>
        /// Hàm lấy tổng số bài tập theo bộ lọc
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<int> GetTotalExerciseAsync(Filter filter);

        /// <summary>
        /// Hàm lấy 1 bài tập
        /// </summary>
        /// <param name="id">id bài tập</param>
        /// <returns></returns>
        new Task<GetExerciseDto> GetOneAsync(Guid id);
    }
}
