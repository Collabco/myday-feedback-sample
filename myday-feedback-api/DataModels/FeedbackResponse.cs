using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Myday.Feedback.DataModels
{
    public class FeedbackResponse
    {
        public int Id { get; set; }

        public ResponseType Type { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string ReplyEmail { get; set; }

        public int? CategoryId { get; set; } 

        public int? QuestionId { get; set; }

        public SentimentType? Sentiment { get; set; }

        public string Comments { get; set; }
    }
}