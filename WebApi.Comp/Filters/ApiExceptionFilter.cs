using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using WebApi.Comp.Models;

namespace WebApi.Comp.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            ApiError apiError = null;
            ApiResponse apiResponse = null;
            int code = 0;

            if (context.Exception is ApiException)
            {
                var ex = context.Exception as ApiException;
                apiError = new ApiError(ex.Message);
                apiError.ValidationErrors = ex.Errors;
                apiError.ReferenceErrorCode = ex.ReferenceErrorCode;
                apiError.ReferenceDocumentLink = ex.ReferenceDocumentLink;
                code = ex.StatusCode;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                apiError = new ApiError("Unauthorized Access");
                code = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                var msg = "";
                string stack = "";
                #if !DEBUG
                     msg = "an unhandled error";
                     stack = null;
                #else
                     msg = context.Exception.GetBaseException().Message;
                     stack = context.Exception.StackTrace;
                #endif
                apiError = new ApiError(msg);
                apiError.Details = stack;
                code = (int)HttpStatusCode.InternalServerError;
            }

            apiResponse = new ApiResponse(code, ResponseMessageEnum.Exception.ToString(), null, apiError);
            HttpStatusCode c = (HttpStatusCode)code;
            context.Response = context.Request.CreateResponse(c, apiResponse);
        }
    }
}