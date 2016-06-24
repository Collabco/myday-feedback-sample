using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Myday.Feedback.Controllers
{
    public class OkResultWithHeaders<T> : OkNegotiatedContentResult<T>
    {
        public OkResultWithHeaders(T content, ApiController controller)
            : base(content, controller)
        { }

        public OkResultWithHeaders(T content, IContentNegotiator contentNegotiator, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
            : base(content, contentNegotiator, request, formatters)
        { }

        public IDictionary<string, IEnumerable<string>> Headers { get; set; }

        public override async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await base.ExecuteAsync(cancellationToken);

            if (this.Headers != null)
            {
                foreach (var header in Headers)
                {
                    response.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            return response;
        }
    }
}