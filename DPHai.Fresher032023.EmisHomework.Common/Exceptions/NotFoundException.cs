using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.Common.Exceptions
{
    /// <summary>
    /// Lớp lỗi không tìm thấy tài nguyên
    /// </summary>
    /// AUTHOR: DPHai
    public class NotFoundException : Exception
    {
        #region Properties
        /// <summary>
        /// Mã lỗi
        /// </summary>
        /// AUTHOR: DPHai
        public int ErrorCode { get; set; }
        #endregion

        #region Constructor
        public NotFoundException() { }
        public NotFoundException(int errorCode)
        {
            ErrorCode = errorCode;
        }
        public NotFoundException(string message) : base(message)
        {

        }
        public NotFoundException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
        #endregion
    }
}
