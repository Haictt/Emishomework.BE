using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.Common.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        /// <summary>
        /// Connection
        /// </summary>
        DbConnection Connection { get; }

        /// <summary>
        /// Transaction
        /// </summary>
        DbTransaction? Transaction { get; }

        /// <summary>
        /// Hàm khởi tạo transaction
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Hàm khởi tạo transaction async
        /// </summary>
        /// <returns></returns>
        Task BeginTransactionAsync();

        /// <summary>
        /// Hàm commit transaction
        /// </summary>
        void Commit();

        /// <summary>
        /// Hàm commit transaction async
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();

        /// <summary>
        /// Hàm rollback transaction
        /// </summary>
        void Rollback();

        /// <summary>
        /// Hàm rollback transaction async
        /// </summary>
        /// <returns></returns>
        Task RollbackAsync();

        /// <summary>
        /// Hàm khởi tạo connection async
        /// </summary>
        /// <returns></returns>
        Task GetOpenConnectionAsync();

        /// <summary>
        /// Hàm đóng connection async
        /// </summary>
        /// <returns></returns>
        Task CloseConnectionAsync();
    }
}
