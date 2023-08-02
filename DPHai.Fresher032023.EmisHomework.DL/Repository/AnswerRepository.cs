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
    public class AnswerRepository : BaseRepository<Answer, Answer>, IAnswerRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        public AnswerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Hàm xóa toàn bộ câu trả lời theo id câu hỏi
        /// </summary>
        /// <param name="questionId">Id câu hỏi</param>
        /// <returns></returns>
        public async Task<bool> DeleteAnswerByQuestionAsync(Guid? questionId)
        {
            var dynamicParams = new DynamicParameters();
            var sqlQuery = $"Proc_DeleteAnswerByQuestionId";
            dynamicParams.Add("p_QuestionId", questionId);
            var res = await _unitOfWork.Connection.ExecuteAsync(sqlQuery, dynamicParams, _unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
            return res > 0;
        }

      
    }
}
