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
    public class AnswerService : BaseService<Answer, GetAnswerDto, Answer, Answer>, IAnswerService
    {
        public AnswerService(IAnswerRepository answerRepository, IUnitOfWork unitOfWork, IMapper _mapper) : base(answerRepository, unitOfWork, _mapper)
        {

        }
    }
}
