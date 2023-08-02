using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.Common.Exceptions
{
    /// <summary>
    /// Lớp lỗi xung đột
    /// </summary>
    /// AUTHOR: DPHai
    public class ConflictException : Exception
    {
        #region Constructor
        public ConflictException()
        {
        }
        public ConflictException(string message) : base(message)
        {
        }
        #endregion
    }
}
