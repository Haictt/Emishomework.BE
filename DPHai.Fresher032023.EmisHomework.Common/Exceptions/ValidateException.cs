using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.Common.Exceptions
{
    /// <summary>
    /// Lớp lỗi validate
    /// </summary>
    /// AUTHOR: DPHai
    public class ValidateException : Exception
    {
        #region Constructor
        public ValidateException()
        {

        }
        public ValidateException(string message) : base(message)
        {

        }
        #endregion
    }
}
