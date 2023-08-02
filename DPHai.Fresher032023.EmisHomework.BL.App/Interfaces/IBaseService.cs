using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.BL.App.Interfaces
{
    public interface IBaseService<TEntity,TEntityGetDto,TEntityPostDto,TEntityFilter>
    {
        /// <summary>
        /// Hàm lấy 1 bản ghi
        /// </summary>
        /// <param name="id">Id bản ghi</param>
        /// <returns></returns>
        Task<TEntityGetDto> GetOneAsync(Guid id);

        /// <summary>
        /// Hàm lấy toàn bộ bản ghi
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntityGetDto>> GetAllAsync();

        /// <summary>
        /// Hàm xóa nhiều bàn ghi theo id list
        /// </summary>
        /// <param name="ids">List id</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(Guid[] ids);
    }
}
