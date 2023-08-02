using DPHai.Fresher032023.EmisHomework.BL.App.Interfaces;
using DPHai.Fresher032023.EmisHomework.Common.Dto;
using DPHai.Fresher032023.EmisHomework.Common.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DPHai.Fresher032023.EmisHomework.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class TopicController : BaseController<Topic, GetTopicDto, Topic, Topic>
    {
        protected readonly ITopicService _topicService;
        public TopicController(ITopicService topicService) : base(topicService)
        {
            _topicService = topicService;
        }

        /// <summary>
        /// Hàm lấy toàn bộ chủ đề theo môn và khối tương ứng
        /// </summary>
        /// <param name="gradeId">Id khối</param>
        /// <param name="subjectId">Id môn</param>
        /// <returns></returns>
        [HttpGet("grade-subject")]
        public async Task<IEnumerable<GetTopicDto>> GetAllTopicByGradeAndSubjectAsync([FromQuery]Guid gradeId, [FromQuery] Guid subjectId)
        {
            return await _topicService.GetAllTopicByGradeAndSubjectAsync(gradeId, subjectId);
        }
    }
}
