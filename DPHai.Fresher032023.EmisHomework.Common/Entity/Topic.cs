using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.Common.Entity
{
    /// <summary>
    /// Chủ đề
    /// </summary>
    public class Topic : Base
    {
        /// <summary>
        /// Id chủ đề
        /// </summary>
        [Required]
        public Guid TopicId { get; set; }

        /// <summary>
        /// Tên chủ đề
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string? TopicName { get; set; }

        /// <summary>
        /// Id khối 
        /// </summary>
        public Guid GradeId { get; set; }

        /// <summary>
        /// Id môn học
        /// </summary>
        public Guid SubjectId { get; set; }

    }
}
