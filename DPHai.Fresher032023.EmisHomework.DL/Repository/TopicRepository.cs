using Dapper;
using DPHai.Fresher032023.EmisHomework.Common.Entity;
using DPHai.Fresher032023.EmisHomework.Common.UnitOfWork;
using DPHai.Fresher032023.EmisHomework.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DPHai.Fresher032023.EmisHomework.DL.Repository
{
    public class TopicRepository : BaseRepository<Topic, Topic>, ITopicRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        public TopicRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Hàm lấy toàn bộ chủ đề theo khối và môn
        /// </summary>
        /// <param name="gradeId">Id khối</param>
        /// <param name="subjectId">Id môn</param>
        /// <returns></returns>
        public async Task<IEnumerable<Topic>> GetAllTopicByGradeAndSubjectAsync(Guid gradeId, Guid subjectId)
        {
            var sqlQuery = $"Proc_GetAllTopicByGradeAndSubjectId";
            var dynamicParams = new DynamicParameters();
           
            dynamicParams.Add($"p_GradeId", gradeId);
            dynamicParams.Add($"p_SubjectId", subjectId);
            var entities = await _unitOfWork.Connection.QueryAsync<Topic>(sqlQuery,dynamicParams,_unitOfWork.Transaction, commandType: CommandType.StoredProcedure);

            return entities;
        }
    }
}
