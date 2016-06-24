using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Myday.Feedback.DataModels
{
    public class FeedbackQuestion
    {
        public int Id { get; set; }
        
        public string QuestionText { get; set; }        

        public bool EnableComments { get; set; }        
    }
}