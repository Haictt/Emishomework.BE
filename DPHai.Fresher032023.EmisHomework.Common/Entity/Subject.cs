using DPHai.Fresher032023.EmisHomework.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.Common.Entity
{
    /// <summary>
    /// Môn học
    /// </summary>
    public class Subject : Base
    {
        /// <summary>
        /// Id môn học
        /// </summary>
        [Required]
        public Guid SubjectId { get; set; }

        /// <summary>
        /// Tên môn học
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string? SubjectName { get; set; }

        /// <summary>
        /// Ảnh môn học
        /// </summary>
        public Guid? SubjectImage { get; set; }
    }
}
