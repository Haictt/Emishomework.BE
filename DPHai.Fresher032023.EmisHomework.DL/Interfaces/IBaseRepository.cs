using DPHai.Fresher032023.EmisHomework.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.DL.Interfaces
{
    public interface IBaseRepository<TEntity,TEntityFilter>
    {
        /// <summary>
        /// Hàm lấy toàn bộ bản ghi
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Hàm lấy 1 bản ghi theo id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        Task<TEntity> GetOneAsync(Guid id);

        /// <summary>
        /// Hàm láy tổng số bản ghi
        /// </summary>
        /// <param name="entity">đối tượng</param>
        /// <returns></returns>
        Task<int> GetTotalAsync(TEntity entity);

        /// <summary>
        /// Hàm thêm 1 bản ghi
        /// </summary>
        /// <param name="entity">bản ghi</param>
        /// <returns></returns>
        Task<Guid> PostAsync(TEntity entity);

        /// <summary>
        /// Hàm thêm nhiều bản ghi
        /// </summary>
        /// <param name="entities">List bản ghi</param>
        /// <returns></returns>
        Task<bool> PostMultipleAsync(IList<TEntity> entities);

        /// <summary>
        /// Hàm cập nhật 1 bản ghi
        /// </summary>
        /// <param name="entity">bản ghi</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TEntity entity);

        /// <summary>
        /// Hàm xóa nhiều bản ghi theo id list
        /// </summary>
        /// <param name="ids">list id</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(string ids);
    }
}
