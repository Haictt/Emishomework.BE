﻿using DPHai.Fresher032023.EmisHomework.BL.App.Interfaces;
using DPHai.Fresher032023.EmisHomework.Common.Dto;
using DPHai.Fresher032023.EmisHomework.Common.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DPHai.Fresher032023.EmisHomework.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class SubjectController : BaseController<Subject,GetSubjectDto,Subject,Subject>
    {
        public SubjectController(ISubjectService subjectService) : base(subjectService)
        {
            
        }
    }
}
