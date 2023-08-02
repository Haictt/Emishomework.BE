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
    public class QuestionService : BaseService<Question,GetQuestionDto,Question,Question>,IQuestionService
    {
        public QuestionService(IQuestionRepository questionRepository,IUnitOfWork unitOfWork, IMapper mapper) : base(questionRepository,unitOfWork,mapper)
        {
            
        }
    }
}
