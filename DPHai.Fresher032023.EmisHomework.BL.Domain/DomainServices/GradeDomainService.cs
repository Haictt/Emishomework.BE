using AutoMapper;
using DPHai.Fresher032023.EmisHomework.BL.Domain.Interfaces;
using DPHai.Fresher032023.EmisHomework.Common.Dto;
using DPHai.Fresher032023.EmisHomework.Common.Entity;
using DPHai.Fresher032023.EmisHomework.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.BL.Domain.DomainServices
{
    public class GradeDomainService : BaseDomainService<Grade, GetGradeDto, Grade, Grade>, IGradeDomainService
    {
        public GradeDomainService(IGradeRepository gradeRepository, IMapper mapper) : base(gradeRepository, mapper)
        {

        }
    }
}
