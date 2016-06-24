using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Myday.Feedback.DataModels
{

    /// <summary>
    /// A sentiment on a feedback response
    /// </summary>
    public enum SentimentType
    {
        Unhappy = -1,
        Neutral = 0,
        Happy = 1
    }
}