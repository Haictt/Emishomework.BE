using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.Common.Exceptions
{
    /// <summary>
    /// Lớp lỗi hệ thống
    /// </summary>
    /// AUTHOR: DPHai
    public class InternalException : Exception
    {
        #region Constructor
        public InternalException()
        {

        }
        public InternalException(string message) : base(message)
        {

        }
        #endregion
    }
}
