using AutoMapper;
using DPHai.Fresher032023.EmisHomework.Common.Dto;
using DPHai.Fresher032023.EmisHomework.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.BL.Domain.Automapper
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<Answer,GetAnswerDto>();
            CreateMap<PostAnswerDto, Answer>();
        }
    }
}
