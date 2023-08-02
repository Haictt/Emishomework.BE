using DPHai.Fresher032023.EmisHomework.Common.Entity;
using DPHai.Fresher032023.EmisHomework.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.Common.Dto
{
    public class GetQuestionDto
    {
        private List<GetAnswerDto?>? _answers;

        /// <summary>
        /// Id câu hỏi
        /// </summary>
        [Required]
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Nội dung câu hỏi
        /// </summary>
        [Required]
        public string? QuestionContent { get; set; }

        /// <summary>
        /// Đáp án câu hỏi
        /// </summary>
        public string? QuestionHint { get; set; }

        /// <summary>
        /// Id bài tập
        /// </summary>
        [Required]
        public Guid ExerciseId { get; set; }

        /// <summary>
        /// Loại câu hỏi
        /// </summary>
        [Required]
        [EnumDataType(typeof(QuestionType))]
        public QuestionType QuestionType { get; set; }

        /// <summary>
        /// Danh sách câu trả lời
        /// </summary>
        public List<GetAnswerDto?> Answers
        {
            get => _answers ?? (_answers = new List<GetAnswerDto?>());
            set => _answers = value;
        }
    }
}
