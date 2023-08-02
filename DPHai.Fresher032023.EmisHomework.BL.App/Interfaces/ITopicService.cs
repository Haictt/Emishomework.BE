using DPHai.Fresher032023.EmisHomework.Common.Dto;
using DPHai.Fresher032023.EmisHomework.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.BL.App.Interfaces
{
    public interface ITopicService : IBaseService<Topic,GetTopicDto,Topic,Topic>
    {
        /// <summary>
        /// Hàm lấy toàn bộ chủ đề theo môn và khối
        /// </summary>
        /// <param name="gradeId">Id khối</param>
        /// <param name="subjectId">Id môn</param>
        /// <returns></returns>
        Task<IEnumerable<GetTopicDto>> GetAllTopicByGradeAndSubjectAsync(Guid gradeId, Guid subjectId);
    }
}
