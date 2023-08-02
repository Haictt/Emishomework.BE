using Dapper;
using DPHai.Fresher032023.EmisHomework.Common.UnitOfWork;
using DPHai.Fresher032023.EmisHomework.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.DL.Repository
{
    public abstract class BaseRepository<TEntity, TEntityFilter> : IBaseRepository<TEntity, TEntityFilter>
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected string table;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            table = typeof(TEntity).Name;
        }

        /// <summary>
        /// Hàm lấy toàn bộ bản ghi
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {

            var sqlQuery = $"Proc_GetAll{table}";

            var entities = await _unitOfWork.Connection.QueryAsync<TEntity>(sqlQuery, commandType: CommandType.StoredProcedure);

            return entities;
        }

        /// <summary>
        /// Hàm lấy 1 bản ghi theo id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public virtual async Task<TEntity> GetOneAsync(Guid id)
        {
            var dynamicParams = new DynamicParameters();
            var sqlQuery = $"Proc_Get{table}ById";
            dynamicParams.Add($"p_{table}Id", id);

            var entity = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<TEntity>(
                sqlQuery,
                dynamicParams,
                _unitOfWork.Transaction,
                commandType: CommandType.StoredProcedure);

            return entity;
        }

        /// <summary>
        /// Hàm thêm 1 bản ghi
        /// </summary>
        /// <param name="entity">bản ghi</param>
        /// <returns></returns>
        public virtual async Task<Guid> PostAsync(TEntity entity)
        {
            var dynamicParams = new DynamicParameters();
            var sqlQuery = $"Proc_Post{table}";
            var dtoProperties = typeof(TEntity).GetProperties();
            var newGuid = Guid.NewGuid();
            foreach (var property in dtoProperties)
            {
                var paramName = "p_" + property.Name;
                var paramValue = property.GetValue(entity);
                if (paramName != "p_CreatedDate" && paramName != "p_CreatedBy" && paramName != "p_ModifiedDate" && paramName != "p_ModifiedBy" && paramName != $"p_{table}Id")
                {
                    dynamicParams.Add(paramName, paramValue);
                }

            }
            dynamicParams.Add($"p_{table}Id", newGuid.ToString("D"));
            dynamicParams.Add("p_CreatedDate", DateTime.Now);
            dynamicParams.Add("p_CreatedBy", "DPHai");
            dynamicParams.Add("p_ModifiedDate", DateTime.Now);
            dynamicParams.Add("p_ModifiedBy", "DPHai");
            await _unitOfWork.Connection.ExecuteAsync(sqlQuery, dynamicParams, _unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
            return newGuid;
        }

        /// <summary>
        /// Hàm láy tổng số bản ghi
        /// </summary>
        /// <param name="entity">đối tượng</param>
        /// <returns></returns>
        public virtual async Task<int> GetTotalAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Hàm thêm nhiều bản ghi
        /// </summary>
        /// <param name="entities">List bản ghi</param>
        /// <returns></returns>
        public virtual async Task<bool> PostMultipleAsync(IList<TEntity> entities)
        {

            var dynamicParams = new DynamicParameters();
            var sqlQuery = "";
            var index = 0;
            // tạo lệnh sql và add dynamic param
            foreach (var entity in entities)
            {
                var notNullProps = entity.GetType().GetProperties().Where(prop => prop.GetValue(entity) != null);
                sqlQuery += $"INSERT INTO {table} (";
                sqlQuery += string.Join(", ", notNullProps.Select(prop => prop.Name));
                sqlQuery += ", CreatedDate, CreatedBy, ModifiedDate, ModifiedBy";
                sqlQuery += ") Values (";
                sqlQuery += string.Join(", ", notNullProps.Select(prop => $"@p_{prop.Name}_{index}"));
                sqlQuery += $", @p_CreatedDate_{index}, @p_CreatedBy_{index}, @p_ModifiedDate_{index}, @p_ModifiedBy_{index}";
                sqlQuery += ");";

                foreach (var prop in notNullProps)
                {
                    dynamicParams.Add($"p_{prop.Name}_{index}", prop.GetValue(entity));
                }

                dynamicParams.Add($"p_{table}Id_{index}", Guid.NewGuid().ToString("D"));
                dynamicParams.Add($"p_CreatedDate_{index}", DateTime.Now);
                dynamicParams.Add($"p_CreatedBy_{index}", "DPHai");
                dynamicParams.Add($"p_ModifiedDate_{index}", DateTime.Now);
                dynamicParams.Add($"p_ModifiedBy_{index}", "DPHai");
                index++;
            }

            var res = await _unitOfWork.Connection.ExecuteAsync(sqlQuery, dynamicParams, _unitOfWork.Transaction);

            return res > 0;

        }

        /// <summary>
        /// Hàm cập nhật 1 bản ghi
        /// </summary>
        /// <param name="entity">bản ghi</param>
        /// <returns></returns>
        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            var dynamicParams = new DynamicParameters();
            var sqlQuery = $"Proc_Update{table}";
            var dtoProperties = typeof(TEntity).GetProperties();

            foreach (var property in dtoProperties)
            {
                var paramName = "p_" + property.Name;
                var paramValue = property.GetValue(entity);
                if (paramName != "p_ModifiedDate" && paramName != "p_ModifiedBy")
                {
                    dynamicParams.Add(paramName, paramValue);
                }

            }
            dynamicParams.Add("p_ModifiedDate", DateTime.Now);
            dynamicParams.Add("p_ModifiedBy", "DPHai");
            var res = await _unitOfWork.Connection.ExecuteAsync(sqlQuery, dynamicParams, _unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
            return res > 0;
        }

        /// <summary>
        /// Hàm xóa nhiều bản ghi theo id list
        /// </summary>
        /// <param name="ids">list id</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(string ids)
        {
            var dynamicParams = new DynamicParameters();
            var sqlQuery = $"Proc_Delete{table}ByIds";
            dynamicParams.Add($"p_{table}Ids", ids);

            var res = await _unitOfWork.Connection.ExecuteAsync(sqlQuery, dynamicParams, _unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
            return res > 0;
        }
    }
}
