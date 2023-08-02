using DPHai.Fresher032023.EmisHomework.Common.Attributes;
using DPHai.Fresher032023.EmisHomework.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.Common.Dto
{
    public class PostExerciseDto
    {
        private List<PostQuestionDto?>? _questions;

        /// <summary>
        /// Id bài tập
        /// </summary>
        public Guid? ExerciseId { get; set; }

        /// <summary>
        /// Tên bài tập
        /// </summary>
        [MaxLength(255)]
        public string? ExerciseName { get; set; }

        /// <summary>
        /// Ảnh bài tập
        /// </summary>
        public Guid? ExerciseImage { get; set; }

        /// <summary>
        /// Id khối
        /// </summary>
        [Required]
        public Guid GradeId { get; set; }

        /// <summary>
        /// Id môn học
        /// </summary>
        [Required]
        public Guid SubjectId { get; set; }

        /// <summary>
        /// Id chủ đề
        /// </summary>
        public Guid? TopicId { get; set; }

        /// <summary>
        /// Trạng thái bài tập
        /// </summary>
        [Required]
        [EnumDataType(typeof(ExerciseStatus))]
        public ExerciseStatus ExerciseStatus { get; set; }

        /// <summary>
        /// Thẻ tìm kiếm bài tập
        /// </summary>
        public string? ExerciseTag { get; set; }

        /// <summary>
        /// Danh sách câu hỏi
        /// </summary>
        public List<PostQuestionDto?> Questions
        {
            get => _questions ?? (_questions = new List<PostQuestionDto?>());
            set => _questions = value;
        }

        /// <summary>
        /// Các trường cần cập nhật
        /// </summary>
        [Required]
        public List<string> UpdateFields { get; set; }
    }
}
