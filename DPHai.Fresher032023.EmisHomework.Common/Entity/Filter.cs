using DPHai.Fresher032023.EmisHomework.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.Common.Entity
{
    /// <summary>
    /// Bộ lọc
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// Tìm kiếm
        /// </summary>
        public string? SearchField { get; set; }

        /// <summary>
        /// Trạng thái bài tập
        /// </summary>
        public ExerciseStatus? ExerciseStatus { get; set; }

        /// <summary>
        /// Id môn học
        /// </summary>
        public Guid? SubjectId { get; set; }

        /// <summary>
        /// Id khối
        /// </summary>
        public Guid? GradeId { get; set; }

        /// <summary>
        /// Bắt đầu từ bàn ghi thứ mấy
        /// </summary>
        public int? Offset { get; set; } = 0;

        /// <summary>
        /// Số bàn ghi
        /// </summary>
        public int? Limit { get; set; } = 1000000;
    }
}
