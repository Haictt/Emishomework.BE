using DPHai.Fresher032023.EmisHomework.Common;
using DPHai.Fresher032023.EmisHomework.Common.Exceptions;
using System.Net;
using System.Runtime.InteropServices;

namespace DPHai.Fresher032023.EmisHomework.API.Middlewares
{
    public class ExceptionMiddleware
    {
        #region Fields
        private readonly RequestDelegate _next;
        #endregion

        #region Contructor
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Khi có request đi qua middleware sẽ gọi đến middleware tiếp theo (_next) trong pipeline và bắt exception nếu có
        /// </summary>
        /// <param name="context">Request</param>
        /// <returns>Task</returns>
        /// AUTHOR: DPHai + ChatGPT
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);

            }
        }

        /// <summary>
        /// hàm xử lý thông báo lỗi trả về
        /// </summary>
        /// <param name="context">request</param>
        /// <param name="exception">loại lỗi</param>
        /// <returns>Task</returns>
        /// AUTHOR: DPHai + ChatGPT
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is NotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(
                    text: new BaseException()
                    {
                        ErrorCode = context.Response.StatusCode,
                        UserMessage = MISAResource.NotFound_Exception,
                        DevMessage = exception.Message,
                        TraceId = context.TraceIdentifier,
                        MoreInfo = exception.HelpLink
                    }.ToString() ?? ""
                );
                return;
            }
            else if (exception is ValidateException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(
                    text: new BaseException()
                    {
                        ErrorCode = context.Response.StatusCode,
                        UserMessage = MISAResource.Validate_Exception,
                        DevMessage = exception.Message,
                        TraceId = context.TraceIdentifier,
                        MoreInfo = exception.HelpLink
                    }.ToString() ?? ""
                );
                return;
            }
            else if (exception is ConflictException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                await context.Response.WriteAsync(
                    text: new BaseException()
                    {
                        ErrorCode = context.Response.StatusCode,
                        UserMessage = MISAResource.Conflict_Exception,
                        DevMessage = exception.Message,
                        TraceId = context.TraceIdentifier,
                        MoreInfo = exception.HelpLink
                    }.ToString() ?? ""
                );
                return;
            }
            else if (exception is InternalException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(
                    text: new BaseException()
                    {
                        ErrorCode = context.Response.StatusCode,
                        UserMessage = MISAResource.Internal_Exception,
                        DevMessage = exception.Message,
                        TraceId = context.TraceIdentifier,
                        MoreInfo = exception.HelpLink
                    }.ToString() ?? ""
                );
                return;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(
                    text: new BaseException()
                    {
                        ErrorCode = context.Response.StatusCode,
                        UserMessage = MISAResource.Internal_Exception,
                        DevMessage = exception.Message,
                        TraceId = context.TraceIdentifier,
                        MoreInfo = exception.HelpLink
                    }.ToString() ?? ""
                );
            }


        }
        #endregion

    }
}
