using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Myday.Feedback.Controllers
{
    [RoutePrefix("v1/questions")]
    public class V1QuestionController : BaseApiController
    {
        /// <summary>
        /// Get questions
        /// </summary>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="400">Bad request</response>
        /// <response code="403">Access to perform the operation was forbidden</response>        
        /// <response code="500">Internal server error</response>
        [Authorize()]
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<Models.Question>))]

        public async Task<IHttpActionResult> Get()
        {
            if (!this.IsValidTenant)
            {
                return StatusCode(HttpStatusCode.Forbidden, "Unauthorised acccess denied.");
            }

            var dbContext = new DataModels.FeedbackContext();            
            return Ok(await dbContext.FeedbackQuestions.Select(q => new Models.Question() { Id = q.Id, QuestionText = q.QuestionText, EnableComments = q.EnableComments }).ToListAsync());
        }

        /// <summary>
        /// Create a new question
        /// </summary>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="400">Bad request</response>
        /// <response code="403">Access to perform the operation was forbidden</response>        
        /// <response code="500">Internal server error</response>
        [Authorize(Roles ="TenantAdmin,FeedbackAdmin")]
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Models.Question))]
        public async Task<IHttpActionResult> Post(Models.Question question)
        {
            if (!this.IsValidTenant)
            {
                return StatusCode(HttpStatusCode.Forbidden, "Unauthorised acccess denied.");
            }

            var dbContext = new DataModels.FeedbackContext();

            var feedbackQuestion = new DataModels.FeedbackQuestion
            {
                QuestionText = question.QuestionText,
                EnableComments = question.EnableComments
            };

            dbContext.FeedbackQuestions.Add(feedbackQuestion);

            await dbContext.SaveChangesAsync();
            question.Id = feedbackQuestion.Id;
            return Ok(question);
        }
    }
}
