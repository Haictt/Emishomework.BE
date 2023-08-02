using DPHai.Fresher032023.EmisHomework.Common.Attributes;
using DPHai.Fresher032023.EmisHomework.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.Common.Entity
{
    /// <summary>
    /// Câu trả lời
    /// </summary>
    public class Answer : Base
    {
        /// <summary>
        /// Id câu trả lời
        /// </summary>
        [Required]
        public Guid AnswerId { get; set; }

        /// <summary>
        /// Nội dung câu trả lời 
        /// </summary>
        [Required]
        public string? AnswerContent { get; set; }

        /// <summary>
        /// Ảnh đính kèm câu trả lời
        /// </summary>
        public Guid? AnswerImage { get; set; }

        /// <summary>
        /// Trạng thái câu trả lời
        /// </summary>
        [Required]
        [EnumDataType(typeof(AnswerStatus))]
        public AnswerStatus AnswerStatus { get; set; }

        /// <summary>
        /// Thứ tự câu trả lời
        /// </summary>
        [Required]
        public int AnswerOrder { get; set; }

        /// <summary>
        /// Id câu hỏi
        /// </summary>
        public Guid? QuestionId { get; set; }

    }
}
