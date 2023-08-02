using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.Common.Enums
{
    /// <summary>
    /// Loại câu hỏi
    /// </summary>
    public enum QuestionType
    {
        /// <summary>
        /// Chọn đáp án
        /// </summary>
        Choose=1,

        /// <summary>
        /// Đúng sai
        /// </summary>
        Truefalse=2,

        /// <summary>
        /// Điền từ
        /// </summary>
        Fillin=3,

        /// <summary>
        /// Tự luận
        /// </summary>
        Write=4
    }
}
