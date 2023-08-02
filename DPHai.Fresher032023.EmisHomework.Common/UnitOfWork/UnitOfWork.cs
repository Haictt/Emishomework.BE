using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace DPHai.Fresher032023.EmisHomework.Common.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbConnection _connection;
        private DbTransaction? _transaction = null;

        public UnitOfWork(IConfiguration configuration)
        {
            _connection = new MySqlConnection(configuration["ConnectionString"]);
        }

        /// <summary>
        /// Connection
        /// </summary>
        public DbConnection Connection => _connection;

        /// <summary>
        /// Transaction
        /// </summary>
        public DbTransaction? Transaction => _transaction;

        /// <summary>
        /// Hàm khởi tạo transaction
        /// </summary>
        public void BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
        }

        /// <summary>
        /// Hàm khởi tạo transaction async
        /// </summary>
        /// <returns></returns>
        public async Task BeginTransactionAsync()
        {
            await GetOpenConnectionAsync();
            if (_transaction == null)
                _transaction = await _connection.BeginTransactionAsync();
        }

        /// <summary>
        /// Hàm commit transaction
        /// </summary>
        public void Commit()
        {
            _transaction?.Commit();
            Dispose();
        }

        /// <summary>
        /// Hàm commit transaction async
        /// </summary>
        /// <returns></returns>
        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
            await DisposeAsync();
            await CloseConnectionAsync();
        }

        /// <summary>
        /// Hàm dispose transaction
        /// </summary>
        public void Dispose()
        {
            _transaction?.Dispose();
            _transaction = null;
        }

        /// <summary>
        /// Hàm dispose transaction async
        /// </summary>
        /// <returns></returns>
        public async ValueTask DisposeAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
            }
            _transaction = null;
        }

        /// <summary>
        /// Hàm khởi tạo connection async
        /// </summary>
        /// <returns></returns>
        public async Task GetOpenConnectionAsync()
        {
            if (_connection.State == ConnectionState.Closed)
                await _connection.OpenAsync();
        }

        /// <summary>
        /// Hàm đóng connection async
        /// </summary>
        /// <returns></returns>
        public async Task CloseConnectionAsync()
        {
            if (_connection.State == ConnectionState.Open)
                await _connection.CloseAsync();
        }

        /// <summary>
        /// Hàm rollback transaction
        /// </summary>
        public void Rollback()
        {
            _transaction?.Rollback();
            Dispose();
        }

        /// <summary>
        /// Hàm rollback transaction async
        /// </summary>
        /// <returns></returns>
        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
            await DisposeAsync();
            await CloseConnectionAsync();
        }
    }
}
