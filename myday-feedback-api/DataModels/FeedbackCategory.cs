using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Myday.Feedback.DataModels
{
    /// <summary>
    /// A category of feedback response
    /// </summary>
    public class FeedbackCategory
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public string RoutingEmailAddresses { get; set; }
    }
}