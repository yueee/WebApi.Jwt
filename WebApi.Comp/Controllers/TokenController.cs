using System.Net;
using System.Web.Http;
using WebApi.Comp.Tools;

namespace WebApi.Comp.Controllers
{
    public class TokenController : ApiController
    {
        /// <summary>
        /// 这是一个带参数的get请求
        /// </summary>
        /// <remarks>
        /// 例子:
        /// Get api/Get
        /// </remarks>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>测试字符串</returns> 
        /// <response code="201">返回value字符串</response>
        /// <response code="400">如果id为空</response>  
        // GET api/values/2
        [HttpGet]
        [AllowAnonymous]
        public string Get(string username, string password)
        {
            if (username.Equals("admin") && password.Equals("password"))
            {

            }
            return JwtManager.GenerateToken(username);

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <remarks>
        /// 请求例子
        /// param=123
        /// </remarks>
        /// <param name="param">请求参数</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/pub/getus")]
        [AllowAnonymous]
        public object CheckUser([FromBody]string param)
        {
            return new { param };
        }
    }
}
