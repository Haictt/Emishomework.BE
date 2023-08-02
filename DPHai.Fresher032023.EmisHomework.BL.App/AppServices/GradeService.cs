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
    public class GradeService : BaseService<Grade, GetGradeDto, Grade, Grade>,IGradeService
    {
        public GradeService(IGradeRepository gradeRepository, IUnitOfWork unitOfWork, IMapper mapper) :base(gradeRepository, unitOfWork, mapper)
        {
            
        }
    }
}
