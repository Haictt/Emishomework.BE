using DPHai.Fresher032023.EmisHomework.Common.Entity;
using DPHai.Fresher032023.EmisHomework.Common.UnitOfWork;
using DPHai.Fresher032023.EmisHomework.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.DL.Repository
{
    public class GradeRepository : BaseRepository<Grade, Grade>, IGradeRepository
    {
        
        public GradeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
    }
}
