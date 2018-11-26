using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Comp.Models
{
    /// <summary>
    /// 对参数验证的封装
    /// </summary>
    public class ValidationError
    {
        public string Field { get; set; }
        public string Message { get; set; }

        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }
}