using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.Common.Exceptions
{
    /// <summary>
    /// Lớp cơ sở lỗi
    /// </summary>
    public class BaseException
    {
        #region Properties
        /// <summary>
        /// Mã lỗi
        /// </summary>
        /// AUTHOR: DPHai
        public int ErrorCode { get; set; }

        /// <summary>
        /// Thông báo người dùng
        /// </summary>
        /// AUTHOR: DPHai
        public string? UserMessage { get; set; }

        /// <summary>
        /// Thông báo ltv
        /// </summary>
        /// AUTHOR: DPHai
        public string? DevMessage { get; set; }

        /// <summary>
        /// Trace Id
        /// </summary>
        /// AUTHOR: DPHai
        public string? TraceId { get; set; }

        /// <summary>
        /// Thông tin thêm
        /// </summary>
        /// AUTHOR: DPHai
        public string? MoreInfo { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Chuyển đổi chuỗi
        /// </summary>
        /// <returns></returns>
        /// AUTHOR: DPHai
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        #endregion
    }
}
