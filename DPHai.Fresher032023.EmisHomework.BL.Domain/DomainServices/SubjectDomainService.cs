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
    public class SubjectDomainService : BaseDomainService<Subject, GetSubjectDto, Subject, Subject>, ISubjectDomainService
    {
        public SubjectDomainService(ISubjectRepository subjectRepository, IMapper mapper) : base(subjectRepository, mapper)
        {

        }
    }
}
