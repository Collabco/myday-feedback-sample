using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Myday.Feedback.Models
{
    public class FeedbackResponse
    {
        public int Id { get; set; }

        public DataModels.SentimentType? Sentiment { get; set; }

        public string Comments { get; set; }
    }
}