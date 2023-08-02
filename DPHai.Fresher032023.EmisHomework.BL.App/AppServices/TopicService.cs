using AutoMapper;
using DPHai.Fresher032023.EmisHomework.BL.App.Interfaces;
using DPHai.Fresher032023.EmisHomework.Common.Dto;
using DPHai.Fresher032023.EmisHomework.Common.Entity;
using DPHai.Fresher032023.EmisHomework.Common.UnitOfWork;
using DPHai.Fresher032023.EmisHomework.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.BL.App.AppServices
{
    public class TopicService : BaseService<Topic,GetTopicDto,Topic,Topic>,ITopicService
    {
        protected readonly ITopicRepository _topicRepository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public TopicService(ITopicRepository topicRepository, IUnitOfWork unitOfWork, IMapper mapper):base(topicRepository, unitOfWork, mapper)
        {
            _topicRepository = topicRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Hàm lấy toàn bộ chủ đề theo môn và khối
        /// </summary>
        /// <param name="gradeId">Id khối</param>
        /// <param name="subjectId">Id môn</param>
        /// <returns></returns>
        public async Task<IEnumerable<GetTopicDto>> GetAllTopicByGradeAndSubjectAsync(Guid gradeId, Guid subjectId)
        {
            var topics = await _topicRepository.GetAllTopicByGradeAndSubjectAsync(gradeId, subjectId);
            var topicDtos = _mapper.Map<IEnumerable<GetTopicDto>>(topics);
            return topicDtos;
        }
    }
}
