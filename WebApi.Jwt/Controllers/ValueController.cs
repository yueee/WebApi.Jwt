using System.Web.Http;
using WebApi.Comp.Filters;

namespace WebApi.Comp.Controllers
{
    public class ValueController : ApiController
    {
        [JwtAuthentication]
        public string Get()
        {
            return "value";
        }
    }
}
