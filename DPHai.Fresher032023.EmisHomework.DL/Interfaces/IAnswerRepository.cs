using DPHai.Fresher032023.EmisHomework.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.DL.Interfaces
{
    public interface IAnswerRepository : IBaseRepository<Answer,Answer>
    {
        /// <summary>
        /// Hàm xóa toàn bộ câu trả lời theo id câu hỏi
        /// </summary>
        /// <param name="questionId">Id câu hỏi</param>
        /// <returns></returns>
        Task<bool> DeleteAnswerByQuestionAsync(Guid? questionId);
    }
}
