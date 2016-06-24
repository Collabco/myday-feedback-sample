using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Myday.Feedback.Models
{
    /// <summary>
    /// Feedback Question
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Id of the question
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The text of the question
        /// </summary>
        public string QuestionText { get; set; }

        /// <summary>
        /// Enables / Disables posting of comments to question
        /// </summary>
        public bool EnableComments { get; set; }
    }
}