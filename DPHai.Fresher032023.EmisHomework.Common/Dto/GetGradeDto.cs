using DPHai.Fresher032023.EmisHomework.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.Common.Dto
{
    public class GetGradeDto
    {
        /// <summary>
        /// Id khối
        /// </summary>
        [Required]
        public Guid GradeId { get; set; }

        /// <summary>
        /// Tên khối
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string? GradeName { get; set; }
    }
}
