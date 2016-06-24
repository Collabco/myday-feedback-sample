using Microsoft.Azure;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Myday.Feedback.Controllers
{
    /// <summary>
    /// Base API Controller
    /// </summary>
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// The tenant id
        /// </summary>
        protected string TenantId
        {
            get
            {
                var principal = this.User as ClaimsPrincipal;
                var claim = principal.FindFirst("tenant");
                return claim?.Value;
            }
        }

        /// <summary>
        /// A claims identity
        /// </summary>
        protected ClaimsIdentity ClaimsIdentity
        {
            get
            {
                return this.User?.Identity as ClaimsIdentity;
            }
        }

        /// <summary>
        /// Roles
        /// </summary>
        protected IEnumerable<string> Roles
        {
            get
            {
                if (ClaimsIdentity != null)
                {
                    return ClaimsIdentity.Claims.Where(claim => claim.Type == ClaimsIdentity.RoleClaimType).Select(claim => claim.Value);
                }
                else
                {
                    return new string[] { };
                }
            }
        }


        static readonly IEnumerable<string> allowedTeanants = CloudConfigurationManager.GetSetting("AllowedTenantIds")?.Split(',');

        /// <summary>
        /// Is valid tenant request
        /// </summary>
        protected bool IsValidTenant
        {
            get
            {
                return allowedTeanants?.Any(at => at == "*" || at == this.TenantId) ?? false;
            }
        }

        /// <summary>
        /// Is a feedback admin
        /// </summary>
        protected bool IsAdmin
        {
            get
            {
                return this.User != null ? this.User.IsInRole("TenantAdmin") || this.User.IsInRole("FeedbackAdmin") : false;
            }
        }

        /// <summary>
        /// Return a not found result with a reason
        /// </summary>
        /// <param name="reason">The reason it wasn't found</param>
        /// <returns></returns>
        protected System.Web.Http.Results.ResponseMessageResult NotFound(string reason)
        {
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                ReasonPhrase = reason
            };

            return this.ResponseMessage(response);
        }

        /// <summary>
        /// Send any HTTP status code with the reason populated
        /// </summary>
        /// <param name="code">Http status code</param>
        /// <param name="reason">The reason for the code</param>
        /// <returns></returns>

        protected System.Web.Http.Results.ResponseMessageResult StatusCode(HttpStatusCode code, string reason)
        {
            var response = new HttpResponseMessage
            {
                StatusCode = code,
                ReasonPhrase = reason
            };

            return this.ResponseMessage(response);
        }

        /// <summary>
        /// Send an OK result with abitary headers set
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content">Content to return</param>
        /// <param name="headers">Headers to set</param>
        /// <returns></returns>
        protected System.Web.Http.IHttpActionResult OkWithHeaders<T>(T content,
            IDictionary<string, IEnumerable<string>> headers)
        {
            return new OkResultWithHeaders<T>(content, this)
            {
                Headers = headers
            };
        }
    }
}