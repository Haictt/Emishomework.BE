using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.Common.Dto
{
    public class GetTopicDto
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
    }
}
