using DPHai.Fresher032023.EmisHomework.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.DL.Interfaces
{
    public interface ITopicRepository : IBaseRepository<Topic,Topic>
    {
        /// <summary>
        /// Hàm lấy toàn bộ chủ đề theo khối và môn
        /// </summary>
        /// <param name="gradeId">Id khối</param>
        /// <param name="subjectId">Id môn</param>
        /// <returns></returns>
        Task<IEnumerable<Topic>> GetAllTopicByGradeAndSubjectAsync(Guid gradeId, Guid subjectId);
    }
}
