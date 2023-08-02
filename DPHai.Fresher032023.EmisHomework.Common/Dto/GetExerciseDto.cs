﻿using DPHai.Fresher032023.EmisHomework.Common.Entity;
using DPHai.Fresher032023.EmisHomework.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.Common.Dto
{
    public class GetExerciseDto
    {
        private List<GetQuestionDto?>? _questions;

        /// <summary>
        /// Id bài tập
        /// </summary>
        [Required]
        public Guid ExerciseId { get; set; }

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
        /// Tổng số câu hỏi
        /// </summary>
        [Required]
        public int TotalQuestion { get; set; }

        /// <summary>
        /// Danh sách câu hỏi
        /// </summary>
        public List<GetQuestionDto?> Questions {
            get => _questions ?? (_questions = new List<GetQuestionDto?>());
            set => _questions = value;
        }
    }
}
